$(document).ready(function () {
    if (sessionStorage.getItem('user')) {

    } else {
        $("#rightNavBar").append('<li><a href= "RegisterPage.html" title= "Register" > Register</a ></li ><li><a href="LoginPage.html" title="Log In">Log In</a></li>');
    }

});