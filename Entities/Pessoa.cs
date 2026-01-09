namespace UserManagementConsole.Entities
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }

        public Pessoa(string nome, int idade, string email)
        {
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
                + Email;
        }
    }
}
