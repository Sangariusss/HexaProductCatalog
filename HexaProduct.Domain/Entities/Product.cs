using System.Text.Json.Serialization;

namespace HexaProductCatalog.Domain.Entities;

public class Product
{
    [JsonPropertyName("title")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }
}