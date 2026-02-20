using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(User user)
        {
            _repository.Add(user);
            _repository.Save();
        }

        public void DeleteUser(User user)
        {
            _repository.Delete(user);
            _repository.Save();
        }
        public void Update(User updatedUser)
        {
            _repository.Update(updatedUser);
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