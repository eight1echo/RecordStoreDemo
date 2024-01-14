namespace RecordStoreDemo.Features.Purchasing.Catalogs.Queries.GetCatalogProduct;

public class GetCatalogProductEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<CatalogProductModel>>
{
    [HttpGet("api/purchasing/catalogs/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Catalog Product",
        OperationId = "CatalogProduct_Get",
        Tags = new[] { "Catalogs" })]
    public override async Task<ActionResult<CatalogProductModel>> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var product = await _context.CatalogProducts
            .Where(p => p.Id == id)
            .Select(p => new CatalogProductModel
            {
                Id = p.Id,
                VendorId = p.VendorId,
                VendorName = p.VendorName,

                Artist = p.Artist,
                Cost = p.Cost.Value,
                Description = p.Description,
                Format = p.Format,
                Label = p.Label,
                SKU = p.SKU,
                StreetDate = p.StreetDate.ToShortDateString(),
                Title = p.Title,
                UPC = p.UPC.Value,

                CartQuantity = p.CartQuantity,
                OrderedQuantity = p.OrderedQuantity
            }).FirstOrDefaultAsync(cancellationToken);

        if (product is not null)
            return Ok(product);

        return NotFound();
    }
}