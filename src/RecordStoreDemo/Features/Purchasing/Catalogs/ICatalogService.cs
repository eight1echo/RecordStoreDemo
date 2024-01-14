using Microsoft.AspNetCore.Components.Forms;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.UpdateCatalogOptions;

namespace RecordStoreDemo.Features.Purchasing.Catalogs;

public interface ICatalogService
{
    Task<List<CatalogProductModel>> CatalogProductsFromCSV(Guid vendorId, string vendorName, CatalogModel catalogOptions);
    Task<List<CatalogProductModel>> FindCatalogProducts(ProductQueryRequest request);
    Task<CatalogProductModel?> FindCatalogProductByUPC(string upc);
    Task<CatalogProductModel> GetCatalogProduct(Guid Id);
    Task<List<CatalogProductModel>> ImportCatalogProducts(ImportCatalogProductsRequest request);
    Task<CatalogModel> UpdateCatalogOptions(UpdateCatalogOptionsRequest request);
    Task UploadCatalog(string vendorName, IBrowserFile file);
}