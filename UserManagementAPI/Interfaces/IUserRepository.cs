using UserManagementAPI.Entities;

namespace UserManagementAPI.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User? GetById(Guid id);
        List<User> GetByName(string partName);
        List<User> GetAll();
        void Save();
    }
}
