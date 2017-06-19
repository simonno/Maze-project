$(document).ready(function () {
    maze = [[0, 1, 1, 1, 1, 1, 1, 1],
            [1, 1, 0, 0, 0, 0, 0, 1],
            [0, 1, 0, 1, 0, 0, 1, 1],
            [0, 1, 0, 1, 0, 0, 1, 1],
            [0, 1, 0, 1, 0, 0, 1, 1],
            [0, 1, 0, 1, 0, 0, 1, 1],
            [0, 1, 0, 1, 0, 0, 1, 1],
            [0, 1, 0, 1, 0, 0, 0, 1],
            [0, 1, 0, 1, 1, 1, 0, 1],
            [0, 1, 0, 1, 1, 1, 0, 1],
            [0, 0, 0, 0, 1, 1, 1, 1]];
    var startRow = 2;
    var startCol = 0;
    var exitRow = 8;
    var exitCol = 6;
    var playerImage = new Image(500, 500);
    var exitImage = new Image(500, 500);
    playerImage.src = "Images/simpson.png";
    exitImage.src = "Images/exit1.png";

    $("#mazeCanvas").drawMaze(maze, startRow, startCol, exitRow, exitCol, playerImage, exitImage);
});