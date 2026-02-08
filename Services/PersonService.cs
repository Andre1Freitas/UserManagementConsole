using UserManagementConsole.Entities;
using UserManagementConsole.Interfaces;

namespace UserManagementConsole.Services
{
    class PersonService
    {
        private readonly IUserRepository _repository;

        public PersonService(IUserRepository repository)
        {
            _repository = repository;
            _repository.Load();
        }

        public void CadastrarNovaPessoa(User p)
        {
            _repository.Add(p);
            _repository.Save();
        }

        public void RemoverPessoa(Guid id)
        {
            _repository.Remove(id);
            _repository.Save();
        }
        public void Edit(Guid id, User novaPessoa)
        {
            _repository.Edit(id, novaPessoa);
            _repository.Save();
        }
        public void PercorrerLista()
        {
            foreach (User p in _repository.GetAll())
            {
                Console.WriteLine(p);
            }
        }
        public User ProcuraUmaPessoaNaLista(Guid id)
        {
            return _repository.GetById(id);
        }
        public List<User> ProcuraPorNome(string parteNome)
        {
            return _repository.GetByName(parteNome);
        }
        public List<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}