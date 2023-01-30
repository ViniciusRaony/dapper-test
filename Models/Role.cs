using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;

namespace dapperblog.Models
{
    [Table("[Role]")]
    public class Role : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}