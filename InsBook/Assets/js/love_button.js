function heart(id) {
    if ($("#" + id).hasClass("liked")) {
        $("#" + id).html('<i class="fa fa-heart-o" aria-hidden="true"></i>');
        $("#" + id).removeClass("liked");
        $("#" + id + "-modal").html('<i class="fa fa-heart-o" aria-hidden="true"></i>');
    } else {
        $("#" + id).html('<i class="fa fa-heart" aria-hidden="true"></i>');
        $("#" + id).addClass("liked");
        $("#" + id + "-modal").html('<i class="fa fa-heart" aria-hidden="true"></i>');
    }
}