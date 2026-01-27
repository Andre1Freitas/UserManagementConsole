using System.Text.Json.Serialization;

namespace UserManagementConsole.Entities
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public Guid Id { get; private set; }

        public Pessoa(string nome, int idade, string email)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            Id = Guid.NewGuid();
        }
        [JsonConstructor]
        public Pessoa(Guid id, string nome, int idade, string email)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Email = email;
        }

        public override string ToString()
        {
            return Nome
                + " "
                + Idade
                + " "
                + Email
                + " "
                + Id;
        }
    }
}
