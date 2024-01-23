namespace RecordStoreDemo.Features.Customers.Rewards.Commands.AttachRewardsCard;

public class AttachRewardsCardEndpoint(ICustomerProfileRepository customerRepo) : EndpointBaseAsync
    .WithRequest<AttachRewardsCardRequest>
    .WithResult<ActionResult<RewardsCardModel>>
{
    [HttpPut("api/customers/rewards")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Attach a Rewards Card to a Customer Profile",
        OperationId = "RewardsCard_Attach",
        Tags = new[] { "Rewards" })]
    public override async Task<ActionResult<RewardsCardModel>> HandleAsync(
      [FromBody] AttachRewardsCardRequest request,
      CancellationToken cancellationToken = default)
    {
        var customer = await customerRepo.GetCustomer(request.CustomerProfileId);

        customer.AttachRewardsCard(request.CardNumber);

        await customerRepo.Update(customer);
        
        var result = new RewardsCardModel
        {
            Id = customer.RewardsCard.Id,
            Number = customer.RewardsCard.Number.ToSpacedRewardsCard(),
            Points = customer.RewardsCard.Points
        };

        return Ok(result);
    }
}