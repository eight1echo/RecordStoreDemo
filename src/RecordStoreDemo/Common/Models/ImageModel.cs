using RecordStoreDemo.External.DataSources;

namespace RecordStoreDemo.Common.Models;
public class ImageModel
{
    public ImageModel(string path, WebQuerySource source)
    {
        Path = path;
        Source = source;
    }

    public string Path { get; set; }
    public WebQuerySource Source { get; set; }
}