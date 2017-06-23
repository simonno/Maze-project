(function ($) {
    $.fn.moveSingle = function (eve, currentRow, currentCol,
        rowsMaze, colsMaze,
        mazeData, ) {
        canvasElement = this[0];
        alert("hii11");
        var newRow = currentRow;
        var newCol = currentCol;
        var keycode = eve.which;
        switch (keycode) {
            case 38: // Up
                alert("Up");
                newRow = currentRow - 1;
                break;
            case 37: // Left
                alert("Left");
                newCol = currentCol - 1;
                break;
            case 39: // Right
                alert("Right");
                newCol = currentCol + 1;
                break;
            case 40: // Down
                alert("Down");
                newRow = currentRow + 1;
                break;
            default:
                break;
        }
        var newPos;
        var backRow, backCol;
        if ((newRow < 0) || (newRow > rowsMaze)
            || (newCol < 0) || (newCol > colsMaze) ||
            (mazeData[newCol + newRow * colsMaze] == 1)) {

            return -999;
        }
        else {
            backRow = newRow;
            backCol = newCol;
            newPos = { backRow, backCol };
            return newPos;
        }


    };
}(jQuery));