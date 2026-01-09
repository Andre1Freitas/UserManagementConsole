using UserManagementConsole.Entities;

namespace UserManagementConsole.Services
{
    class GerenciadorPessoas
    {
        List<Pessoa> Pessoas = new List<Pessoa>();

        public void CadastrarNovaPessoa(Pessoa p)
        {
            Pessoas.Add(p);
        }

        public void RemoverPessoa(string nome)
        {
            Pessoa p = ProcuraUmaPessoaNaLista(nome);
            Pessoas.Remove(p);
        }
        public void PercorrerLista()
        {
            foreach (Pessoa p in Pessoas)
            {
                Console.WriteLine(p);
            }
        }
        public Pessoa ProcuraUmaPessoaNaLista(String nome)
        {
            foreach (Pessoa p in Pessoas)
            {
                if (p.Nome == nome)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
