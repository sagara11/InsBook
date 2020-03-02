$(document).ready(function () {
    // new post section
    $(".post-image").css("display", "none");
    $(".newpost-function").css("display", "none");
    $("#newpost-function-btn").click(function () {
        if ($("#newpost-function-btn").hasClass("clicked")) {
            $(".newpost-function").css("display", "none");
            $("#newpost-function-btn").removeClass("clicked");
        } else {
            $("#newpost-function-btn").addClass("clicked");
            $(".newpost-function").css("display", "block");
        }
    });
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#img')
                .attr('src', e.target.result)
                .width(100)
                .height(100);
        };

        reader.readAsDataURL(input.files[0]);
    }
    $(".post-image").css("display", "block");
}