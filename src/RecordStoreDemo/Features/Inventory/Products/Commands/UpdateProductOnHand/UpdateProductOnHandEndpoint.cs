namespace RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductOnHand;

public class UpdateProductOnHandEndpoint(IInventoryProductRepository _productsRepo) : EndpointBaseAsync
    .WithRequest<UpdateProductOnHandRequest>
    .WithResult<ActionResult<OnHandHistoryModel>>
{
    [HttpPut("api/inventory/onhand")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Make an On Hand Adjustment",
        OperationId = "ProductsOnHand_Update",
        Tags = new[] { "Inventory" })]
    public override async Task<ActionResult<OnHandHistoryModel>> HandleAsync(
      UpdateProductOnHandRequest request,
      CancellationToken cancellationToken = default)
    {
        var product = await _productsRepo.GetProduct(request.ProductId);

        var onHandChange = product.OnHandAdjustment(request.QuantityChange, request.Reason);

        await _productsRepo.Update(product);

        var result = new OnHandHistoryModel
        {
            ProductId = onHandChange.ProductId,
            NewOnHand = onHandChange.NewOnHand,
            QuantityChange = onHandChange.QuantityChange,
            Reason = onHandChange.Reason
        };

        return Ok(result);
    }
}