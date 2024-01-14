namespace RecordStoreDemo.Features.Purchasing.Vendors.Commands.CreateVendor;

public class CreateVendorEndpoint(IVendorRepository _vendorRepo) : EndpointBaseAsync
    .WithRequest<CreateVendorRequest>
    .WithActionResult
{
    [HttpPost("api/purchasing/vendors")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Create Vendor",
        OperationId = "Vendor_Create",
        Tags = new[] { "Vendors" })]
    public override async Task<ActionResult> HandleAsync(
      CreateVendorRequest request,
      CancellationToken cancellationToken = default)
    {
        var vendor = new Vendor(request.Name);

        await _vendorRepo.Add(vendor);

        var result = new VendorModel()
        {
            Id = vendor.Id,
            Name = vendor.Name,
        };

        return CreatedAtRoute("GetVendor", new { id = result.Id }, result);
    }
}