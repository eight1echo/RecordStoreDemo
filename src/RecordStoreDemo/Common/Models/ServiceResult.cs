namespace RecordStoreDemo.Common.Models;
public class ServiceResult<T> where T : class
{
    public ServiceResult(T value)
    {
        Message = string.Empty;
        Successful = true;
        Value = value;
    }
    public ServiceResult(string? errorMessage)
    {
        Message = errorMessage ?? string.Empty;
        Successful = false;
        Value = null;
    }

    public bool Successful { get; private set; }
    public T? Value { get; private set; }
    public string Message { get; private set; }

    /// <summary>
    /// Generate a ServiceResult with the value returned from a call to an HttpClient, or an error message if any.
    /// </summary>
    public static async Task<ServiceResult<T>> GetResultAsync(HttpResponseMessage httpResponse)
    {
        if (httpResponse.IsSuccessStatusCode)
        {
            var resultValue = await httpResponse.Content.ReadFromJsonAsync<T>();

            if (resultValue is not null)
            {
                return new ServiceResult<T>(resultValue);
            }
            else
                return new ServiceResult<T>($"Failed to Deserialize JSON to Type:{typeof(T)}");
        }

        return new ServiceResult<T>(httpResponse.ReasonPhrase);
    }
}