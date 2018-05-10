// Add jQuery
var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.3.1.js';
document.getElementsByTagName('head')[0].appendChild(script); 

function errorModal() {
    $('#errorModal').modal('show');
}

function successModal() {
    $('#successModal').modal('show');
}