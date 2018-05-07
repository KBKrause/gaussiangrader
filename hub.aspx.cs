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

            PageHandler.SetClassList(this, (string)Session[Constants.EMAIL]);
        }
    }

    // TODO Re-add validation
    protected void Click_addClass(object sender, EventArgs e)
    {
        DatabaseManager.InsertClass(txt_class_title.Text, txt_class_code.Text, (string)Session[Constants.EMAIL]);
    }

    protected void Click_addAssignment(object sender, EventArgs e)
    {
        DatabaseManager.InsertAssignment(txt_hw_name.Text, Int32.Parse(txt_hw_points.Text), txt_hw_coursecode.Text);
    }

    protected void Click_addStudent(object sender, EventArgs e)
    {
        DatabaseManager.InsertStudent(txt_stuFirst.Text, txt_stuLast.Text);
    }
}