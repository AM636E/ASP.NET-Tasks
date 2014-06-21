using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TodoList
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private DataAccess.UserRepository _repostory;

        protected void Page_Init()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repostory = new DataAccess.UserRepository(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsAuthenticated())
            {
                this.btnLogout.Visible = true;
                this.lblFirstname.Text = "Hello, " + _repostory.GetFirstName(Page.User.Identity.Name);
                this.btnRegister.Visible = false;
            }
        }

        protected void odsTask_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            e.ObjectInstance = new DataAccess.TaskRepository(connectionString);
        }

        protected void odsUser_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            e.ObjectInstance = new DataAccess.UserRepository(connectionString);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
          
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            
        }

        private bool IsAuthenticated()
        {
            return Page.User != null && Page.User.Identity != null && Page.User.Identity.IsAuthenticated;
        }
    }
}