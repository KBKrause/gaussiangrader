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

        ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", functionCall, true);
    }

    public static void CallJavascript(Page page, string functionCall)
    {
        ScriptManager.RegisterStartupScript(page, page.GetType(), "", functionCall, true);
    }
}