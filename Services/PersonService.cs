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

        public void AddUser(User user)
        {
            _repository.Add(user);
            _repository.Save();
        }

        public void DeleteUser(Guid id)
        {
            _repository.Remove(id);
            _repository.Save();
        }
        public void Edit(Guid id, User updatedUser)
        {
            _repository.Edit(id, updatedUser);
            _repository.Save();
        }
        public User GetUserById(Guid id)
        {
            return _repository.GetById(id)!;
        }
        public List<User> SearchByName(string namePart)
        {
            return _repository.GetByName(namePart);
        }
        public List<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}