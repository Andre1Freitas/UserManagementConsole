using UserManagementConsole.Entities;

namespace UserManagementConsole.Interfaces
{
    public interface IUserRepository
    {
        void Add(Pessoa pessoa);
        void Remove(string nome);
        Pessoa GetByName(string nome);
        List<Pessoa> GetAll();

        void Load();
        void Save();
    }
}
