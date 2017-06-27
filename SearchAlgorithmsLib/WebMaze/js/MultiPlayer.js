var MultiPlayerHub = $.connection.MultiPlayerHub;

var currentRow;
var currentCol;
var startRow;
var startCol;
var rowsMaze;
var colsMaze;
var prevRow;
var prevCol;
var playerImage;
var maze;
MultiPlayerHub.client.gotlist = function (list) {
    var array = JSON.parse(list); 
    if (array && array.length) {
        $.each(array, function (index, value) {
            $('#gamesSelect').append($("<option/>", {
                key: index,
                text: value
            }));
        });
    }
}

MultiPlayerHub.client.gotMaze = function (jsonMaze) {
    var Maze = JSON.parse(jsonMaze);
     maze = Maze.Maze;
     rowsMaze = Maze.Rows;
     colsMaze = Maze.Cols;
     startRow = Maze.Start.Row;
     startCol = Maze.Start.Col;
     currentCol = startCol;
     currentRow = startRow;


    var exitRow = Maze.End.Row;
    var exitCol = Maze.End.Col;
     playerImage = new Image(500, 500);
    var exitImage = new Image(500, 500);
    playerImage.src = "Images/simpson.png";
    exitImage.src = "Images/exit1.png";

    $("#myMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);
    
    var exitImage2 = new Image(500, 500);
    var playerImage2 = new Image(500, 500);
    exitImage2.src = "Images/exit1.png";
    playerImage2.src = "Images/monster.jpg";
    $("#opponentMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage2, exitImage2);

};



$.connection.hub.start().done(function () {
    MultiPlayerHub.server.list();

    $("#newGame").click(function () {
        var mazeName = $("#mazeName").val();
        var rows = $("#mazeRows").val();
        var cols = $("#mazeCols").val();

        MultiPlayerHub.server.start(mazeName, rows, cols);
    });

    $("#joinGame").click(function () {
        var mazeName = $("#gamesSelect :selected").val();
        if (mazeName != null) {
            MultiPlayerHub.server.join(mazeName);
        }
    });

    $(document).keydown(function (event) {
        var key = event.which;
        if (key == 37 || key == 38 || key == 39 || key == 40) {
            event.preventDefault();
            //if (validMove) {
                var newPos = isValidMove(key, currentRow, currentCol, rowsMaze, colsMaze, maze);
                if (newPos != "-1") {
                     prevRow = currentRow;
                     prevCol = currentCol;
                    currentRow = newPos.backRow;
                    currentCol = newPos.backCol;

                    $("#myMazeCanvas").drawMove(playerImage, rowsMaze, colsMaze, currentRow, currentCol, prevRow, prevCol);
                    if ((currentRow == exitRow) && (currentCol == exitCol)) {
                        alert("you win");
                    }

                }
            //}
        }
    });
});



    //$(document).ready(function () {

    //    $.validator.setDefaults({
    //        highlight: function (element) {
    //            $(element).closest('.form-group').addClass('has-error');
    //        },
    //        unhighlight: function (element) {
    //            $(element).closest('.form-group').removeClass('has-error');
    //        }
    //    });

    //    // validate signup form on keyup and submit
    //    $("#newGameForm").validate({
    //        rules: {
    //            mazeName: {
    //                required: true,
    //                minlength: 2
    //            },
    //            mazeRows: {
    //                required: true,
    //                number: true
    //            },
    //            mazeCols: {
    //                required: true,
    //                number: true
    //            },
    //        },
    //        messages: {
    //            mazeName: {
    //                required: "Enter a name for the maze",
    //                minlength: jQuery.validator.format("Enter at least {0} characters"),
    //            },
    //            mazeRows: {
    //                required: "Enter a number of rows for the maze",
    //                number: jQuery.validator.format("Enter only numbers"),

    //            },
    //            mazeCols: {
    //                required: "Enter a number of rows for the maze",
    //                number: jQuery.validator.format("Enter only numbers"),
    //            },
    //        },
    //        submitHandler: function () {
    //            var mazeName = $("#mazeName").val();
    //            var rows = $("#mazeRows").val();
    //            var cols = $("#mazeCols").val();

    //            MultiPlayerHub.server.start(mazeName, rows, cols);
    //        },
    //    });
    //});