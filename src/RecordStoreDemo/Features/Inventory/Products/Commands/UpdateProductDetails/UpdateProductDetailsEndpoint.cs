namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;

public class UpdateProductDetailsEndpoint(IInventoryProductRepository productsRepo) : EndpointBaseAsync
    .WithRequest<UpdateProductDetailsRequest>
    .WithResult<ActionResult<InventoryProductModel>>
{
    [HttpPut("api/inventory/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Update Product's Details",
        OperationId = "Products_Update",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<InventoryProductModel>> HandleAsync(
      [FromBody] UpdateProductDetailsRequest request,
      CancellationToken cancellationToken = default)
    {
        var product = await productsRepo.GetProduct(request.InventoryProductId);

        product.SetDetails(request.Artist, request.Department, request.Format, request.Genre, request.StreetDate.Value, request.Title, request.UPC);

        await productsRepo.Update(product);

        var result = new InventoryProductModel
        {
            Id = product.Id,
            Artist = product.Artist,
            Department = product.Category.Department,
            Format = product.Category.Format,
            Genre = product.Genre,
            StreetDate = product.StreetDate,
            Title = product.Title,
            UPC = product.UPC.Value
        };

        return Ok(result);
    }
}