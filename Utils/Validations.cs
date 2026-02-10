using System.Text.RegularExpressions;

namespace UserManagementConsole.Utils
{
    public static class Validations
    {
        static public (bool isValid, string errorMessage) ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return (false, "Nome está vazio ou com espaço. Digite novamente: ");
            }
            if (name.Length < 2)
            {
                return (false, "Nome muito curto. Digite novamente: ");
            }
            if (name.Length > 50)
            {
                return (false, "Nome muito longo. Digite novamente: ");
            }
            if (Regex.IsMatch(name, @"\d"))
            {
                return (false, "Nome tem números. Digite novamente: ");
            }
            if (!Regex.IsMatch(name, @"^[\p{L}\s]+$"))
            {
                return (false, "Nome tem caracteres especiais. Digite novamente: ");
            }
            return (true, "");
        }

        static public (bool isValid, string errorMessage) ValidateAge(int age)
        {
            if (age < 0 || age > 120)
            {
                return (false, "Idade deve estar entre 0 e 120. Digite uma idade valida: ");
            }
            return (true, "");
        }

        static public (bool isValid, string errorMessage) ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                return (false, "Email está vazio ou com espaço. Digite novamente: ");
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return (false, "Email invalido. Digite novamente: ");
            }
            return (true, "");
        }
    }
}
