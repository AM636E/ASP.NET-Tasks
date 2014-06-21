using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
namespace TodoList
{
    public partial class Tasks : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Warn("hello");
        }

        protected void gvTask_Sorting(object sender, GridViewSortEventArgs e)
        {
            var grid = (GridView)sender;
            var tasks = (IEnumerable<Entities.Task>)grid.DataSource;

            if (e.SortDirection == SortDirection.Ascending)
            {
                tasks = tasks.OrderBy(s =>
                {
                    return s.Id;
                }
                    );
            }
            else
            {
                tasks = tasks.OrderByDescending(s => s.Id);
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static Entities.Task GetTask(int taskId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            TaskRepository repository = new TaskRepository(connectionString);
            UserRepository uRepo = new UserRepository(connectionString);
            var task = repository.GetById(taskId);
            //var user = uRepo.GetById(task.User_Id);
            //task.User = user;
            //return new Entities.Task() { Id = taskId, Created = DateTime.Now, Title = "Lorem ipsum", Text = "Dolore sit amet", User = new Entities.User() { Id = 1, Login = "User" } };
            return task;
        }
    }
}