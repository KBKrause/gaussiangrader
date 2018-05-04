<%@ WebHandler Language="C#" Class="classview" %>

using System;
using System.Web;
using System.Web.SessionState;

public class classview : IHttpHandler
{
        // This was found at https://www.codeproject.com/Tips/832696/How-to-send-Data-from-JavaScript-to-Csharp-Server.
    public void ProcessRequest (HttpContext context)
    {
        string jsonString = String.Empty;
        HttpContext.Current.Request.InputStream.Position = 0;
        using (System.IO.StreamReader inputStream =
        new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
        {
            jsonString = inputStream.ReadToEnd();
            System.Web.Script.Serialization.JavaScriptSerializer jSerialize =
                new System.Web.Script.Serialization.JavaScriptSerializer();
            var data = jSerialize.Deserialize<ClassString>(jsonString);

            if (data != null)
            {
                string className = data.className;
                    Constants.CURR_CLASS = className;
                System.Diagnostics.Debug.Print("class name retrieved from Constants: " + Constants.CURR_CLASS);
                context.Response.Write(jSerialize.Serialize(
                     new
                     {
                         Response = "Message Has been sent successfully"
                     }));
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private class ClassString
    {
        public string className {get;set;}
    }
}