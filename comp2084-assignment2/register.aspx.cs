using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//referencing ef models
using comp2084_assignment2.Models;

//refencing security systems alarm - YOU SHALL NOT PASS
using System.Security.Cryptography;

namespace comp2084_assignment2
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //connect to db
            using (DefaultConnection db = new DefaultConnection())
            {
                //create new user
                Users objU = new Users();

                //fill the form inputs
                objU.Firstname = txtFirstname.Text;
                objU.Lastname = txtLastname.Text;
                objU.Username = txtUsername.Text;

                //salt and hash text password
                String password = txtPassword.Text;
                String salt = CreateSalt(8);
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

                objU.Password = base64;
                objU.Salt = salt;

                //save
                db.Users1.Add(objU);
                db.SaveChanges();
            }
        }
    }
}