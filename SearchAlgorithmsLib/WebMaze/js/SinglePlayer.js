
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
            alert("submitted!");
            var mazeName = $("#mazeName").val();
            var rows = $("#mazeRows").val();
            var cols = $("#mazeCols").val();

            $.ajax({
                url: "api/SinglePlayer",
                type: 'GET',
                data: { name: mazeName, rows: rows, cols: cols },
                dataType: 'json',
                success: function (data) {
                    var rowsMaze = rows
                    var colsMaze = cols
                    var maze = data.Maze;
                    var startRow = data.Start.Row;
                    var startCol = data.Start.Col;
                    var exitRow = data.End.Row;
                    var exitCol = data.End.Col;
                    var playerImage = new Image(500, 500);
                    var exitImage = new Image(500, 500);
                    playerImage.src = "Images/simpson.png";
                    exitImage.src = "Images/exit1.png";

                    $("#mazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);
                }
            });
        },
    });
});

$("#btnSolveGame").click(function () {
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
        success: function (data) {
            // TODO SOLVE 
        }
    });
});