using Azure.Security.KeyVault.Secrets;
using RecordStoreDemo.External.DataSources.Discogs;
using RecordStoreDemo.External.DataSources.LastFM;
using RecordStoreDemo.External.Shopify;

namespace RecordStoreDemo.External.Azure;
public class AzureKeyVaultService(SecretClient _secretClient)
{
    public async Task<string> GetSecret(string secretName)
    {
        KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);

        return secret.Value;           
    }

    public async Task<DiscogsCredentials> AuthenticateDiscogs()
    {
        var token = await GetSecret("DiscogsToken");

        return new DiscogsCredentials(token);
    }

    public async Task<LastFMCredentials> AuthenticateLastFM()
    {
        var apiKey = await GetSecret("LastFMApiKey");
        var apiSecret = await GetSecret("LastFMApiSecret");

        return new LastFMCredentials(apiKey, apiSecret);
    }

    public async Task<ShopifyCredentials> AuthenticateShopify()
    {
        var storeUrl = await GetSecret("ShopifyTestStoreURL");
        var token = await GetSecret("ShopifyTestStoreToken");

        return new ShopifyCredentials(storeUrl, token);
    }
}