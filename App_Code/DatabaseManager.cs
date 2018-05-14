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
    private struct SQLAbstraction
    {
        public string sql;
        public SqlConnection conn;
        public SqlCommand cmd;
    };

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
        string sql = "INSERT Instructors (Id, first, last, pwd) VALUES (@Id, @first, @last, @pwd)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddStringParameter("Id", id));
        abs.cmd.Parameters.Add(AddStringParameter("first", first));
        abs.cmd.Parameters.Add(AddStringParameter("last", last));
        abs.cmd.Parameters.Add(AddStringParameter("pwd", pwd));

        ExecuteNonquery(ref abs);
    }

    // TODO Add error codes for : copy of primary key
    public static void InsertClass(string className, string courseCode, string instructorID)
    {
        string sql = "INSERT Classes (courseCode, title, FK_instructorId) VALUES (@courseCode, @title, @FK_instructorId)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddStringParameter("courseCode", courseCode));
        abs.cmd.Parameters.Add(AddStringParameter("title", className));
        abs.cmd.Parameters.Add(AddStringParameter("FK_instructorId", instructorID));

        ExecuteNonquery(ref abs);

        System.Diagnostics.Debug.Print("Attempted to insert class");
    }

    public static void InsertAssignment(string name, int points, string courseCode)
    {
        string sql = "INSERT Assignments (name, totalPoints, FK_courseCode) VALUES (@name, @totalPoints, @FK_courseCode)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddStringParameter("name", name));
        abs.cmd.Parameters.Add(AddIntParameter("totalPoints", points));
        abs.cmd.Parameters.Add(AddStringParameter("FK_courseCode", courseCode));

        ExecuteNonquery(ref abs);

        System.Diagnostics.Debug.Print("Attempted to insert assignment");
    }

    public static void InsertStudent(string first, string last)
    {
        string sql = "INSERT Students (first, last) VALUES (@first, @last)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddStringParameter("first", first));
        abs.cmd.Parameters.Add(AddStringParameter("last", last));

        ExecuteNonquery(ref abs);

        System.Diagnostics.Debug.Print("Attempted to insert student");
    }

    public static void InsertStudentIntoClass(string courseCode, int studentID)
    {
        string sql = "INSERT StudentsAndClasses (studentId, classcourseCode) VALUES (@studentId, @classcourseCode)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddStringParameter("classcourseCode", courseCode));
        abs.cmd.Parameters.Add(AddIntParameter("studentId", studentID));

        ExecuteNonquery(ref abs);

        System.Diagnostics.Debug.Print("Attempted to insert student for class ");
    }

    public static void InsertStudentScore(int studentID, int assignID, int scoresRcd)
    {
        string sql = "INSERT StudentsAndAssignments (studentId, assignmentId, pointsRecd) VALUES (@studentId, @assignmentId, @pointsRecd)";

        SQLAbstraction abs = CreateSQL(sql);

        abs.cmd.Parameters.Add(AddIntParameter("studentId", studentID));
        abs.cmd.Parameters.Add(AddIntParameter("assignmentId", assignID));
        abs.cmd.Parameters.Add(AddIntParameter("pointsRecd", scoresRcd));

        ExecuteNonquery(ref abs);

        System.Diagnostics.Debug.Print("Attempted to insert student grade");
    }

    private static void ExecuteNonquery(ref SQLAbstraction abs)
    {
        abs.conn.Open();
        abs.cmd.ExecuteNonQuery();
        abs.conn.Close();
    }

    private static SQLAbstraction CreateSQL(string sql)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GradebookConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);

        SQLAbstraction ret = new SQLAbstraction
        {
            sql = sql,
            conn = conn,
            cmd = cmd
        };

        return ret;
    }

    private static SqlParameter AddIntParameter(string parameterName, int value)
    {
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@" + parameterName;
        param.Value = value;

        return param;
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
 