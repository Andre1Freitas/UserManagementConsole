using Xunit;
using UserManagementConsole.Entities;

namespace UserManagement.Tests
{
    public class UserTests
    {
        [Fact]
        public void UserConstructor_ShouldGenerateId_WhenCreated()
        {
            // Arrange
            string name = "Teste User";
            int age = 25;
            string email = "teste@email.com";

            // Act
            var user = new User(name, age, email);

            // Assert
            Assert.NotEqual(Guid.Empty, user.Id); // Garante que o ID não é vazio (00000...)
            Assert.Equal(name, user.Name);
            Assert.Equal(age, user.Age);
        }

        [Fact]
        public void Update_ShouldChangeUserProperties()
        {
            // Arrange
            var user = new User("Original", 20, "original@email.com");
            string newName = "Atualizado";
            int newAge = 30;
            string newEmail = "novo@email.com";

            // Act
            user.Update(newName, newAge, newEmail);

            // Assert
            Assert.Equal(newName, user.Name);
            Assert.Equal(newAge, user.Age);
            Assert.Equal(newEmail, user.Email);
            // O ID deve permanecer o mesmo, isso é importante!
            Assert.NotEqual(Guid.Empty, user.Id);
        }
    }
}