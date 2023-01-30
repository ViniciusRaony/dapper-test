using Dapper.Contrib.Extensions;
using dapperblog.Interfaces;
using Microsoft.Data.SqlClient;

namespace dapperblog.Repositories
{
    public class Repository<TModel> where TModel : class, IModel// É uma classe do tipo genérico, ele vai criar em tempo de execução. O Where especifica para não ficar tão aberto o type.
    {
        private readonly SqlConnection _connection; // readonly, nao alterar

        public Repository(SqlConnection connection)
            => _connection = connection;
        
        public IEnumerable<TModel> Get()            
            => _connection.GetAll<TModel>();         
        public TModel Get(int id)  
            => _connection.Get<TModel>(id);   
        public void Create(TModel model)
            => _connection.Insert<TModel>(model);

        public void Update(TModel model)
        {
            if (model.Id != 0)
                _connection.Update<TModel>(model); 
        }
        public void Delete(TModel model)
        {
            if (model.Id != 0)
                _connection.Delete<TModel>(model); 
        }
        public void Delete(int id)
        {            
            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model); 
        }    
    }  
}