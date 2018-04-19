// This is the Javascript file tied to login.aspx
// It handles the quick front responsibilities of this page.

// Add jQuery
var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.3.1.js';
document.getElementsByTagName('head')[0].appendChild(script); 

function doAlert()
{
    alert("This is an alert");
}

function signUpValidation()
{
    // fuck you javascript
    // TODO make a resources file
    // TODO is "text" even used?
    $.get('login.aspx', null, function (text)
    {
        var obj = $('#txt_password').val();
        alert(obj);
    });

    /*
    if (pwd1 != pwd2)
    {
        alert("Passwords don't match!!!");
    }
    else
    {
        alert(pwd1 + " = " + pwd2);
    }
    */
}