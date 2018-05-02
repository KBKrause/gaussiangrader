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
    //console.log("The clicked button is " + text);
    window.location = "classview.aspx";
}