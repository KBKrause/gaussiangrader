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

        string allTheFuncs = "setClassList(" + instructorID + "); ";
        //ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", func, true);

        foreach (string itr in arrClassNames)
        {
            // TODO It's a bad idea to have this very specfic JS function being called from this class.
            string elem = "'" + itr + "'";
            // TODO add the course code here, then modify the JS function to add this to the GET request so we can insert properly into tables.
            string appendFunc = "appendTextToList(" + elem + "); ";
            allTheFuncs += appendFunc;
        }

        ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", allTheFuncs, true);
        //ScriptManager.RegisterStartupScript(page, page.GetType(), "Modal", "<script>" + allTheFuncs + "</script>", false);
        //ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "Modal", allTheFuncs, true);
    }
}