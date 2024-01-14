namespace RecordStoreDemo.Features.Receiving.Commands.CreateReceive;

public class CreateReceiveEndpoint(IReceiveRepository _receivingRepo) : EndpointBaseAsync
    .WithRequest<CreateReceiveRequest>
    .WithResult<ActionResult>
{
    [HttpPost("api/receiving")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Create Receive",
        OperationId = "Receives_Create",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult> HandleAsync(
      CreateReceiveRequest request,
      CancellationToken cancellationToken = default)
    {
        var newReceive = new Receive(request.VendorId);

        await _receivingRepo.Add(newReceive);

        var result = new ReceiveModel()
        {
            Id = newReceive.Id,
            VendorId = request.VendorId,
            DateCreated = newReceive.DateCreated,
            Status = newReceive.Status,
            Items = []
        };

        return CreatedAtRoute("GetReceive", new { vendorId = result.Id }, result);
    }
}