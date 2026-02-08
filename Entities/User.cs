using System.Text.Json.Serialization;

namespace UserManagementConsole.Entities
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Guid Id { get; private set; }

        public User(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
            Id = Guid.NewGuid();
        }
        [JsonConstructor]
        public User(Guid id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }

        public void Update(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public override string ToString()
        {
            return Name
                + " "
                + Age
                + " "
                + Email
                + " "
                + Id;
        }
    }
}
