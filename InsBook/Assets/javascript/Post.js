function ShowPostTools(loai) {
    if (loai === 0) {
        $(".post-ganthe").css("display", "flex");
        $(".post-diadiem").css("display", "none");
        $(".post-chude").css("display", "none");
    }
    if (loai === 1) {
        $(".post-diadiem").css("display", "flex");
        $(".post-ganthe").css("display", "none");
        $(".post-chude").css("display", "none");
    }
    if (loai === 2) {
        $(".post-chude").css("display", "flex");
        $(".post-diadiem").css("display", "none");
        $(".post-ganthe").css("display", "none");
    }
}

//$("#post-banbe-data").autocomplete({
//    source: @Html.Raw(Json.Encode(ViewBag.BanBe)),
//minLength: 1,
//    select: function (event, ui) {
//        $("#post-banbe-data").val(ui.item.id);
//    }
//    }).autocomplete("instance")._renderItem = function (ul, item) {
//    return $('<li><div><img src=' + baseUrl + '/Images/' + item.anh_url + '><span>' + item.value + '</span></div></li>').appendTo(ul);
//};