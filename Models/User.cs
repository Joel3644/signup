using System.Security.Cryptography;
using System.Text;

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


    public string ToHash(){
        using (SHA256 sha256Hash = SHA256.Create()){
            byte[] sourceBytes = Encoding.UTF8.GetBytes(Password!);
            byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash;
        }
    }
}