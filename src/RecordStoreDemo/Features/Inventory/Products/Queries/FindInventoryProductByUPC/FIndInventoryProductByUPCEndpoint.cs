namespace RecordStoreDemo.Features.Inventory.Products.Queries.GetInventoryProductByUPC;

public class FIndInventoryProductByUPCEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<string>
    .WithResult<ActionResult<InventoryProductModel>>
{
    [HttpGet("api/inventory/find/{upc}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Find Inventory Product By UPC",
        OperationId = "InventoryProducts_FindByUPC",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<InventoryProductModel>> HandleAsync(
      string upc,
      CancellationToken cancellationToken = default)
    {
        var product = await _context.InventoryProducts
            .Where(p => p.UPC.Value == upc)
            .Select(p => new InventoryProductModel
            {
                Id = p.Id,
                Artist = p.Artist,
                Department = p.Category.Department,
                Genre = p.Genre,
                Format = p.Category.Format,
                OnHand = p.OnHand,
                Price = p.Price.Value,
                StreetDate = p.StreetDate,
                Title = p.Title,
                UPC = p.UPC.Value,
            }).FirstOrDefaultAsync(cancellationToken);

        if (product is not null)
            return Ok(product);

        return NotFound();
    }
}