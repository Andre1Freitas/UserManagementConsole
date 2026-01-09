using UserManagementConsole.Services;
using UserManagementConsole.Entities;
using UserManagementConsole.Utils;

namespace UserManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 1;
            GerenciadorPessoas gerenciador = new GerenciadorPessoas();

            while (opcao > 0)
            {
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1 - Cadastrar nova pessoa");
                Console.WriteLine("2 - Excluir pessoa da lista");
                Console.WriteLine("3 - Mostrar lista inteira");
                Console.WriteLine("4 - Procurar uma pessoa da lista");
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
                        Console.Write("Escreva o nome da pessoa a ser removida: ");
                        nome = Console.ReadLine()!;
                        gerenciador.RemoverPessoa(nome);
                        break;
                    case 3:
                        gerenciador.PercorrerLista();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Escreva o nome da pessoa a ser procurada: ");
                        nome = Console.ReadLine()!;
                        Pessoa p = gerenciador.ProcuraUmaPessoaNaLista(nome);
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
                }

                Console.Clear();
            }
        }
    }
}

