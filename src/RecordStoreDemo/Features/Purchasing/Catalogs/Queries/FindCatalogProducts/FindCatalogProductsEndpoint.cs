using System.Linq.Expressions;

namespace RecordStoreDemo.Features.Purchasing.Catalogs.Queries.FindCatalogProducts;

public class FindCatalogProductsEndpoint(RecordStoreDbContext _context) : EndpointBaseAsync
    .WithRequest<ProductQueryRequest>
    .WithResult<ActionResult<List<CatalogProductModel>>>
{
    [HttpGet("api/purchasing/catalogs/find")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Find Catalog Products",
        OperationId = "CatalogProducts_Find",
        Tags = new[] { "Catalogs" })]
    public override async Task<ActionResult<List<CatalogProductModel>>> HandleAsync(
      [FromQuery] ProductQueryRequest request,
      CancellationToken cancellationToken = default)
    {
        Expression<Func<CatalogProduct, bool>> filter;

        var queryable = _context.CatalogProducts.AsQueryable();

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
            .Select(x => new CatalogProductModel()
            {
                Id = x.Id,

                VendorId = x.VendorId,
                VendorName = x.VendorName,

                OrderedQuantity = x.OrderedQuantity,
                CartQuantity = x.CartQuantity,

                Artist = x.Artist,
                Cost = x.Cost.Value,
                Description = x.Description,
                Format = x.Format,
                Label = x.Label,
                SKU = x.SKU,
                StreetDate = x.StreetDate.ToString("yyyy-MM-dd"),
                Title = x.Title,
                UPC = x.UPC.Value
            }).ToListAsync(cancellationToken);

        return products;
    }
}