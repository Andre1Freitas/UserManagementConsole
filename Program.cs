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
            MenuConsole menu = new MenuConsole();

            int option = 1;
            while (option != 0)
            {
                option = menu.ExibirMenuELerOpcao();
                if (option < 0 || option > 5)
                {
                    menu.ExibirMensagem("Opção invalida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                    menu.AguardarTecla();
                    menu.LimparTela();
                    continue;
                }
                switch (option)
                {
                    case 0: break;

                    case 1:
                        personService.AddUser(menu.ColetarDadosNovaPessoa());
                        menu.ExibirMensagem("Pessoa cadastrada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.AguardarTecla();
                        break;

                    case 2:
                        List<User> users = personService.GetAll();
                        if (menu.VerificarListaVazia(users, "Lista está vazia"))
                        {
                            break;
                        }
                        User userToDelete = menu.SelecionarPessoaDaLista(users);
                        if (menu.ConfirmarAcao($"Tem certeza que deseja remover {userToDelete.Name}? (s/n):"))
                        {
                            personService.DeleteUser(userToDelete.Id);
                            menu.ExibirMensagem("Pessoa excluida com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                            menu.AguardarTecla();
                            break;
                        }
                        menu.ExibirMensagem("Pessoa não foi excluida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                        menu.AguardarTecla();
                        break;

                    case 3:
                        menu.ExibirLista(personService.GetAll());
                        menu.AguardarTecla();
                        break;

                    case 4:
                        if (menu.VerificarListaVazia(personService.GetAll(), "Lista está vazia"))
                        {
                            break;
                        }
                        string nameSearch = menu.BuscarNomePessoa();
                        menu.ExibirResultadosBusca(personService.SearchByName(nameSearch));
                        menu.ExibirMensagem("[Pressione Enter para continuar]");
                        menu.AguardarTecla();
                        break;

                    case 5:
                        users = personService.GetAll();
                        if (menu.VerificarListaVazia(users, "Lista está vazia"))
                        {
                            break;
                        }
                        User existingUser = menu.SelecionarPessoaDaLista(users);
                        User updatedUser = menu.ColetarDadosNovaPessoa();
                        personService.Edit(existingUser.Id, updatedUser);
                        menu.ExibirMensagem("Pessoa editada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.AguardarTecla();
                        break;
                }
                menu.LimparTela();
            }
        }
    }
}