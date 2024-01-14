namespace RecordStoreDemo.Features.Inventory.Products.Commands.CreateInventoryProduct;

public class CreateInventoryProductEndpoint(IInventoryProductRepository _productRepo) : EndpointBaseAsync
    .WithRequest<CreateInventoryProductRequest>
    .WithResult<ActionResult<InventoryProductModel>>
{
    [HttpPost("api/inventory")]
    [SwaggerOperation(
        Summary = "Create Inventory Product",
        OperationId = "InventoryProducts_Create",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<InventoryProductModel>> HandleAsync(
      CreateInventoryProductRequest request,
      CancellationToken cancellationToken = default)
    {
        var newProduct = new InventoryProduct(request.CatalogProductId, request.Artist, request.Department, request.Format, request.Genre, request.Price, request.StreetDate.Value, request.Title, request.UPC);
        await _productRepo.Add(newProduct);

        var result = new InventoryProductModel()
        {
            Id = newProduct.Id,
            CatalogProductId = newProduct.CatalogProductId,

            Artist = newProduct.Artist,
            Department = newProduct.Category.Department,
            Format = newProduct.Category.Format,
            Genre = newProduct.Genre,
            Price = newProduct.Price.Value,
            StreetDate = newProduct.StreetDate,
            Title = newProduct.Title,
            UPC = newProduct.UPC.Value
        };

        return Ok(result);
    }
}