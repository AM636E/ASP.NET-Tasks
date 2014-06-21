using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

namespace TodoList
{
    public class Global : System.Web.HttpApplication
    {
        private DataAccess.UserRepository _repository;
        protected void Application_Start(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repository = new DataAccess.UserRepository(connectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (User != null)
            {
                var username = User.Identity.Name;
                var roles = GetUserRoles(username);
                GenericIdentity identity = new System.Security.Principal.GenericIdentity(username);
                GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, roles);
                HttpContext.Current.User = principal;
                FormsAuthentication.SetAuthCookie(username, false);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private string[] GetUserRoles(string username)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            _repository = new DataAccess.UserRepository(connectionString);
            Entities.User user = _repository.GetByLogin(username);
            List<string> roles = new List<string>();

            if (user.Disabled == false)
            {
                roles.Add("user");

                if (user.IsAdmin)
                {
                    roles.Add("admin");
                }
            }

            return roles.ToArray();
        }
    }
}