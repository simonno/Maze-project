var validMove = 0;
var currentRow;
var currentCol;
var playerImage;
var maze;
var rowsMaze;
var colsMaze;
var exitRow;
var exitCol;

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
            var mazeName = $("#mazeName").val();
            var rows = $("#mazeRows").val();
            var cols = $("#mazeCols").val();

            $.ajax({
                url: "api/SinglePlayer",
                type: 'GET',
                data: { name: mazeName, rows: rows, cols: cols },
                dataType: 'json',
                success: function (responseData) {
                    rowsMaze = rows;
                    colsMaze = cols;
                    maze = responseData.Maze;
                    currentRow = responseData.Start.Row;
                    currentCol = responseData.Start.Col;
                    exitRow = responseData.End.Row;
                    exitCol = responseData.End.Col;
                    playerImage = new Image(500, 500);
                    var exitImage = new Image(500, 500);
                    playerImage.src = "Images/simpson.png";
                    exitImage.src = "Images/exit1.png";

                    currentRow = responseData.Start.Row;
                    currentCol = responseData.Start.Col;

                    $("#mazeCanvas").drawMaze(rowsMaze, colsMaze, maze, currentRow, currentCol, exitRow, exitCol, playerImage, exitImage);
                    validMove = 1;
                }
            });
        },
    });


    $(document).keydown(function (event) {
        event.preventDefault();
        if (validMove) {
            var newPos = isValidMove(event, currentRow, currentCol, rowsMaze, colsMaze, maze);
            if (newPos != "-1") {
                var prevRow = currentRow;
                var prevCol = currentCol;
                currentRow = newPos.backRow;
                currentCol = newPos.backCol;

                $("#mazeCanvas").drawSingleMove(playerImage, rowsMaze, colsMaze, currentRow, currentCol, prevRow, prevCol);
                if ((currentRow == exitRow) && (currentCol == exitCol)) {
                    alert("you win");
                }
            }
        }
    });

    $("#btnSolveGame").click(function () {
        //alert("solve");

        alert("solve");
        var sreachAlgo = $("#SearchAlgo").val();
        var type = 0;
        if (sreachAlgo == "DFS") {
            type = 1
        }

        $.ajax({
            url: "api/SinglePlayer",
            type: 'GET',
            data: { name: mazeName, type: type },
            dataType: 'json',
            success: function (responseData) {
                alert(responseData);
            }

        }); alert("solve2");

    });
});