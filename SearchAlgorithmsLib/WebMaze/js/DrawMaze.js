﻿
(function ($) {
    $.fn.drawMaze = function (
        rows, cols,
        mazeData, // the matrix containing the maze cells
        startRow, startCol, // initial position of the player
        exitRow, exitCol, // the exit position
        playerImage, // player's icon (of type Image)
        exitImage // exit's icon (of type Image)
    ) {
        var canvas = this.get(0);
        var context = canvas.getContext("2d");
        var parent = this.parent();
        this.width(parent.width());
        this.height(parent.height());
        var cellWidth = canvas.width / cols;
        var cellHeight = canvas.height / rows;
        context.lineWidth = 0.01 * canvas.width;
        context.strokeStyle = "Black";
        context.strokeRect(0, 0, canvas.width, canvas.height);
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (mazeData[j + i * cols] == 1) {
                    context.fillRect(cellWidth * j, cellHeight * i, cellWidth, cellHeight);
                }
            }
        }

        playerImage.onload = function drawPlayer() {
            context.drawImage(playerImage, cellWidth * startCol, cellHeight * startRow, cellWidth, cellHeight);
        }

        exitImage.onload = function () {
            context.drawImage(exitImage, cellWidth * exitCol, cellHeight * exitRow, cellWidth, cellHeight);
        }

        return this;
    };
}(jQuery));