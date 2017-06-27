var validMove = 0;
var myCurrentRow;
var myCurrentCol;
var opponentCurrentRow;
var opponentCurrentCol;
var startRow;
var startCol;
var myPlayerImage;
var myExitImage;
var maze;
var rowsMaze;
var colsMaze;
var exitRow;
var exitCol;
var opponentExitImage;
var opponentPlayerImage;

var MultiPlayerHub = $.connection.MultiPlayerHub;
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
    exitRow = Maze.End.Row;
    exitCol = Maze.End.Col;
    myPlayerImage = new Image(500, 500);
    myExitImage = new Image(500, 500);
    myPlayerImage.src = "Images/simpson.png";
    myExitImage.src = "Images/exit1.png";
    myCurrentRow = startRow;
    myCurrentCol = startCol;


    $("#myMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, myPlayerImage, myExitImage);
    
    opponentExitImage = new Image(500, 500);
    opponentPlayerImage = new Image(500, 500);
    opponentExitImage.src = "Images/exit1.png";
    opponentPlayerImage.src = "Images/monster.jpg";
    opponentCurrentRow = startRow;
    opponentCurrentCol = startCol;
    $("#opponentMazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, opponentPlayerImage, opponentExitImage);

    validMove = 1;
};

MultiPlayerHub.client.gotDirection = function (userName, direction) {
    var newPos = isValidMove(direction, opponentCurrentRow, opponentCurrentCol, rowsMaze, colsMaze, maze);
    if (newPos != "-1") {
        var prevRow = opponentCurrentRow;
        var prevCol = opponentCurrentCol;
        opponentCurrentRow = newPos.backRow;
        opponentCurrentCol = newPos.backCol;

        $("#opponentMazeCanvas").drawMove(opponentPlayerImage, rowsMaze, colsMaze, opponentCurrentRow, opponentCurrentCol, prevRow, prevCol);
        if ((opponentCurrentRow == exitRow) && (opponentCurrentCol == exitCol)) {
            alert("opponent win");
        }

    }
}



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
});

$(document).keydown(function (event) {
    var key = event.which;
    if (key == 37 || key == 38 || key == 39 || key == 40) {
        event.preventDefault();
        if (validMove) {
            var newPos = isValidMove(key, myCurrentRow, myCurrentCol, rowsMaze, colsMaze, maze);
            if (newPos != "-1") {
                var prevRow = myCurrentRow;
                var prevCol = myCurrentCol;
                myCurrentRow = newPos.backRow;
                myCurrentCol = newPos.backCol;

                MultiPlayerHub.server.move("Noam", key);

                $("#myMazeCanvas").drawMove(myPlayerImage, rowsMaze, colsMaze, myCurrentRow, myCurrentCol, prevRow, prevCol);
                if ((myCurrentRow == exitRow) && (myCurrentCol == exitCol)) {
                    alert("you win");
                }

            }
        }
    }
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