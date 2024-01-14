using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;

public class CatalogProductMap : ClassMap<CatalogProductModel>
{
    public CatalogProductMap(CatalogModel options)
    {
        var artist = ParseColumn(options.ArtistColumn);
        var cost = ParseColumn(options.CostColumn);
        var description = ParseColumn(options.DescriptionColumn);
        var format = ParseColumn(options.FormatColumn);
        var label = ParseColumn(options.LabelColumn);
        var sku = ParseColumn(options.SKUColumn);
        var streetdate = ParseColumn(options.StreetDateColumn);
        var title = ParseColumn(options.TitleColumn);
        var upc = ParseColumn(options.UPCColumn);

        Map(c => c.Artist).Index(artist).Ignore(artist == 404);
        Map(c => c.Cost).Index(cost).Ignore(cost == 404).TypeConverter<CostConverter>();
        Map(c => c.Description).Index(description).Ignore(description == 404);
        Map(c => c.Format).Index(format).Ignore(format == 404);
        Map(c => c.Label).Index(label).Ignore(label == 404);
        Map(c => c.SKU).Index(sku).Ignore(sku == 404);
        Map(c => c.StreetDate).Index(streetdate).Ignore(streetdate == 404);
        Map(c => c.Title).Index(title).Ignore(title == 404);
        Map(c => c.UPC).Index(upc).Ignore(upc == 404);
    }

    private static int ParseColumn(string column)
    {
        if (column.Length == 1)
        {
            return (int)(CatalogAlphabet)Enum.Parse(typeof(CatalogAlphabet), column);
        }

        else return 404;
    }

    public static string ParseFormat(string catalogFormat)
    {
        return catalogFormat switch
        {
            // SONY
            "LP7?" => "7\"",
            "78EP" => "10\"",
            "LP10\"" => "10\"",
            "LP12\"MS" => "12\"",
            "CD EP" => "CD",
            "CDMS" => "CD",
            "DDC" => "CD/DVD",
            "TP" => "CASS",

            // Universal
            "7\" Vinyl Singles" => "7\"",
            "7\"  Vinyl Singles" => "7\"",
            "Vinyl Singles" => "12\"",
            "Vinyl EP" => "12\"",
            "Vinyl LP's" => "LP",
            "Blu Ray Audio + CD" => "BLU-A/CD",
            "BLU RAY + BNS CD" => "CD/BLU",
            "CD with DVD" => "CD/DVD",
            "Compact Disc" => "CD",
            "Compact Disc EP's" => "CD",
            "Compact Disc Enhanced" => "CD",
            "Compact Disc Singles" => "CD Single",
            "Cassette" => "CASS",
            "Digital Video Disc" => "DVD",
            "DVD + BNS CD" => "CD/DVD",
            "BLU RAY" => "BLU",

            // Warner
            "A" => "LP",
            "SN" => "EP/Single",
            "VB" => "BLU",
            "VV" => "DVD",
            "TS" => "Apparel",
            "HD" => "Apparel",
            "JT" => "Apparel",
            "GM" => "Merch",

            _ => catalogFormat,
        };
    }

    public class CostConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            text = text!.Replace("$", "").Trim();

            return Convert.ToDecimal(text);
        }
    }
}