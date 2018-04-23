using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    // TODO
    // Create a class that handles all of the login fails / signup fails with the modal.
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Click_signUpSubmit(object sender, EventArgs e)
    {
        //System.Diagnostics.Debug.Print("retval");

        // Check the textboxes first
        if (txt_password.Text != txt_confirmPassword.Text)
        {
            // TODO set some mini debug thing to show that they don't match.
            System.Diagnostics.Debug.Print("pwds don't match!");
        }
        else if ((txt_first.Text == "") || (txt_last.Text == "") || (txt_email.Text == "") || (txt_password.Text == "") || (txt_confirmPassword.Text == ""))
        {
            PageHandler.DisplayModal(this, labelErrorModalText, "errorModal();", "You did not fill in 1 or more fields.");
        }
        else
        {
            System.Diagnostics.Debug.Print("pwds match!");

            // Surround the text with apostrophes so SQL uses this as a row value instead of a column name.
            // See below for the full query.
            string email = "'" + txt_email.Text + "'";

            // Be careful when using SELECT / FROM / WHERE / =. The strings must be an exact match as they are represented in the db.
            DatabaseManager db = new DatabaseManager("SELECT * FROM Instructors WHERE Id = " + email);

            // db.Reader.Read() advances through the selected rows, if any were found.

            // If this email already exists, do not proceed.
            if (db.Reader.HasRows)
            {
                PageHandler.DisplayModal(this, labelErrorModalText, "errorModal();", "This email already exists in our database.");
            }
            // If this email doesn't exist, check the other fields to make sure they're good.
            // If they are good, insert into db.
            else
            {
                DatabaseManager.InsertInstructor(txt_email.Text, txt_first.Text, txt_last.Text, txt_password.Text);

                labelSuccessModal.Text = "Your account has been created! Please login to get started.";
                
                // This calls a Javascript function called "errorModal()."
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "successModal();", true);
            }
        }
    }

    protected void Click_login(object sender, EventArgs e)
    {
        // TODO Rename the username box to email / id.
        if ((textUserName.Text == "") || (textPassword.Text == ""))
        {
            PageHandler.DisplayModal(this, labelErrorModalText, "errorModal();", "Please fill in both the username and password fields.");
        }
        else
        {
            DatabaseManager db = new DatabaseManager("SELECT * FROM Instructors WHERE Id = '" + textUserName.Text + "' AND pwd = '" + textPassword.Text + "'");

            // If no record found, error.
            if (db.Reader.HasRows == false)
            {
                PageHandler.DisplayModal(this, labelErrorModalText, "errorModal();", "Login failed.");
            }
            else
            {
                // Do a page redirect after acquiring user info.
                Session["username"] = db.Reader.GetValue(1) + " " + db.Reader.GetValue(2);
                Session["email"] = textUserName;

                System.Diagnostics.Debug.Print("Username found is " + (string)Session["username"]);
            }
        }
    }
}