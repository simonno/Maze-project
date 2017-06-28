$("#save").click(function () {
    var mazeRows = $("#defaultRows").val();
    var mazeCols = $("#defaultCols").val();
    var SearchAlgo = $("#SearchAlgo").val();
    if (SearchAlgo == "DFS") {
        numSearchAlgo = 1;
    } else {
        numSearchAlgo = 0;

    }
    if (sessionStorage.getItem('user')) {
        if (mazeRows == '') {
            sessionStorage.setItem('defaultRows', mazeRows);
        }
        if (mazeCols == '') {
            sessionStorage.setItem('defaultCols', mazeCols);
        }
        if (numSearchAlgo == '') {
            sessionStorage.setItem('defaultAlgo', numSearchAlgo);
        }
    }
});