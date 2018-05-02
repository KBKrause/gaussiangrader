// This is the Javascript file tied to login.aspx
// It handles the quick front responsibilities of this page.

// Add jQuery
var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.3.1.js';
document.getElementsByTagName('head')[0].appendChild(script); 

var uniqueID = 0;

function setElementText(id, text) {
    $(id).html(text);
}

function appendTextToList(text) {
    // TODO For some reason, getElementById does not work.
    // I tried $(document).ready() and that didn't help either.

    // <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Click_addClass" CausesValidation="False"/>

    var onClickString = "redirectToClass('" + text + "'); ";
    var buttonString = "<button type='button' class='btn btn-info' onclick=" + onClickString + ">" + text + "</button>";
    console.log("buttonString = " + buttonString);
    var inner = $('#list-profile').html();
    inner += ("<br />" + buttonString);
    $('#list-profile').html(inner);
}

function setClassList(text) {
    setElementText('#list-class', text);
}

function redirectToClass(text) {
    var postdata = JSON.stringify(
        {
            "className":text
        });
    try {
        $.ajax({
            type: "POST",
            url: "classview.ashx",
            cache: false,
            data: postdata,
            dataType: "json",
            success: getSuccess,
            error: getFail
        });
    } catch (e) {
        alert(e);
    }
    function getSuccess(data, textStatus, jqXHR) {
        alert(data.Response);
    };
    function getFail(jqXHR, textStatus, errorThrown) {
        alert(jqXHR.status);
    };
    window.location = "classview.aspx";
}