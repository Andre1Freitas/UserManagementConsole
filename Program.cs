using UserManagementConsole.Services;
using UserManagementConsole.Entities;
using UserManagementConsole.Interfaces;
using UserManagementConsole.Repositories;
using UserManagementConsole.Utils;

namespace UserManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository repository = new UserJsonRepository();
            PersonService personService = new PersonService(repository);
            ConsoleMenu menu = new ConsoleMenu();

            int option = 1;
            while (option != 0)
            {
                option = menu.DisplayMenuAndReadOption();
                if (option < 0 || option > 5)
                {
                    menu.DisplayMessage("Opção invalida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                    menu.WaitForKey();
                    menu.ClearScreen();
                    continue;
                }
                switch (option)
                {
                    case 0: break;

                    case 1:
                        personService.AddUser(menu.CollectNewUserData());
                        menu.DisplayMessage("Pessoa cadastrada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.WaitForKey();
                        break;

                    case 2:
                        List<User> users = personService.GetAll();
                        if (menu.IsListEmpty(users, "Lista está vazia"))
                        {
                            break;
                        }
                        User userToDelete = menu.SelectUserFromList(users);
                        if (menu.ConfirmAction($"Tem certeza que deseja remover {userToDelete.Name}? (s/n):"))
                        {
                            personService.DeleteUser(userToDelete.Id);
                            menu.DisplayMessage("Pessoa excluida com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                            menu.WaitForKey();
                            break;
                        }
                        menu.DisplayMessage("Pessoa não foi excluida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                        menu.WaitForKey();
                        break;

                    case 3:
                        menu.ShowList(personService.GetAll());
                        menu.WaitForKey();
                        break;

                    case 4:
                        if (menu.IsListEmpty(personService.GetAll(), "Lista está vazia"))
                        {
                            break;
                        }
                        string nameSearch = menu.SearchUserName();
                        menu.DisplaySearchResults(personService.SearchByName(nameSearch));
                        menu.DisplayMessage("[Pressione Enter para continuar]");
                        menu.WaitForKey();
                        break;

                    case 5:
                        users = personService.GetAll();
                        if (menu.IsListEmpty(users, "Lista está vazia"))
                        {
                            break;
                        }
                        User existingUser = menu.SelectUserFromList(users);
                        User updatedUser = menu.CollectNewUserData();
                        personService.Edit(existingUser.Id, updatedUser);
                        menu.DisplayMessage("Pessoa editada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.WaitForKey();
                        break;
                }
                menu.ClearScreen();
            }
        }
    }
}