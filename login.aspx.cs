using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

// TODO Validation not displaying errors.

// URGENT TODO Fix DatabaseManager class to prevent sql injection.

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
                DatabaseManager.InsertInstructor(txt_email.Text, txt_first.Text, txt_last.Text, Hasher.HashString(txt_password.Text.Trim()));

                labelSuccessModal.Text = "Your account has been created! Please login to get started.";

                // This calls a Javascript function called "errorModal()."
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "successModal();", true);
            }
        }
    }

    private bool ValidateCredentials(string userName, string password)
    {
        bool returnValue = false;

        // TODO Allow @ and . only with alphanumeric
        if (userName.Length <= 50 && password.Length <= 50)
        {
            SqlConnection conn = null;

            try
            {
                string sql = "select count(*) from Instructors where id = @username and pwd = @password";

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlParameter user = new SqlParameter();
                user.ParameterName = "@username";
                user.Value = userName.Trim();
                cmd.Parameters.Add(user);

                SqlParameter pass = new SqlParameter();
                pass.ParameterName = "@password";
                pass.Value = Hasher.HashString(password.Trim());
                cmd.Parameters.Add(pass);

                System.Diagnostics.Debug.Print("hashed pwd: " + pass.Value.ToString());

                conn.Open();

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    Session[Constants.EMAIL] = userName;
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                // exception logging here
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
        else
        {
            // Log error - user name not alpha-numeric or 
            // username or password exceed the length limit!
        }

        return returnValue;
    }

    protected void Loginbtn_Click(object sender, EventArgs e)
    {
        bool authenticated = this.ValidateCredentials(loginUser.Text, loginPass.Text);

        if (authenticated)
        {
            Session[Constants.USERNAME] = "logged in";
            Server.Transfer("~/hub.aspx", true);
        }
        else
        {
            System.Diagnostics.Debug.Print("Did not validate credentials");
        }
    }
}