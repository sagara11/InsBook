function ShowPostTools(loai, postId) {
    //postId = -1 là ShowPostTools trong phần thêm bài viết
    if ($("#show-edit-post-" + postId).hasClass('show') && postId !== -1) {
        if (loai === 0) {
            $("#edit-post-ganthe-" + postId).css("display", "flex");
            $("#edit-post-diadiem-" + postId).css("display", "none");
            $("#edit-post-chude-" + postId).css("display", "none");
        }
        if (loai === 1) {
            $("#edit-post-diadiem-" + postId).css("display", "flex");
            $("#edit-post-chude-" + postId).css("display", "none");
            $("#edit-post-ganthe-" + postId).css("display", "none");
        }
        if (loai === 2) {
            $("#edit-post-chude-" + postId).css("display", "flex");
            $("#edit-post-diadiem-" + postId).css("display", "none");
            $("#edit-post-ganthe-" + postId).css("display", "none");
        }
    }
    else {
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
}
//Hàm autocomplte lấy địa điểm cho bài viết
$("#post-diadiem-data").autocomplete({
    source: post_locations,
    select: function (event, ui) {
        if ($("#result-diadiem-b").length > 0) {
            $("#result-diadiem-b").empty();
            $("#result-diadiem-b").append(ui.item.value);
        } else {
            $("#result-diadiem").append('tại <b id="result-diadiem-b">' + ui.item.value + '</b>');
        }
        $("#post-diadiem-data").val(ui.item.value);
        return false;
    }
});

$(".edit-post-diadiem-data").autocomplete({
    source: post_locations,
    select: function (event, ui) {
        var post_id = this.id.split("-");
        post_id = post_id[post_id.length - 1];
        if ($("#result-diadiem-b-" + post_id).length > 0) {
            $("#result-diadiem-b-" + post_id).empty();
            $("#result-diadiem-b-" + post_id).append(ui.item.value);
        } else {
            $("#edit-result-diadiem-" + post_id).append('tại <b id="result-diadiem-b-' + post_id + '">' + ui.item.value + '</b>');
        }
        $("#edit-post-diadiem-data-" + post_id).val(ui.item.value);
        return false;
    }
});
//Hàm autocomplete lấy danh sách bạn bè cho bài viết
var selected_friends = [];
var add_friends = [];
add_friends = [...friends];

var selected_edit_friends = [];
var edit_friends = [...friends];

//Hàm thêm ảnh cho bài viết
var selected_img = [];
var js = 0;
//Hỗ trợ sửa ảnh cho bài viết
var edit_selected_img = [];
var edit_js;

$("#post-banbe-data")
    // don't navigate away from the field on tab when selecting an item
    .on("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).autocomplete("instance").menu.active) {
            event.preventDefault();
        }
    })
    .autocomplete({
        minLength: 1,
        source: function (request, response) {
            // delegate back to autocomplete, but extract the last term
            response($.ui.autocomplete.filter(
                add_friends, request.term));
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            $.each(add_friends, function (i, el) {
                if (this.id == ui.item.id) {
                    add_friends.splice(i, 1);
                }
            });
            selected_friends.push(ui.item);
            var html = '<div id = "friend-tag-' + ui.item.id + '" class = "friends-tag-span">' +
                '<span id = "friend-tag-' + ui.item.id + '-name">' + ui.item.value + '</span>' +
                '<a href = "#" onclick="DeleteFriendTag(' + ui.item.id + ', event, -1)">' +
                '    <i class="fas fa-times"></i>' +
                '</a>' +
                '</div>';
            $("#friends-tag").append(html);
            $("#post-banbe-data").val("");
            $("#post-banbe-data").attr('placeholder', '');
            if ($(".result-banbe-b").length > 0) {
                $("#result-tenbanbe").append('<span id="result-banbe-' + ui.item.id + '" class="result-banbe-b"><b>' + ui.item.value + ', </b></span>');
            } else {
                $("#result-tenbanbe").append('với <span id="result-banbe-' + ui.item.id + '" class="result-banbe-b"><b>' + ui.item.value + ', </b></span>');
            }
            return false;

        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $('<li><div><img src=' + baseUrl + '/Images/' + item.anh_url + '><span>' + item.value + '</span></div></li>').appendTo(ul);
    };

//
$(".edit-post-bande-data")
    // don't navigate away from the field on tab when selecting an item
    .on("keydown", function (event) {
        var post_id = this.id.split("-");
        post_id = post_id[post_id.length - 1];
        if (event.keyCode === $.ui.keyCode.TAB &&
            $("#edit-post-banbe-data-" + post_id).autocomplete("instance").menu.active) {
            event.preventDefault();
        }
    })
    .autocomplete({
        minLength: 1,
        source: function (request, response) {
            // delegate back to autocomplete, but extract the last term
            response($.ui.autocomplete.filter(
                edit_friends, request.term));
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var post_id = this.id.split("-");
            post_id = post_id[post_id.length - 1];
            $.each(edit_friends, function (i, el) {
                if (this.id == ui.item.id) {
                    edit_friends.splice(i, 1);
                }
            });
            selected_edit_friends.push(ui.item);
            var html = '<div id = "friend-tag-' + ui.item.id + '-' + post_id + '" class = "friends-tag-span">' +
                '<span id = "friend-tag-' + ui.item.id + '-name">' + ui.item.value + '</span>' +
                '<a href = "#" onclick="DeleteFriendTag(' + ui.item.id + ', event,' + post_id + ')">' +
                '    <i class="fas fa-times"></i>' +
                '</a>' +
                '</div>';
            $("#friends-tag-" + post_id).append(html);
            $("#edit-post-banbe-data-" + post_id).val("");
            $("#edit-post-banbe-data-" + post_id).attr('placeholder', '');
            if ($(".result-banbe-b-" + post_id).length > 0) {
                $("#edit-result-tenbanbe-" + post_id).append('<span id="result-banbe-' + ui.item.id + '-' + post_id + '" class="result-banbe-b-' + post_id + '"><b>' + ui.item.value + ', </b></span>');
            } else {
                $("#edit-result-tenbanbe-" + post_id).append('với <span id="result-banbe-' + ui.item.id + '-' + post_id + '" class="result-banbe-b-' + post_id + '"><b>' + ui.item.value + ', </b></span>');
            }
            return false;
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $('<li><div><img src=' + baseUrl + '/Images/' + item.anh_url + '><span>' + item.value + '</span></div></li>').appendTo(ul);
    };

//Hàm hủy gắn thẻ bạn bè
function DeleteFriendTag(friendId, e, postId) { //postId = -1 khi thêm bài
    e = e || window.event;
    e.preventDefault();
    if ($("#show-edit-post-" + postId).hasClass('show') && postId !== -1) {
        $("#friend-tag-" + friendId + '-' + postId).remove();

        var item = selected_edit_friends.find(x => x.id === friendId);

        $.each(selected_edit_friends, function (i, el) {
            if (this.id == friendId) {
                selected_edit_friends.splice(i, 1);
            }
        });
        edit_friends.push(item);
        if (selected_edit_friends.length === 0) {
            $("#edit-post-banbe-data-" + postId).attr('placeholder', 'Cùng với ai ?');
            $("#edit-result-tenbanbe-" + postId).empty();
        } else {
            $("#result-banbe-" + friendId + '-' + postId).remove();
        }
    }
    else {
        $("#friend-tag-" + friendId).remove();

        var item = selected_friends.find(x => x.id === friendId);

        $.each(selected_friends, function (i, el) {
            if (this.id == friendId) {
                selected_friends.splice(i, 1);
            }
        });
        add_friends.push(item);
        if (selected_friends.length === 0) {
            $("#post-banbe-data").attr('placeholder', 'Cùng với ai ?');
            $("#result-tenbanbe").empty();
        } else {
            $("#result-banbe-" + friendId).remove();
            //$("#result-tenbanbe").html(text.replace('với ,', 'với'));
        }
    }
}

function readURL(input, postId) { //postId = -1 khi thêm bài viết
    if ($("#show-edit-post-" + postId).hasClass('show') && postId !== -1) {
        var data = input.files;
        if (data && data[0]) {
            $.each(data, function (i, val) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    return new Promise(function (resolve, reject) {
                        $('#modal-body-result-img-' + postId).css("display", "flex");

                        var html = '<div class="edit-selected-post-img" id="edit-selected-img-' + postId + '-' + edit_js + '">' +
                            '   <img src="' + e.target.result + '" alt="" />' +
                            '   <div class="edit-div-close-post-img">' +
                            '       <button type = "button" class="edit-close-post-img" onclick="ClosePostImage(' + edit_js + ', ' + postId + ')"><i class="fas fa-times"></i></button>' +
                            '   </div>' +
                            '</div>';
                        $(html).insertBefore('#edit-post-anh-default-' + postId);
                        resolve();
                    }).then(function (e) {
                        val["idz"] = edit_js;
                        edit_selected_img.push(val);
                        edit_js += 1;
                    });
                };
                reader.readAsDataURL(val);
            });
        }
        $("#tools-img-" + postId).val("");
    }
    else {
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
                            '       <button type = "button" class="close-post-img" onclick="ClosePostImage(' + js + ', -1)"><i class="fas fa-times"></i></button>' +
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
}

function ClosePostImage(index, postId) { //postId = -1 khi them bai viet
    if ($("#show-edit-post-" + postId).hasClass('show') && postId !== -1) {
        $("#edit-selected-img-" + postId + "-" + index).remove();
        $.each(edit_selected_img, function (i, el) {
            if (this.idz == index) {
                edit_selected_img.splice(i, 1);
            }
        });
        console.table(edit_selected_img);
    }
    else {
        $("#selected-img-" + index).remove();
        $.each(selected_img, function (i, el) {
            if (this.idz == index) {
                selected_img.splice(i, 1);
            }
        });
        console.table(selected_img);
    }
}

$("#post-diadiem-data").keyup(function () {
    if ($("#post-diadiem-data").val() === "") {
        $("#result-diadiem").empty();
    }
});

$(".edit-post-diadiem-data").keyup(function () {
    var post_id = this.id.split("-");
    post_id = post_id[post_id.length - 1]; // Lấy post_id
    if ($("#edit-post-diadiem-data-" + post_id).val() === "") {
        $("#edit-result-diadiem-" + post_id).empty();
    }
});
//Hàm liên quan bài viết

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
        var url = window.location.href.split('/');
        var friendID = url[6];
        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('post', JSON.stringify(post)); //fomr[1]
        formData.append('friendID', friendID); //fomr[2]
        var haha = selected_img.length;
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
                    var html = '<article class="post-box post-' + response.data.id + '">' +
                        '                        <header class="post-title">' +
                        '                            <div class="post-info">' +
                        '                                <img src="' + baseUrl + '/Images/' + response.data.avatarnguoidang + '" alt="" class="rounded rounded-circle lazy" width="50px" height="50px">' +
                        '                                <p class="post-user-info-' + response.data.id + '">' +
                        '                                    <a href="#" title="">' + response.data.tennguoidang + '</a>';
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

                    html = html + '</p>' +
                        '                                </div>' +
                        '                                <div class="post-option" data-target="#post-option-modal-' + response.data.id + '" data-toggle="modal">' +
                        '                                    &#8230;' +
                        '                                </div>' +
                        '                                <div class="modal post-option-modal fade" id="post-option-modal-' + response.data.id + '">' +
                        '                                    <div class="modal-dialog modal-dialog-centered">' +
                        '                                        <div class="modal-content">' +
                        '                                            <div class="modal-body">' +
                        '                                                <ul>' +
                        '                                                    <li>' +
                        '                                                        <a class="report" href="">Báo cáo</a>' +
                        '                                                    </li>' +
                        '                                                    <li>' +
                        '                                                        <a href="#" onclick="EditPost(' + response.data.id + ', event, ' + session_userId + ')">Sửa bài viết</a>' +
                        '                                                    </li>' +
                        '                                                    <li>' +
                        '                                                        <a href="#" onclick="DeletePost(' + response.data.id + ', event, ' + session_userId + ')">Xóa bài viết</a>' +
                        '                                                    </li>' +
                        '                                                </ul>' +
                        '                                            </div>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                </div>' +
                        '<!-- Modal -->' +
                        '                                <div class="modal fade show-edit-post-modal" id="show-edit-post-' + response.data.id + '" tabindex="-1" role="dialog">' +
                        '                                    <div class="modal-dialog modal-dialog-centered" role="document">' +
                        '                                        <div class="modal-content">' +
                        '                                            <div class="modal-header">' +
                        '                                                <h3><i class="fas fa-pencil-alt"></i>Sửa bài viết</h3>' +
                        '                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                        '                                                    <span aria-hidden="true">×</span>' +
                        '                                                </button>' +
                        '                                            </div>' +
                        '                                            <div class="modal-body">' +
                        '                                                <div class="modal-body-content">' +
                        '                                                    <div class="user-ava" id="user-ava-' + response.data.id + '">' +
                        '                                                        <img src="' + baseUrl + '/Images/' + response.data.avatarnguoidang + '" alt="" />' +
                        '                                                    </div>' +
                        '                                                    <div class="form-group">' +
                        '<textarea class="form-control" id="edit-post-content-' + response.data.id + '" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>' +
                        '</div>' +
                        '                                                </div>' +
                        '                                                <div class="modal-body-result">' +
                        '                                                    <p class="modal-body-result-text"><span class="edit-result-tenbanbe" id="edit-result-tenbanbe-' + response.data.id + '"></span><span class="edit-result-diadiem" id="edit-result-diadiem-' + response.data.id + '"></span></p>' +
                        '                                                    <div class="modal-body-result-img" id="modal-body-result-img-' + response.data.id + '">' +
                        '                                                        <label for="tools-img-' + response.data.id + '" class="edit-tools-item" id="edit-post-anh-default-' + response.data.id + '"><img src="/Images/default-adding-post.png" alt="" /></label>' +
                        '                                                    </div>' +
                        '                                                </div>' +
                        '                                                <div class="input-group modal-body-input edit-post-diadiem" id="edit-post-diadiem-' + response.data.id + '">' +
                        '                                                    <div class="input-group-prepend">' +
                        '                                                        <div class="input-group-text"><i class="fas fa-map-marker-alt"></i></div>' +
                        '                                                    </div>' +
                        '                                                    <input type="text" class="form-control edit-post-diadiem-data" id="edit-post-diadiem-data-' + response.data.id + '" placeholder="Bạn đang ở đâu ?">' +
                        '                                                </div>' +
                        '                                                <div class="input-group modal-body-input edit-post-ganthe" id="edit-post-ganthe-' + response.data.id + '">' +
                        '                                                    <div class="input-group-prepend">' +
                        '                                                        <div class="input-group-text"><i class="fas fa-user"></i></div>' +
                        '                                                    </div>' +
                        '                                                    <div id="friends-tag-' + response.data.id + '" class="edit-friends-tag">' +
                        '' +
                        '                                                    </div>' +
                        '                                                    <input type="text" class="form-control edit-post-bande-data" id="edit-post-banbe-data-' + response.data.id + '" placeholder="Cùng với ai ?">' +
                        '                                                </div>' +
                        '                                                <div class="input-group modal-body-input edit-post-chude" id="edit-post-chude-' + response.data.id + '">' +
                        '                                                    <div class="input-group-prepend">' +
                        '                                                        <div class="input-group-text"><i class="fas fa-filter"></i></div>' +
                        '                                                    </div>' +
                        '                                                    <input type="text" class="form-control" id="" placeholder="Chủ đề bài viết ?">' +
                        '                                                </div>' +
                        '                                                <div class="modal-body-tools">' +
                        '                                                    <input class="tools-img" type="file" name="edit_images" id="tools-img-' + response.data.id + '" accept="image/*" onchange="readURL(this, ' + response.data.id + ');" multiple />' +
                        '                                                    <label for="tools-img-' + response.data.id + '" class="tools-item">Ảnh/Video</label>' +
                        '                                                    <span class="tools-item show-edit-post-ganthe" onclick="ShowPostTools(0, ' + response.data.id + ')">Gắn thẻ bạn bè</span>' +
                        '                                                    <span class="tools-item show-edit-post-diadiem" onclick="ShowPostTools(1,' + response.data.id + ')">Check in</span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="modal-footer">' +
                        '                                                <div class="form-group">' +
                        '                                                    <select class="form-control" id="edit-post-baomat-data-' + response.data.id + '">' +
                        '                                                        <option selected value="0">Công khai</option>' +
                        '                                                        <option value="2">Bạn bè</option>' +
                        '                                                        <option value="3">Chỉ mình tôi</option>' +
                        '                                                    </select>' +
                        '                                                </div>' +
                        '                                                <button class="btn btn-primary" onclick="ActionEditPost(' + response.data.id + ')">' +
                        '                                                    Đăng' +
                        '                                                </button>' +
                        '                                            </div>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                </div>' +
                        '                            </header><!-- /header -->' +
                        '<div class="post-content">' +
                        '   <p id="post-content-text-' + response.data.id + '" class="post-content-text">' + response.data.noidung + '</p>';
                    if (response.data.anh.length != 0) {
                        html = html + ' <div id="post-content-image-' + response.data.id + '" class="post-content-image">';
                        if (response.data.anh.length == 1) {
                            html = html + '<img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[0]["id"] + ')" />'
                        }
                        else if (response.data.anh.length == 2) {
                            html = html + '<div class = "row soanh-2">';
                            response.data.anh.forEach(function (img) {
                                html = html + '<div class="col-md-6">' +
                                    '   <img src="' + baseUrl + '/Images/' + img["anh_url"] + '" alt="" onclick="ShowPostModal(' + img["id"] + ')" />' +
                                    '</div>';
                            });
                            html = html + '</div>';
                        }
                        else if (response.data.anh.length == 3) {
                            html = html + '<div class = "row soanh-3">' +
                                '   <div class="col-md-12">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[0]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[1]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[2]["id"] + ')" />' +
                                '   </div>' +
                                '</div>';
                        }
                        else if (response.data.anh.length == 4) {
                            html = html + '<div class = "row soanh-4">' +
                                '   <div class="col-md-12">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[0]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[1]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[2]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[3]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[3]["id"] + ')" />' +
                                '   </div>' +
                                '</div>';
                        }
                        else if (response.data.anh.length == 5) {
                            html = html + '<div class = "row soanh-5">' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[0]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-6">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[1]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[2]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[3]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[3]["id"] + ')" />' +
                                '   </div>' +
                                '   <div class="col-md-4">' +
                                '       <img src="' + baseUrl + '/Images/' + response.data.anh[4]["anh_url"] + '" alt="" onclick="ShowPostModal(' + response.data.anh[4]["id"] + ')" />' +
                                '   </div>' +
                                '</div>';
                        }
                        else {
                            alert("số ảnh lớn");
                        }
                        html = html + ' </div>';
                    }
                    html = html + ' </div>' +
                        '                       <div class="post-socialfunction">' +
                        '                            <section class="post-icons">' +
                        '                                <button type="button" class="btn btn-light post-like-icon" id="post-like-icon-' + response.data.id + '"><i class="fas fa-heart"></i></button>' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
                        '                                <button type="button" class="btn btn-light" data-toggle="modal" data-target="#post-share-' + response.data.id + '"><i class="far fa-paper-plane"></i></button>' +
                        '                                <button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>' +
                        '                            </section>' +
                        '                            <section class="list-like">' +
                        '                                <button type="button" class="btn btn-light like-count-' + response.data.id + '" id="like-count-' + response.data.id + '">0 lượt thích</button>' +
                        '                            </section>' +
                        '                            <section class="post-time">' +
                        '                                <p>2 giờ trước</p>' +
                        '                            </section>' +
                        '<div class="user-comments" id="user-comments-' + response.data.id + '">' +
                        '</div>' +
                        '                            <section class="comment-bar" id="comment-bar-' + response.data.id + '">' +
                        '                                <div class="form-group">' +
                        '                                    <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="post-comment-content-' + response.data.id + '"></textarea>' +
                        '                                </div>' +
                        '<button type="button" class="btn btn-light post-comment-button" id = "post-comment-button-' + response.data.id + '" > Đăng</button > ' +
                        '                            </section>' +
                        '                        </div>';
                    if (response.data.anh.length > 0) {
                        response.data.anh.forEach(function (add) {
                            html = html + '<!-- Modal -->' +
                                '                                    <div class="post-box-modal modal fade" id="modal-post-' + add.id + '">' +
                                '                                        <div class="modal-dialog modal-dialog-centered">' +
                                '                                            <div class="modal-content">' +
                                '                                                <div class="modal-col-7">' +
                                '                                                    <div class="post-content">' +
                                '                                                        <img class="" src="' + baseUrl + '/Images/' + add.anh_url + '" alt="">' +
                                '                                                    </div>' +
                                '                                                </div>' +
                                '                                                <div class="modal-col-5">' +
                                '                                                    <div class="post-title">' +
                                '                                                        <div class="post-info">' +
                                '                                                            <img height="50px" width="50px" class="rounded rounded-circle" src="' + baseUrl + '/Images/' + response.data.avatarnguoidang + '" alt="">' +
                                '                                                            <p id="modal-post-info-' + add.id + '"><a href="#" title="">' + response.data.tennguoidang + '</a></p>' +
                                '                                                        </div>' +
                                '                                                    </div>' +
                                '' +
                                '                                                    <p class="post-content-text" id="modal-post-content-text-' + add.id + '"> </p>' +
                                '                                                    <div class="post-socialfunction">' +
                                '' +
                                '                                                        <div class="user-comments" id="modal-user-comments-' + add.id + '">' +
                                '                                                        </div>' +
                                '                                                        <section class="post-icons">' +
                                '                                                            <button type="button" class="btn btn-light post-like-icon" id="modal-post-like-icon-' + add.id + '">' +
                                '                                                                <i class="fas fa-heart"></i>' +
                                '                                                            </button>' +
                                '                                                            <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
                                '                                                            <button type="button" class="btn btn-light"></button>' +
                                '                                                        </section>' +
                                '' +
                                '                                                        <section class="list-like">' +
                                '                                                            <button type="button" class="btn btn-light like-count-' + add.id + '" id="like-count-' + add.id + '">0 lượt thích</button>' +
                                '                                                            <div class="modal fade modal-list-like-post" id="modal-list-like-post-' + response.data.id + '" tabindex="-1" role="dialog">' +
                                '                                                                <div class="modal-dialog modal-dialog-centered" role="document">' +
                                '                                                                    <div class="modal-content">' +
                                '                                                                        <div class="modal-header">' +
                                '                                                                            <h5 class="modal-title" id="exampleModalLongTitle">Likes</h5>' +
                                '                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                                '                                                                                <span aria-hidden="true">×</span>' +
                                '                                                                            </button>' +
                                '                                                                        </div>' +
                                '                                                                        <div class="modal-body" id="modal-list-like-body-' + response.data.id + '">' +
                                '' +
                                '                                                                        </div>' +
                                '                                                                    </div>' +
                                '                                                                </div>' +
                                '                                                            </div>' +
                                '                                                        </section>' +
                                '                                                        <section class="post-time" id="modal-post-time-' + add.id + '">' +
                                '                                                            <p>2 giờ trước</p>' +
                                '                                                        </section>' +
                                '                                                        <section class="comment-bar" id="comment-bar-' + add.id + '">' +
                                '                                                            <div class="form-group">' +
                                '                                                                <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="modal-post-comment-content-' + add.id + '"></textarea>' +
                                '                                                            </div>' +
                                '                                                            <button type="button" class="btn btn-light modal-post-comment-button" id="modal-post-comment-button-' + add.id + '">Đăng</button>' +
                                '                                                        </section>' +
                                '                                                    </div>' +
                                '                                                </div>' +
                                '                                            </div>' +
                                '                                        </div>' +
                                '                                    </div>';
                        });
                    }
                    html = html + '              </article>';
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
                            add_friends.push(item);
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

