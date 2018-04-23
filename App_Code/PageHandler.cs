using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageHandler
/// </summary>
public sealed class PageHandler
{
    public static void DisplayModal(Page page, Label label, string functionCall, string bodyText)
    {
        label.Text = bodyText;

        // This calls a Javascript function called "errorModal()."
        ScriptManager.RegisterStartupScript(page, page.GetType(), "Error", functionCall, true);
    }
}