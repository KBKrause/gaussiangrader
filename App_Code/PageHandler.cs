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

    public static void SetClassList(Page page, string instructorID)
    {
        instructorID = "'" + instructorID + "'";

        DatabaseManager db = new DatabaseManager("SELECT courseCode, title FROM Classes WHERE FK_instructorId = " + instructorID);

        List<string> classNames = new List<string>();
        List<string> classCodes = new List<string>();

        while (db.Reader.Read())
        {
            classCodes.Add(db.Reader.GetString(0));
            classNames.Add(db.Reader.GetString(1));
        }

        string[] arrClassNames = classNames.ToArray();
        string[] arrClassCodes = classCodes.ToArray();



        string func = "setClassList(" + instructorID + ")";
        ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", func, true);
    }
}