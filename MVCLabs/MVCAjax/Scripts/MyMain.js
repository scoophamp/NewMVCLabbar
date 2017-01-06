//Upload picture
$(document).ready(function () {
    var form = $("#uploadpicture");

    form.submit(function (e) {
        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "/Gallery/UploadPicture",
            data: new FormData(document.getElementsByTagName("form")[0]), beforeSend: function () {
                $("#imgSpinner1").show();
            },
            success: function (data) {
                $("#content").html(data);
                $("#imgSpinner1").hide();

            },
            processData: false,
            contentType: false
        });
    });
});