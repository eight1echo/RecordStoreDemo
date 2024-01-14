using RecordStoreDemo.Features.Purchasing.Vendors.Commands.CreateVendor;
using RecordStoreDemo.Features.Purchasing.Vendors.Queries.GetVendorDetails;

namespace RecordStoreDemo.Features.Purchasing.Vendors;

public interface IVendorService
{
    Task<VendorModel> CreateVendor(CreateVendorRequest request);
    Task<VendorDetailsModel> GetVendor(Guid vendorId);
    Task<List<VendorModel>> ListVendors();
}