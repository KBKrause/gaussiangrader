using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class classview : System.Web.UI.Page
{
    public static string loadedString {get; set;}

    protected void Page_Load(object sender, EventArgs e)
    {
        // TODO Consolidate these lines to a single function across all of the "members only" pages.
        if (Session[Constants.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            SQLAssignSource.SelectCommand = "SELECT name, totalPoints FROM Assignments, Classes WHERE Assignments.FK_courseCode = Classes.courseCode AND Classes.title = @classTitle";
            SQLAssignSource.SelectParameters.Clear();
            SQLAssignSource.SelectParameters.Add("classTitle", Constants.CURR_CLASS);

            SQLStudentRoster.SelectCommand = "SELECT Students.Id, Students.first, Students.last FROM Classes, Students, StudentsAndClasses WHERE StudentsAndClasses.classcourseCode = Classes.courseCode AND StudentsAndClasses.studentId = Students.Id AND Classes.title = @title";
            SQLStudentRoster.SelectParameters.Clear();
            SQLStudentRoster.SelectParameters.Add("title", Constants.CURR_CLASS);

            classNameLabel.Text = Constants.CURR_CLASS;
            studentsGridLabel.Text = Constants.CURR_CLASS;
        }
    }

    public void setString(string str)
    {
        loadedString = str;
    }

    protected void InsertStudentInClass(object sender, EventArgs e)
    {
        DatabaseManager.InsertStudentIntoClass(txt_courseCode.Text, Int32.Parse(txt_studentID.Text));
    }

    protected void InsertStudentScore(object sender, EventArgs e)
    {
        DatabaseManager.InsertStudentScore(Int32.Parse(txt_stuas_stu.Text), Int32.Parse(txt_stuas_assign.Text), Int32.Parse(txt_stuas_pts.Text));
    }
}