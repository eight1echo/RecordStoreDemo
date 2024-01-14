namespace RecordStoreDemo.Features.Receiving;

public class ReceiveItemModel
{
    public Guid Id { get; set; }
    public Guid ReceiveId { get; set; }
    public Guid ProductId { get; set; }
    public virtual InventoryProductModel Product { get; set; } = new();
    public decimal Cost { get; set; }
    public int Quantity { get; set; }

    public bool DetailsChanged(ReceiveItemModel comparedWith)
    {
        if (Product.Artist != comparedWith.Product.Artist)
            return true;

        if (Product.Department != comparedWith.Product.Department)
            return true;

        if (Product.Format != comparedWith.Product.Format)
            return true;

        if (Product.Genre != comparedWith.Product.Genre)
            return true;

        if (Product.Title != comparedWith.Product.Title)
            return true;

        return false;
    }
}