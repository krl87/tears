using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comp2084_assignment2
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //kill session
            Session["UserID"] = null;
            Session.Abandon();

            //redirect
            Response.Redirect("login.aspx");
        }
    }
}