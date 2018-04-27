using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberPages_hub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            string FK_instructor = "'" + (string)Session[Constants.EMAIL] + "'";
            DatabaseManager db = new DatabaseManager("SELECT * FROM Classes WHERE FK_instructorID = " + FK_instructor);

            db.Reader.Read();
            
            if (db.Reader.HasRows == false)
            {
                PageHandler.CallJavascript(this, "setElementText(You have no classes.)");
            }
            else
            {
                PageHandler.CallJavascript(this, "setElementText(You have some classes ...)");
            }
        }
    }
}