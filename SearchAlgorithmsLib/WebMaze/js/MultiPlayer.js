var messagesHub = $.connection.messagesHub;

$.connection.hub.start().done(function () {
    messagesHub.server.list();
    messagesHub.client.gotList = function (list) {
        $.each(list, function (key, value) {
            $('#gamesSelect').append($("<option/>", {
                value: key,
                text: value
            }));
        });
    }

    messagesHub.client.gotMaze = function (jsonMaze) {
        var rowsMaze = localStorage.getItem("rows");
        var colsMaze = localStorage.getItem("cols");
        var maze = jsonMaze.Maze;
        var startRow = jsonMaze.Start.Row;
        var startCol = jsonMaze.Start.Col;
        var exitRow = jsonMaze.End.Row;
        var exitCol = jsonMaze.End.Col;
        var playerImage = new Image(500, 500);
        var exitImage = new Image(500, 500);
        playerImage.src = "Images/simpson.png";
        exitImage.src = "Images/exit1.png";

        $("#myMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);

        playerImage.src = "Images/monster.jpg";

        $("#opponentMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);

    };
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        }
    });

    // validate signup form on keyup and submit
    $("#newGameForm").validate({
        rules: {
            mazeName: {
                required: true,
                minlength: 2
            },
            mazeRows: {
                required: true,
                number: true
            },
            mazeCols: {
                required: true,
                number: true
            },
        },
        messages: {
            mazeName: {
                required: "Enter a name for the maze",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
            },
            mazeRows: {
                required: "Enter a number of rows for the maze",
                number: jQuery.validator.format("Enter only numbers"),

            },
            mazeCols: {
                required: "Enter a number of rows for the maze",
                number: jQuery.validator.format("Enter only numbers"),
            },
        },

        // specifying a submitHandler prevents the default submit, good for the demo
        submitHandler: function () {
            alert("submitted!");
            var mazeName = $("#mazeName").val();
            var rows = $("#mazeRows").val();
            var cols = $("#mazeCols").val();
            localStorage.setItem("rows", rows);
            localStorage.setItem("cols", cols);

            messagesHub.server.start(mazeName, rows, cols);
        },
    });
});
