using System.Text.RegularExpressions;

namespace UserManagementConsole.Utils
{
    static class Validacoes
    {
        static public (bool isValido, string mensagemErro) ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                return (false, "Nome está vazio ou com espaço. Digite novamente: ");
            }
            if (nome.Length < 2)
            {
                return (false, "Nome muito curto. Digite novamente: ");
            }
            if (nome.Length > 50)
            {
                return (false, "Nome muito longo. Digite novamente: ");
            }
            if (Regex.IsMatch(nome, @"\d"))
            {
                return (false, "Nome tem números. Digite novamente: ");
            }
            if (!Regex.IsMatch(nome, @"^[\p{L}\s]+$"))
            {
                return (false, "Nome tem caracteres especiais. Digite novamente: ");
            }
            return (true, "");
        }

        static public (bool isValido, string mensagemErro) ValidarIdade(int idade)
        {
            if (idade < 0 || idade > 120)
            {
                return (false, "Idade deve estar entre 0 e 120. Digite uma idade valida: ");
            }
            return (true, "");
        }

        static public (bool isValido, string mensagemErro) ValidarEmail(string email)
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
