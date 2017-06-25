var MultiPlayerHub = $.connection.MultiPlayerHub;

$.connection.hub.start().done(function () {
    MultiPlayerHub.server.list();
    MultiPlayerHub.client.gotList = function (list) {
        $.each(list, function (key, value) {
            $('#gamesSelect').append($("<option/>", {
                value: key,
                text: value
            }));
        });
    }

    MultiPlayerHub.client.gotMaze = function (jsonMaze) {
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


    $("#newGame").click(function () {
        alert("submitted!");
        var mazeName = $("#mazeName").val();
        var rows = $("#mazeRows").val();
        var cols = $("#mazeCols").val();
        localStorage.setItem("rows", rows);
        localStorage.setItem("cols", cols);

        MultiPlayerHub.server.start(mazeName, rows, cols);

    });

});