namespace RecordStoreDemo.Features.Receiving.Commands.SubmitReceive;

public class SubmitReceiveEndpoint(IReceiveRepository _receiveRepo) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult>
{
    [HttpPost("api/receiving/submit")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [SwaggerOperation(
        Summary = "Submit Receive",
        OperationId = "Receive_Submit",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult> HandleAsync(
      Guid vendorId,
      CancellationToken cancellationToken = default)
    {
        var receive = await _receiveRepo.GetPendingReceiveByVendorId(vendorId);

        receive.Submit();

        await _receiveRepo.Update(receive);

        return NoContent();
    }
}