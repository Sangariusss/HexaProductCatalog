using HexaProductCatalog.Domain.Entities;
using HexaProductCatalog.Domain.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ProductProxy : IProductProxy
{
    private readonly HttpClient _httpClient;
    private const string ExternalApiUrl = "https://dummyjson.com/products";

    public ProductProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetExternalProducts()
    {
        try
        {
            var response = await _httpClient.GetStringAsync(ExternalApiUrl);
            var jsonResponse = JsonSerializer.Deserialize<ApiResponse>(response);
            return jsonResponse?.Products ?? new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }

    public class ApiResponse
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}