namespace RecordStoreDemo.Features.Inventory.Products.Queries.GetOnHandHistory;

public class GetOnHandHistoryEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<List<OnHandHistoryModel>>>
{
    [HttpGet("api/inventory/{id}/onhand")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Get On Hand History",
        OperationId = "OnHandHistory_Get",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<List<OnHandHistoryModel>>> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var onHandHistory = await _context.OnHandHistory
            .Where(i => i.ProductId == id)
            .Select(i => new OnHandHistoryModel
            {
                Date = i.DateCreated.ToShortDateString(),
                NewOnHand = i.NewOnHand,
                QuantityChange = i.QuantityChange,
                Reason = i.Reason,
            }).ToListAsync(cancellationToken);

        return Ok(onHandHistory);
    }
}