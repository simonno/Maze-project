function drawMaze(maze) {
    var myCanvas = this;
    var context = myCanvas[0].getcontext("2d");
    var rows = maze.length;
    var cols = maze[0].length;
    var cellWidth = this.width / cols;
    var cellHeight = this.height / rows;
    for (var i = 0; i < rows; i++) {
        for (var j = 0; j < cols; j++) {
            if (maze[i][j] == 1) {
                context.fillRect(cellWidth * j, cellHeight * i, cellWidth, cellHeight);
            }
        }
    }
    return this;
}


(function ($) {

    $.fn.drawMaze = drawMaze;

}(jQuery));