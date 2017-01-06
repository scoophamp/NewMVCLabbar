$(document).ready(function (e) {

    setInterval(reloadComments, 5000);
});

var reloadComments = function (e) {
    $.ajax({
        type: "GET",
        url: "/Gallery/IndexPartial",
        success: function (data) {
            $('#content').html(data);
        }
    });
};