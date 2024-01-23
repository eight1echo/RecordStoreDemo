namespace RecordStoreDemo.Features.Customers.Profiles.Queries.FindCustomers;

public class FindCustomersEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<string>
    .WithResult<ActionResult<List<CustomerProfileModel>>>
{
    [HttpGet("api/customers/find/{query}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Find Customer Profiles",
        OperationId = "CustomerProfiles_Find",
        Tags = new[] { "Customers" })]
    public override async Task<ActionResult<List<CustomerProfileModel>>> HandleAsync(
      string query,
      CancellationToken cancellationToken = default)
    {
        var customers = await _context.CustomerProfiles
            .Where(p => p.Name.Contains(query))
            .Select(p => new CustomerProfileModel
            {
                Id = p.Id,
                Name = p.Name,
                Contact = p.GetContact()
            }).ToListAsync(cancellationToken);

        return customers;
    }
}