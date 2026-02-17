using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;
using System.Text.Json;

namespace UserManagementAPI.Repositories
{
    public class UserJsonRepository : IUserRepository
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "users.json");
        private List<User> _users = new List<User>();

        public UserJsonRepository()
        {
            Load();
        }

        public void Add(User user)
        {
            _users.Add(user);
            Save();
        }

        public void Edit(Guid id, User newUser)
        {
            User? existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Update(newUser.Name, newUser.Age, newUser.Email);
                Save();
            }
        }

        public void Remove(Guid id)
        {
            _users.RemoveAll(u => u.Id == id);
            Save();
        }

        public User? GetById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetByName(string namePart)
        {
            return _users.Where(u => u.Name.ToLower().Contains(namePart.ToLower())).ToList();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Load()
        {
            _users.Clear();

            var directory = Path.GetDirectoryName(_filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
                return;
            }

            string json = File.ReadAllText(_filePath);
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            var loadedUsers = JsonSerializer.Deserialize<List<User>>(json);
            if (loadedUsers != null)
            {
                _users = loadedUsers;
            }
        }

        public void Save()
        {
            var directory = Path.GetDirectoryName(_filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_users, options);
            File.WriteAllText(_filePath, json);
        }
    }
}