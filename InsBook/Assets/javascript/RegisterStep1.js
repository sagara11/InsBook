$(".btn-primary").click(function() {
    var id2 = $(this).attr("id-add");
    var token = $('input[name="__RequestVerificationToken"]').val();
    $.ajax({
        url: "/Client/Friend/AddFriend",
        type: "post",
        dataType: "text",
        data: {
            __RequestVerificationToken: token, 
            id2 : id2
        }
    }).done(function(results) {
        alert("thanh cong")
    });
})

$(".btn-light").click(function() {
    var id2 = $(this).attr("id-disappear");
    $("#list-friends-" + id2).remove();
    // sau khi remove thì gợi ý ra bạn mới ko đc trùng với những thằng đang có và đã xoá và chính nos
    //$.ajax({
    //    url: "/Client/Friend/DisapearFriend",
    //    type: "get",
    //    dataType: "text",
    //    data: {
    //        __RequestVerificationToken: token,
    //        id2: id2
    //    }
    //}).done(function(results) {
    //    alert("thanh cong")
    //});
})