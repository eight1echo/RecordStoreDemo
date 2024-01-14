namespace RecordStoreDemo.Features.Purchasing.Vendors.Queries.GetVendorDetails;

public class GetVendorDetailsEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<VendorDetailsModel>>
{
    [HttpGet("api/purchasing/vendors/{id}", Name = "GetVendor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Vendor Details",
        OperationId = "Vendor_Get",
        Tags = new[] { "Vendors" })]
    public override async Task<ActionResult<VendorDetailsModel>> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var vendor = await _context.Vendors
            .Where(v => v.Id == id)
            .Select(v => new VendorDetailsModel
            {
                Id = v.Id,
                Name = v.Name,

                Catalog = new CatalogModel
                {
                    FileType = v.Catalog.FileType,
                    HasHeader = v.Catalog.HasHeader,

                    ArtistColumn = v.Catalog.ArtistColumn,
                    CostColumn = v.Catalog.CostColumn,
                    DescriptionColumn = v.Catalog.DescriptionColumn,
                    FormatColumn = v.Catalog.FormatColumn,
                    LabelColumn = v.Catalog.LabelColumn,
                    SKUColumn = v.Catalog.SKUColumn,
                    StreetDateColumn = v.Catalog.StreetDateColumn,
                    TitleColumn = v.Catalog.TitleColumn,
                    UPCColumn = v.Catalog.UPCColumn,
                },

                PendingOrder = v.Orders.Where(o => o.Status == PurchaseOrderStatus.Pending)
                .Select(o => new PurchaseOrderModel
                {
                    VendorId = o.VendorId,
                    DateCreated = o.DateCreated,
                    TotalCost = o.Total,

                    Items = o.Items.Select(i => new PurchaseOrderItemModel
                    {
                        Quantity = i.Quantity,

                        Product = new CatalogProductModel
                        {
                            Id = i.CatalogProduct.Id,
                            UPC = i.CatalogProduct.UPC.Value,
                            Artist = i.CatalogProduct.Artist,
                            Cost = i.CatalogProduct.Cost.Value,
                            Format = i.CatalogProduct.Format,
                            Title = i.CatalogProduct.Title,
                        }
                    }).ToList(),

                }).FirstOrDefault(),

                PastOrders = v.Orders.Where(o => o.Status == PurchaseOrderStatus.Submitted).Select(o => new PurchaseOrderModel
                {
                    VendorId = o.VendorId,
                    DateSubmitted = o.DateSubmitted,
                    TotalCost = o.Total,

                    TotalItems = o.Items.Select(i => i.Quantity).Sum()
                }).ToList(),

            }).FirstOrDefaultAsync(cancellationToken);

        if (vendor is not null)
            return Ok(vendor);

        return NotFound();
    }
}