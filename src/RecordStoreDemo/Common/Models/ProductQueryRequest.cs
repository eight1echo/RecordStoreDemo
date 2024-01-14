namespace RecordStoreDemo.Common.Models;
public class ProductQueryRequest
{
    public string? Artist { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? UPC { get; set; } = null;

    public bool IsValid()
    {
        if (!string.IsNullOrEmpty(Artist) || !string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(UPC))
        {
            return true;
        }

        return false;
    }
}