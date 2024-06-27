namespace Contracts.Responses;

public record ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
