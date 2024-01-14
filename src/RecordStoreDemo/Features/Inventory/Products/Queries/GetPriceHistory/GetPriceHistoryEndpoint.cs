namespace RecordStoreDemo.Features.Inventory.Products.Queries.GetPriceHistory;

public class GetPriceHistoryEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<List<PriceHistoryModel>>>
{
    [HttpGet("api/inventory/{id}/price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Get Price History",
        OperationId = "PriceHistory_Get",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<List<PriceHistoryModel>>> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var priceHistory = await _context.PriceHistory
            .Where(p => p.ProductId == id)
            .Select(p => new PriceHistoryModel
            {
                Date = p.DateCreated.ToShortDateString(),
                NewPrice = p.NewPrice.Value,
                OldPrice = p.OldPrice.Value,
                Reason = p.Reason
            }).ToListAsync(cancellationToken);

        return Ok(priceHistory);
    }
}