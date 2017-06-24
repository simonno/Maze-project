(function ($) {
    $.fn.drawSingleMove = function (
        playerImage,rows, cols,
        currentRow, currentCol,
        prevRow, prevCol,// initial position of the player
         // player's icon (of type Image)
    ) {
        var canvas = this.get(0);
        var context = canvas.getContext("2d");
        var parent = this.parent();
        this.width(parent.width());
        this.height(parent.height());
        var cellWidth = canvas.width / cols;
        var cellHeight = canvas.height / rows;
       
       
        context.drawImage(playerImage, cellWidth * currentCol, cellHeight * currentRow, cellWidth, cellHeight);
        context.fillStyle = "white";
        context.fillRect(cellWidth * prevCol, cellHeight * prevRow, cellWidth, cellHeight);
        return this;
    };
}(jQuery));