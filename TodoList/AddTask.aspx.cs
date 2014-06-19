using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addTaskFrom_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Server.Transfer("Tasks.aspx");
        }
    }
}