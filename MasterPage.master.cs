using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.USERNAME] != null)
        {
            string email = "'" + (string)Session[Constants.EMAIL] + "'";

            // Be careful when using SELECT / FROM / WHERE / =. The strings must be an exact match as they are represented in the db.
            DatabaseManager db = new DatabaseManager("SELECT * FROM Instructors WHERE Id = " + email);

            db.Reader.Read();

            labellogin.Text = "Wecome, " + db.Reader.GetString(1) + " " + db.Reader.GetString(2) + "!";
            btnloginout.Text = "Logout";
            btnloginout.Click += new EventHandler(Click_logout);
        }
        else
        {
            labellogin.Text = "You are not signed in.";
        }
    }

    protected void Click_logout(object sender, EventArgs e)
    {
        Session[Constants.USERNAME] = null;
        Session[Constants.EMAIL] = null;

        labellogin.Text = "You are not signed in.";
        btnloginout.Text = "Login";
        Response.Redirect("~/login.aspx");
    }
}
