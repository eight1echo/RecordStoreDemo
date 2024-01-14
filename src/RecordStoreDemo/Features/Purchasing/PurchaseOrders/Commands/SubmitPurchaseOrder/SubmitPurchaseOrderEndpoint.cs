namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.SubmitPurchaseOrder;

public class SubmitPurchaseOrderEndpoint(IPurchaseOrderRepository _purchaseOrderRepo) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult>
{
    [HttpPost("api/purchasing/orders/{vendorId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(
        Summary = "Submit Purchase Order",
        OperationId = "PurchaseOrder_Submit",
        Tags = new[] { "PurchaseOrders" })]
    public override async Task<ActionResult> HandleAsync(
      Guid vendorId,
      CancellationToken cancellationToken = default)
    {
        var order = await _purchaseOrderRepo.GetPendingPurchaseOrderByVendorId(vendorId);

        order.Submit();

        await _purchaseOrderRepo.Update(order);

        return NoContent();
    }
}