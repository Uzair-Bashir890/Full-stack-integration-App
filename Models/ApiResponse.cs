namespace ServerApp.Models;

public class ApiResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public IEnumerable<Product> Data { get; set; } = Array.Empty<Product>();
    public int Count { get; set; }
}