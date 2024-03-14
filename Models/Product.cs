public class Product{
    public int Id { get; set; }
    public string? Name { get; set; }
    public float UnitPrice { get; set; }
    public int Quantity { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}