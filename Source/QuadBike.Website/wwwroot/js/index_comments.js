$(document).ready(function () {

    $("#addComment").click(function () {
        var comment = $("#inputContentComment").val();
        if (comment) {
            var xhr = new XMLHttpRequest();

            var json = JSON.stringify({
                Content: comment
            });

            xhr.open("POST", '/Comment', true)
            xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');

            xhr.send(json);
        }
    });

});