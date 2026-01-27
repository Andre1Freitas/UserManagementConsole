using UserManagementConsole.Services;
using UserManagementConsole.Entities;
using UserManagementConsole.Utils;
using UserManagementConsole.Interfaces;
using UserManagementConsole.Repositories;

namespace UserManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository repository = new UserJsonRepository();
            GerenciadorPessoas gerenciador = new GerenciadorPessoas(repository);

            int opcao = 1;
            while (opcao > 0)
            {
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1 - Cadastrar nova pessoa");
                Console.WriteLine("2 - Excluir pessoa da lista");
                Console.WriteLine("3 - Mostrar lista inteira");
                Console.WriteLine("4 - Procurar uma pessoa da lista");
                Console.WriteLine("5 - Editar uma pessoa da lista");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 0: break;
                    case 1:
                        Console.WriteLine("Escreva as informações dessa pessoa:");

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        var resultNome = Validacoes.ValidarNome(nome);
                        while (!resultNome.isValido)
                        {
                            Console.WriteLine(resultNome.mensagemErro);
                            nome = Console.ReadLine();
                            resultNome = Validacoes.ValidarNome(nome);
                        }

                        Console.Write("Idade: ");
                        int idade;
                        (bool isValido, string mensagemErro) resultIdade;
                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out idade))
                            {
                                Console.WriteLine("Idade Invalida. Digite um numero inteiro valido.");
                                continue;
                            }
                            resultIdade = Validacoes.ValidarIdade(idade);
                            if (!resultIdade.isValido)
                            {
                                Console.WriteLine(resultIdade.mensagemErro);
                                continue;
                            }
                            break;
                        }

                        Console.Write("Email: ");
                        string email = Console.ReadLine()!;
                        var resultEmail = Validacoes.ValidarEmail(email);
                        while (!resultEmail.isValido)
                        {
                            Console.WriteLine(resultEmail.mensagemErro);
                            email = Console.ReadLine();
                            resultEmail = Validacoes.ValidarEmail(email);
                        }

                        gerenciador.CadastrarNovaPessoa(new Pessoa(nome, idade, email));

                        break;
                    case 2:
                        Console.Write("Escreva o id da pessoa a ser removida: ");
                        Guid id = Guid.Parse(Console.ReadLine()!);
                        gerenciador.RemoverPessoa(id);
                        break;
                    case 3:
                        gerenciador.PercorrerLista();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Escreva o id da pessoa a ser procurada: ");
                        id = Guid.Parse(Console.ReadLine()!);
                        Pessoa p = gerenciador.ProcuraUmaPessoaNaLista(id);
                        if (p == null)
                        {
                            Console.WriteLine("Não existe pessoa com esse nome");
                        }
                        else
                        {
                            Console.WriteLine(p);
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        gerenciador.PercorrerLista();
                        Console.WriteLine("Escreva as novas informações dessa pessoa:");

                        Console.Write("Nome: ");
                        nome = Console.ReadLine();

                        resultNome = Validacoes.ValidarNome(nome);
                        while (!resultNome.isValido)
                        {
                            Console.WriteLine(resultNome.mensagemErro);
                            nome = Console.ReadLine();
                            resultNome = Validacoes.ValidarNome(nome);
                        }

                        Console.Write("Idade: ");
                        (bool isValido, string mensagemErro) resultIdad;
                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out idade))
                            {
                                Console.WriteLine("Idade Invalida. Digite um numero inteiro valido.");
                                continue;
                            }
                            resultIdad = Validacoes.ValidarIdade(idade);
                            if (!resultIdad.isValido)
                            {
                                Console.WriteLine(resultIdad.mensagemErro);
                                continue;
                            }
                            break;
                        }

                        Console.Write("Email: ");
                        email = Console.ReadLine()!;
                        resultEmail = Validacoes.ValidarEmail(email);
                        while (!resultEmail.isValido)
                        {
                            Console.WriteLine(resultEmail.mensagemErro);
                            email = Console.ReadLine();
                            resultEmail = Validacoes.ValidarEmail(email);
                        }

                        Console.Write("Id: ");
                        Guid idEditar = Guid.Parse(Console.ReadLine());

                        Pessoa pessoaEditada = new Pessoa(nome, idade, email);

                        gerenciador.Edit(idEditar, pessoaEditada);

                        break;
                }

                Console.Clear();
            }
        }
    }
}

