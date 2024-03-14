public class User{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Sex { get; set; }
    public string? Password { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}