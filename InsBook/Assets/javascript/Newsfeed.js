$(document).ready(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() >= $(document).height() - 2 * $(window).height()) {
            $.ajax({
                type: 'get',
                url: '/Client/Post/GetAllPostNewsFeed',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        var url = window.location.href.split('/');
                        var baseUrl = url[0] + '//' + url[2];
                        response.baiviet.forEach(function (baiviet) {
                            var html = '<article class="post-box post-' + baiviet.id + '">' +
                                '                        <header class="post-title">' +
                                '                            <div class="post-info">' +
                                '                                <img src="' + baseUrl + '/Images/' + baiviet.avatarnguoidang + '" alt="" class="rounded rounded-circle lazy" width="50px" height="50px">' +
                                '                                <p class="post-user-info-' + baiviet.id + '">' +
                                '                                    <a href="#" title="">' + baiviet.tennguoidang + '</a>';
                            if (baiviet.ganthe.length != 0) {
                                html = html + '<span>với ';
                                baiviet.ganthe.forEach(function (ganthe) {
                                    html = html + '<a href="#" title=""><b>' + ganthe["ten"] + '</b></a>, ';
                                });
                                html = html + '</span>';
                            }
                            if (baiviet.diadiem != "") {
                                html = html + '<span> tại <b>' + baiviet.diadiem + '</b></span>';
                            }

                            html = html + '</p>' +
                                '                                </div>' +
                                '                                <div class="post-option" data-target="#post-option-modal-' + baiviet.id + '" data-toggle="modal">' +
                                '                                    &#8230;' +
                                '                                </div>' +
                                '                                <div class="modal post-option-modal fade" id="post-option-modal-' + baiviet.id + '">' +
                                '                                    <div class="modal-dialog modal-dialog-centered">' +
                                '                                        <div class="modal-content">' +
                                '                                            <div class="modal-body">' +
                                '                                                <ul>' +
                                '                                                    <li>' +
                                '                                                        <a class="report" href="">Báo cáo</a>' +
                                '                                                    </li>' +
                                '                                                    <li>' +
                                '                                                        <a href="#" onclick="EditPost(' + baiviet.id + ', event, ' + session_userId + ')">Sửa bài viết</a>' +
                                '                                                    </li>' +
                                '                                                    <li>' +
                                '                                                        <a href="#" onclick="DeletePost(' + baiviet.id + ', event, ' + session_userId + ')">Xóa bài viết</a>' +
                                '                                                    </li>' +
                                '                                                </ul>' +
                                '                                            </div>' +
                                '                                        </div>' +
                                '                                    </div>' +
                                '                                </div>' +
                                '<!-- Modal -->' +
                                '                                <div class="modal fade show-edit-post-modal" id="show-edit-post-' + baiviet.id + '" tabindex="-1" role="dialog">' +
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
                                '                                                    <div class="user-ava" id="user-ava-' + baiviet.id + '">' +
                                '                                                        <img src="' + baseUrl + '/Images/' + baiviet.avatarnguoidang + '" alt="" />' +
                                '                                                    </div>' +
                                '                                                    <div class="form-group">' +
                                '<textarea class="form-control" id="edit-post-content-' + baiviet.id + '" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>' +
                                '</div>' +
                                '                                                </div>' +
                                '                                                <div class="modal-body-result">' +
                                '                                                    <p class="modal-body-result-text"><span class="edit-result-tenbanbe" id="edit-result-tenbanbe-' + baiviet.id + '"></span><span class="edit-result-diadiem" id="edit-result-diadiem-' + baiviet.id + '"></span></p>' +
                                '                                                    <div class="modal-body-result-img" id="modal-body-result-img-' + baiviet.id + '">' +
                                '                                                        <label for="tools-img-' + baiviet.id + '" class="edit-tools-item" id="edit-post-anh-default-' + baiviet.id + '"><img src="/Images/default-adding-post.png" alt="" /></label>' +
                                '                                                    </div>' +
                                '                                                </div>' +
                                '                                                <div class="input-group modal-body-input edit-post-diadiem" id="edit-post-diadiem-' + baiviet.id + '">' +
                                '                                                    <div class="input-group-prepend">' +
                                '                                                        <div class="input-group-text"><i class="fas fa-map-marker-alt"></i></div>' +
                                '                                                    </div>' +
                                '                                                    <input type="text" class="form-control edit-post-diadiem-data" id="edit-post-diadiem-data-' + baiviet.id + '" placeholder="Bạn đang ở đâu ?">' +
                                '                                                </div>' +
                                '                                                <div class="input-group modal-body-input edit-post-ganthe" id="edit-post-ganthe-' + baiviet.id + '">' +
                                '                                                    <div class="input-group-prepend">' +
                                '                                                        <div class="input-group-text"><i class="fas fa-user"></i></div>' +
                                '                                                    </div>' +
                                '                                                    <div id="friends-tag-' + baiviet.id + '" class="edit-friends-tag">' +
                                '' +
                                '                                                    </div>' +
                                '                                                    <input type="text" class="form-control edit-post-bande-data" id="edit-post-banbe-data-' + baiviet.id + '" placeholder="Cùng với ai ?">' +
                                '                                                </div>' +
                                '                                                <div class="input-group modal-body-input edit-post-chude" id="edit-post-chude-' + baiviet.id + '">' +
                                '                                                    <div class="input-group-prepend">' +
                                '                                                        <div class="input-group-text"><i class="fas fa-filter"></i></div>' +
                                '                                                    </div>' +
                                '                                                    <input type="text" class="form-control" id="" placeholder="Chủ đề bài viết ?">' +
                                '                                                </div>' +
                                '                                                <div class="modal-body-tools">' +
                                '                                                    <input class="tools-img" type="file" name="edit_images" id="tools-img-' + baiviet.id + '" accept="image/*" onchange="readURL(this, ' + baiviet.id + ');" multiple />' +
                                '                                                    <label for="tools-img-' + baiviet.id + '" class="tools-item">Ảnh/Video</label>' +
                                '                                                    <span class="tools-item show-edit-post-ganthe" onclick="ShowPostTools(0, ' + baiviet.id + ')">Gắn thẻ bạn bè</span>' +
                                '                                                    <span class="tools-item show-edit-post-diadiem" onclick="ShowPostTools(1,' + baiviet.id + ')">Check in</span>' +
                                '                                                </div>' +
                                '                                            </div>' +
                                '                                            <div class="modal-footer">' +
                                '                                                <div class="form-group">' +
                                '                                                    <select class="form-control" id="edit-post-baomat-data-' + baiviet.id + '">' +
                                '                                                        <option selected value="0">Công khai</option>' +
                                '                                                        <option value="2">Bạn bè</option>' +
                                '                                                        <option value="3">Chỉ mình tôi</option>' +
                                '                                                    </select>' +
                                '                                                </div>' +
                                '                                                <button class="btn btn-primary" onclick="ActionEditPost(' + baiviet.id + ')">' +
                                '                                                    Đăng' +
                                '                                                </button>' +
                                '                                            </div>' +
                                '                                        </div>' +
                                '                                    </div>' +
                                '                                </div>' +
                                '                            </header><!-- /header -->' +
                                '<div class="post-content">' +
                                '   <p id="post-content-text-' + baiviet.id + '" class="post-content-text">' + baiviet.noidung + '</p>';
                            if (baiviet.anh.length != 0) {
                                html = html + ' <div id="post-content-image-' + baiviet.id + '" class="post-content-image">';
                                if (baiviet.anh.length == 1) {
                                    html = html + '<img src="' + baseUrl + '/Images/' + baiviet.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[0]["id"] + ')" />'
                                }
                                else if (baiviet.anh.length == 2) {
                                    html = html + '<div class = "row soanh-2">';
                                    baiviet.anh.forEach(function (img) {
                                        html = html + '<div class="col-md-6">' +
                                            '   <img src="' + baseUrl + '/Images/' + img["anh_url"] + '" alt="" onclick="ShowPostModal(' + img["id"] + ')" />' +
                                            '</div>';
                                    });
                                    html = html + '</div>';
                                }
                                else if (baiviet.anh.length == 3) {
                                    html = html + '<div class = "row soanh-3">' +
                                        '   <div class="col-md-12">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[0]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-6">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[1]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-6">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[2]["id"] + ')" />' +
                                        '   </div>' +
                                        '</div>';
                                }
                                else if (baiviet.anh.length == 4) {
                                    html = html + '<div class = "row soanh-4">' +
                                        '   <div class="col-md-12">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[0]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[1]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[2]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[3]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[3]["id"] + ')" />' +
                                        '   </div>' +
                                        '</div>';
                                }
                                else if (baiviet.anh.length == 5) {
                                    html = html + '<div class = "row soanh-5">' +
                                        '   <div class="col-md-6">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[0]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[0]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-6">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[1]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[1]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[2]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[2]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[3]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[3]["id"] + ')" />' +
                                        '   </div>' +
                                        '   <div class="col-md-4">' +
                                        '       <img src="' + baseUrl + '/Images/' + baiviet.anh[4]["anh_url"] + '" alt="" onclick="ShowPostModal(' + baiviet.anh[4]["id"] + ')" />' +
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
                                '                                <button type="button" class="btn btn-light post-like-icon" id="post-like-icon-' + baiviet.id + '"><i class="fas fa-heart"></i></button>' +
                                '                                <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
                                '                                <button type="button" class="btn btn-light" data-toggle="modal" data-target="#post-share-' + baiviet.id + '"><i class="far fa-paper-plane"></i></button>' +
                                '                                <button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>' +
                                '                            </section>' +
                                '                            <section class="list-like">' +
                                '                                <button type="button" class="btn btn-light like-count-' + baiviet.id + '" id="like-count-' + baiviet.id + '">0 lượt thích</button>' +
                                '                            </section>' +
                                '                            <section class="post-time">' +
                                '                                <p>2 giờ trước</p>' +
                                '                            </section>' +
                                '<div class="user-comments" id="user-comments-' + baiviet.id + '">' +
                                '</div>' +
                                '                            <section class="comment-bar" id="comment-bar-' + baiviet.id + '">' +
                                '                                <div class="form-group">' +
                                '                                    <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="post-comment-content-' + baiviet.id + '"></textarea>' +
                                '                                </div>' +
                                '<button type="button" class="btn btn-light post-comment-button" id = "post-comment-button-' + baiviet.id + '" > Đăng</button > ' +
                                '                            </section>' +
                                '                        </div>';
                            if (baiviet.anh.length > 0) {
                                baiviet.anh.forEach(function (add) {
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
                                        '                                                            <img height="50px" width="50px" class="rounded rounded-circle" src="' + baseUrl + '/Images/' + baiviet.avatarnguoidang + '" alt="">' +
                                        '                                                            <p id="modal-post-info-' + add.id + '"><a href="#" title="">' + baiviet.tennguoidang + '</a></p>' +
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
                                        '                                                            <div class="modal fade modal-list-like-post" id="modal-list-like-post-' + baiviet.id + '" tabindex="-1" role="dialog">' +
                                        '                                                                <div class="modal-dialog modal-dialog-centered" role="document">' +
                                        '                                                                    <div class="modal-content">' +
                                        '                                                                        <div class="modal-header">' +
                                        '                                                                            <h5 class="modal-title" id="exampleModalLongTitle">Likes</h5>' +
                                        '                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                                        '                                                                                <span aria-hidden="true">×</span>' +
                                        '                                                                            </button>' +
                                        '                                                                        </div>' +
                                        '                                                                        <div class="modal-body" id="modal-list-like-body-' + baiviet.id + '">' +
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
                                });
                            }

                            html = html + '              </article>';
                            $('.user-newsfeed').append(html);
                            $('.lazy').Lazy();
                        }
                                
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
    $('.lazy').Lazy();
}