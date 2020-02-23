<?php include "../layouts/header.php" ?>
<main>
    <div class="container">
        <div class="row">
            <div class="col-8">
                <!-- Newsfeed -->
                <section id="newsfeed">
                    <div class="post-box">
                        <div class="post-title">
                            <img height="50px" width="50px" class="rounded rounded-circle" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                            <p>name</p>
                        </div>
                        <div class="post-content" data-toggle="modal" data-target="#modal1">
                            <img class="img-fluid" src="http://localhost\messenger-frontend\media\78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                        </div>
                        <div class="post-socialfunction">
                            <div class="like-comment">
                                <i class="fa fa-heart-o" aria-hidden="true"></i>
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                            </div>
                            <div class="like-number">
                                200 likes
                            </div>
                            <div class="post-caption">
                                Caption
                            </div>
                            <div class="post-comment">
                                <p class="comment-name">Name</p>
                                <p>comment....</p>
                            </div>
                        </div>
                        <div class="post-usercomment">
                            <input class="form-control" type="text" placeholder="Thêm bình luận...">
                            <button>Đăng</button>
                        </div>
                        <!-- Modal -->
                        <div class="modal fade" id="modal1">
                            <div class="modal-dialog modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="col-7">
                                        <div class="post-content">
                                            <img class="img-fluid" src="http://localhost\messenger-frontend\media\78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="post-title">
                                            <img height="50px" width="50px" class="rounded rounded-circle" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                            <p>name</p>
                                        </div>
                                        <div class="post-socialfunction">
                                            <div class="post-caption">
                                                Caption
                                            </div>
                                            <div class="like-comment">
                                                <i class="fa fa-heart-o" aria-hidden="true"></i>
                                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                                <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                                            </div>
                                            <div class="like-number">
                                                200 likes
                                            </div>
                                            <div class="post-comment">
                                                <p class="comment-name">Name</p>
                                                <p>comment....</p>
                                            </div>
                                        </div>
                                        <div class="post-usercomment">
                                            <input class="form-control" type="text" placeholder="Thêm bình luận...">
                                            <button>Đăng</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="post-box">
                        <div class="post-title">
                            <img height="50px" width="50px" class="rounded rounded-circle" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                            <p>name</p>
                        </div>
                        <div class="post-content" data-toggle="modal" data-target="#modal2">
                            <img class="img-fluid" src="http://localhost\messenger-frontend\media\78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                        </div>
                        <div class="post-socialfunction">
                            <div class="like-comment">
                                <i class="fa fa-heart-o" aria-hidden="true"></i>
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                            </div>
                            <div class="like-number">
                                200 likes
                            </div>
                            <div class="post-caption">
                                Caption
                            </div>
                            <div class="post-comment">
                                <p class="comment-name">Name</p>
                                <p>comment....</p>
                            </div>
                        </div>
                        <div class="post-usercomment">
                            <input class="form-control" type="text" placeholder="Thêm bình luận...">
                            <button>Đăng</button>
                        </div>
                        <!-- Modal -->
                        <div class="modal fade" id="modal2">
                            <div class="modal-dialog modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="col-7">
                                        <div class="post-content">
                                            <img class="img-fluid" src="http://localhost\messenger-frontend\media\78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="post-title">
                                            <img height="50px" width="50px" class="rounded rounded-circle" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                            <p>name</p>
                                        </div>
                                        <div class="post-socialfunction">
                                            <div class="post-caption">
                                                Caption
                                            </div>
                                            <div class="like-comment">
                                                <i class="fa fa-heart-o" aria-hidden="true"></i>
                                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                                <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                                            </div>
                                            <div class="like-number">
                                                200 likes
                                            </div>
                                            <div class="post-comment">
                                                <p class="comment-name">Name</p>
                                                <p>comment....</p>
                                            </div>
                                        </div>
                                        <div class="post-usercomment">
                                            <input class="form-control" type="text" placeholder="Thêm bình luận...">
                                            <button>Đăng</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <div class="col-4">
                <!-- Thông tin tài khoản -->
                <section id="user-info">
                    <div class="user-avatar">
                        <img class="rounded rounded-circle" height="70px" width="70px" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                    </div>
                    <div>
                        <p>
                            user-name
                        </p>
                        <p>
                            <small>
                                user-name-2
                            </small>
                        </p>
                    </div>
                </section>
                <!-- Messenger -->
                <section id="messenger-section">
                    <div class="message-header">
                        Tin nhắn
                    </div>
                    <div class="message-body">
                        <div class="message-box">
                            <div class="message-avatar">
                                <img class="rounded rounded-circle" height="50px" width="50px" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                <div>
                                    <p>Content</p>
                                    <p class="message-time">
                                        <small>2 minutes ago</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="message-box">
                            <div class="message-avatar">
                                <img class="rounded rounded-circle" height="50px" width="50px" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                <div>
                                    <p>Content</p>
                                    <p class="message-time">
                                        <small>2 minutes ago</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="message-box">
                            <div class="message-avatar">
                                <img class="rounded rounded-circle" height="50px" width="50px" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                <div>
                                    <p>Content</p>
                                    <p class="message-time">
                                        <small>2 minutes ago</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="message-box">
                            <div class="message-avatar">
                                <img class="rounded rounded-circle" height="50px" width="50px" src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
                                <div>
                                    <p>Content</p>
                                    <p class="message-time">
                                        <small>2 minutes ago</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- Giới thiệu -->
                <section id="intro">
                    <p>
                        <small>
                            Giới thiệu về chúng tôi
                        </small>
                    </p>
                </section>
            </div>
        </div>
    </div>
</main>
<?php include "../layouts/footer.php" ?>