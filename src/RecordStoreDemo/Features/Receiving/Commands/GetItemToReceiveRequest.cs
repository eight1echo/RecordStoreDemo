namespace RecordStoreDemo.Features.Receiving.Requests;

public class GetItemToReceiveRequest
{
    [Required]
    [MinLength(1)]
    public string UPC { get; set; } = string.Empty;
}