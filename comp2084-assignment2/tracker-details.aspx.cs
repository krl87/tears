using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//referencing ef models
using comp2084_assignment2.Models;

namespace comp2084_assignment2
{
    public partial class tracker_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ComicID"]))
                {
                    GetComic();
                }
            }
        }

        protected void GetComic()
        {
            //look up comic and fill
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 ComicID = Convert.ToInt32(Request.QueryString["ComicID"]);

                //look up comic
                Comics trac = (from c in db.Comics1
                               where c.ComicID == ComicID
                               select c).FirstOrDefault();

                txtTitle.Text = trac.Title;
                txtAuthor.Text = trac.Author;
                txtPublisher.Text = trac.Issue.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
         //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                Comics trac = new Comics();

                Int32 ComicID = 0;

                //check for url
                if (!String.IsNullOrEmpty(Request.QueryString["ComicID"]))
                {
                    //get id from url
                     ComicID = Convert.ToInt32(Request.QueryString["ComicID"]);

                    trac = (from c in db.Comics1
                            where c.ComicID == ComicID
                            select c).FirstOrDefault();
                }

                //fill properties
                trac.Title = txtTitle.Text;
                trac.Author = txtAuthor.Text;
                trac.Publisher = txtPublisher.Text;
                trac.Issue = Convert.ToInt32(txtIssue.Text);

                //no id in the url
                if (ComicID == 0)
                {
                    db.Comics1.Add(trac);
                }
              
                //save
                db.SaveChanges();

                //redirect
                Response.Redirect("tracker.aspx");
            }
        }
    }
}