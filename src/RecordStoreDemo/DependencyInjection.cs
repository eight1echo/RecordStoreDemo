using Azure.Identity;
using Microsoft.Extensions.Azure;
using ParkSquare.Discogs;
using System.Net;

using RecordStoreDemo.External.Azure;
using RecordStoreDemo.External.DataSources.Discogs;
using RecordStoreDemo.External.DataSources.LastFM;
using RecordStoreDemo.External.DataSources.MusicBrainz;
using RecordStoreDemo.External.DataSources.WebScraping;
using RecordStoreDemo.External.Shopify;
using Microsoft.Extensions.DependencyInjection;

namespace RecordStoreDemo;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationFeatures(this IServiceCollection services)
    {
        services.AddTransient<IWebstoreCollectionService, WebstoreCollectionService>();
        services.AddTransient<IWebstoreImageService, WebstoreImageService>();
        services.AddTransient<IWebstoreMetaFieldService, WebstoreMetaFieldService>();
        services.AddTransient<IWebstoreProductService, WebstoreProductService>();

        return services;
    }
    public static IServiceCollection AddAzureInfrastructure(this IServiceCollection services)
    {
        services.AddAzureClients(builder =>
        {
            builder.AddSecretClient(new Uri("https://recordstoredemo.vault.azure.net/"));
            builder.UseCredential(new DefaultAzureCredential());
        });

        services.AddTransient<AzureKeyVaultService>();
        services.AddTransient<AzureStorageService>();

        return services;
    }
    public static IServiceCollection AddExternal(this IServiceCollection services)
    {
        // Discogs
        services.AddSingleton<IApiQueryBuilder, ApiQueryBuilder>();
        services.AddSingleton<IClientConfig, DiscogsClientConfig>();
        services.AddHttpClient<IDiscogsClient, DiscogsClient>()
            .ConfigurePrimaryHttpMessageHandler(_ =>
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
        services.AddTransient<IDiscogsService, DiscogsService>();

        // LastFM
        services.AddTransient<ILastFMService, LastFMService>();

        // MusicBrainz
        services.AddTransient<IMusicBrainzService, MusicBrainzService>();

        // Shopify
        services.AddTransient<IShopifyClientFactory, ShopifyClientFactory>();

        // WebScraping
        services.AddHttpClient<IRecordStoreDayClient, RecordStoreDayClient>();
        services.AddHttpClient<IVintageVinylClient, VintageVinylClient>();

        return services;
    }
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RecordStoreDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddTransient<IInventoryProductRepository, InventoryProductRepository>();
        services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddTransient<IReceiveRepository, ReceiveRepository>();
        services.AddTransient<IVendorRepository, VendorRepository>();

        return services;
    }
}