using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ef reference
using comp2084_assignment2.Models;

namespace comp2084_assignment2
{
    public partial class authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate grid
            if (!IsPostBack)
            {
                GetAuthors();
            }
        }
        protected void GetAuthors()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var track = from t in db.Comics1
                            select t;
                //bind to grid
                grdAuthors.DataSource = track.ToList();
                grdAuthors.DataBind();
            }
        }
    }
}