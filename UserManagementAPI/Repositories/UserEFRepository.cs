using UserManagementAPI.Data;
using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Repositories;

public class UserEFRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserEFRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<User> GetAll() => _context.Users.ToList();

    public User? GetById(Guid id) => _context.Users.Find(id);

    public List<User> GetByName(string name) => _context.Users.Where(p => p.Name.Contains(name)).ToList();

    public void Add(User user) => _context.Users.Add(user);

    public void Update(User user)
    {
        var existingUser = _context.Users.Find(user.Id);
        if (existingUser != null)
        {
            existingUser.Update(user.Name, user.Age, user.Email);
            Save();
        }
    }

    public void Delete(User user) => _context.Users.Remove(user);

    public void Save() => _context.SaveChanges();
}