namespace RecordStoreDemo.Common.Models;
public abstract class ProductRequest
{
    [Required]
    [Length(2, 60)]
    public string Artist { get; set; } = null!;

    [Required]
    [ValidProductDepartment]
    public string Department { get; set; } = "Media";

    [Required]
    [ValidProductFormat]
    public string Format { get; set; } = "LP";

    [ValidMusicGenre]
    public string Genre { get; set; } = string.Empty;

    public DateTime? StreetDate { get; set; } = DateTime.MinValue;

    [Required]
    [Length(2, 60)]
    public string Title { get; set; } = null!;

    [Required]
    public string UPC { get; set; } = string.Empty;
}