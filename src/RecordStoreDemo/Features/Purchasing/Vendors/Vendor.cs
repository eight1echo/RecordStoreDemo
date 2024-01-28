namespace RecordStoreDemo.Features.Purchasing.Vendors;

public class Vendor : BaseEntity
{
    public Vendor(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        Catalog = new Catalog();
    }

    public string Name { get; private set; } = null!;
    public Catalog Catalog { get; set; } = null!;

    private readonly List<PurchaseOrder> _orders = [];
    public virtual ICollection<PurchaseOrder> Orders => _orders.AsReadOnly();

    private readonly List<CatalogProduct> _products = [];
    public virtual ICollection<CatalogProduct> Products => _products.AsReadOnly();

    /// <summary>
    /// Adds new or updates existing CatalogProducts. To be called when importing a Vendor's Catalog.
    /// </summary>
    public List<CatalogProduct> ImportCatalogProducts(List<CatalogProduct> catalogProducts)
    {
        var newProducts = new List<CatalogProduct>();

        foreach (var product in catalogProducts)
        {
            var existing = _products.Where(p => p.UPC.Value == product.UPC.Value).FirstOrDefault();

            if (existing is not null)
            {
                // TODO: Update Existing Products
            }
            else
            {
                _products.Add(product);
                newProducts.Add(product);
            }
        }

        return newProducts;
    }
}