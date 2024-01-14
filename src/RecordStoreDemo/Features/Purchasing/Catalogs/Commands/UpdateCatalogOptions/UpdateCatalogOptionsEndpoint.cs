namespace RecordStoreDemo.Features.Purchasing.Catalogs.Commands.UpdateCatalogOptions;

public class UpdateCatalogOptionsEndpoint(IVendorRepository _vendorRepo) : EndpointBaseAsync
    .WithRequest<UpdateCatalogOptionsRequest>
    .WithResult<ActionResult<CatalogModel>>
{
    [HttpPut("api/purchasing/catalogs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Update Catalog",
        OperationId = "Catalog_Update",
        Tags = new[] { "Catalogs" })]
    public override async Task<ActionResult<CatalogModel>> HandleAsync(
      UpdateCatalogOptionsRequest request,
      CancellationToken cancellationToken = default)
    {
        var vendor = await _vendorRepo.GetVendor(request.VendorId);

        var columns = new Dictionary<string, string>()
        {
            { "ArtistColumn", request.ArtistColumn },
            { "CostColumn", request.CostColumn },
            { "DescriptionColumn", request.DescriptionColumn },
            { "FormatColumn", request.FormatColumn },
            { "LabelColumn", request.LabelColumn },
            { "SKUColumn", request.SKUColumn },
            { "StreetDateColumn", request.StreetDateColumn },
            { "TitleColumn", request.TitleColumn },
            { "UPCColumn", request.UPCColumn },
        };

        vendor.Catalog.UpdateOptions(request.FileType, request.HasHeader, columns);

        await _vendorRepo.Update(vendor);

        var result = new CatalogModel()
        {
            FileType = vendor.Catalog.FileType,
            HasHeader = vendor.Catalog.HasHeader,

            ArtistColumn = vendor.Catalog.ArtistColumn,
            CostColumn = vendor.Catalog.CostColumn,
            DescriptionColumn = vendor.Catalog.DescriptionColumn,
            FormatColumn = vendor.Catalog.FormatColumn,
            LabelColumn = vendor.Catalog.LabelColumn,
            SKUColumn = vendor.Catalog.SKUColumn,
            StreetDateColumn = vendor.Catalog.StreetDateColumn,
            TitleColumn = vendor.Catalog.TitleColumn,
            UPCColumn = vendor.Catalog.UPCColumn,
        };

        return Ok(result);
    }
}