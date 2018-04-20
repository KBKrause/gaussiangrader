using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// The DatabaseManager class handles and encapsulates the SQL logic to access the application's database.
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