using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;

namespace dapperblog.Models
{
    [Table("[Tag]")]
    public class Tag : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}