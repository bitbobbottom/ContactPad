namespace ContactNotePad.Models;

public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
