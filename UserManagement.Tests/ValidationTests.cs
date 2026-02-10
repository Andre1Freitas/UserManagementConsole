using Xunit;
using UserManagementConsole.Utils;

namespace UserManagement.Tests
{
    public class ValidationTests
    {
        // --- TESTES DE NOME ---

        [Fact] // Teste simples: um caso de sucesso
        public void ValidateName_ShouldReturnTrue_WhenNameIsValid()
        {
            // Arrange
            string validName = "André Freitas";

            // Act
            var result = Validations.ValidateName(validName);

            // Assert
            Assert.True(result.isValid);
            Assert.Empty(result.errorMessage); // Se é valido, mensagem deve ser vazia
        }

        [Theory] // Teste com vários cenários de erro
        [InlineData("", "Nome está vazio")]          // Vazio
        [InlineData("A", "Nome muito curto")]        // Curto
        [InlineData("André123", "Nome tem números")] // Com número
        [InlineData("André@", "Nome tem caracteres especiais")] // Especial
        public void ValidateName_ShouldReturnFalse_WhenNameIsInvalid(string name, string expectedMessagePart)
        {
            // Act
            var result = Validations.ValidateName(name);

            // Assert
            Assert.False(result.isValid);
            // Verifica se a mensagem de erro contém o trecho esperado (Contains é melhor que Equal para mensagens)
            Assert.Contains(expectedMessagePart, result.errorMessage);
        }

        // --- TESTES DE IDADE ---

        [Theory]
        [InlineData(18)]
        [InlineData(0)]
        [InlineData(120)]
        public void ValidateAge_ShouldReturnTrue_WhenAgeIsWithinRange(int age)
        {
            var result = Validations.ValidateAge(age);
            Assert.True(result.isValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(121)]
        public void ValidateAge_ShouldReturnFalse_WhenAgeIsOutOfRange(int age)
        {
            var result = Validations.ValidateAge(age);
            Assert.False(result.isValid);
        }

        // --- TESTES DE EMAIL ---

        [Fact]
        public void ValidateEmail_ShouldReturnTrue_WhenEmailIsValid()
        {
            var result = Validations.ValidateEmail("teste@dominio.com");
            Assert.True(result.isValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("andre.com")]    // Sem @
        [InlineData("andre@com")]    // Sem dominio
        [InlineData("andre@.com")]   // Ponto logo após @
        public void ValidateEmail_ShouldReturnFalse_WhenEmailIsInvalid(string email)
        {
            var result = Validations.ValidateEmail(email);
            Assert.False(result.isValid);
        }
    }
}