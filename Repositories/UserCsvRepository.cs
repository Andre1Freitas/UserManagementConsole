using UserManagementConsole.Entities;
using UserManagementConsole.Interfaces;
namespace UserManagement.Repositories;
using UserManagementConsole.Utils;

class UserCsvRepository : IUserRepository
{
    private readonly string _filePath = @"Data\users.csv";
    private readonly string _folderPath = @"Data\";
    private List<Pessoa> pessoas = new List<Pessoa>();

    public void Load()
    {
        pessoas.Clear();
        if (!Directory.Exists(_folderPath))
        {
            Directory.CreateDirectory(_folderPath);
        }
        if (!File.Exists(_filePath))
        {
            using (File.Create(_filePath))
            {
                return;
            }
        }
        using (StreamReader sr = new StreamReader(_filePath))
        {
            while (!sr.EndOfStream)
            {
                string linha = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] coluna = linha.Split(';');
                if (coluna.Length != 3)
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(coluna[0].Trim()) || string.IsNullOrWhiteSpace(coluna[1].Trim()) || string.IsNullOrWhiteSpace(coluna[2].Trim()))
                {
                    continue;
                }
                string nome = coluna[0].Trim();

                if (int.TryParse(coluna[1].Trim(), out int idade))
                {
                    var resultIdade = Validacoes.ValidarIdade(idade);
                    if (!resultIdade.isValido)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                var resultEmail = Validacoes.ValidarEmail(coluna[2]);
                if (!resultEmail.isValido)
                {
                    continue;
                }
                string email = coluna[2].Trim();

                pessoas.Add(new Pessoa(nome, idade, email));
            }
        }
    }
    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(_filePath))
        {
            sw.WriteLine("Nome;Idade;Email");

            foreach (Pessoa p in pessoas)
            {
                sw.WriteLine($"{p.Nome};{p.Idade};{p.Email}");
            }
        }
    }

    public void Add(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }
    public void Remove(string nome)
    {
        Pessoa pessoaRemover = GetByName(nome);

        if (pessoaRemover != null)
        {
            pessoas.Remove(pessoaRemover);
        }
    }

    public List<Pessoa> GetAll()
    {
        return pessoas;
    }

    public Pessoa GetByName(string nome)
    {
        return pessoas.FirstOrDefault(x => x.Nome == nome);
    }
}