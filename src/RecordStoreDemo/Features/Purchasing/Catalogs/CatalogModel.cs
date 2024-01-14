namespace RecordStoreDemo.Features.Purchasing.Catalogs;
public class CatalogModel
{
    public string FileType { get; set; } = string.Empty;

    public bool HasHeader { get; set; }

    public string ArtistColumn { get; set; } = string.Empty;
    public string CostColumn { get; set; } = string.Empty;
    public string DescriptionColumn { get; set; } = string.Empty;
    public string FormatColumn { get; set; } = string.Empty;
    public string LabelColumn { get; set; } = string.Empty;
    public string StreetDateColumn { get; set; } = string.Empty;
    public string SKUColumn { get; set; } = string.Empty;
    public string TitleColumn { get; set; } = string.Empty;
    public string UPCColumn { get; set; } = string.Empty;
}