namespace RecordStoreDemo.Features.Inventory.Products;

public class InventoryProduct : BaseEntity
{
    public InventoryProduct(Guid catalogProductId, string artist, string department, string format, string genre, decimal price, DateTime streetDate, string title, string upc)
    {
        CatalogProductId = catalogProductId;
        Price = new Price(price);
        SetDetails(artist, department, format, genre, streetDate, title, upc);
    }

    public Guid CatalogProductId { get; set; }
    public virtual CatalogProduct CatalogProduct { get; set; } = null!;

    public string Artist { get; private set; } = null!;
    public Category Category { get; private set; } = null!;
    public string Genre { get; private set; } = null!;
    public int OnHand { get; private set; }
    public Price Price { get; private set; }
    public DateTime StreetDate { get; private set; }
    public string Title { get; private set; } = null!;
    public UPC UPC { get; private set; } = null!;

    private readonly List<OnHandChange> _onHandHistory = [];
    public virtual ICollection<OnHandChange> OnHandHistory => _onHandHistory.AsReadOnly();

    private readonly List<PriceChange> _priceHistory = [];
    public virtual ICollection<PriceChange> PriceHistory => _priceHistory.AsReadOnly();

    public void SetDetails(string artist, string department, string format, string genre, DateTime streetDate, string title, string upc)
    {
        Artist = Guard.Against.NullOrWhiteSpace(artist, nameof(Artist));
        Category = new Category(department, format);
        Genre = Guard.Against.InvalidMusicGenre(genre, nameof(Genre));
        StreetDate = streetDate;
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(Title));
        UPC = new UPC(upc);
    }

    public OnHandChange OnHandAdjustment(int quantityChange, string reason)
    {
        var inventoryChange = new OnHandChange(Id, OnHand, quantityChange, reason);
        OnHand += quantityChange;

        if (OnHand < 0)
            throw new InventoryQuantityException(Id);

        _onHandHistory.Add(inventoryChange);

        return inventoryChange;
    }

    public PriceChange PriceAdjustment(decimal newPrice, string reason)
    {
        var priceChange = new PriceChange(Id, new Price(Price.Value), new Price(newPrice), reason);

        Price.PriceChange(newPrice);

        _priceHistory.Add(priceChange);

        return priceChange;
    }

#nullable disable
    private InventoryProduct() { }
}