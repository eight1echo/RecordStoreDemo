namespace RecordStoreDemo.Features.Webstore.MetaFields;
public class WebstoreMetaFieldModel
{
    public WebstoreMetaFieldModel(string key, string values)
    {
        Key = key;

        if (string.IsNullOrEmpty(values))
        {
            Values = [];
        }
        else
        {
            var splitValues = values.Split(',');
            foreach (var splitValue in splitValues)
            {
                var value = splitValue.Trim(new char[] { '[', ']', '\"' });
                Values.Add(value);
            }
        }
    }
    public long Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public List<string> Values { get; set; } = new List<string>();
}
