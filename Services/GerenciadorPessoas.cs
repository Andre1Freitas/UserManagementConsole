using UserManagementConsole.Entities;
using UserManagementConsole.Interfaces;

namespace UserManagementConsole.Services
{
    class GerenciadorPessoas
    {
        private readonly IUserRepository _repository;

        public GerenciadorPessoas(IUserRepository repository)
        {
            _repository = repository;
            _repository.Load();
        }

        public void CadastrarNovaPessoa(Pessoa p)
        {
            _repository.Add(p);
            _repository.Save();
        }

        public void RemoverPessoa(Guid id)
        {
            _repository.Remove(id);
            _repository.Save();
        }
        public void Edit(Guid id, Pessoa novaPessoa)
        {
            _repository.Edit(id, novaPessoa);
            _repository.Save();
        }
        public void PercorrerLista()
        {
            foreach (Pessoa p in _repository.GetAll())
            {
                Console.WriteLine(p);
            }
        }
        public Pessoa ProcuraUmaPessoaNaLista(Guid id)
        {
            return _repository.GetById(id);
        }
        public List<Pessoa> ProcuraPorNome(string parteNome)
        {
            return _repository.GetByName(parteNome);
        }
        public List<Pessoa> GetAll()
        {
            return _repository.GetAll();
        }
    }
}