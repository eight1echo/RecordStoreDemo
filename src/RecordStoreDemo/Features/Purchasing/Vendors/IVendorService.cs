using RecordStoreDemo.Features.Purchasing.Vendors.Commands.CreateVendor;
using RecordStoreDemo.Features.Purchasing.Vendors.Queries.GetVendorDetails;

namespace RecordStoreDemo.Features.Purchasing.Vendors;

public interface IVendorService
{
    Task<ServiceResult<VendorModel>> CreateVendor(CreateVendorRequest request);
    Task<ServiceResult<VendorDetailsModel>> GetVendor(Guid vendorId);
    Task<ServiceResult<List<VendorModel>>> ListVendors();
}