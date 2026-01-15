namespace UserManagement.Repositories
{
    class UserCsvRepositorie
    {
        private readonly string _filePath = @"Data\users.csv";

        public void Load()
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
                return;
            }

        }
    }
}
/*
Como pensar o Load() (fluxo mental)

Antes de escrever código, pense assim:

Fluxo correto do Load():

Verifica se o diretório Data/ existe

se não existir → cria

Verifica se o arquivo users.csv existe

se não existir → cria arquivo vazio

Lê o arquivo linha por linha

Converte cada linha em Pessoa

Retorna / popula a lista interna

👉 Perceba:

Criar diretório ≠ criar arquivo

São duas responsabilidades diferentes
*/