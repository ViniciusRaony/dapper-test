using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;

namespace dapperblog.Models
{
    [Table("[User]")] // Por padrão o dapper pluraliza e tenta buscar por Users, por isso necessita criar a Notificação de Table
    public class User : IModel
    {
        public User()
            => Roles = new List<Role>();
        
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)] // Não escrever no insert
        public List<Role> Roles { get; set; }

    }
    
}