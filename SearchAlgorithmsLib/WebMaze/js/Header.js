$(document).ready(function () {
    var userName = sessionStorage.getItem('user')
    if (userName != undefined) {
        $("#rightNavBar").append('<li><a> Hello' + userName + '</a ></li ><li><a title="Log out">Log out</a></li>');

    } else {
        $("#rightNavBar").append('<li><a href= "RegisterPage.html" title= "Register" > Register</a ></li ><li><a href="LoginPage.html" title="Log In">Log In</a></li>');
    }

});