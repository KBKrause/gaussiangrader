// This is the Javascript file tied to login.aspx
// It handles the quick front responsibilities of this page.

// Add jQuery
var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.3.1.js';
document.getElementsByTagName('head')[0].appendChild(script); 

function setElementText(id, text) {
    $(id).html(text);
}

function setClassList(text) {
    setElementText('#list-class', text);
}