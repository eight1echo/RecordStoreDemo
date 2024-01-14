namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrderItem;

public class UpdatePurchaseOrderItemEndpoint(IPurchaseOrderRepository _purchaseOrder, IVendorRepository _vendorRepo) : EndpointBaseAsync
    .WithRequest<UpdatePurchaseOrderItemRequest>
    .WithResult<ActionResult<PurchaseOrderItemModel>>
{
    [HttpPut("api/purchasing/orders/items/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Update Purchase Order Item Quantity",
        OperationId = "PurchaseOrderItem_Update",
        Tags = new[] { "PurchaseOrders" })]
    public override async Task<ActionResult<PurchaseOrderItemModel>> HandleAsync(
      UpdatePurchaseOrderItemRequest request,
      CancellationToken cancellationToken = default)
    {
        var order = await _purchaseOrder.GetPendingPurchaseOrderByVendorId(request.VendorId);

        var item = order.Items
            .Where(i => i.CatalogProductId == request.CatalogProductId)
            .FirstOrDefault();

        if (item is null)
        {
            var product = await _vendorRepo.GetCatalogProduct(request.CatalogProductId);
            item = order.AddItem(product, request.NewQuantity);
        }
        else
        {
            item = order.UpdateItem(request.CatalogProductId, request.NewQuantity);
        }

        await _purchaseOrder.Update(order);

        var result = new PurchaseOrderItemModel
        {
            CatalogProductId = item.CatalogProductId,
            PurchaseOrderId = item.PurchaseOrderId,
            Quantity = item.Quantity,
        };

        return Ok(result);
    }
}