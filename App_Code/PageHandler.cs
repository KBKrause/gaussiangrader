using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// PageHandler acts like a controller, which connects the C# code to the Javascript to render the page.
/// </summary>
public sealed class PageHandler
{
    public static void DisplayModal(Page page, Label label, string functionCall, string bodyText)
    {
        label.Text = bodyText;

        ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", functionCall, true);
    }

    public static void SetClassList(Page page)
    {
        ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", "setClassList('helloWorld')", true);
    }
}