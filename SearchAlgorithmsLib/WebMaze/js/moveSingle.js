
var isValidMove = function (keycode, currentRow, currentCol, rowsMaze, colsMaze, mazeData) {
    canvasElement = this[0];
    var newRow = currentRow;
    var newCol = currentCol;
    switch (keycode) {
        case 38: // Up
            newRow = currentRow - 1;
            break;
        case 37: // Left
            newCol = currentCol - 1;
            break;
        case 39: // Right
            newCol = currentCol + 1;
            break;
        case 40: // Down
            newRow = currentRow + 1;
            break;
        default:
            break;
    }
    var newPos;
    var backRow, backCol;
    if ((newRow < 0) || (newRow >= rowsMaze) || (newCol < 0) || (newCol >= colsMaze) || (mazeData[newCol + newRow * colsMaze] == 1)) {
        return -1;
    } else {
        backRow = newRow;
        backCol = newCol;
        newPos = { backRow, backCol };
        return newPos;
    }
};