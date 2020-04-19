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
var selected_img = [];
var js = 0;
function readURL(input) {
    var data = input.files;
    if (data && data[0]) {
        $.each(data, function (i, val) {
            var reader = new FileReader();
            reader.onload = function (e) {
                return new Promise(function (resolve, reject) {
                    $('.card-body-result-img').css("display", "flex");
                    var html = '<div class="selected-post-img" id="selected-img-' + js + '">' +
                        '   <img src="' + e.target.result + '" alt="" />' +
                        '   <div class="div-close-post-img">' +
                        '       <button type = "button" class="close-post-img" onclick="ClosePostImage(' + js + ')"><i class="fas fa-times"></i></button>' +
                        '   </div>' +
                        '</div>';
                    $(html).insertBefore('#post-anh-default');
                    resolve();
                }).then(function (e) {
                    val["idz"] = js;
                    selected_img.push(val);
                    js += 1;
                });
            };
            reader.readAsDataURL(val);
        });
    }
    $("#tools-img").val("");
}
function ClosePostImage(index) {
    $("#selected-img-" + index).remove();
    $.each(selected_img, function (i, el) {
        if (this.idz == index) {
            selected_img.splice(i, 1);
        }
    });
    console.table(selected_img);
}

$("#post-diadiem-data").keyup(function () {
    if ($("#post-diadiem-data").val() === "") {
        $("#result-diadiem").empty();
    }
});

function AddPost() {
    if ($("#post-content").val() == "") {
        alert("Bạn chưa nhập nội dung bài viết");
    }
    else {
        var friends_id = [];
        selected_friends.forEach(function (item) {
            friends_id.push(item.id);
        })

        var post = {
            content: $("#post-content").val(),
            location: $("#post-diadiem-data").val(),
            friends: friends_id,
            security: $("#post-baomat-data").val()
        };
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('post', JSON.stringify(post)); //fomr[1]

        for (var i = 0; i < selected_img.length; i++) {
            formData.append("post_images_" + i, selected_img[i]);
        }

        $.ajax({
            type: 'post',
            url: '/Client/Post/AddPost',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    alert("Thêm bài viết thành công");
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    var html = '<article class="post-box">' +
                        '                        <header class="post-title">' +
                        '                            <div class="user-avatar">' +
                        '                                <img src="' + baseUrl + '/Images/' + response.data.avatarnguoidang + '" alt="">' +
                        '                            </div>' +
                        '                            <a href="#" title="">' + response.data.tennguoidang + '</a>';
                    if (response.data.ganthe.length != 0) {
                        html = html + '<span>với ';
                        response.data.ganthe.forEach(function (ganthe) {
                            html = html + '<a href="#" title=""><b>' + ganthe["ten"] + '</b></a>, ';
                        });
                        html = html + '</span>';
                    }
                    if (response.data.diadiem != "") {
                        html = html + '<span> tại <b>' + response.data.diadiem + '</b></span>';
                    }
                    html = html + ' </header><!-- /header -->' +
                        '<div class="post-content">' +
                        '   <p class="post-content-text">' + response.data.noidung + '</p>';
                    if (response.data.anh.length != 0) {
                        html = html + ' <div class="post-content-image">';
                        if (response.data.anh.length == 1) {
                            html = html + '<img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="">'
                        }
                        else if (response.data.anh.length == 2) {
                            html = html + '<div class = "row soanh-2">';
                            response.data.anh.forEach(function (img) {
                                html = html + '<div class="col-md-6">' +
                                    '   <img src="' + baseUrl + '/Images/' + img["anh_url"] + '" alt="">' +
                                    '</div>';
                            });
                            html = html + '</div>';
                        }
                        else if (response.data.anh.length == 3) {
                            html = html + '<div class = "row soanh-3">' +
                                '   <div class="col-md-12">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '</div>';
                        }
                        else if (response.data.anh.length == 4) {
                            html = html + '<div class = "row soanh-4">' +
                                '   <div class="col-md-12">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[3]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '</div>';
                        }
                        else if (response.data.anh.length == 5) {
                            html = html + '<div class = "row soanh-5">' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[3]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[4]["anh_url"] + '" alt="">' +
                                '   </div>' +
                                '</div>';
                        }
                        else {
                            alert("số ảnh lớn");
                        }
                        html = html + ' </div>';
                    }
                    html = html + ' </div>' +
                        '                       <div class="post-info">' +
                        '                            <section class="post-icons">' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-heart"></i></button>' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-paper-plane"></i></button>' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>' +
                        '                            </section>' +
                        '                            <section class="list-like">' +
                        '                                <button type="button" class="btn btn-light">123 lượt thích</button>' +
                        '                            </section>' +
                        '                            <section class="post-time">' +
                        '                                <p>2 giờ trước</p>' +
                        '                            </section>' +
                        '                            <section class="comment-bar">' +
                        '                                <div class="form-group">' + 
                        '                                    <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>' +
                        '                                </div>' +
                        '                                <button type="button" class="btn btn-light">Đăng</button>' +
                        '                            </section>' +
                        '                        </div>';
                        '              </article>'
                    $(html).insertAfter(".add-post-box");

                    $("#post-content").val("");
                    $("#result-tenbanbe").empty();
                    $("#result-diadiem").empty();

                    $(".card-body-result-img").empty();
                    $(".card-body-result-img").append('<label for="tools-img" class="tools-item" id="post-anh-default"><img src="/Images/default-adding-post.png" alt="" /></label>');
                    $('.card-body-result-img').css("display", "none");
                    $("#tools-img").val("");

                    $("#post-diadiem-data").val("");

                    $("#post-banbe-data").val("");
                    $("#friends-tag").empty();

                    if (selected_friends.length > 0) {
                        selected_friends.forEach(function (item) {
                            friends.push(item);
                        });
                        selected_friends = [];
                    }
                    if (selected_img.length > 0) {
                        selected_img = [];
                    }
                    $(".post-chude").css("display", "none");
                    $(".post-diadiem").css("display", "none");
                    $(".post-ganthe").css("display", "none");
                    $("#post-baomat-data").val("0");
                }
            }
        });
    }
}