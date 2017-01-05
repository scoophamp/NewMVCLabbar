//Upload picture
$(document).ready(function () {
    var form = $("form");
    form.submit(function (e) {
        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "/Gallery/UploadPicture",
            data: new FormData(document.getElementsByTagName("form")[0]), beforeSend: function () {
                $("#imgSpinner1").show();
            },
            success: function (data) {
                $("#imgSpinner1").hide();

            },
            processData: false,
            contentType: false
        });
    });
});
//Delete picture
$(document).ready(function () {
    var form = $("form");
    form.submit(function (e) {
        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "/Gallery/DeletePicture",
            data: new FormData(document.getElementsByID("form")[0]), beforeSend: function () {
                $("#imgSpinner1").show();
            },
            success: function (data) {
                $("#imgSpinner1").hide();

            },
            processData: false,
            contentType: false
        });
    });
});