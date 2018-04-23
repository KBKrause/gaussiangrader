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
            labelErrorModalText.Text = "You did not fill in 1 or more fields.";

            // This calls a Javascript function called "errorModal()."
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "errorModal();", true);
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
                labelErrorModalText.Text = "This email already exists in our database.";

                // This calls a Javascript function called "errorModal()."
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "errorModal();", true);
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
}