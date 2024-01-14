namespace RecordStoreDemo.Common.Exceptions;

public class InventoryQuantityException : Exception
{
    public InventoryQuantityException(Guid productId) : base($"[InventoryProductId: {productId}] Cannot adjust inventory quantity to below zero.")
    {
    }
}