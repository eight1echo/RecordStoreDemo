namespace RecordStoreDemo.Features.Customers.SpecialOrders.Queries.GetSpecialOrder;

public class GetSpecialOrderEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<SpecialOrderModel>>
{
    [HttpGet("api/specialorders/{id}", Name = "GetSpecialOrder")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Customer Special Order",
        OperationId = "SpecialOrder_Get",
        Tags = new[] { "SpecialOrders" })]
    public override async Task<ActionResult<SpecialOrderModel>> HandleAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
        var order = await _context.SpecialOrders
            .Where(s => s.Id == id)
            .Select(s => new SpecialOrderModel
            {
                Id = s.Id,
                DateOrdered = s.DateOrdered,
                DateReceived = s.DateReceived,
                Contacted = s.Contacted,
                Price = s.Product.Price.Value,
                Product = $"{s.Product.Artist}/{s.Product.Title} [{s.Product.Category.Format}]",
                Status = s.Status,
                UPC = s.Product.UPC.Value,
            }).FirstOrDefaultAsync(cancellationToken);

        if (order is not null)
            return Ok(order);

        return NotFound();
    }
}