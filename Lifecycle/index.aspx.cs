using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lifecycle
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
          //  txtLifeLog.Text += "Page PreInit\n";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
           /* txtLifeLog.Text += "Page Init\n";
            var txt = new TextBox();
            txt.Attributes.Add("ID", "test");
            txt.Attributes.Add("runat", "server");
            this.form1.Controls.Add(txt);
            this.ViewState["test"] = 3;*/
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
           // txtLifeLog.Text += "Page InitComplete\n";
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
           /* txtLifeLog.Text += "Page PreLoad\n";
            if (this.IsPostBack)
            {
                txtLifeLog.Text += " ... Againe\n";
            }*/
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           /*a txtLifeLog.Text += "Page Load\n";
            if (this.IsPostBack)
            {
                txtLifeLog.Text += " ... Againe\n";
            }*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var a;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
          /*  txtLifeLog.Text += "Page Load\n";
             if (this.IsPostBack)
             {
                 txtLifeLog.Text += " ... Againe\n";
             }*/
        }

        protected void Page_PreRender()
        {
           // var a 
        }

        protected void Page_PreRenderComplete()
        {
            // var a 
        }

        protected void Page_SaveStateComplete() { }
        protected void Page_Unload() { }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}