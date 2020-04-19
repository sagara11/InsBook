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

//------------------------THÊM ẢNH--------------------------------------
function previewImages() {
    var preview = document.querySelector(".post-image");

    if (this.files) {
        [].forEach.call(this.files, readAndPreview);
    }

    function readAndPreview(file) {
        if (!/\.(jpe?g|png|gif)$/i.test(file.name)) {
            return alert(file.name + " không phải ảnh hợp lệ");
        }

        var reader = new FileReader();

        reader.addEventListener("load", function () {
            var image = new Image();
            image.height = 100;
            image.className = "new-image";
            image.style.marginRight = "10px";
            image.style.marginBottom = "10px";
            image.width = 100;
            image.src = this.result;
            preview.appendChild(image);
            $(".post-image").css("display", "block");
        });

        reader.readAsDataURL(file);
        $("#image-add").html("Thêm ảnh");
    }
}
document
    .querySelector("#img-1-input")
    .addEventListener("change", previewImages);

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