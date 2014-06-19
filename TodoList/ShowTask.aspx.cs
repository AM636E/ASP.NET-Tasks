using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace TodoList
{
    public partial class ShowTask : System.Web.UI.Page
    {
        private TaskRepository _repository;

        protected void Page_Init(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repository = new TaskRepository(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["taskId"] == null)
            {
                throw new Exception();
            }

            Entities.Task task = _repository.GetById(Convert.ToInt32(Request["taskId"]));

            this.lblTaskTitle.Text = task.Title;
            this.lblTaskBody.Text = task.Text;
        }
    }
}