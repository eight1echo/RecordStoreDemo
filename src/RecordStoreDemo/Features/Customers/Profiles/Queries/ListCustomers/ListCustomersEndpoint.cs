namespace RecordStoreDemo.Features.Customers.Profiles.Queries.ListCustomers;

public class ListCustomersEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<List<CustomerProfileModel>>>
{
    [HttpGet("api/customers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "List Customer Profiles",
        OperationId = "CustomerProfiles_List",
        Tags = new[] { "Customers" })]
    public override async Task<ActionResult<List<CustomerProfileModel>>> HandleAsync(
      CancellationToken cancellationToken = default)
    {
        var customers = await _context.CustomerProfiles
            .Select(p => new CustomerProfileModel
            {
                Id = p.Id,
                Name = p.Name,
                Contact = p.GetContact()

            }).OrderBy(v => v.Name).ToListAsync(cancellationToken);

        return Ok(customers);
    }
}