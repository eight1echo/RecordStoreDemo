namespace RecordStoreDemo.Features.Purchasing.Catalogs.Queries.GetCatalogProductByUPC;

public class FindCatalogProductByUPCEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<string>
    .WithResult<ActionResult<CatalogProductModel>>
{
    [HttpGet("api/purchasing/catalogs/find/{upc}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Find Catalog Product By UPC",
        OperationId = "CatalogProduct_FindByUPC",
        Tags = new[] { "Catalogs" })]
    public override async Task<ActionResult<CatalogProductModel>> HandleAsync(
      string upc,
      CancellationToken cancellationToken = default)
    {
        var product = await _context.CatalogProducts
            .Where(p => p.UPC.Value == upc)
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