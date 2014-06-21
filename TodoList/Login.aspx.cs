using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;

namespace TodoList
{
    public partial class Login : System.Web.UI.Page
    {
        private DataAccess.UserRepository _repository;

        protected void Page_Init()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repository = new DataAccess.UserRepository(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            DataAccess.UserRepository repo = new DataAccess.UserRepository(connectionString);

            if(repo.DoesUserExists(this.txtLogin.Text, this.txtPassword.Text))
            {
                var roles = GetUserRoles(this.txtLogin.Text);                
                GenericIdentity identity = new System.Security.Principal.GenericIdentity(this.txtLogin.Text);
                GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, roles);
                HttpContext.Current.User = principal;
                FormsAuthentication.SetAuthCookie(this.txtLogin.Text, false);

                Response.Redirect("~/Tasks.aspx");
            }
            else
            {
                this.lblStatus.Text = String.Format("User with username {0} and password provided does not exists", this.txtLogin.Text);
            }
        }

        private string[] GetUserRoles(string username)
        {
            Entities.User user = _repository.GetByLogin(username);
            List<string> roles = new List<string>();

            if(user.Disabled == false)
            {
                roles.Add("user");

                if(user.IsAdmin)
                {
                    roles.Add("admin");
                }
            }

            return roles.ToArray();
        }
    }
}