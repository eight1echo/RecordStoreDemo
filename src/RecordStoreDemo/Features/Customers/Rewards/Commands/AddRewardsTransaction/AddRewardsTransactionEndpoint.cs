namespace RecordStoreDemo.Features.Customers.Rewards.Commands.AddRewardsTransaction;

public class AddRewardsTransactionEndpoint(ICustomerProfileRepository customerRepo) : EndpointBaseAsync
    .WithRequest<AddRewardsTransactionRequest>
    .WithResult<ActionResult<RewardsTransactionModel>>
{
    [HttpPost("api/customers/rewards")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Add Rewards Card Transaction",
        OperationId = "RewardsCard_Transaction",
        Tags = new[] { "Rewards" })]
    public override async Task<ActionResult<RewardsTransactionModel>> HandleAsync(
      [FromBody] AddRewardsTransactionRequest request,
      CancellationToken cancellationToken = default)
    {
        var customer = await customerRepo.GetCustomer(request.CustomerProfileId);

        var transaction = customer.RewardsCard.AddTransaction(request.CardNumber.Replace(" ", ""), request.PointsChange);

        await customerRepo.Update(customer);

        var result = new RewardsTransactionModel
        {
            Date = transaction.Date,
            PointsChange = transaction.PointsChange
        };

        return Ok(result);
    }
}