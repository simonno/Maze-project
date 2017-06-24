
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
                    var rowsMaze = rows
                    var colsMaze = cols
                    var maze = responseData.Maze;
                    var startRow = responseData.Start.Row;
                    var startCol = responseData.Start.Col;
                    var exitRow = responseData.End.Row;
                    var exitCol = responseData.End.Col;
                    var playerImage = new Image(500, 500);
                    var exitImage = new Image(500, 500);
                    var whiteRec = new Image(500, 500);
                    playerImage.src = "Images/simpson.png";
                    exitImage.src = "Images/exit1.png";
                    whiteRec.src ="Images/whiteRec.png"

                    var currentRow = responseData.Start.Row;
                    var currentCol = responseData.Start.Col;

                    $("#mazeCanvas").drawMaze(rowsMaze, colsMaze, maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);
                    $(document).keydown(function (eve) {
                        //  alert("Handler for .keydown() called.");
                        var keycode = eve.which;
                        // alert(keycode);

                        //switch (keycode) {
                        //    case 38: // Up
                        //        alert("Up");
                        //        break;
                        //    case 37: // Left
                        //        alert("Left");
                        //        break;
                        //    case 39: // Right
                        //        alert("Right");
                        //        break;
                        //    case 40: // Down
                        //        alert("Down");
                        //        break;
                        //    default:
                        //        break;
                        //}
                        eve.preventDefault();

                        var newPos = $("#mazeCanvas").moveSingle(eve,
                            currentRow, currentCol, rowsMaze, colsMaze, maze);
                        if (newPos != "-999") {
                            var prevRow = currentRow;
                            var prevCol = currentCol;
                            currentRow = newPos.backRow;
                            currentCol = newPos.backCol;
                            alert(currentRow + "row");
                            alert(currentCol + "col");

                            $("#mazeCanvas").drawSingleMove(playerImage, whiteRec, rowsMaze,
                                colsMaze, currentRow, currentCol, prevRow, prevCol);


                            if ((currentRow == exitRow) && (currentCol == exitCol)) {
                                alert("you win");
                            }
                        } else {
                            alert("the step is wrong");
                        }
                    });
                }
            });
        },
    });


    $("#btnSolveGame").click(function () {
    //alert("solve");
       
            alert("solve");
            var sreachAlgo = $("#SearchAlgo").val();
            var type = 0;
            if (sreachAlgo == "DFS") {
                type = 1
            }
            alert("solve2");
            $.ajax({
                url: "api/SinglePlayer",
                type: 'GET',
                data: { name: mazeName, type: type },
                dataType: 'json',
                success: function ( e,responseData) {
                    
                    var Elem = e.target;
                    if (Elem.nodeName == "INPUT") {
                        var maze = responseData.mazeName;

                        alert("k");

                    } 
                }

            });alert("solve2");
        
    });
});