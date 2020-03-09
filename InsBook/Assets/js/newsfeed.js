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

    // share modal
    $(".tag-input").css("display", "none");
    $(".location-input").css("display", "none");
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

function tag(id) {
    if ($("#" + id + "-taginput").hasClass('show')) {
        $("#" + id + "-taginput").removeClass('show');
        $("#" + id + "-taginput").css('display', 'none');
    } else {
        $("#" + id + "-taginput").addClass('show');
        $("#" + id + "-taginput").css('display', 'block');
    }
}

function location_open(id) {
    if ($("#" + id + "-locationinput").hasClass("show")) {
        $("#" + id + "-locationinput").css('display', 'none');
        $("#" + id + "-locationinput").removeClass('show');
    } else {
        $("#" + id + "-locationinput").addClass('show');
        $("#" + id + "-locationinput").css('display', 'block');
    }
}