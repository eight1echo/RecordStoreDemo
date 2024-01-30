using Microsoft.AspNetCore.Components.Forms;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.UpdateCatalogOptions;

namespace RecordStoreDemo.Features.Purchasing.Catalogs;

public interface ICatalogService
{
    Task<List<CatalogProductModel>> CatalogProductsFromCSV(Guid vendorId, string vendorName, CatalogModel catalogOptions);
    Task<ServiceResult<CatalogProductModel>> FindCatalogProductByUPC(string upc);
    Task<ServiceResult<List<CatalogProductModel>>> FindCatalogProducts(ProductQueryRequest request);
    Task<ServiceResult<CatalogProductModel>> GetCatalogProduct(Guid id);
    Task<ServiceResult<List<CatalogProductModel>>> ImportCatalogProducts(ImportCatalogProductsRequest request);
    Task<ServiceResult<CatalogModel>> UpdateCatalogOptions(UpdateCatalogOptionsRequest request);
    Task UploadCatalog(string vendorName, IBrowserFile file);
}