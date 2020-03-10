$(document).ready(function () {
    // new post section
    $(".post-image").css("display", "none");
    $(".newpost-function").css("display", "none");
    $("#newpost-function-btn").click(function () {
        if ($("#newpost-function-btn").hasClass("clicked")) {
            $(".newpost-function").css("display", "none");
            $("#newpost-function-btn").removeClass("clicked");
            $("#newpost-function-btn").css("background-color", "rgb(240, 240, 240)");
        } else {
            $("#newpost-function-btn").addClass("clicked");
            $("#newpost-function-btn").css("background-color", "rgb(200, 200, 200)");
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
        $("#" + id + "-tag").css('background-color', 'rgb(240, 240, 240)');
    } else {
        $("#" + id + "-taginput").addClass('show');
        $("#" + id + "-taginput").css('display', 'block');
        $("#" + id + "-tag").css('background-color', 'rgb(200, 200, 200)');
        $("#" + id + "-location").css('background-color', 'rgb(240, 240, 240)');
        $("#" + id + "-locationinput").css('display', 'none');
        $("#" + id + "-locationinput").removeClass('show');
    }
}

function location_open(id) {
    if ($("#" + id + "-locationinput").hasClass("show")) {
        $("#" + id + "-locationinput").css('display', 'none');
        $("#" + id + "-locationinput").removeClass('show');
        $("#" + id + "-location").css('background-color', 'rgb(240, 240, 240)');
    } else {
        $("#" + id + "-locationinput").addClass('show');
        $("#" + id + "-locationinput").css('display', 'block');
        $("#" + id + "-location").css('background-color', 'rgb(200, 200, 200)');
        $("#" + id + "-tag").css('background-color', 'rgb(240, 240, 240)');
        $("#" + id + "-taginput").removeClass('show');
        $("#" + id + "-taginput").css('display', 'none');
    }
}