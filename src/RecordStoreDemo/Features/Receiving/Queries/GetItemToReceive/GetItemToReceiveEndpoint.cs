using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;
using RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;

namespace RecordStoreDemo.Features.Receiving.Queries.GetItemToReceive;

public class GetItemToReceiveEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<string>
    .WithResult<ActionResult<AddItemToReceiveRequest>>
{
    [HttpGet("api/receiving/items/{upc}", Name = "GetReceiveItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Item To Receive",
        OperationId = "Receive_GetItem",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult<AddItemToReceiveRequest>> HandleAsync(
      string upc,
      CancellationToken cancellationToken = default)
    {
        var addItemRequest = await _context.InventoryProducts
            .Where(p => p.UPC.Value == upc)
            .Select(p => new AddItemToReceiveRequest
            {
                CatalogProductId = p.CatalogProductId,
                InventoryProductId = p.Id,
                Quantity = 1,
                UPC = p.UPC.Value,
                UpdateRequest = new UpdateProductDetailsRequest
                {
                    InventoryProductId = p.Id,
                    Artist = p.Artist,
                    Department = p.Category.Department,
                    Format = p.Category.Format,
                    Genre = p.Genre,
                    StreetDate = p.StreetDate,
                    Title = p.Title,
                    UPC = p.UPC.Value
                }
            }).FirstOrDefaultAsync(cancellationToken);

        if (addItemRequest is not null)
            return Ok(addItemRequest);

        return NotFound();
    }
}