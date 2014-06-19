using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccess;
using Newtonsoft.Json;

namespace TodoList
{
    /// <summary>
    /// Summary description for AjaxService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AjaxService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "hello, world";
        }

        [WebMethod]
        public string GetTasks()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;

            var repo = new TaskRepository(connectionString);

            return JsonConvert.SerializeObject(new Entities.Task());
        }

        [WebMethod]
        public string GetTask(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;

            var repo = new TaskRepository(connectionString);

            return JsonConvert.SerializeObject(repo.GetById(id));
        }
    }
}
