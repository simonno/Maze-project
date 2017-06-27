$(document).ready(function () {
    var userName = sessionStorage.getItem('user')
    if (userName != undefined) {
        $("#rightNavBar").append('<li><a>Hello ' + userName + '</a ></li ><li><a id="logOut" title="Log out">Log out</a></li>');
        $("#logOut").click(function () {
            sessionStorage.removeItem('user');
            window.location.assign("HomePage.html")

        });
    } else {
        $("#rightNavBar").append('<li id="register"><a href= "RegisterPage.html" title= "Register" >Register</a ></li ><li id="login"><a href="LoginPage.html" title="Log In">Log In</a></li>');
    }


});