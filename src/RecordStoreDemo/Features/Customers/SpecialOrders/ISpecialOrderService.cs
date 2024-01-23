using RecordStoreDemo.Features.Customers.SpecialOrders.Commands.CreateSpecialOrder;

namespace RecordStoreDemo.Features.Customers.SpecialOrders;
public interface ISpecialOrderService
{
    Task<SpecialOrderModel> CreateSpecialOrder(CreateSpecialOrderRequest request);
    Task<List<SpecialOrderModel>> GetCustomerSpecialOrders(Guid customerProfileId);
    Task<List<SpecialOrderModel>> GetProductSpecialOrders(Guid inventoryProductId);
}
