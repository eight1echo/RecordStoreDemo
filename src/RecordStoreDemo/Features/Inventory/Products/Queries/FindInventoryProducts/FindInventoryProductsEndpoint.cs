using System.Linq.Expressions;

namespace RecordStoreDemo.Features.Inventory.Products.Queries.FindInventoryProducts;

public class FindInventoryProductsEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<ProductQueryRequest>
    .WithResult<ActionResult<List<InventoryProductModel>>>
{
    [HttpGet("api/inventory/find")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Find Inventory Products",
        OperationId = "InventoryProducts_Find",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<List<InventoryProductModel>>> HandleAsync(
      [FromQuery] ProductQueryRequest request,
      CancellationToken cancellationToken = default)
    {
        Expression<Func<InventoryProduct, bool>> filter;

        var queryable = _context.InventoryProducts.AsQueryable();

        if (!string.IsNullOrEmpty(request.UPC))
        {
            filter = vp => vp.UPC.Value == request.UPC;
            queryable = queryable.Where(filter);
        }
        else
        {
            request.Artist ??= string.Empty;
            request.Title ??= string.Empty;

            var split = request.Artist.Split(' ').ToList();

            foreach (var s in split)
            {
                queryable = queryable.Where(vp => vp.Artist.Contains(s) && vp.Title.Contains(request.Title));
            }
        }

        var products = await queryable
            .OrderBy(vp => vp.Artist)
            .Select(x => new InventoryProductModel()
            {
                Id = x.Id,

                Artist = x.Artist,
                Department = x.Category.Department,
                Format = x.Category.Format,
                Genre = x.Genre,
                OnHand = x.OnHand,
                Price = x.Price.Value,
                StreetDate = x.StreetDate,
                Title = x.Title,
                UPC = x.UPC.Value
            }).ToListAsync(cancellationToken);

        return products;
    }
}