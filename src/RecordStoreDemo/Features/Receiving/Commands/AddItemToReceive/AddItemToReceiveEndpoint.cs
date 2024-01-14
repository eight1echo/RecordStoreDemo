namespace RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;

public class AddItemToReceiveEndpoint(IReceiveRepository _receivingRepo) : EndpointBaseAsync
    .WithRequest<AddItemToReceiveRequest>
    .WithResult<ActionResult<ReceiveItemModel>>
{
    [HttpPost("api/receiving/items")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Add Item to Receive",
        OperationId = "Receives_AddItem",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult<ReceiveItemModel>> HandleAsync(
      AddItemToReceiveRequest request,
      CancellationToken cancellationToken = default)
    {
        var receive = await _receivingRepo.GetReceive(request.ReceiveId);

        var item = new ReceiveItem(request.ReceiveId, request.InventoryProductId, request.CatalogProductId, request.Quantity);
        item = receive.AddItem(item);

        await _receivingRepo.Update(receive);

        var result = new ReceiveItemModel()
        {
            Id = item.Id,
            Cost = item.CatalogProduct.Cost.Value,
            ProductId = item.InventoryProductId,
            Quantity = item.Quantity,

            Product = new InventoryProductModel()
            {
                Artist = item.InventoryProduct.Artist,
                Department = item.InventoryProduct.Category.Department,
                Format = item.InventoryProduct.Category.Format,
                Genre = item.InventoryProduct.Genre,
                Price = item.InventoryProduct.Price.Value,
                Title = item.InventoryProduct.Title,
                UPC = item.InventoryProduct.UPC.Value,
            }
        };

        return result;
    }
}