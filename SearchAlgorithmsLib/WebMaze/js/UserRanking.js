$(document).ready(function () {
    var usersUrl = "api/Users";
    $.getJSON(usersUrl, function (responseData) {
        

        $("#rankTable").DataTable({
            data: responseData,
            columns: [
                { 'data' : 'Username' },
                { 'data' : 'Wins' },
                { 'data' : 'Losses' }
            ] 
        });
    });
    
})
