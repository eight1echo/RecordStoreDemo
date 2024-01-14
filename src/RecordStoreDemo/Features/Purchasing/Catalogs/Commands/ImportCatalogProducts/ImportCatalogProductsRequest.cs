namespace RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;
public class ImportCatalogProductsRequest
{
    [Required]
    public Guid VendorId { get; set; }
    [Required]
    public List<CatalogProductModel> CatalogProducts { get; set; } = [];
}