using UserManagementConsole.Entities;

namespace UserManagementConsole.Utils
{
    public class ConsoleMenu
    {
        public int DisplayMenuAndReadOption()
        {
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1 - Cadastrar nova pessoa");
            Console.WriteLine("2 - Excluir pessoa da lista");
            Console.WriteLine("3 - Mostrar lista inteira");
            Console.WriteLine("4 - Procurar uma pessoa da lista");
            Console.WriteLine("5 - Editar uma pessoa da lista");
            Console.WriteLine("0 - Sair");
            if (int.TryParse(Console.ReadLine()!, out int option)) return option;
            return -1;
        }

        public void ShowList(List<User> users)
        {
            if (users.Count == 0)
            {
                DisplayMessage("Nenhuma pessoa cadastrada", ConsoleColor.Red);
                return;
            }
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Name} ({users[i].Email})");
            }
        }
        public void DisplaySearchResults(List<User> users)
        {
            if (users.Count == 0)
            {
                DisplayMessage("Nenhuma pessoa encontrada", ConsoleColor.Red);
                return;
            }
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Name} {users[i].Age} ({users[i].Email}) {users[i].Id}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void DisplayMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void WaitForKey()
        {
            Console.ReadLine();
        }

        public string RequestValidName()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine()!;

            var nameResult = Validations.ValidateName(name);
            while (!nameResult.isValid)
            {
                DisplayMessage($"{nameResult.errorMessage}", ConsoleColor.Red);
                name = Console.ReadLine()!;
                nameResult = Validations.ValidateName(name);
            }
            return name;
        }

        public int RequestValidAge()
        {
            Console.Write("Idade: ");
            int age;
            (bool isValid, string errorMessage) ageResult;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    DisplayMessage("Idade Invalida. Digite um numero inteiro valido.", ConsoleColor.Red);
                    continue;
                }
                ageResult = Validations.ValidateAge(age);
                if (!ageResult.isValid)
                {
                    DisplayMessage($"{ageResult.errorMessage}", ConsoleColor.Red);
                    continue;
                }
                break;
            }
            return age;
        }

        public string RequestValidEmail()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            var emailResult = Validations.ValidateEmail(email);
            while (!emailResult.isValid)
            {
                DisplayMessage($"{emailResult.errorMessage}", ConsoleColor.Red);
                email = Console.ReadLine()!;
                emailResult = Validations.ValidateEmail(email);
            }
            return email;
        }

        public Guid RequestValidGuid(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    DisplayMessage("Guid invalido!", ConsoleColor.Red);
                    continue;
                }
                return id;
            }
        }

        public User CollectNewUserData()
        {
            Console.WriteLine("Escreva as informações dessa pessoa:");
            return new User(RequestValidName(), RequestValidAge(), RequestValidEmail());
        }

        public User SelectUserFromList(List<User> users)
        {

            ShowList(users);
            while (true)
            {
                Console.WriteLine("Escreva o numero da pessoa: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num < 1 || num > users.Count)
                    {
                        DisplayMessage("Numero invalido! Tente novamente", ConsoleColor.Red);
                        continue;
                    }
                    return users[num - 1];
                }
                DisplayMessage("Entrada invalida! Digite apenas numeros", ConsoleColor.Red);
                continue;
            }
        }
        public string SearchUserName()
        {
            while (true)
            {
                Console.WriteLine("Digite parte do nome da pessoa: ");
                string? namePart = Console.ReadLine();
                if (string.IsNullOrEmpty(namePart))
                {
                    DisplayMessage("Nome não pode ser vazio!", ConsoleColor.Red);
                    continue;
                }
                return namePart!;
            }
        }
        public bool ConfirmAction(string message)
        {
            while (true)
            {
                DisplayMessage(message, ConsoleColor.Yellow);
                string? input = Console.ReadLine()?.ToLower();

                if (input == "s") return true;
                if (input == "n") return false;

                DisplayMessage("Resposta invalida! Digite 's' para sim ou 'n' para não.", ConsoleColor.Red);
            }
        }
        public bool IsListEmpty(List<User> users, string message)
        {
            if (users.Count == 0)
            {
                DisplayMessage(message, ConsoleColor.Red);
                WaitForKey();
                return true;
            }
            return false;
        }
    }

}