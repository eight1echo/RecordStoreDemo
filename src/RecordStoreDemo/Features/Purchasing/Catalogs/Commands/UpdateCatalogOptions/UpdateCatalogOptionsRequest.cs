namespace RecordStoreDemo.Features.Purchasing.Catalogs.Commands.UpdateCatalogOptions;
public class UpdateCatalogOptionsRequest
{
    [Required]
    public Guid VendorId { get; set; }
    [Required]
    public string FileType { get; set; } = "csv";
    [Required]
    public bool HasHeader { get; set; }
    [Required]
    public string ArtistColumn { get; set; } = "N/A";
    [Required]
    public string CostColumn { get; set; } = "N/A";
    [Required]
    public string DescriptionColumn { get; set; } = "N/A";
    [Required]
    public string FormatColumn { get; set; } = "N/A";
    [Required]
    public string LabelColumn { get; set; } = "N/A";
    [Required]
    public string StreetDateColumn { get; set; } = "N/A";
    [Required]
    public string SKUColumn { get; set; } = "N/A";
    [Required]
    public string TitleColumn { get; set; } = "N/A";
    [Required]
    public string UPCColumn { get; set; } = "N/A";
}