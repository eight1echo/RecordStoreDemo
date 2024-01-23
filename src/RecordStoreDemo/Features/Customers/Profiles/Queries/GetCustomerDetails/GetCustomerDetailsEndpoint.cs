namespace RecordStoreDemo.Features.Customers.Profiles.Queries.GetCustomerDetails;

public class GetCustomerDetailsEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<CustomerDetailsModel>>
{
    [HttpGet("api/customers/{profileId}", Name = "GetCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Customer Details",
        OperationId = "CustomerProfile_Get",
        Tags = new[] { "Customers" })]
    public override async Task<ActionResult<CustomerDetailsModel>> HandleAsync(
      Guid profileId,
      CancellationToken cancellationToken = default)
    {
        var customer = await _context.CustomerProfiles
            .Where(p => p.Id == profileId)
            .Select(p => new CustomerDetailsModel
            {
                Id = p.Id,
                Name = p.Name,
                Contact = p.GetContact(),

                RewardsCard = new RewardsCardModel
                {
                    Id = p.RewardsCard.Id,
                    Number = p.RewardsCard.Number.ToSpacedRewardsCard(),
                    Points = p.RewardsCard.Points,

                    Transactions = p.RewardsCard.Transactions.Select(t => new RewardsTransactionModel
                    {
                        Date = t.Date,
                        PointsChange = t.PointsChange
                    }).ToList(),
                },

                SpecialOrders = p.SpecialOrders.Select(s => new SpecialOrderModel
                {
                    Id = s.Id,
                    DateOrdered = s.DateOrdered,
                    DateReceived = s.DateReceived,
                    Contacted = s.Contacted,
                    Price = s.Product.Price.Value,
                    Product = $"{s.Product.Artist}/{s.Product.Title} [{s.Product.Category.Format}]",
                    Status = s.Status,
                    UPC = s.Product.UPC.Value,
                }).ToList()
               
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (customer is not null)
            return Ok(customer);

        return NotFound();
    }
}