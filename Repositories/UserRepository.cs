using dapperblog.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace dapperblog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection; // readonly, nao alterar

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id); // Verificando se usuário existe
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }
        // private readonly SqlConnection _connection; // readonly, nao alterar

        // public UserRepository(SqlConnection connection)
        //     => _connection = connection;
        
        // public IEnumerable<User> Get()            
        //     => _connection.GetAll<User>();         

        // public User Get(int id)  
        //     => _connection.Get<User>(id);   
        // public void Create(User user)
        // {
        //     user.Id = 0;
        //     _connection.Insert<User>(user);  
        // }
            
        // public void Update(User user)
        // {
        //     if (user.Id != 0)
        //         _connection.Update<User>(user); 
        // }
        // public void Delete(User user)
        // {
        //     if (user.Id != 0)
        //         _connection.Delete<User>(user); 
        // }

        // public void Delete(int id)
        // {
        //     if (id != 0)
        //         return;
            
        //     var user = _connection.Get<User>(id);
        //     _connection.Insert<User>(user); 
        // }          

    }    
}