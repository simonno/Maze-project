$("#login").click(function () {
    var inputUsername = $("#inputUsername").val();
    var inputPassword = $("#inputPassword").val();
    var url = "http://localhost:50570/api/Users/login" + "/" + inputUsername + "/" + inputPassword;
    //TODO connection to server
    var data;
    $.post(url).done(function (data) {
        // alert(data);
        if (data == "1") {
            sessionStorage.setItem('user', inputUsername);
            // alert("login");
        } else if (data == "-1") {
            alert("try again");
        }

    })

});
if (sessionStorage.getItem('user')) {

    $(location).prop('href', 'http://localhost:50570/HomePage.html')
}