function DeletePost(postId, e, userId) {
    e = e || window.event;
    e.preventDefault();
    $("#post-option-modal-" + postId).modal("hide");
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            //Gọi đến hàm real time
            DeletePostRT(postId, userId);
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        }
        else {
            $("#post-option-modal-" + postId).modal("show");
        }
    })
}

function EditPost(postId, e, userId) {
    e = e || window.event;
    e.preventDefault();
    $("#post-option-modal-" + postId).modal("hide");

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();
    formData.append('__RequestVerificationToken', token); //form[0]

    formData.append('img_post_id', postId);

    $.ajax({
        type: 'post',
        url: '/Client/Post/GetPostInfo',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status) {
                //truyền dữ liệu vào edit modal
                var url = window.location.href.split('/');
                var baseUrl = url[0] + '//' + url[2];
                var data = response.data;
                //
                $("#edit-result-tenbanbe-" + postId).empty();
                $("#edit-result-diadiem-" + postId).empty();
                $("#modal-body-result-img-" + postId).empty()
                $('#modal-body-result-img-' + postId).append('<label for="tools-img-' + postId + '" class="edit-tools-item" id="edit-post-anh-default-' + postId + '"><img src="' + baseUrl + '/Images/default-adding-post.png" alt="" /></label>');

                $("#edit-post-diadiem-data-" + postId).val("");
                $("#edit-post-diadiem-data-" + postId).val("");
                $("#friends-tag-" + postId).empty();
                $("#tools-img-" + postId).empty();
                edit_js = 0;
                //loại bỏ những thằng đã đc gắn thẻ
                edit_friends = [...friends].filter((item) => !data.ganthe.find(({ id }) => item.id === id));
                selected_edit_friends = [...friends].filter((item) => data.ganthe.find(({ id }) => item.id === id))

                //array.filter((elem) => !anotherArray.find(({ id }) => elem.id === id) && elem.sub);
                $("#user-ava-" + postId + " img").attr("src", baseUrl + "/Images/" + data.avatarnguoidang);
                $("#edit-post-content-" + postId).val(data.noidung);
                //check in 
                if (data.diadiem != null) {
                    $("#edit-result-diadiem-" + postId).html('tại <b id="result-diadiem-b-' + postId + '">' + data.diadiem + '</b>');
                    $("#edit-post-diadiem-data-" + postId).val(data.diadiem);
                }
                if (data.ganthe.length > 0) {
                    var html = "cùng với ";
                    var temp = "";
                    data.ganthe.forEach(function (item) {
                        html = html + '<span id="result-banbe-' + item.id + '-' + postId + '" class="result-banbe-b-' + postId + '"><b>' + item.ten + ', </b></span>';
                        temp = temp + '<div id = "friend-tag-' + item.id + '-' + postId + '" class = "friends-tag-span">' +
                            '<span id = "friend-tag-' + item.id + '-name">' + item.ten + '</span>' +
                            '<a href = "#" onclick="DeleteFriendTag(' + item.id + ', event,' + postId + ')">' +
                            '    <i class="fas fa-times"></i>' +
                            '</a>' +
                            '</div>';
                    });
                    $("#edit-result-tenbanbe-" + postId).html(html);
                    $("#friends-tag-" + postId).empty();
                    $("#friends-tag-" + postId).append(temp);
                }
                if (data.anh.length > 0) {
                    $('#modal-body-result-img-' + postId).empty();

                    $('#modal-body-result-img-' + postId).css("display", "flex");

                    var html1 = "";
                    data.anh.forEach(function (item) {
                        html1 = html1 + '<div class="edit-selected-post-img" id="edit-selected-img-' + postId + '-' + edit_js + '">' +
                            '   <img src="' + baseUrl + '/Images/' + item.anh_url + '" alt="" />' +
                            '   <div class="edit-div-close-post-img">' +
                            '       <button type="button" class="edit-close-post-img" onclick="ClosePostImage(' + edit_js + ', ' + postId + ')"><i class="fas fa-times"></i></button>' +
                            '   </div>' +
                            '</div>';

                        item["idz"] = edit_js;
                        edit_selected_img.push(item);
                        edit_js += 1;
                    });
                    $('#modal-body-result-img-' + postId).append('<label for="tools-img-' + postId + '" class="edit-tools-item" id="edit-post-anh-default-' + postId + '"><img src="' + baseUrl + '/Images/default-adding-post.png" alt="" /></label>');
                    $(html1).insertBefore('#edit-post-anh-default-' + postId);

                }
                //hiển thị modal
                $("#show-edit-post-" + postId).modal("show");
            }
        }
    });
    //EditPostRT(postId, userId);
}
function ActionEditPost(postId) {
    if ($("#edit-post-content-" + postId).val() == "") {
        alert("Bạn chưa nhập nội dung bài viết");
    }
    else {
        var friends_id = [];
        selected_edit_friends.forEach(function (item) {
            friends_id.push(item.id);
        })

        var post = {
            id: postId,
            content: $("#edit-post-content-" + postId).val(),
            location: $("#edit-post-diadiem-data-" + postId).val(),
            friends: friends_id,
            security: $("#edit-post-baomat-data-" + postId).val()
        };
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('post', JSON.stringify(post)); //fomr[1]

        for (var i = 0; i < edit_selected_img.length; i++) {
            if (edit_selected_img[i] instanceof File) {
                formData.append("post_images_" + i, edit_selected_img[i]);
            }
            else {
                formData.append("post_images_" + i, JSON.stringify(edit_selected_img[i]));
            }
        }

        $.ajax({
            type: 'post',
            url: '/Client/Post/ActionEditPost',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    EditSuccessPostRT(data);
                }
            }
        });
    }
}
$('.post-like-icon').click(function () {
    var post_id = this.id.split("-");
    post_id = post_id[post_id.length - 1]; // Lấy post_id
    if (this.className == "btn btn-light post-like-icon liked") {
        $("#post-like-icon-" + post_id).removeClass("liked");
        $("#modal-post-like-icon-" + post_id).removeClass("liked");
    }
    else {
        $("#post-like-icon-" + post_id).addClass("liked");
        $("#modal-post-like-icon-" + post_id).addClass("liked");
    }
});
$('.list-like button').click(function () {
    var post_id = this.id.split("-");
    post_id = post_id[post_id.length - 1]; // Lấy post_id
    if (this.innerHTML !== "0 lượt thích") {
        if ($("#modal-post-" + post_id).hasClass('show')) {
            $("#modal-list-like-post-" + post_id).modal("show");
        }
        else {
            $("#list-like-post-" + post_id).modal("show");
        }
    }
});

