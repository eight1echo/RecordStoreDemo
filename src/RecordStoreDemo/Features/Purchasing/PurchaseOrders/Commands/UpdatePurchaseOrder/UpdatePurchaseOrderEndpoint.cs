namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrder;

public class UpdatePurchaseOrderEndpoint(IPurchaseOrderRepository _purchaseOrder) : EndpointBaseAsync
    .WithRequest<UpdatePurchaseOrderRequest>
    .WithResult<ActionResult<PurchaseOrderModel>>
{
    [HttpPut("api/purchasing/orders/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Update Purchase Order",
        OperationId = "PurchaseOrder_Update",
        Tags = new[] { "PurchaseOrders" })]
    public override async Task<ActionResult<PurchaseOrderModel>> HandleAsync(
      UpdatePurchaseOrderRequest request,
      CancellationToken cancellationToken = default)
    {
        var order = await _purchaseOrder.GetPendingPurchaseOrderByVendorId(request.VendorId);

        foreach (var existingItem in order.Items)
        {
            var updatedItem = request.Items.FirstOrDefault(i => i.Product.Id == existingItem.CatalogProductId);

            if (updatedItem is null)
            {
                order.RemoveItem(existingItem.CatalogProductId);
            }
            else
            {
                if (updatedItem.Quantity != existingItem.Quantity)
                {
                    var difference = updatedItem.Quantity - existingItem.Quantity;
                    existingItem.UpdateQuantity(difference);
                }
            }
        }

        await _purchaseOrder.Update(order);

        var result = new PurchaseOrderModel
        {
            DateCreated = order.DateCreated,
            TotalCost = order.Total,

            Items = order.Items.Select(i => new PurchaseOrderItemModel
            {
                Quantity = i.Quantity,

                Product = new CatalogProductModel
                {
                    UPC = i.CatalogProduct.UPC.Value,
                    Artist = i.CatalogProduct.Artist,
                    Cost = i.CatalogProduct.Cost.Value,
                    Format = i.CatalogProduct.Format,
                    Title = i.CatalogProduct.Title,
                }
            }).ToList(),
        };

        return Ok(result);
    }
}