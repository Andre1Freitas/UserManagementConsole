using UserManagementConsole.Entities;
using UserManagementConsole.Interfaces;
using UserManagementConsole.Utils;
using System.Text.Json;

namespace UserManagementConsole.Repositories
{
    class UserJsonRepository : IUserRepository
    {
        private readonly string _filePath = @"..\..\..\Data\users.json";
        private readonly string _folderPath = @"..\..\..\Data\";
        private List<Pessoa> pessoas = new List<Pessoa>();

        public void Add(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }
        public void Edit(Guid id, Pessoa novaPessoa)
        {
            Pessoa? pessoaEditar = pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoaEditar != null)
            {
                pessoaEditar.Nome = novaPessoa.Nome;
                pessoaEditar.Email = novaPessoa.Email;
                pessoaEditar.Idade = novaPessoa.Idade;
            }
        }
        public void Remove(Guid id)
        {
            pessoas.RemoveAll(x => x.Id == id);
        }
        public Pessoa? GetById(Guid id)
        {
            return pessoas.FirstOrDefault(x => x.Id == id);
        }
        public List<Pessoa> GetByName(string parteNome)
        {
            return pessoas.Where(p => p.Nome.ToLower().Contains(parteNome.ToLower())).ToList();
        }
        public List<Pessoa> GetAll()
        {
            return pessoas;
        }
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
            if(string.IsNullOrEmpty(File.ReadAllText(_filePath)))
            {
                return;
            }

            string jsonString = File.ReadAllText(_filePath);
            List<Pessoa>? lista = JsonSerializer.Deserialize<List<Pessoa>>(jsonString);
            if (lista != null)
            {
                pessoas = lista;
            }
        }
        public void Save()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(pessoas, option);

            File.WriteAllText(_filePath, jsonString);
        }
    }
}
