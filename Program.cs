using Microsoft.Data.SqlClient;
using dapperblog.Models;
using dapperblog.Repositories;
using dapperblog.repositories;

internal class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=blog;User Id=sa;Password=Testing123;TrustServerCertificate=True";
    private static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        // ReadUsers(connection);
        // ReadRoles(connection);     
        CreateUsers(connection);           
        // DeleteRole(connection, 1);
        connection.Close();
    }

     public static void DeleteRole(SqlConnection connection, int id)
    {
        var repository = new Repository<Role>(connection);
        repository.Delete(id); 
        Console.WriteLine("Usuario deletado");      
      
    }
    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.Get();        

        foreach (var item in items)                    
            Console.WriteLine(item.Name);       
    }

    public static void CreateUsers(SqlConnection connection)
    {
        var user = new User()
        {
            Email = "teste@email.com",
            Bio = "Biografia",
            Image = "img Teste",
            Name = "Nome teste",
            PasswordHash = "HASH256",
            Slug = "teste slug"
        };
        var repository = new Repository<User>(connection);
        repository.Create(user);      
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var items = repository.Get();        

        foreach (var item in items)                    
            Console.WriteLine(item.Name);       
    }  

    public static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
}