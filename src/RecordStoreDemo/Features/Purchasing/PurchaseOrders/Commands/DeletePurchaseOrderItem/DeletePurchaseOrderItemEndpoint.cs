namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.DeletePurchaseOrderItem;

public class DeletePurchaseOrderItemEndpoint(IPurchaseOrderRepository _purchaseOrderRepo) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult>
{
    [HttpDelete("api/purchasing/orders/items/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(
        Summary = "Remove Purchase Order Item from Order",
        OperationId = "PurchaseOrderItem_Remove",
        Tags = new[] { "PurchaseOrders" })]
    public override async Task<ActionResult> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var order = await _purchaseOrderRepo.GetPendingPurchaseOrderByProductId(id);

        order.RemoveItem(id);

        await _purchaseOrderRepo.Update(order);

        return NoContent();
    }
}