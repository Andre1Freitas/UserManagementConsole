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
            GerenciadorPessoas gerenciador = new GerenciadorPessoas(repository);
            MenuConsole menu = new MenuConsole();

            int opcao = 1;
            while (opcao != 0)
            {
                opcao = menu.ExibirMenuELerOpcao();
                if (opcao < 0 || opcao > 5)
                {
                    menu.ExibirMensagem("Opção invalida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                    menu.AguardarTecla();
                    menu.LimparTela();
                    continue;
                }
                switch (opcao)
                {
                    case 0: break;

                    case 1:
                        gerenciador.CadastrarNovaPessoa(menu.ColetarDadosNovaPessoa());
                        menu.ExibirMensagem("Pessoa cadastrada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.AguardarTecla();
                        break;

                    case 2:
                        Pessoa pessoaDeletar = menu.SelecionarPessoaDaLista(gerenciador.GetAll());
                        if (menu.ConfirmarAcao($"Tem certeza que deseja remover {pessoaDeletar.Nome}? (s/n):"))
                        {
                            gerenciador.RemoverPessoa(pessoaDeletar.Id);
                            menu.ExibirMensagem("Pessoa excluida com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                            menu.AguardarTecla();
                            break;
                        }
                        menu.ExibirMensagem("Pessoa não foi excluida!\n[Pressione Enter para continuar]", ConsoleColor.Red);
                        menu.AguardarTecla();
                        break;

                    case 3:
                        menu.ExibirLista(gerenciador.GetAll());
                        menu.AguardarTecla();
                        break;

                    case 4:
                        Pessoa pessoaProcurada = menu.SelecionarPessoaDaLista(gerenciador.GetAll());
                        Console.WriteLine(pessoaProcurada);
                        menu.AguardarTecla();
                        break;

                    case 5:
                        Pessoa pessoaAntiga = menu.SelecionarPessoaDaLista(gerenciador.GetAll());
                        Pessoa pessoaAtualizada = menu.ColetarDadosNovaPessoa();
                        gerenciador.Edit(pessoaAntiga.Id, pessoaAtualizada);
                        menu.ExibirMensagem("Pessoa editada com sucesso!\n[Pressione Enter para continuar]", ConsoleColor.Green);
                        menu.AguardarTecla();
                        break;
                }
                menu.LimparTela();
            }
        }
    }
}