using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace DevProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            Console.WriteLine(connectionString);

            try
            {

                UserRepository repository = new UserRepository(connectionString);

                var users = repository.GetAll();

                foreach(var user in users)
                {
                    Console.WriteLine("{0} {1}", user.Login, user.Email);
                }
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
