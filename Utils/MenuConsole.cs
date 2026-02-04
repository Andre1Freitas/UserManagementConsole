using UserManagementConsole.Entities;

namespace UserManagementConsole.Utils
{
    public class MenuConsole
    {
        public int ExibirMenuELerOpcao()
        {
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1 - Cadastrar nova pessoa");
            Console.WriteLine("2 - Excluir pessoa da lista");
            Console.WriteLine("3 - Mostrar lista inteira");
            Console.WriteLine("4 - Procurar uma pessoa da lista");
            Console.WriteLine("5 - Editar uma pessoa da lista");
            Console.WriteLine("0 - Sair");
            if (int.TryParse(Console.ReadLine()!, out int a)) return a;
            return -1;
        }

        public void ExibirLista(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                ExibirMensagem("Nenhuma pessoa cadastrada", ConsoleColor.Red);
                return;
            }
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pessoas[i].Nome} ({pessoas[i].Email})");
            }
        }
        public void ExibirResultadosBusca(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                ExibirMensagem("Nenhuma pessoa encontrada", ConsoleColor.Red);
                return;
            }
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pessoas[i].Nome} {pessoas[i].Idade} ({pessoas[i].Email}) {pessoas[i].Id}");
            }
        }

        public void ExibirMensagem(string msg)
        {
            Console.WriteLine(msg);
        }
        public void ExibirMensagem(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void LimparTela()
        {
            Console.Clear();
        }

        public void AguardarTecla()
        {
            Console.ReadLine();
        }

        public string PedirNomeValido()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            var resultNome = Validacoes.ValidarNome(nome);
            while (!resultNome.isValido)
            {
                ExibirMensagem($"{resultNome.mensagemErro}", ConsoleColor.Red);
                nome = Console.ReadLine();
                resultNome = Validacoes.ValidarNome(nome);
            }
            return nome;
        }

        public int PedirIdadeValida()
        {
            Console.Write("Idade: ");
            int idade;
            (bool isValido, string mensagemErro) resultIdade;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.WriteLine("Idade Invalida. Digite um numero inteiro valido.");
                    ExibirMensagem("Idade Invalida. Digite um numero inteiro valido.", ConsoleColor.Red);
                    continue;
                }
                resultIdade = Validacoes.ValidarIdade(idade);
                if (!resultIdade.isValido)
                {
                    ExibirMensagem($"{resultIdade.mensagemErro}", ConsoleColor.Red);
                    continue;
                }
                break;
            }
            return idade;
        }

        public string PedirEmailValido()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            var resultEmail = Validacoes.ValidarEmail(email);
            while (!resultEmail.isValido)
            {
                ExibirMensagem($"{resultEmail.mensagemErro}", ConsoleColor.Red);
                email = Console.ReadLine();
                resultEmail = Validacoes.ValidarEmail(email);
            }
            return email;
        }

        public Guid PedirGuid(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    ExibirMensagem("Guid invalido!", ConsoleColor.Red);
                    continue;
                }
                return id;
            }
        }

        public Pessoa ColetarDadosNovaPessoa()
        {
            Console.WriteLine("Escreva as informações dessa pessoa:");
            return new Pessoa(PedirNomeValido(), PedirIdadeValida(), PedirEmailValido());
        }

        public Pessoa SelecionarPessoaDaLista(List<Pessoa> pessoas)
        {
            ExibirLista(pessoas);
            while (true)
            {
                Console.WriteLine("Escreva o numero da pessoa: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num < 1 || num > pessoas.Count)
                    {
                        ExibirMensagem("Numero invalido! Tente novamente", ConsoleColor.Red);
                        continue;
                    }
                    return pessoas[num - 1];
                }
                ExibirMensagem("Entrada invalida! Digite apenas numeros", ConsoleColor.Red);
                continue;
            }
        }
        public string BuscarNomePessoa()
        {
            while (true)
            {
                Console.WriteLine("Digite parte do nome da pessoa: ");
                string? parteNome = Console.ReadLine();
                if (string.IsNullOrEmpty(parteNome))
                {
                    ExibirMensagem("Nome não pode ser vazio!", ConsoleColor.Red);
                    continue;
                }
                return parteNome!;
            }
        }
        public bool ConfirmarAcao(string msg)
        {
            while (true)
            {
                ExibirMensagem(msg, ConsoleColor.Yellow);
                string? input = Console.ReadLine()?.ToLower();

                if (input == "s") return true;
                if (input == "n") return false;

                ExibirMensagem("Resposta invalida! Digite 's' para sim ou 'n' para não.", ConsoleColor.Red);
            }
        }
    }

}