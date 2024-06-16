namespace IWantApp.Domain.Products;

public class Products : Entity
{
    public string Name { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    
}
