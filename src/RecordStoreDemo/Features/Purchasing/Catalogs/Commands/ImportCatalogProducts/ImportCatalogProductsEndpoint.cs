namespace RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;

public class ImportCatalogProductsEndpoint(IVendorRepository _vendorRepo) : EndpointBaseAsync
    .WithRequest<ImportCatalogProductsRequest>
    .WithActionResult<List<CatalogProductModel>>
{
    [HttpPost("api/purchasing/catalogs")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Import Products",
        OperationId = "Catalog_Import",
        Tags = new[] { "Catalogs" })]
    public override async Task<ActionResult<List<CatalogProductModel>>> HandleAsync(
      ImportCatalogProductsRequest request,
      CancellationToken cancellationToken = default)
    {
        var vendor = await _vendorRepo.GetVendorWithProducts(request.VendorId);

        var catalogProducts = request.CatalogProducts.Select(cp => new CatalogProduct
            (cp.VendorName, cp.Artist, cp.Cost, cp.Description, cp.Format, cp.Label, cp.SKU, DateTime.Parse(cp.StreetDate), cp.Title, cp.UPC)).ToList();

        var importResult = vendor.ImportCatalogProducts(catalogProducts);
        await _vendorRepo.Update(vendor);

        var newProducts = importResult.Select(p => new CatalogProductModel
        {
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
            UPC = p.UPC.Value

        }).ToList();

        return Ok(newProducts);
    }
}