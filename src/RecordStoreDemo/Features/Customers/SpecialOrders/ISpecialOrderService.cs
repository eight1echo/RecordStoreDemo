using RecordStoreDemo.Features.Customers.SpecialOrders.Commands.CreateSpecialOrder;

namespace RecordStoreDemo.Features.Customers.SpecialOrders;
public interface ISpecialOrderService
{
    Task<ServiceResult<SpecialOrderModel>> CreateSpecialOrder(CreateSpecialOrderRequest request);
    Task<ServiceResult<List<SpecialOrderModel>>> GetCustomerSpecialOrders(Guid customerProfileId);
    Task<ServiceResult<List<SpecialOrderModel>>> GetProductSpecialOrders(Guid inventoryProductId);
}
