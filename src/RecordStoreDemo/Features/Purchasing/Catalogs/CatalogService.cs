using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using RecordStoreDemo.External.Azure;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.ImportCatalogProducts;
using RecordStoreDemo.Features.Purchasing.Catalogs.Commands.UpdateCatalogOptions;

namespace RecordStoreDemo.Features.Purchasing.Catalogs;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;
    private readonly AzureStorageService _storageService;

    public CatalogService(HttpClient httpClient, AzureStorageService storageService)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/purchasing/catalogs/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _storageService = storageService;
    }

    public async Task<List<CatalogProductModel>> FindCatalogProducts(ProductQueryRequest request)
    {
        var response = await _httpClient.GetFromJsonAsync<List<CatalogProductModel>>($"find?Artist={request.Artist}&Title={request.Title}&UPC={request.UPC}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
    public async Task<CatalogProductModel?> FindCatalogProductByUPC(string upc)
    {
        var response = await _httpClient.GetAsync($"find/{upc}");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<CatalogProductModel>();

            return result;
        }

        return null;
    }
    public async Task<CatalogProductModel> GetCatalogProduct(Guid id)
    {
        var response = await _httpClient.GetAsync($"{id}");
        var result = await response.Content.ReadFromJsonAsync<CatalogProductModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
    public async Task<List<CatalogProductModel>> ImportCatalogProducts(ImportCatalogProductsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await response.Content.ReadFromJsonAsync<List<CatalogProductModel>>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
    public async Task<CatalogModel> UpdateCatalogOptions(UpdateCatalogOptionsRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync("", request);
        var result = await response.Content.ReadFromJsonAsync<CatalogModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
    public async Task UploadCatalog(string vendorName, IBrowserFile file)
    {
        await _storageService.UploadToStorage("catalogs", vendorName, file);
    }

    public async Task<List<CatalogProductModel>> CatalogProductsFromCSV(Guid vendorId, string vendorName, CatalogModel catalogOptions)
    {
        var content = await _storageService.ReadFromStorage("catalogs", vendorName);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = catalogOptions.HasHeader,
            ShouldSkipRecord = x => x.Row.Parser.Record?.All(field => string.IsNullOrWhiteSpace(field)) ?? false
        };

        using var reader = new StreamReader(content);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap(new CatalogProductMap(catalogOptions));

        var products = new List<CatalogProductModel>();
        while (csv.Read())
        {
            var record = csv.GetRecord<CatalogProductModel>();

            if (record is not null)
            {
                record.VendorId = vendorId;
                record.VendorName = vendorName;
                record.Format = CatalogProductMap.ParseFormat(record.Format.Trim());
                products.Add(record);
            }
        }

        return products;
    }
}