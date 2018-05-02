using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class classview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // TODO Consolidate these lines to a single function across all of the "members only" pages.
        if (Session[Constants.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {

        }
    }
}