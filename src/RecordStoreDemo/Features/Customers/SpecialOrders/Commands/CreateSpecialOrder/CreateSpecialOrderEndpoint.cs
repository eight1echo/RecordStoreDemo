namespace RecordStoreDemo.Features.Customers.SpecialOrders.Commands.CreateSpecialOrder;
public class CreateSpecialOrderEndpoint(
    ICustomerProfileRepository _customerRepo, 
    IInventoryProductRepository _inventoryRepo, 
    IPurchaseOrderRepository _purchaseOrder) : EndpointBaseAsync
    .WithRequest<CreateSpecialOrderRequest>
    .WithActionResult
{
    [HttpPost("api/specialorders/")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerOperation(
        Summary = "Create Customer Special Order",
        OperationId = "SpecialOrder_Create",
        Tags = new[] { "SpecialOrders" })]
    public override async Task<ActionResult> HandleAsync(
      CreateSpecialOrderRequest request,
      CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepo.GetCustomer(request.CustomerProfileId);
        var product = await _inventoryRepo.GetProduct(request.InventoryProductId);
        var purchaseOrder = await _purchaseOrder.GetPendingPurchaseOrderByVendorId(product.CatalogProduct.VendorId);

        var existing = purchaseOrder.Items
            .Where(i => i.CatalogProductId == product.CatalogProductId)
            .FirstOrDefault();

        if (existing is null)
        {
            purchaseOrder.AddItem(product.CatalogProduct, request.Quantity);
        }
        else
        {
            existing = purchaseOrder.UpdateItem(product.CatalogProductId, existing.Quantity + request.Quantity);
        }
        
        var specialOrder = customer.AddSpecialOrder(request.InventoryProductId);

        await _customerRepo.Update(customer);

        var result = new SpecialOrderModel
        {
            Id = specialOrder.Id,
            DateOrdered = specialOrder.DateOrdered,
            Price = specialOrder.Product.Price.Value,
            Product = $"{product.Artist}/{product.Title} [{product.Category.Format}]",
            UPC = specialOrder.Product.UPC.Value,

            CustomerProfile = new CustomerProfileModel
            {
                Name = customer.Name,
                Contact = customer.GetContact()
            }
        };      

        return CreatedAtRoute("GetSpecialOrder", new { id = result.Id }, result);
    }
}