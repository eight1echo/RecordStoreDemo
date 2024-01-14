namespace RecordStoreDemo.Features.Purchasing.Catalogs;

public class Catalog : BaseEntity
{
    public Guid VendorId { get; private set; }

    public string FileType { get; private set; } = "csv";

    public bool HasHeader { get; private set; }

    public string ArtistColumn { get; private set; } = "N/A";
    public string CostColumn { get; private set; } = "N/A";
    public string DescriptionColumn { get; private set; } = "N/A";
    public string FormatColumn { get; private set; } = "N/A";
    public string LabelColumn { get; private set; } = "N/A";
    public string StreetDateColumn { get; private set; } = "N/A";
    public string SKUColumn { get; private set; } = "N/A";
    public string TitleColumn { get; private set; } = "N/A";
    public string UPCColumn { get; private set; } = "N/A";

    public void SetHasHeader(bool hasHeader)
    {
        HasHeader = hasHeader;
    }

    public void SetFileType(string fileType)
    {
        FileType = Guard.Against.InvalidCatalogFile(fileType, nameof(fileType));
    }

    public void SetColumns(Dictionary<string, string> columns)
    {
        ArtistColumn = Guard.Against.InvalidColumnPosition(columns["ArtistColumn"], nameof(ArtistColumn));
        CostColumn = Guard.Against.InvalidColumnPosition(columns["CostColumn"], nameof(CostColumn));
        DescriptionColumn = Guard.Against.InvalidColumnPosition(columns["DescriptionColumn"], nameof(DescriptionColumn));
        FormatColumn = Guard.Against.InvalidColumnPosition(columns["FormatColumn"], nameof(FormatColumn));
        LabelColumn = Guard.Against.InvalidColumnPosition(columns["LabelColumn"], nameof(LabelColumn));
        StreetDateColumn = Guard.Against.InvalidColumnPosition(columns["StreetDateColumn"], nameof(StreetDateColumn));
        SKUColumn = Guard.Against.InvalidColumnPosition(columns["SKUColumn"], nameof(SKUColumn));
        TitleColumn = Guard.Against.InvalidColumnPosition(columns["TitleColumn"], nameof(TitleColumn));
        UPCColumn = Guard.Against.InvalidColumnPosition(columns["UPCColumn"], nameof(UPCColumn));
    }

    public void UpdateOptions(string fileType, bool hasHeader, Dictionary<string, string> columns)
    {
        SetFileType(fileType);
        SetHasHeader(hasHeader);
        SetColumns(columns);
    }
}