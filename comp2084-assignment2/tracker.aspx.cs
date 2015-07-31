using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference ef 
using comp2084_assignment2.Models;

namespace comp2084_assignment2
{
    public partial class tracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate grid
            if (!IsPostBack)
            {
                GetComics();
            }
        }

        protected void GetComics()
        {
            //list comics for user
            using (DefaultConnection db = new DefaultConnection())
            {
                var track = from t in db.Comics1
                            select t;
                
                //bind to grid
                grdComics.DataSource = track.ToList();
                grdComics.DataBind();
            }
        }
        protected void grdComics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set new page and populate grid
            grdComics.PageIndex = e.NewPageIndex;
            GetComics();
        }
        
        protected void grdComics_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //identify
            Int32 ComicID = Convert.ToInt32(grdComics.DataKeys[e.RowIndex].Values["ComicID"]);

            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                Comics track = (from c in db.Comics1
                                where c.ComicID == ComicID
                                select c).FirstOrDefault();

                //delete
                db.Comics1.Remove(track);
                db.SaveChanges();

                //refresh grid
                GetComics();
            }
        }
    }
}