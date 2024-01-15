namespace RecordStoreDemo.Features.Receiving.Queries.GetItemToReceive;

public class GetItemToReceiveRequest
{
    [Required]
    [MinLength(1)]
    public string UPC { get; set; } = string.Empty;
}