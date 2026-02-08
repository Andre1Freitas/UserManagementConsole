using UserManagementConsole.Entities;

namespace UserManagementConsole.Interfaces
{
    public interface IUserRepository
    {
        void Add(User pessoa);
        void Edit(Guid id, User novaPessoa);
        void Remove(Guid id);
        User? GetById(Guid id);
        List<User> GetByName(string parteNome);
        List<User> GetAll();
        void Load();
        void Save();
    }
}
