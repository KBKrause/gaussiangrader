// This is the Javascript file tied to login.aspx
// It handles the quick front responsibilities of this page.

// Add jQuery
var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.3.1.js';
document.getElementsByTagName('head')[0].appendChild(script); 

$(document).ready(function () {
    // TODO Why does this not work?
    //document.getElementById("#list-profile").innerHTML += "Hello";
    $("#list-profile").html("ey");
});

function setElementText(id, text) {
    $(id).html(text);
}

function appendTextToList(text) {
    var elem = document.getElementById("#list-profile");
    elem.innerHTML += text;
}

function setClassList(text) {
    setElementText('#list-class', text);
}