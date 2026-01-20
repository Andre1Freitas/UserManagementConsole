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

        public void RemoverPessoa(string nome)
        {
            _repository.Remove(nome);
            _repository.Save();
        }
        public void PercorrerLista()
        {
            foreach (Pessoa p in _repository.GetAll())
            {
                Console.WriteLine(p);
            }
        }
        public Pessoa ProcuraUmaPessoaNaLista(String nome)
        {
            return _repository.GetByName(nome);
        }
    }
}