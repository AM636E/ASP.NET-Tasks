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
                TaskRepository tr = new TaskRepository(connectionString);

                var tasks = tr.GetAll();

                foreach (var task in tasks)
                {
                    Console.WriteLine(task.Text);
                  
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
