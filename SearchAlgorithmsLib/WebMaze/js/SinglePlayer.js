var validMove = 0;
var myCurrentRow;
var myCurrentCol;
var startRow;
var startCol;
var myPlayerImage;
var myExitImage;
var maze;
var rowsMaze;
var colsMaze;
var exitRow;
var exitCol;
var type;
var mazeName;



$(document).ready(function () {

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
            // alert("submitted!");
            mazeName = $("#mazeName").val();
            var rows = $("#mazeRows").val();
            var cols = $("#mazeCols").val();

            $.ajax({
                url: "api/SinglePlayer",
                type: 'GET',
                data: { name: mazeName, rows: rows, cols: cols },
                dataType: 'json',
                success: function (responseData) {
                    rowsMaze = responseData.Rows;
                    colsMaze = responseData.Cols;
                    maze = responseData.Maze;
                    myCurrentRow = responseData.Start.Row;
                    startRow = responseData.Start.Row;
                    myCurrentCol = responseData.Start.Col;
                    startCol = responseData.Start.Col;
                    exitRow = responseData.End.Row;
                    exitCol = responseData.End.Col;
                    myPlayerImage = new Image(500, 500);
                    myExitImage = new Image(500, 500);
                    myPlayerImage.src = "Images/simpson.png";
                    myExitImage.src = "Images/exit1.png";
                    myCurrentRow = responseData.Start.Row;
                    myCurrentCol = responseData.Start.Col;

                    $("#mazeCanvas").drawMaze(rowsMaze, colsMaze, maze, myCurrentRow, myCurrentCol, exitRow, exitCol, myPlayerImage, myExitImage);
                    validMove = 1;
                }
            });
        },
    });


    $(document).keydown(function (event) {
        var key = event.which;
        movePlayer(key)
    });

    var movePlayer = function (key) {
        if (key == 37 || key == 38 || key == 39 || key == 40) {
            if (validMove) {
                var newPos = isValidMove(key, myCurrentRow, myCurrentCol, rowsMaze, colsMaze, maze);
                if (newPos != "-1") {
                    var prevRow = myCurrentRow;
                    var prevCol = myCurrentCol;
                    myCurrentRow = newPos.backRow;
                    myCurrentCol = newPos.backCol;

                    $("#mazeCanvas").drawMove(myPlayerImage, rowsMaze, colsMaze, myCurrentRow, myCurrentCol, prevRow, prevCol);
                    if ((myCurrentRow == exitRow) && (myCurrentCol == exitCol)) {
                        alert("you win");
                    }
                }
            }
        }
    }

    $("#btnSolveGame").click(function () {

        var type = 0;
        if ($("#SearchAlgo").val() == "DFS") {
            type = 1
        }

        $.ajax({
            url: "api/SinglePlayer",
            type: 'GET',
            data: { mazeName: mazeName, typeOfSearch: type },
            dataType: 'json',
            success: function (responseData) {
                var i;
                var solution = responseData.Solution;
                alert(responseData.Solution);
                var len = solution.length;
                for (i = 0; i < len; i++) {
                    switch (keycode) {
                        case 'U': // Up
                            movePlayer(38)
                            break;
                        case 'L': // Left
                            movePlayer(37)
                            break;
                        case 'R': // Right
                            movePlayer(39)
                            break;
                        case 'D': // Down
                            movePlayer(40)
                            break;
                        default:
                            break;
                    }
                }

            },
            error: function () {
                alert("error");
            }
            
        });
    });
});