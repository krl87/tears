﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference ef
using comp2084_assignment2.Models;

namespace comp2084_assignment2
{
    public partial class publishers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate grid
            if (!IsPostBack)
            {
                GetPublishers();
            }
        }

        protected void GetPublishers(){
            //get list of comics
            using (DefaultConnection db = new DefaultConnection())
            {
                var track = from t in db.Comics1
                            select t;

                //bind to the grid
                grdPublishers.DataSource = track.ToList();
                grdPublishers.DataBind();
            }
        }
    }
}