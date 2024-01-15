namespace RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;

public class AddItemToReceiveEndpoint(IInventoryProductRepository _inventoryRepo, IReceiveRepository _receivingRepo) : EndpointBaseAsync
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
        var inventoryProduct = await _inventoryRepo.GetProduct(request.InventoryProductId);

        var item = new ReceiveItem(request.ReceiveId, inventoryProduct.Id, inventoryProduct.CatalogProductId, request.Quantity);
        item = receive.AddItem(item);

        await _receivingRepo.Update(receive);

        var result = new ReceiveItemModel()
        {
            Id = item.Id,
            Cost = inventoryProduct.CatalogProduct.Cost.Value,
            ProductId = item.InventoryProductId,
            Quantity = item.Quantity,

            Product = new InventoryProductModel()
            {
                Artist = inventoryProduct.Artist,
                Department = inventoryProduct.Category.Department,
                Format = inventoryProduct.Category.Format,
                Genre = inventoryProduct.Genre,
                Price = inventoryProduct.Price.Value,
                StreetDate = inventoryProduct.StreetDate,
                Title = inventoryProduct.Title,
                UPC = inventoryProduct.UPC.Value,
            }
        };

        return result;
    }
}