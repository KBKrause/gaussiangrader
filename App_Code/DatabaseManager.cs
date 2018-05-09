using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// The DatabaseManager class handles and encapsulates the SQL logic to access the application's database.
/// TODO: Fix this class so it can handle multiple queries.
/// </summary>
public sealed class DatabaseManager
{
    private string queryText;

    // This syntax declares a private SqlDataReader called reader.
    // Below is a public "accessor," which provides a convenient way to make get and set methods.
    // This allows users to use the reader variable without changing it.
    // An alternative approach (like in Java) would be creating a public get method and a private set method.
    private SqlDataReader reader;
    public SqlDataReader Reader
    {
        get
        {
            return reader;
        }
        private set
        {
            reader = value;
        }
    }

    public DatabaseManager(string queryText)
    {
        this.queryText = queryText;

        // This gets the connection string value from Web.Config using "GradebookConnectionString" as the name of the connection string.
        // In the SqlConnection constructor below, it is looking for the long, complicated string, not "GradebookConnectionString" (which acts
        //      like a reference.
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString;

        SqlConnection sqlConnection = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        // TODO Probably should validate the text first. Prevent SQL injection attacks (eg. drop table).
        // Set the SQL query equal to the parameter of the constructor.
        cmd.CommandText = queryText;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection;

        sqlConnection.Open();

        // Execute reader performs the query. Now we can reference the reader object of this class publically but without changing its value.
        reader = cmd.ExecuteReader();
        this.reader = reader;
    }

    // TODO Fix sql injection.
    // TODO error codes.
    public static void InsertInstructor(string id, string first, string last, string pwd)
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString;

        System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connString);

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;

        string valuesString = "('" + id + "', '" + first + "', '" + last + "', '" + pwd + "')";
        System.Diagnostics.Debug.Print("valuesString: " + valuesString);

        cmd.CommandText = "INSERT Instructors (Id, first, last, pwd) VALUES " + valuesString;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }

    // TODO Add error codes for : copy of primary key
    public static void InsertClass(string className, string courseCode, string instructorID)
    {
        string sql = "INSERT Classes (courseCode, title, FK_instructorId) VALUES (@courseCode, @title, @FK_instructorId)";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.Add(AddStringParameter("courseCode", courseCode));
        cmd.Parameters.Add(AddStringParameter("title", className));
        cmd.Parameters.Add(AddStringParameter("FK_instructorId", instructorID));

        conn.Open();

        cmd.ExecuteNonQuery();
        conn.Close();

        System.Diagnostics.Debug.Print("Attempted to insert class");
    }

    // TODO Ensure this inserts
    public static void InsertAssignment(string name, int points, string courseCode)
    {
        string sql = "INSERT Assignments (name, totalPoints, FK_courseCode) VALUES (@name, @totalPoints, @FK_courseCode)";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.Add(AddStringParameter("name", name));

        SqlParameter param = new SqlParameter();
        param.ParameterName = "totalPoints";
        param.Value = points;

        cmd.Parameters.Add(param);
        cmd.Parameters.Add(AddStringParameter("FK_courseCode", courseCode));

        conn.Open();

        cmd.ExecuteNonQuery();
        conn.Close();

        System.Diagnostics.Debug.Print("Attempted to insert assignment");
    }

    public static void InsertStudent(string first, string last)
    {
        string sql = "INSERT Students (first, last) VALUES (@first, @last)";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.Add(AddStringParameter("first", first));
        cmd.Parameters.Add(AddStringParameter("last", last));

        conn.Open();

        cmd.ExecuteNonQuery();
        conn.Close();

        System.Diagnostics.Debug.Print("Attempted to insert student");
    }

    public static void InsertStudentIntoClass(string courseCode, int studentID)
    {
        string sql = "INSERT StudentsAndClasses (studentId, classcourseCode) VALUES (@studentId, @classcourseCode)";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.Add(AddStringParameter("classcourseCode", courseCode));

        SqlParameter param = new SqlParameter();
        param.ParameterName = "studentID";
        param.Value = studentID;
        cmd.Parameters.Add(param);

        conn.Open();

        cmd.ExecuteNonQuery();
        conn.Close();

        System.Diagnostics.Debug.Print("Attempted to insert student for class ");
    }

    public static void InsertStudentScore(int studentID, int assignID, int scoresRcd)
    {
        string sql = "INSERT StudentsAndAssignments (studentId, assignmentId, pointsRecd) VALUES (@studentId, @assignmentId, @pointsRecd)";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        SqlParameter param = new SqlParameter();
        param.ParameterName = "studentId";
        param.Value = studentID;
        cmd.Parameters.Add(param);

        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "assignmentId";
        param2.Value = assignID;
        cmd.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter();
        param3.ParameterName = "pointsRecd";
        param3.Value = scoresRcd;
        cmd.Parameters.Add(param3);

        conn.Open();

        cmd.ExecuteNonQuery();
        conn.Close();

        System.Diagnostics.Debug.Print("Attempted to insert student grade");
    }

    private static SqlParameter AddStringParameter(string parameterName, string value)
    {
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@" + parameterName;
        param.Value = value.Trim();

        return param;
    }

    ~DatabaseManager()
    {
        // Close the connection when this object is being gc'd.
        if (this.reader.IsClosed == false)
        {
            this.reader.Close();
        }

        System.Diagnostics.Debug.Print("DB conn closed");
    }
}
 