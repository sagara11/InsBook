function heart(id) {
    if ($("#" + id).hasClass("liked")) {
        $("#" + id).html('<i class="fa fa-heart-o" aria-hidden="true"></i>');
        $("#" + id).removeClass("liked");
    } else {
        $("#" + id).html('<i class="fa fa-heart" aria-hidden="true"></i>');
        $("#" + id).addClass("liked");
    }
}