function DeletePostRT(post_id, userId) {

}

function EditSuccessPostRT(edit_post) {

}

// Bắt đầu hàm realtime
$(function () {
    // Reference the auto-generated proxy for the hub.
    var post = $.connection.postHub;
    // Create a function that the hub can call back to display messages.
    post.client.LikePost = function (postId, status) {
        var like_count = $(".like-count-" + postId).text().split(' ');
        if (status) {
            //$("#post-like-icon-" + postId).addClass("liked");
            $(".like-count-" + postId).text("");
            $(".like-count-" + postId).text((parseInt(like_count[0]) + 1) + " lượt thích");
        } else {
            //$("#post-like-icon-" + postId).removeClass("liked");
            $(".like-count-" + postId).text("");
            $(".like-count-" + postId).text((parseInt(like_count[0]) - 1) + " lượt thích");
        }
    };
    post.client.DeletePost = function (postId) {
        $(".post-" + postId).remove();
    };
    post.client.CommentPost = function (comment) {
        var url = window.location.href.split('/');
        var baseUrl = url[0] + '//' + url[2];
        if (comment.parent_id == null) {
            var html1 = '<div id="comment-item-' + comment.comment_id + '" class="comment-item">' +
                '                                            <div class="comment-item-parent" id="comment-item-parent-' + comment.comment_id + '">' +
                '                                                <div class="user-ava">' +
                '                                                    <img src="' + baseUrl + '/Images/' + comment.anhnguoidang + '" alt="">' +
                '                                                </div>' +
                '                                                <div class="comment-item-detail">' +
                '                                                    <h3 class="user-name">' + comment.tennguoidang + '</h3>' +
                '                                                    <span>' + comment.noidung + '</span>' +
                '                                                    <div class="comment-item-info">' +
                '                                                        <time datetime="2011-01-12" title="12 tháng 9 1945">Chưa làm</time>' +
                '                                                        <button type="button" class="btn btn-light">0 lượt thích</button>' +
                '                                                        <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(' + comment.comment_id + ')">Trả lời</button>' +
                '                                                    </div>' +
                '                                                </div>' +
                '                                                <div class="comment-item-tool">' +
                '                                                    <i class="far fa-heart"></i>' +
                '                                                </div>' +
                '                                            </div>' +
                '<section id="comment-bar-child-' + comment.comment_id + '" class="comment-bar-child">' +
                '   <div class="user-ava">' +
                '       <img src="#" alt="Alternate Text" />' +
                '   </div>' +
                '   <div class="form-group">' +
                '       <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="post-comment-child-content-' + comment.comment_id + '"></textarea>' +
                '   </div>' +
                '   <button type="button" class="btn btn-light post-comment-child-button" id="post-comment-child-button-' + comment.comment_id + '-' + comment.post_id + '">Đăng</button>' +
                '</section>' +
                '                                        </div>';

            var html2 = '<div id="comment-item-' + comment.comment_id + '" class="comment-item">' +
                '                                            <div class="comment-item-parent" id="modal-comment-item-parent-' + comment.comment_id + '">' +
                '                                                <div class="user-ava">' +
                '                                                    <img src="' + baseUrl + '/Images/' + comment.anhnguoidang + '" alt="">' +
                '                                                </div>' +
                '                                                <div class="comment-item-detail">' +
                '                                                    <h3 class="user-name">' + comment.tennguoidang + '</h3>' +
                '                                                    <span>' + comment.noidung + '</span>' +
                '                                                    <div class="comment-item-info">' +
                '                                                        <time datetime="2011-01-12" title="12 tháng 9 1945">Chưa làm</time>' +
                '                                                        <button type="button" class="btn btn-light">0 lượt thích</button>' +
                '                                                        <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(' + comment.comment_id + ')">Trả lời</button>' +
                '                                                    </div>' +
                '                                                </div>' +
                '                                                <div class="comment-item-tool">' +
                '                                                    <i class="far fa-heart"></i>' +
                '                                                </div>' +
                '                                            </div>' +
                '<section id="modal-comment-bar-child-' + comment.comment_id + '" class="comment-bar-child">' +
                '   <div class="user-ava">' +
                '       <img src="#" alt="Alternate Text" />' +
                '   </div>' +
                '   <div class="form-group">' +
                '       <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="modal-post-comment-child-content-' + comment.comment_id + '"></textarea>' +
                '   </div>' +
                '   <button type="button" class="btn btn-light modal-post-comment-child-button" id="modal-post-comment-child-button-' + comment.comment_id + '-' + comment.post_id + '">Đăng</button>' +
                '</section>' +
                '                                        </div>';
            if ($("#comment-list-" + comment.post_id).length > 0) {
                $("#comment-list-" + comment.post_id).append(html1);
                $('#post-comment-content-' + comment.post_id).val("");

                $("#modal-comment-list-" + comment.post_id).append(html2);
                $('#modal-post-comment-content-' + comment.post_id).val("");
            }
            else {
                var myvar = '<div id="comment-list-' + comment.post_id + '" class="comment-list">' +
                    '                                    </div>';
                $("#user-comments-" + comment.post_id).append(myvar);

                $("#comment-list-" + comment.post_id).append(html1);
                $('#post-comment-content-' + comment.post_id).val("");


                var myvar1 = '<div id="modal-comment-list-' + comment.post_id + '" class="comment-list">' +
                    '                                    </div>';
                $("#modal-user-comments-" + comment.post_id).append(myvar1);

                $("#modal-comment-list-" + comment.post_id).append(html2);
                $('#modal-post-comment-content-' + comment.post_id).val("");
            }
        } else {
            var html = '<div class="comment-item-child" id="comment-item-child-' + comment.comment_id + '">' +
                '                                                    <div class="user-ava">' +
                '                                                        <img src="' + baseUrl + '/Images/' + comment.anhnguoidang + '" alt="">' +
                '                                                    </div>' +
                '                                                    <div class="comment-item-detail">' +
                '                                                        <h3 class="user-name">' + comment.tennguoidang + '</h3>' +
                '                                                        <span>' + comment.noidung + '</span>' +
                '                                                        <div class="comment-item-info">' +
                '                                                            <time datetime="2011-01-12" title="12 tháng 9 1945">Chưa làm</time>' +
                '                                                            <button type="button" class="btn btn-light">0 lượt thích</button>' +
                '                                                            <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(' + comment.parent_id + ')">Trả lời</button>' +
                '                                                        </div>' +
                '                                                    </div>' +
                '                                                    <div class="comment-item-tool">' +
                '                                                        <i class="far fa-heart"></i>' +
                '                                                    </div>' +
                '                                                </div>';
            if ($("#comment-item-childs-" + comment.parent_id).length > 0) {
                $("#comment-childs-" + comment.parent_id).append(html);
                $("#post-comment-child-content-" + comment.parent_id).val("");

                $("#comment-item-childs-" + comment.parent_id + " > button").text("Xem câu trả lời (" + $("#comment-childs-" + comment.parent_id + " > .comment-item-child").length + ")");

                $("#modal-comment-childs-" + comment.parent_id).append(html);
                $("#modal-post-comment-child-content-" + comment.parent_id).val("");

                $("#modal-comment-item-childs-" + comment.parent_id + " > button").text("Xem câu trả lời (" + $("#comment-childs-" + comment.parent_id + " > .comment-item-child").length + ")");
            } else {
                var temp = '<div class="comment-item-childs" id="comment-item-childs-' + comment.parent_id + '">' +
                    '   <button data-toggle="collapse" data-target="#comment-childs-' + comment.parent_id + '" class="btn btn-light">Xem câu trả lời (1)</button>' +
                    '   <div id="comment-childs-' + comment.parent_id + '" class="collapse">' +
                    '   </div>' +
                    '</div>';
                $(temp).insertAfter($("#comment-item-parent-" + comment.parent_id));
                $("#comment-childs-" + comment.parent_id).append(html);
                $("#post-comment-child-content-" + comment.parent_id).val("");

                var temp1 = '<div class="comment-item-childs" id="modal-comment-item-childs-' + comment.parent_id + '">' +
                    '   <button data-toggle="collapse" data-target="#modal-comment-childs-' + comment.parent_id + '" class="btn btn-light">Xem câu trả lời (1)</button>' +
                    '   <div id="modal-comment-childs-' + comment.parent_id + '" class="collapse">' +
                    '   </div>' +
                    '</div>';
                $(temp1).insertAfter($("#modal-comment-item-parent-" + comment.parent_id));
                $("#modal-comment-childs-" + comment.parent_id).append(html);
                $("#modal-post-comment-child-content-" + comment.parent_id).val("");
            }
        }
    };
    post.client.ShowEditPost = function (editPost) {
        var url = window.location.href.split('/');
        var baseUrl = url[0] + '//' + url[2];
        if (editPost != null) {
            //sửa trên view trang chủ
            $("#show-edit-post-" + editPost.id).modal("hide"); //tắt edit modal
            $("#post-content-text-" + editPost.id).text(editPost.noidung); // sửa nội dung
            $(".post-user-info-" + editPost.id).empty() //sửa gắn thẻ và checkin
            $(".post-user-info-" + editPost.id).append('<a href="#" title="">' + editPost.tennguoidang + '</a>');
            if (editPost.ganthe.length > 0) {
                var html = '<span>với ';
                editPost.ganthe.forEach(function (ganthe) {
                    html = html + '<a href="#"><b>' + ganthe.ten + ', </b></a>';
                });
                html = html + '</span>';
                $(".post-user-info-" + editPost.id).append(html);
            }
            if (editPost.diadiem != null) {
                $(".post-user-info-" + editPost.id).append('<span>tại <b>' + editPost.diadiem + '</b></span>');
            }
            $("#post-content-image-" + editPost.id).empty() //sửa ảnh
            if (editPost.anh.length > 0) {
                if (editPost.anh.length == 1) {
                    $("#post-content-image-" + editPost.id).append('<img src="' + baseUrl + '/Images/' + editPost.anh[0].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[0].id + ')">')
                }
                else if (editPost.anh.length == 2) {
                    var html = '<div class="row soanh-2">';
                    editPost.anh.forEach(function (img) {
                        html = html + '<div class="col-md-6">' +
                            '<img src="' + baseUrl + '/Images/' + img.anh_url + '" alt="" onclick="ShowPostModal(' + img.id + ')" />' +
                            '</div>';
                    });
                    html = html + '</div>';
                    $("#post-content-image-" + editPost.id).append(html);
                }
                else if (editPost.anh.length == 3) {
                    var html = '<div class="row soanh-3">' +
                        '                        <div class="col-md-12">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[0].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[0].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-6">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[1].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[1].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-6">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[2].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[2].id + ')" />' +
                        '                        </div>' +
                        '                    </div>';
                    $("#post-content-image-" + editPost.id).append(html);
                }
                else if (editPost.anh.length == 4) {
                    var html = '<div class="row soanh-4">' +
                        '                        <div class="col-md-12">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[0].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[0].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[1].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[1].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[2].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[2].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[3].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[3].id + ')" />' +
                        '                        </div>' +
                        '                    </div>';
                    $("#post-content-image-" + editPost.id).append(html);
                }
                else if (editPost.anh.length == 5) {
                    var html = '<div class="row soanh-5">' +
                        '                        <div class="col-md-6">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[0].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[0].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-6">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[1].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[1].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[2].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[2].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[3].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[3].id + ')" />' +
                        '                        </div>' +
                        '                        <div class="col-md-4">' +
                        '                            <img src="' + baseUrl + '/Images/' + editPost.anh[4].anh_url + '" alt="" onclick="ShowPostModal(' + editPost.anh[4].id + ')" />' +
                        '                        </div>' +
                        '                    </div>';
                    $("#post-content-image-" + editPost.id).append(html);
                }
                else if (editPost.anh.length > 5) {
                    $("#post-content-image-" + editPost.id).append('<p class="text-center">Chức năng đang cập nhật</p>');
                }
            }
            var del_ids = []; // trạng thái trước khi sửa: cũ + hủy
            var temp = $(".post-" + editPost.id + " > .post-box-modal").map(function () {
                var t = $(this).attr('id').split('-');
                del_ids.push(t[t.length - 1]);
            });

            var add_ids = []; // trạng thái sau khi sửa: cũ + mới
            editPost.anh.forEach(function (remain) {
                add_ids.push((remain.id).toString());
            });
            //lấy bài viết mới   
            //1 2: trc
            //2 3 4 5: sau
            var new_ids = add_ids.filter(function (item) {
                return !del_ids.includes(item);
            });
            //lấy bài viết đã hủy
            var remove_ids = del_ids.filter(function (item) {
                return !add_ids.includes(item);
            });

            //hủy modal
            remove_ids.forEach(function (del) {
                $("#modal-post-" + del).remove();
            });
            //thêm mới modal
            editPost.anh.forEach(function (add) {
                if (new_ids.includes((add.id).toString())) {
                    var myvar = '<!-- Modal -->' +
                        '                                    <div class="post-box-modal modal fade" id="modal-post-' + add.id + '">' +
                        '                                        <div class="modal-dialog modal-dialog-centered">' +
                        '                                            <div class="modal-content">' +
                        '                                                <div class="modal-col-7">' +
                        '                                                    <div class="post-content">' +
                        '                                                        <img class="" src="' + baseUrl + '/Images/' + add.anh_url + '" alt="">' +
                        '                                                    </div>' +
                        '                                                </div>' +
                        '                                                <div class="modal-col-5">' +
                        '                                                    <div class="post-title">' +
                        '                                                        <div class="post-info">' +
                        '                                                            <img height="50px" width="50px" class="rounded rounded-circle" src="' + baseUrl + '/Images/' + editPost.avatarnguoidang + '" alt="">' +
                        '                                                            <p id="modal-post-info-' + add.id + '"><a href="#" title="">' + editPost.tennguoidang + '</a></p>' +
                        '                                                        </div>' +
                        '                                                    </div>' +
                        '' +
                        '                                                    <p class="post-content-text" id="modal-post-content-text-' + add.id + '></p>' +
                        '                                                    <div class="post-socialfunction">' +
                        '' +
                        '                                                        <div class="user-comments" id="modal-user-comments-' + add.id + '">' +
                        '                                                        </div>' +
                        '                                                        <section class="post-icons">' +
                        '                                                            <button type="button" class="btn btn-light post-like-icon" id="modal-post-like-icon-' + add.id + '">' +
                        '                                                                <i class="fas fa-heart"></i>' +
                        '                                                            </button>' +
                        '                                                            <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
                        '                                                            <button type="button" class="btn btn-light"></button>' +
                        '                                                        </section>' +
                        '' +
                        '                                                        <section class="list-like">' +
                        '                                                            <button type="button" class="btn btn-light like-count-' + add.id + '" id="like-count-' + add.id + '">0 lượt thích</button>' +
                        '                                                            <div class="modal fade modal-list-like-post" id="modal-list-like-post-' + editPost.id + '" tabindex="-1" role="dialog">' +
                        '                                                                <div class="modal-dialog modal-dialog-centered" role="document">' +
                        '                                                                    <div class="modal-content">' +
                        '                                                                        <div class="modal-header">' +
                        '                                                                            <h5 class="modal-title" id="exampleModalLongTitle">Likes</h5>' +
                        '                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                        '                                                                                <span aria-hidden="true">×</span>' +
                        '                                                                            </button>' +
                        '                                                                        </div>' +
                        '                                                                        <div class="modal-body" id="modal-list-like-body-' + editPost.id + '">' +
                        '' +
                        '                                                                        </div>' +
                        '                                                                    </div>' +
                        '                                                                </div>' +
                        '                                                            </div>' +
                        '                                                        </section>' +
                        '                                                        <section class="post-time" id="modal-post-time-' + add.id + '">' +
                        '                                                            <p>2 giờ trước</p>' +
                        '                                                        </section>' +
                        '                                                        <section class="comment-bar" id="comment-bar-' + add.id + '">' +
                        '                                                            <div class="form-group">' +
                        '<textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="modal-post-comment-content-' + add.id + '"></textarea>' +
                        '</div>' +
                        '                                                            <button type="button" class="btn btn-light modal-post-comment-button" id="modal-post-comment-button-' + add.id + '">Đăng</button>' +
                        '                                                        </section>' +
                        '                                                    </div>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                        </div>' +
                        '                                    </div>';
                    $(myvar).insertBefore("#share-post-" + editPost.id);
                }
            });
        }
    };
    post.client.ShowListLike = function (listlike, postId) {
        var html = '';

        var url = window.location.href.split('/');
        var baseUrl = url[0] + '//' + url[2];
        listlike.forEach(function (like_item) {
            html = html + '<div class="list-like-item">' +
                '                                                            <div class="list-like-item-ava" id="list-like-item-ava-' + like_item.idnguoithich + '">' +
                '                                                                <img src="' + baseUrl + '/Images/' + like_item.anhnguoithich + '" alt="Alternate Text" />' +
                '                                                            </div>' +
                '                                                            <p class="list-like-item-name" id="list-like-item-name-' + like_item.idnguoithich + '"><a href="/Client/Personal/Index/' + like_item.idnguoithich + '">' + like_item.tennguoithich + '</a></p>' +
                '                                                            <button class="btn btn-primary ml-auto">Thêm bạn</button>' +
                '                                                        </div>';
        });
        if ($("#modal-post-" + post_id).hasClass('show')) {
            $("#modal-list-like-body-" + postId).empty();
            $("#modal-list-like-body-" + postId).append(html);
        }
        else {
            $("#list-like-body-" + postId).empty();
            $("#list-like-body-" + postId).append(html);
        }
    }
    $.connection.hub.qs = { "session_userId": session_userId };
    // Start the connection.
    $.connection.hub.start().done(function () {

        DeletePostRT = function (post_id, userId) {
            post.server.deletePost(post_id, userId);
        }
        EditSuccessPostRT = function (edit_post) {
            post.server.showEditPost(edit_post);
        }
        $('.user-newsfeed').on('click', '.post-like-icon', function () {
            var post_id = this.id.split("-");
            post_id = post_id[post_id.length - 1]; // Lấy post_id

            if (this.className == "btn btn-light post-like-icon liked") {
                post.server.likePost(post_id, true);
            }
            else {
                post.server.likePost(post_id, false);
            }
        });
        $('.user-newsfeed').on('click', '.post-comment-button', function () {
            var post_id = this.id.split("-");
            post_id = post_id[post_id.length - 1]; // Lấy post_id
            var content = $('#post-comment-content-' + post_id).val();
            if (content !== "") {
                post.server.commentPost(post_id, content, -1);
            } else {
                //Để nút đăng disable
            }
        });
        $('.user-newsfeed').on('click', '.post-comment-child-button', function () {
            //console.table(this);
            var data = this.id.split("-");
            comment_id = data[data.length - 2]; // Lấy comment_id
            post_id = data[data.length - 1];
            var content = $('#post-comment-child-content-' + comment_id).val();
            if (content !== "") {
                post.server.commentPost(post_id, content, comment_id);
            } else {
                //Để nút đăng disable
            }
        });

        $('.user-newsfeed').on('click', '.list-like button', function () {
            //console.table(this);
            var data = this.id.split("-");

            post_id = data[data.length - 1];
            if (this.innerText !== "0 lượt thích") {
                post.server.showListLike(post_id);
            } else {
                //
            }
        });

        $('.user-newsfeed').on('click', '.modal-post-comment-button', function () {
            var post_id = this.id.split("-");
            post_id = post_id[post_id.length - 1]; // Lấy post_id
            var content = $('#modal-post-comment-content-' + post_id).val();
            if (content !== "") {
                post.server.commentPost(post_id, content, -1);
            } else {
                //Để nút đăng disable
            }
        });

        $('.user-newsfeed').on('click', '.modal-post-comment-child-button', function () {
            //console.table(this);
            var data = this.id.split("-");
            comment_id = data[data.length - 2]; // Lấy comment_id
            post_id = data[data.length - 1];
            var content = $('#modal-post-comment-child-content-' + comment_id).val();
            if (content !== "") {
                post.server.commentPost(post_id, content, comment_id);
            } else {
                //Để nút đăng disable
            }
        });
    });
});

