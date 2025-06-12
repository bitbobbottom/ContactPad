using Microsoft.EntityFrameworkCore;
using ContactNotePad.Models;

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<List<Contact>> GetAllContactsAsync(string nickname)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        if (user == null)
            throw new ArgumentException("User not found");

        return await _db.Contacts.Where(c => c.UserId == user.Id).ToListAsync();
    }

    public async Task<Contact> GetContactByIdAsync(int id)
    {
        return await _db.Contacts.FindAsync(id);
    }

    public async Task<User> GetUserByNicknameAsync(string nickname)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        _db.Contacts.Update(contact);
        await _db.SaveChangesAsync();
    }

    public async Task AddContactAsync(Contact contact)
    {
        _db.Contacts.Add(contact);
        await _db.SaveChangesAsync();
    }

    public async Task AddUSerAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }
}
