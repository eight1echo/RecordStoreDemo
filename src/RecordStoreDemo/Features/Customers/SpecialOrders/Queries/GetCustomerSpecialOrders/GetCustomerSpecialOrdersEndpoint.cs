namespace RecordStoreDemo.Features.Customers.SpecialOrders.Queries.GetCustomerSpecialOrders;
public class GetCustomerSpecialOrdersEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<List<SpecialOrderModel>>>
{
    [HttpGet("api/specialorders/customer/{customerProfileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Special Orders for a Customer",
        OperationId = "CustomerSpecialOrders_Get",
        Tags = new[] { "SpecialOrders" })]
    public override async Task<ActionResult<List<SpecialOrderModel>>> HandleAsync(
      Guid customerProfileId,
      CancellationToken cancellationToken = default)
    {
        var orders = await _context.SpecialOrders
            .Where(s => s.CustomerProfileId == customerProfileId)
            .Select(s => new SpecialOrderModel
            {
                Id = s.Id,
                DateOrdered = s.DateOrdered,
                DateReceived = s.DateReceived,
                Contacted = s.Contacted,
                Price = s.Product.Price.Value,
                Product = $"{s.Product.Artist}/{s.Product.Title} [{s.Product.Category.Format}]",
                Status = s.Status,
                UPC = s.Product.UPC.Value,

                CustomerProfile = new CustomerProfileModel
                {
                    Name = s.CustomerProfile.Name,
                    Contact = s.CustomerProfile.GetContact()
                }
            }).ToListAsync(cancellationToken);

        return Ok(orders);
    }
}