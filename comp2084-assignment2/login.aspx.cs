using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference ef
using comp2084_assignment2.Models;

//refencing security systems alarm - YOU SHALL NOT PASS
using System.Security.Cryptography;

namespace comp2084_assignment2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                //create user object
                Users objU = new Users();

                //get salt for username
                String username = txtUsername.Text;

                objU = (from u in db.Users1
                            where u.Username == username select u).FirstOrDefault();

                //username was found
                if (objU != null){
                    String salt = objU.Salt;

                    //salt and hash text password
                    String password = txtPassword.Text;
                    String pass_and_salt = password + salt;

                    // Create a new instance of the hash crypto service provider.
                    HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();

                    // Convert the data to hash to an array of Bytes.
                    byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(pass_and_salt);

                    // Compute the Hash. This returns an array of Bytes.
                    byte[] bytHash = hashAlg.ComputeHash(bytValue);

                    // Optionally, represent the hash value as a base64-encoded string, 
                    // For example, if you need to display the value or transmit it over a network.
                    string base64 = Convert.ToBase64String(bytHash);

                    //check if the password is correct
                    if (objU.Password == base64)
                    {
                        //store id in session object
                        Session["UserID"] = objU.UserID;
                        Session["UserName"] = objU.Firstname + " " + objU.Lastname;

                        //redirect to their comic page
                        Response.Redirect("comics.aspx");
                    }
                    else
                    {
                        lblError.Text = "Invalid Login";
                    }
                }
                else
                {
                    lblError.Text = "Invalid Login";
                }
                }
            }
        }
    }