function ShowCommentBarChild(commentID) {
    if ($("#comment-bar-child-" + commentID).css("display") === "none" || $("#modal-comment-bar-child-" + commentID).css("display") === "none") {
        $("#comment-bar-child-" + commentID).css("display", "flex");
        $("#modal-comment-bar-child-" + commentID).css("display", "flex");

        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();
        formData.append('__RequestVerificationToken', token); //form[0]

        $.ajax({
            type: 'post',
            url: '/Client/Post/GetUserAvatar',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    $("#comment-bar-child-" + commentID + " .user-ava img").attr("src", baseUrl + "/Images/" + response.data);
                    $("#modal-comment-bar-child-" + commentID + " .user-ava img").attr("src", baseUrl + "/Images/" + response.data);
                }
            }
        });
    }
    //else {
    //    $("#comment-bar-child-" + commentID).css("display", "none");
    //}
}

function ShowPostModal(img_post_id) {

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();
    formData.append('__RequestVerificationToken', token); //form[0]

    formData.append('img_post_id', img_post_id);

    $.ajax({
        type: 'post',
        url: '/Client/Post/GetPostInfo',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status) {
                var url = window.location.href.split('/');
                var baseUrl = url[0] + '//' + url[2];
                var post = response.data;
                $("#modal-post-content-text-" + img_post_id).text(post.noidung);

                //gắn thẻ và checkin
                var html = '';
                if (post.ganthe.length > 0) {
                    html = html + '<span>với ';
                    post.ganthe.forEach(function (ganthe) {
                        html = html + '<a href="#" title=""><b>' + ganthe["ten"] + '</b></a>, ';
                    });
                    html = html + '</span>';

                }
                if (post.diadiem != null) {
                    html = html + '<span> tại <b>' + post.diadiem + '</b></span>';
                }
                $("#modal-post-info-" + img_post_id).empty();
                $("#modal-post-info-" + img_post_id).append('<a href="#" title="">' + post.tennguoidang + '</a>' + html);

                $(".like-count-" + img_post_id).text(post.luotthich + " lượt thích");

                var post_comment = '';

                if (post.comment.length > 0) {
                    post_comment = post_comment + '<div id="modal-comment-list-' + img_post_id + '" class="comment-list">';
                    post.comment.forEach(function (item) {
                        post_comment = post_comment + '<div class="comment-item" id="comment-item-' + item.comment_id + '">' +
                            '                    <div class="comment-item-parent" id="modal-comment-item-parent-' + item.comment_id + '">' +
                            '                        <div class="user-ava">' +
                            '                            <img src="' + baseUrl + '/Images/' + item.anhnguoidang + '" alt="">' +
                            '                                                        </div>' +
                            '                            <div class="comment-item-detail">' +
                            '                                <h3 class="user-name"><a href="/Client/Personal/Index/' + item.idnguoidang + '">' + item.tennguoidang + '</a></h3>' +
                            '                                <span>' + item.noidung + '</span>' +
                            '                                <div class="comment-item-info">' +
                            '                                    <time datetime="2011-01-12" title="12 tháng 9 1945">Chưa làm</time>' +
                            '                                    <button type="button" class="btn btn-light">' + item.luotthich + ' lượt thích</button>' +
                            '                                    <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(' + item.comment_id + ')">Trả lời</button>' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <div class="comment-item-tool">' +
                            '                                <i class="far fa-heart"></i>' +
                            '                            </div>' +
                            '                        </div>';
                        if (item.comment_child.length > 0) {

                            post_comment = post_comment + '<div class="comment-item-childs" id="modal-comment-item-childs-' + item.comment_id + '">' +
                                '        <button data-toggle="collapse" data-target="#modal-comment-childs-' + item.comment_id + '" class="btn btn-light">Xem câu trả lời (' + item.luotbinhluan + ')</button>' +
                                '        <div id="modal-comment-childs-' + item.comment_id + '" class="collapse">';
                            item.comment_child.forEach(function (item_child) {
                                post_comment = post_comment + '<div class="comment-item-child">' +
                                    '                <div class="user-ava">' +
                                    '                    <img src="' + baseUrl + '/Images/' + item_child.anhnguoidang + '" alt="">' +
                                    '                                                                        </div>' +
                                    '                    <div class="comment-item-detail">' +
                                    '                        <h3 class="user-name"><a href="/Client/Personal/Index/' + item.idnguoidang + '">' + item_child.tennguoidang + '</a></h3>' +
                                    '                        <span>' + item_child.noidung + '</span>' +
                                    '                        <div class="comment-item-info">' +
                                    '                            <time datetime="2011-01-12" title="12 tháng 9 1945">Chưa làm</time>' +
                                    '                            <button type="button" class="btn btn-light">? lượt thích</button>' +
                                    '                            <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(' + item_child.parent_id + ')">Trả lời</button>' +
                                    '                        </div>' +
                                    '                    </div>' +
                                    '                    <div class="comment-item-tool">' +
                                    '                        <i class="far fa-heart"></i>' +
                                    '                    </div>' +
                                    '                </div>';
                            });
                            post_comment = post_comment + '</div>' +
                                '</div>';
                        }
                        post_comment = post_comment + '<section class="comment-bar-child" id="modal-comment-bar-child-' + item.comment_id + '">' +
                            '    <div class="user-ava">' +
                            '        <img src="/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="Alternate Text" />' +
                            '    </div>' +
                            '    <div class="form-group">' +
                            '        <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="modal-post-comment-child-content-' + item.comment_id + '"></textarea>' +
                            '    </div>' +
                            '    <button type="button" class="btn btn-light modal-post-comment-child-button" id="modal-post-comment-child-button-' + item.comment_id + '-' + item.post_id + '">Đăng</button>' +
                            '</section>' +
                            '</div >';
                    });
                    post_comment = post_comment + '</div>' +
                        '</div>';
                }
                $("#modal-user-comments-" + img_post_id).empty();
                $("#modal-user-comments-" + img_post_id).append(post_comment);
                $("#modal-post-" + img_post_id).modal("show");
            }
        }
    });
}