using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Click_signUpSubmit(object sender, EventArgs e)
    {
        //System.Diagnostics.Debug.Print("retval");

        if (txt_password.Text != txt_confirmPassword.Text)
        {
            System.Diagnostics.Debug.Print("pwds don't match!");
        }
        else
        {
            System.Diagnostics.Debug.Print("pwds match!");
        }
    }
}