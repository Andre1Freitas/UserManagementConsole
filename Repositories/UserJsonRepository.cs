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
        private List<User> users = new List<User>();

        public void Add(User user)
        {
            users.Add(user);
        }
        public void Edit(Guid id, User newUser)
        {
            User? existingUser = users.FirstOrDefault(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.Update(newUser.Name, newUser.Age, newUser.Email);
            }
        }
        public void Remove(Guid id)
        {
            users.RemoveAll(x => x.Id == id);
        }
        public User? GetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        public List<User> GetByName(string parteNome)
        {
            return users.Where(p => p.Name.ToLower().Contains(parteNome.ToLower())).ToList();
        }
        public List<User> GetAll()
        {
            return users;
        }
        public void Load()
        {
            users.Clear();
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
            List<User>? lista = JsonSerializer.Deserialize<List<User>>(jsonString);
            if (lista != null)
            {
                users = lista;
            }
        }
        public void Save()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(users, option);

            File.WriteAllText(_filePath, jsonString);
        }
    }
}
