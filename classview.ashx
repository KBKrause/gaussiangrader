<%@ WebHandler Language="C#" Class="classview" %>

using System;
using System.Web;

public class classview : IHttpHandler
{
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
                System.Diagnostics.Debug.Print("class name retrieved: " + className);
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