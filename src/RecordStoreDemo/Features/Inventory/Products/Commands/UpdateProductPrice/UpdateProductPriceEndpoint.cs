namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductPrice;

public class UpdateProductPriceEndpoint(IInventoryProductRepository _productsRepo) : EndpointBaseAsync
    .WithRequest<UpdateProductPriceRequest>
    .WithResult<ActionResult<PriceHistoryModel>>
{
    [HttpPut("api/inventory/{id}/price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Make a Price Adjustment",
        OperationId = "ProductsPrice_Update",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<PriceHistoryModel>> HandleAsync(
      UpdateProductPriceRequest request,
      CancellationToken cancellationToken = default)
    {
        var product = await _productsRepo.GetProduct(request.ProductId);

        var priceChange = product.PriceAdjustment(request.NewPrice, request.Reason);

        await _productsRepo.Update(product);

        var result = new PriceHistoryModel
        {
            ProductId = priceChange.ProductId,
            OldPrice = priceChange.OldPrice.Value,
            NewPrice = priceChange.NewPrice.Value,
            Reason = priceChange.Reason
        };

        return Ok(result);
    }
}