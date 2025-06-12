using ContactNotePad.Models;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<Contact>> GetAllContactsAsync(string nickname);
    Task<Contact> GetContactByIdAsync(int id);
    Task<User> GetUserByNicknameAsync(string nickname);
    Task UpdateContactAsync(Contact contact);
    Task AddContactAsync(Contact contact);
    Task AddUSerAsync(User user);
}
