namespace RecordStoreDemo.Features.Receiving.Queries.GetPendingReceive;

public class GetPendingReceiveEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<ActionResult<ReceiveModel>>
{
    [HttpGet("api/receiving/{vendorId}", Name = "GetReceive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Pending Receive",
        OperationId = "Receive_Get",
        Tags = new[] { "Receiving" })]
    public override async Task<ActionResult<ReceiveModel>> HandleAsync(
      Guid vendorId,
      CancellationToken cancellationToken = default)
    {
        var receive = await _context.Receives
            .Where(r => r.VendorId == vendorId && r.Status == ReceiveStatus.Pending)
            .Select(r => new ReceiveModel
            {
                Id = r.Id,
                VendorId = vendorId,
                DateCreated = r.DateCreated,
                Status = r.Status,

                Items = r.Items.Select(i => new ReceiveItemModel
                {
                    Id = i.Id,
                    Cost = i.CatalogProduct.Cost.Value,
                    ProductId = i.InventoryProductId,
                    Quantity = i.Quantity,

                    Product = new InventoryProductModel
                    {
                        Artist = i.InventoryProduct.Artist,
                        Department = i.InventoryProduct.Category.Department,
                        Format = i.InventoryProduct.Category.Format,
                        Genre = i.InventoryProduct.Genre,
                        Price = i.InventoryProduct.Price.Value,
                        StreetDate = i.InventoryProduct.StreetDate,
                        Title = i.InventoryProduct.Title,
                        UPC = i.InventoryProduct.UPC.Value
                    }
                }).ToList()

            }).FirstOrDefaultAsync(cancellationToken);

        if (receive is not null)
            return Ok(receive);

        return NotFound();
    }
}