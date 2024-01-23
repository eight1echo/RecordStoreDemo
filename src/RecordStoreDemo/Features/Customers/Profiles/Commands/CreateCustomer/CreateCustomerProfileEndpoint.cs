namespace RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
public class CreateCustomerProfileEndpoint(ICustomerProfileRepository _customerRepo) : EndpointBaseAsync
    .WithRequest<CreateCustomerProfileRequest>
    .WithActionResult
{
    [HttpPost("api/customers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Create Customer Profile",
        OperationId = "CustomerProfiles_Create",
        Tags = new[] { "Customers" })]
    public override async Task<ActionResult> HandleAsync(
      CreateCustomerProfileRequest request,
      CancellationToken cancellationToken = default)
    {
        var customer = new CustomerProfile(request.Name, request.Contact);

        await _customerRepo.Add(customer);

        var result = new CustomerProfileModel()
        {
            Id = customer.Id,
            Name = customer.Name,
            Contact = customer.GetContact()
        };

        return CreatedAtRoute("GetVendor", new { id = result.Id }, result);
    }
}