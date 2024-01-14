namespace RecordStoreDemo.Features.Receiving.Commands.UpdateReceiveItem;

public class UpdateReceiveItemEndpoint(IReceiveRepository _receiveRepo) : EndpointBaseAsync
    .WithRequest<UpdateReceiveItemRequest>
    .WithResult<ActionResult<ReceiveItemModel>>
{
    [HttpPut("api/receiving/items/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Update Receive Item Quantity",
        OperationId = "ReceieveItem_Update",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult<ReceiveItemModel>> HandleAsync(
      UpdateReceiveItemRequest request,
      CancellationToken cancellationToken = default)
    {
        var receive = await _receiveRepo.GetReceive(request.ReceiveId);
        var item = receive.UpdateItem(request.InventoryProductId, request.NewQuantity);
        await _receiveRepo.Update(receive);

        var result = new ReceiveItemModel
        {
            Id = item.Id,
            ReceiveId = item.ReceiveId,
            Cost = item.CatalogProduct.Cost.Value,
            Quantity = item.Quantity,
        };

        return Ok(result);
    }
}