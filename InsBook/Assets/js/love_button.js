﻿
//var html = '<article class="post-box post-@post.id">' +
//	'                                <header class="post-title">' +
//	'                                    <div class="post-info">' +
//	'                                        <img src="/Images/@post.avatarnguoidang" class="rounded rounded-circle lazy" width="50px" height="50px" alt="">' +
//	'                                        <p class="post-user-info-@post.id">' +
//	'                                            <a href="/Client/Personal/Index/@post.idnguoidang" title="">@post.tennguoidang</a>' +
//	'                                            @if (post.ganthe.Count != 0)' +
//	'                                            {' +
//	'                                                <span>' +
//	'                                                    với' +
//	'                                                    @foreach (var ganthe in post.ganthe)' +
//	'                                                    {' +
//	'                                                        <a href="/Client/Personal/Index/@ganthe.id"><b>@ganthe.ten, </b></a>' +
//	'                                                    }' +
//	'                                                </span>' +
//	'                                            }' +
//	'                                            @if (post.diadiem != null)' +
//	'                                            {' +
//	'                                                <span>tại <b>@post.diadiem</b></span>' +
//	'                                            }' +
//	'                                        </p>' +
//	'                                    </div>' +
//	'                                    <div class="post-option" data-target="#post-option-modal-@post.id" data-toggle="modal">' +
//	'                                        …' +
//	'                                    </div>' +
//	'                                    <div class="modal post-option-modal fade" id="post-option-modal-@post.id">' +
//	'                                        <div class="modal-dialog modal-dialog-centered">' +
//	'                                            <div class="modal-content">' +
//	'                                                <div class="modal-body">' +
//	'                                                    <ul>' +
//	'                                                        <li>' +
//	'                                                            <a class="report" href="#">Báo cáo</a>' +
//	'                                                        </li>' +
//	'                                                        @if (userID == post.idnguoidang)' +
//	'                                                        {' +
//	'                                                            <li>' +
//	'                                                                <a href="#" onclick="EditPost(@post.id, event, @userID)">Sửa bài viết</a>' +
//	'                                                            </li>' +
//	'                                                            <li>' +
//	'                                                                <a href="#" onclick="DeletePost(@post.id, event, @userID)">Xóa bài viết</a>' +
//	'                                                            </li>' +
//	'                                                        }' +
//	'                                                    </ul>' +
//	'                                                </div>' +
//	'                                            </div>' +
//	'                                        </div>' +
//	'                                    </div>' +
//	'' +
//	'                                    <!-- Modal -->' +
//	'                                    <div class="modal fade show-edit-post-modal" id="show-edit-post-@post.id" tabindex="-1" role="dialog">' +
//	'                                        <div class="modal-dialog modal-dialog-centered" role="document">' +
//	'                                            <div class="modal-content">' +
//	'                                                <div class="modal-header">' +
//	'                                                    <h3><i class="fas fa-pencil-alt"></i>Sửa bài viết</h3>' +
//	'                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
//	'                                                        <span aria-hidden="true">×</span>' +
//	'                                                    </button>' +
//	'                                                </div>' +
//	'                                                <div class="modal-body">' +
//	'                                                    <div class="modal-body-content">' +
//	'                                                        <div class="user-ava" id="user-ava-@post.id">' +
//	'                                                            <img src="~/Images/@Profile.anhdd" alt="" />' +
//	'                                                        </div>' +
//	'                                                        <div class="form-group">' +
//	'															<textarea class="form-control" id="edit-post-content-@post.id" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>' +
//	'														 </div>' +
//	'                                                    </div>' +
//	'                                                    <div class="modal-body-result">' +
//	'                                                        <p class="modal-body-result-text"><span class="edit-result-tenbanbe" id="edit-result-tenbanbe-@post.id"></span><span class="edit-result-diadiem" id="edit-result-diadiem-@post.id"></span></p>' +
//	'                                                        <div class="modal-body-result-img" id="modal-body-result-img-@post.id">' +
//	'                                                            <label for="tools-img-@post.id" class="edit-tools-item" id="edit-post-anh-default-@post.id"><img src="/Images/default-adding-post.png" alt="" /></label>' +
//	'                                                        </div>' +
//	'                                                    </div>' +
//	'                                                    <div class="input-group modal-body-input edit-post-diadiem" id="edit-post-diadiem-@post.id">' +
//	'                                                        <div class="input-group-prepend">' +
//	'                                                            <div class="input-group-text"><i class="fas fa-map-marker-alt"></i></div>' +
//	'                                                        </div>' +
//	'                                                        <input type="text" class="form-control edit-post-diadiem-data" id="edit-post-diadiem-data-@post.id" placeholder="Bạn đang ở đâu ?">' +
//	'                                                    </div>' +
//	'                                                    <div class="input-group modal-body-input edit-post-ganthe" id="edit-post-ganthe-@post.id">' +
//	'                                                        <div class="input-group-prepend">' +
//	'                                                            <div class="input-group-text"><i class="fas fa-user"></i></div>' +
//	'                                                        </div>' +
//	'                                                        <div id="friends-tag-@post.id" class="edit-friends-tag">' +
//	'' +
//	'                                                        </div>' +
//	'                                                        <input type="text" class="form-control edit-post-bande-data" id="edit-post-banbe-data-@post.id" placeholder="Cùng với ai ?">' +
//	'                                                    </div>' +
//	'                                                    <div class="input-group modal-body-input edit-post-chude" id="edit-post-chude-@post.id">' +
//	'                                                        <div class="input-group-prepend">' +
//	'                                                            <div class="input-group-text"><i class="fas fa-filter"></i></div>' +
//	'                                                        </div>' +
//	'                                                        <input type="text" class="form-control" id="" placeholder="Chủ đề bài viết ?">' +
//	'                                                    </div>' +
//	'                                                    <div class="modal-body-tools">' +
//	'                                                        <input class="tools-img" type="file" name="edit_images" id="tools-img-@post.id" accept="image/*" onchange="readURL(this, @post.id);" multiple />' +
//	'                                                        <label for="tools-img-@post.id" class="tools-item">Ảnh/Video</label>' +
//	'                                                        <span class="tools-item show-edit-post-ganthe" onclick="ShowPostTools(0, @post.id)">Gắn thẻ bạn bè</span>' +
//	'                                                        <span class="tools-item show-edit-post-diadiem" onclick="ShowPostTools(1, @post.id)">Check in</span>' +
//	'                                                        @*<span class="tools-item show-post-chude" onclick="ShowPostTools(2)" disabled>Chủ đề</span>*@' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                                <div class="modal-footer">' +
//	'                                                    <div class="form-group">' +
//	'                                                        <select class="form-control" id="edit-post-baomat-data-@post.id">' +
//	'                                                            <option selected value="0">Công khai</option>' +
//	'                                                            <option value="2">Bạn bè</option>' +
//	'                                                            <option value="3">Chỉ mình tôi</option>' +
//	'                                                        </select>' +
//	'                                                    </div>' +
//	'                                                    <button class="btn btn-primary" onclick="ActionEditPost(@post.id)">' +
//	'                                                        Đăng' +
//	'                                                    </button>' +
//	'                                                </div>' +
//	'                                            </div>' +
//	'                                        </div>' +
//	'                                    </div>' +
//	'                                </header><!-- /header -->' +
//	'                                <div class="post-content">' +
//	'                                    <p class="post-content-text" id="post-content-text-@post.id">@post.noidung</p>' +
//	'                                    @if (post.anh.Count != 0)' +
//	'                                    {' +
//	'                                        <div id="post-content-image-@post.id" class="post-content-image">' +
//	'                                            @if (post.anh.Count == 1)' +
//	'                                            {' +
//	'                                                <img src="/Images/@post.anh[0].anh_url" alt="" onclick="ShowPostModal(@post.anh[0].id)">' +
//	'                                            }' +
//	'                                            else if (post.anh.Count == 2)' +
//	'                                            {' +
//	'                                                <div class="row soanh-2">' +
//	'                                                    @foreach (var img in post.anh)' +
//	'                                                    {' +
//	'                                                        <div class="col-md-6">' +
//	'                                                            <img src="/Images/@img.anh_url" alt="" onclick="ShowPostModal(@img.id)" />' +
//	'                                                        </div>' +
//	'                                                    }' +
//	'                                                </div>' +
//	'                                            }' +
//	'                                            else if (post.anh.Count == 3)' +
//	'                                            {' +
//	'                                                <div class="row soanh-3">' +
//	'                                                    <div class="col-md-12">' +
//	'                                                        <img src="/Images/@post.anh[0].anh_url" alt="" onclick="ShowPostModal(@post.anh[0].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-6">' +
//	'                                                        <img src="/Images/@post.anh[1].anh_url" alt="" onclick="ShowPostModal(@post.anh[1].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-6">' +
//	'                                                        <img src="/Images/@post.anh[2].anh_url" alt="" onclick="ShowPostModal(@post.anh[2].id)" />' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                            }' +
//	'                                            else if (post.anh.Count == 4)' +
//	'                                            {' +
//	'                                                <div class="row soanh-4">' +
//	'                                                    <div class="col-md-12">' +
//	'                                                        <img src="/Images/@post.anh[0].anh_url" alt="" onclick="ShowPostModal(@post.anh[0].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[1].anh_url" alt="" onclick="ShowPostModal(@post.anh[1].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[2].anh_url" alt="" onclick="ShowPostModal(@post.anh[2].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[3].anh_url" alt="" onclick="ShowPostModal(@post.anh[3].id)" />' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                            }' +
//	'                                            else if (post.anh.Count == 5)' +
//	'                                            {' +
//	'                                                <div class="row soanh-5">' +
//	'                                                    <div class="col-md-6">' +
//	'                                                        <img src="/Images/@post.anh[0].anh_url" alt="" onclick="ShowPostModal(@post.anh[0].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-6">' +
//	'                                                        <img src="/Images/@post.anh[1].anh_url" alt="" onclick="ShowPostModal(@post.anh[1].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[2].anh_url" alt="" onclick="ShowPostModal(@post.anh[2].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[3].anh_url" alt="" onclick="ShowPostModal(@post.anh[3].id)" />' +
//	'                                                    </div>' +
//	'                                                    <div class="col-md-4">' +
//	'                                                        <img src="/Images/@post.anh[4].anh_url" alt="" onclick="ShowPostModal(@post.anh[4].id)" />' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                            }' +
//	'                                            else if (post.anh.Count > 5)' +
//	'                                            {' +
//	'                                                <p class="text-center">Chức năng đang cập nhật</p>' +
//	'                                            }' +
//	'                                        </div>' +
//	'                                    }' +
//	'                                </div>' +
//	'                                <div class="post-socialfunction">' +
//	'                                    <section class="post-icons">' +
//	'                                        @if (post.dsnguoithich.Any(x => x.idnguoithich == userID))' +
//	'                                        {' +
//	'                                            <button type="button" class="btn btn-light post-like-icon liked" id="post-like-icon-@post.id">' +
//	'                                                <i class="fas fa-heart"></i>' +
//	'                                            </button>' +
//	'                                        }' +
//	'                                        else' +
//	'                                        {' +
//	'                                            <button type="button" class="btn btn-light post-like-icon" id="post-like-icon-@post.id">' +
//	'                                                <i class="fas fa-heart"></i>' +
//	'                                            </button>' +
//	'                                        }' +
//	'                                        <button type="button" class="btn btn-light" id="comment-icon-@post.id"><i class="far fa-comment"></i></button>' +
//	'                                        <button type="button" class="btn btn-light" data-toggle="modal" data-target="#modal-share-@post.id"><i class="far fa-paper-plane"></i></button>' +
//	'                                        <button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>' +
//	'                                    </section>' +
//	'                                    <section class="list-like">' +
//	'                                        <button type="button" class="btn btn-light like-count-@post.id" id="like-count-@post.id">@post.luotthich lượt thích</button>' +
//	'' +
//	'                                        <!-- Modal -->' +
//	'                                        <div class="modal fade list-like-post" id="list-like-post-@post.id" tabindex="-1" role="dialog">' +
//	'                                            <div class="modal-dialog modal-dialog-centered" role="document">' +
//	'                                                <div class="modal-content">' +
//	'                                                    <div class="modal-header">' +
//	'                                                        <h5 class="modal-title" id="exampleModalLongTitle">Likes</h5>' +
//	'                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
//	'                                                            <span aria-hidden="true">×</span>' +
//	'                                                        </button>' +
//	'                                                    </div>' +
//	'                                                    <div class="modal-body" id="list-like-body-@post.id">' +
//	'' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                            </div>' +
//	'                                        </div>' +
//	'                                    </section>' +
//	'                                    <section class="post-time">' +
//	'                                        <p>@post.viewthoigian</p>' +
//	'                                    </section>' +
//	'                                    <div class="user-comments" id="user-comments-@post.id">' +
//	'                                        @if (post.comment.Count > 0)' +
//	'                                        {' +
//	'                                            <div id="comment-list-@post.id" class="comment-list">' +
//	'                                                @foreach (var item in post.comment)' +
//	'                                                {' +
//	'                                                    <div class="comment-item" id="comment-item-@item.comment_id">' +
//	'                                                        <div class="comment-item-parent" id="comment-item-parent-@item.comment_id">' +
//	'                                                            <div class="user-ava">' +
//	'                                                                <img src="/Images/@item.anhnguoidang" alt="">' +
//	'                                                            </div>' +
//	'                                                            <div class="comment-item-detail">' +
//	'                                                                <h3 class="user-name"><a href="/Client/Personal/Index/@item.idnguoidang">@item.tennguoidang</a></h3>' +
//	'                                                                <span>@item.noidung</span>' +
//	'                                                                <div class="comment-item-info">' +
//	'                                                                    <time datetime="2011-01-12" title="12 tháng 9 1945">@item.viewthoigian</time>' +
//	'                                                                    <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(@item.comment_id)">Trả lời</button>' +
//	'                                                                </div>' +
//	'                                                            </div>' +
//	'                                                        </div>' +
//	'                                                        @if (item.comment_child.Count > 0)' +
//	'                                                        {' +
//	'                                                            <div class="comment-item-childs" id="comment-item-childs-@item.comment_id">' +
//	'                                                                <button data-toggle="collapse" data-target="#comment-childs-@item.comment_id" class="btn btn-light">Xem câu trả lời (@item.luotbinhluan)</button>' +
//	'                                                                <div id="comment-childs-@item.comment_id" class="collapse">' +
//	'                                                                    @foreach (var item_child in item.comment_child)' +
//	'                                                                    {' +
//	'                                                                        <div class="comment-item-child">' +
//	'                                                                            <div class="user-ava">' +
//	'                                                                                <img src="/Images/@item_child.anhnguoidang" alt="">' +
//	'                                                                            </div>' +
//	'                                                                            <div class="comment-item-detail">' +
//	'                                                                                <h3 class="user-name"><a href="/Client/Personal/Index/@item_child.idnguoidang">@item_child.tennguoidang</a></h3>' +
//	'                                                                                <span>@item_child.noidung</span>' +
//	'                                                                                <div class="comment-item-info">' +
//	'                                                                                    <time datetime="2011-01-12" title="12 tháng 9 1945">@item_child.viewthoigian</time>' +
//	'                                                                                    <button type="button" class="btn btn-light" onclick="ShowCommentBarChild(@item_child.parent_id)">Trả lời</button>' +
//	'                                                                                </div>' +
//	'                                                                            </div>' +
//	'                                                                        </div>' +
//	'                                                                    }' +
//	'                                                                </div>' +
//	'                                                            </div>' +
//	'                                                        }' +
//	'                                                        <section class="comment-bar-child" id="comment-bar-child-@item.comment_id">' +
//	'                                                            <div class="user-ava">' +
//	'                                                                <img src="/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="Alternate Text" />' +
//	'                                                            </div>' +
//	'                                                            <div class="form-group">' +
//	'																 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="post-comment-child-content-@item.comment_id"></textarea>' +
//	'															 </div>' +
//	'                                                            <button type="button" class="btn btn-light post-comment-child-button" id="post-comment-child-button-@item.comment_id-@item.post_id">Đăng</button>' +
//	'                                                        </section>' +
//	'                                                    </div>' +
//	'                                                }' +
//	'                                            </div>' +
//	'                                        }' +
//	'                                    </div>' +
//	'                                    <section class="comment-bar" id="comment-bar-@post.id">' +
//	'                                        <div class="form-group">' +
//	'											 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="post-comment-content-@post.id"></textarea>' +
//	'										 </div>' +
//	'                                        <button type="button" class="btn btn-light post-comment-button" id="post-comment-button-@post.id">Đăng</button>' +
//	'                                    </section>' +
//	'                                </div>' +
//	'                                @*Modal ảnh*@' +
//	'                                @if (post.anh.Count > 0)' +
//	'                                {' +
//	'                                    foreach (var modal_anh in post.anh)' +
//	'                                    {' +
//	'                                        <!-- Modal -->' +
//	'                                        <div class="post-box-modal modal fade" id="modal-post-@modal_anh.id">' +
//	'                                            <div class="modal-dialog modal-dialog-centered">' +
//	'                                                <div class="modal-content">' +
//	'                                                    <div class="modal-col-7">' +
//	'                                                        <div class="post-content">' +
//	'                                                            <img class="" src="/Images/@modal_anh.anh_url" alt="">' +
//	'                                                        </div>' +
//	'                                                    </div>' +
//	'                                                    <div class="modal-col-5">' +
//	'                                                        <div class="post-title">' +
//	'                                                            <div class="post-info">' +
//	'                                                                <img height="50px" width="50px" class="rounded rounded-circle" src="/Images/@post.avatarnguoidang" alt="">' +
//	'                                                                <p id="modal-post-info-@modal_anh.id"><a href="/Client/Personal/Index/@post.idnguoidang" title="">@post.tennguoidang</a></p>' +
//	'                                                            </div>' +
//	'                                                        </div>' +
//	'' +
//	'                                                        <p class="post-content-text" id="modal-post-content-text-@modal_anh.id"></p>' +
//	'                                                        <div class="post-socialfunction">' +
//	'' +
//	'                                                            <div class="user-comments" id="modal-user-comments-@modal_anh.id">' +
//	'                                                            </div>' +
//	'                                                            <section class="post-icons">' +
//	'                                                                @if (post.dsnguoithich.Any(x => x.idnguoithich == userID) && post.id == modal_anh.id)' +
//	'                                                                {' +
//	'                                                                    <button type="button" class="btn btn-light post-like-icon liked" id="modal-post-like-icon-@modal_anh.id">' +
//	'                                                                        <i class="fas fa-heart"></i>' +
//	'                                                                    </button>' +
//	'                                                                }' +
//	'                                                                else' +
//	'                                                                {' +
//	'                                                                    <button type="button" class="btn btn-light post-like-icon" id="modal-post-like-icon-@modal_anh.id">' +
//	'                                                                        <i class="fas fa-heart"></i>' +
//	'                                                                    </button>' +
//	'                                                                }' +
//	'                                                                <button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>' +
//	'                                                                <button type="button" class="btn btn-light"></button>' +
//	'                                                            </section>' +
//	'' +
//	'                                                            <section class="list-like">' +
//	'                                                                <button type="button" class="btn btn-light like-count-@modal_anh.id" id="like-count-@modal_anh.id">0 lượt thích</button>' +
//	'                                                                <div class="modal fade modal-list-like-post" id="modal-list-like-post-@post.id" tabindex="-1" role="dialog">' +
//	'                                                                    <div class="modal-dialog modal-dialog-centered" role="document">' +
//	'                                                                        <div class="modal-content">' +
//	'                                                                            <div class="modal-header">' +
//	'                                                                                <h5 class="modal-title" id="exampleModalLongTitle">Likes</h5>' +
//	'                                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
//	'                                                                                    <span aria-hidden="true">×</span>' +
//	'                                                                                </button>' +
//	'                                                                            </div>' +
//	'                                                                            <div class="modal-body" id="modal-list-like-body-@post.id">' +
//	'' +
//	'                                                                            </div>' +
//	'                                                                        </div>' +
//	'                                                                    </div>' +
//	'                                                                </div>' +
//	'                                                            </section>' +
//	'                                                            <section class="post-time" id="modal-post-time-@modal_anh.id">' +
//	'                                                                <p>@post.viewthoigian</p>' +
//	'                                                            </section>' +
//	'                                                            <section class="comment-bar" id="comment-bar-@modal_anh.id">' +
//	'                                                                <div class="form-group">' +
//	'																	 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)" id="modal-post-comment-content-@modal_anh.id"></textarea>' +
//	'																 </div>' +
//	'                                                                <button type="button" class="btn btn-light modal-post-comment-button" id="modal-post-comment-button-@modal_anh.id">Đăng</button>' +
//	'                                                            </section>' +
//	'                                                        </div>' +
//	'                                                    </div>' +
//	'                                                </div>' +
//	'                                            </div>' +
//	'                                        </div>' +
//	'                                    }' +
//	'                                }' +
//	'                                <div class="modal fade modal-share" id="modal-share-@post.id" tabindex="-1" role="dialog">' +
//	'                                    <div class="modal-dialog modal-dialog-centered" role="document">' +
//	'                                        <div class="modal-content">' +
//	'                                            <div class="modal-header">' +
//	'                                                <h5 class="modal-title text-center w-100" id="">Viết bài</h5>' +
//	'                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
//	'                                                    <span aria-hidden="true">×</span>' +
//	'                                                </button>' +
//	'                                            </div>' +
//	'                                            <div class="modal-body">' +
//	'                                                <div class="user-share">' +
//	'                                                    <div class="user-info">' +
//	'                                                        <div class="user-ava" id="user-ava-share-@post.id">' +
//	'                                                            <img src="https://instagram.fhan2-3.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/s750x750/100996526_586014178690281_5961547765435131671_n.jpg?_nc_ht=instagram.fhan2-3.fna.fbcdn.net&_nc_cat=109&_nc_ohc=Mm-56owGPb0AX-h6SMF&oh=82dca3ea2584189ce5efd6ea2ee5c26b&oe=5EFB787B" alt="" />' +
//	'                                                        </div>' +
//	'                                                        <div class="user-detail">' +
//	'                                                            <h3 class="user-name" id="user-name-share-@post.id"><a href="#">Như Nguyệt</a></h3>' +
//	'                                                            <div class="form-group">' +
//	'                                                                <select id="inputState" class="form-control">' +
//	'                                                                    <option selected value="0">Công khai</option>' +
//	'                                                                    <option value="3">Chỉ mình tôi</option>' +
//	'                                                                    <option value="2">Bạn bè</option>' +
//	'                                                                    <option value="1">Bạn của bạn bè</option>' +
//	'                                                                </select>' +
//	'                                                            </div>' +
//	'                                                        </div>' +
//	'                                                    </div>' +
//	'                                                    <div class="form-group">' +
//	'														 <textarea class="form-control user-share-content" id="user-share-content-@post.id" rows="2" placeholder="Bạn đang nghĩ gì thế ?"></textarea>' +
//	'													 </div>' +
//	'                                                </div>' +
//	'                                                <div id="content-result-@post.id">' +
//	'' +
//	'                                                </div>' +
//	'                                            </div>' +
//	'                                            <div class="modal-footer">' +
//	'                                                <button type="button" class="btn btn-primary btn-block" onclick="SharePost(@post.id, @userID)">Đăng</button>' +
//	'                                            </div>' +
//	'                                        </div>' +
//	'                                    </div>' +
//	'                                </div>' +
//	'                            </article>';








