using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;

namespace dapperblog.Models
{   
    [Table("[Post]")]
    public class Post : IModel // 1 CATEGORIA TEM N POSTS / 1 POST NAO TEM N CATEGORIAS
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int CategoryId { get; set; } // Tem uma referência de Id
    }
    
}