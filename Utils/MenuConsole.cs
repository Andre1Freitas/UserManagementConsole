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
            return int.Parse(Console.ReadLine()!);
        }

        public void ExibirLista(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada");
                return;
            }
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pessoas[i].Nome} ({pessoas[i].Email})");
            }
        }

        public void ExibirMensagem(string msg)
        {
            Console.WriteLine(msg);
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
                Console.WriteLine(resultNome.mensagemErro);
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
            return idade;
        }

        public string PedirEmailValido()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            var resultEmail = Validacoes.ValidarEmail(email);
            while (!resultEmail.isValido)
            {
                Console.WriteLine(resultEmail.mensagemErro);
                email = Console.ReadLine();
                resultEmail = Validacoes.ValidarEmail(email);
            }
            return email;
        }

        public Guid PedirGuid(string mensagem)
        {
            Console.Write(mensagem);
            return Guid.Parse(Console.ReadLine());
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
                int num = int.Parse(Console.ReadLine());
                if (num < 1 || num > pessoas.Count)
                {
                    Console.WriteLine("Numero invalido! Tente novamente");
                    continue;
                }
                return pessoas[num - 1];
            }
        }
        public bool ConfirmarAcao(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string? input = Console.ReadLine()?.ToLower();

                if (input == "s") return true;
                if (input == "n") return false;

                Console.WriteLine("Resposta invalida! Digite 's' para sim ou 'n' para não.");
            }
        }
    }
}