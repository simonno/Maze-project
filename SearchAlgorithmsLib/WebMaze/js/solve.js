(function ($) {
    $.fn.solve = function (
        responseData, playerImage, rows, cols,
        startRow, startCol,
        currentRow, currentCol,// initial position of the player
        // player's icon (of type Image)

    ) {
        alert("solve");
        alert(responseData.Solution);

        alert(responseData.Solution.charAt(1));
        alert(responseData.Solution.charAt(2));
        alert(responseData.Solution.charAt(3));


        return this;
    };
}(jQuery));