using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;

namespace dapperblog.Models
{
    [Table("[Category]")]
    public class Category : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }        
    }
}