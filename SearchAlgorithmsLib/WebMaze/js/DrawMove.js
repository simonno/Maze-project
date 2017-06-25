(function ($) {
    $.fn.drawMove = function (playerImage, rows, cols, currentRow, currentCol, prevRow, prevCol) {
        var canvas = this.get(0);
        var context = canvas.getContext("2d");
        var cellWidth = canvas.width / cols;
        var cellHeight = canvas.height / rows;

        context.drawImage(playerImage, cellWidth * currentCol, cellHeight * currentRow, cellWidth, cellHeight);
        context.fillStyle = "white";
        context.fillRect(cellWidth * prevCol, cellHeight * prevRow, cellWidth, cellHeight);
        return this;
    };
}(jQuery));