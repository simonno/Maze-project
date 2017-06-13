
(function ($) {

    $.fn.drawMaze = function (maze) {
        var canvas = this.get(0);
        var context = canvas.getContext("2d");
        var rows = maze.length;
        var cols = maze[0].length;
        var cellWidth = canvas.width / cols;
        var cellHeight = canvas.height / rows;
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (maze[i][j] == 1) {
                    context.fillRect(cellWidth * j, cellHeight * i, cellWidth, cellHeight);
                }
            }
        }
        return this;
    };

}(jQuery));


$(document).ready(function () {
    maze = [[0, 1, 1, 1, 1, 1, 1],
    [1, 1, 0, 0, 0, 0, 1],
    [0, 1, 0, 1, 0, 1, 1],
    [0, 1, 0, 1, 0, 0, 1],
    [0, 1, 0, 1, 1, 0, 1],
    [0, 1, 0, 1, 1, 0, 1],
    [0, 0, 0, 0, 1, 1, 1]];
    $("#mazeCanvas").drawMaze(maze);
});