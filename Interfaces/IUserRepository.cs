using UserManagementConsole.Entities;

namespace UserManagementConsole.Interfaces
{
    public interface IUserRepository
    {
        void Add(Pessoa pessoa);
        void Edit(Guid id, Pessoa novaPessoa);
        void Remove(Guid id);
        Pessoa? GetById(Guid id);
        List<Pessoa> GetAll();
        void Load();
        void Save();
    }
}
