namespace RecordStoreDemo.Features.Purchasing.Vendors.Queries.ListVendors;

public class ListVendorsEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<List<VendorModel>>>
{
    [HttpGet("api/purchasing/vendors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "List Vendors",
        OperationId = "Vendors_List",
        Tags = new[] { "Vendors" })]
    public override async Task<ActionResult<List<VendorModel>>> HandleAsync(
      CancellationToken cancellationToken = default)
    {
        var vendors = await _context.Vendors
            .Select(v => new VendorModel
            {
                Id = v.Id,
                Name = v.Name,

            }).OrderBy(v => v.Name).ToListAsync(cancellationToken);

        return Ok(vendors);
    }
}