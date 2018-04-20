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

// TODO None of this AJAX works.

// This function uses jQuery to check the values of the passwords entered.
// If the passwords in the ASP text boxes match, it sets the ASP hidden field to have a value of "true."
// Because this runs on client side
/*
function signUpValidation()
{
    // TODO make a resources file
    // TODO is "text" even used?

    $.get('login.aspx', null, function (text)
    {
        var pwd1 = $('#txt_password').val();
        var pwd2 = $('#txt_confirmPassword').val();

        if (pwd1 != pwd2)
        {
            console.log("pwds match");
            $("#<%= retval_signUpValidation.ClientID %>").val("true");
        }
        else
        {
            console.log("pwds don't match");
            $("#<%= retval_signUpValidation.ClientID %>").val("false");
        }
    });
}

function theHeckinPostMethod()
{
    $.ajax({
        url: 'login.aspx/TestFunc',
        type: 'POST',
        data: { field1: "hello", field2: "hello2" },
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert(response.status);
        },
        error: function () {
            alert("error");
        }
    }); 
}
*/