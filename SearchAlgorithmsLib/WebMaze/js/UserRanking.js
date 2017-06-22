$(document).ready(function () {
    var usersUrl = "/api/Users";
    $.getJSON(usersUrl, function (responseData) {

        responseData.forEach(function (user) {
            $("#rankTableBody").append("<tr><td>" + usr.Id+ "</td>" +
                "<td>" + user.Username + "</td>" +
                "<td>" + user.Wins + "</td>" +
                "<td>" + user.Losses + "</td></tr>");
        });
    });
})
