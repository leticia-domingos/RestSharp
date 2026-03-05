using System.Text.Json.Serialization;

namespace ApiAutomationRestSharp.Schemas;

public class UsersResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int Per_Page { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("total_pages")]
    public int Total_Pages { get; set; }

    [JsonPropertyName("data")]
    public List<User> Data { get; set; }
}