using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace TodoList
{
    public partial class EditTask : System.Web.UI.Page
    {
        private TaskRepository _repository;

        protected void Page_Init(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repository = new TaskRepository(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["taskId"] == null)
            {
                throw new Exception("Task id is not specified");
            }

            Entities.Task task = _repository.GetById(Convert.ToInt32(Request["taskId"]));
            this.txtTaskText.Text = task.Text;
            this.txtTaskTitle.Text = task.Title;
        }

        protected void fvEditTask_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {

        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int taskId = Convert.ToInt32(Request["taskId"]);
            Entities.Task task = _repository.GetById(taskId);
            task.Created = DateTime.Now;

            if(this.txtTaskTitle.Text.Length == 0)
            {
                throw new ArgumentException("Enter task title");
            }
            task.Title = this.txtTaskTitle.Text;
            task.Text = this.txtTaskText.Text;

            _repository.UpdateTask(task);

            Response.Redirect("ShowTask.aspx?taskId=" + taskId);
        }
    }
}