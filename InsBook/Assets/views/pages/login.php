
<main>
    <section id="login-page">
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    
                </div>
                <div class="col-md-5">
                    <div class="images-sidebar">
                        <img src="http://localhost/messenger-frontend/media/gentle-man.png" alt="">
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-login">
                        <h1>InsBook</h1>
                        <p>We love it cuz it's fake !</p>
                        <div class="login-form">
                            <form action="#" method="post" accept-charset="utf-8">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <i class="fas fa-user-tie"></i>
                                        </div>
                                    </div>
                                    <input type="text" class="form-control" id="" placeholder="Số điện thoại, tên người dùng hoặc email">
                                </div>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <i class="fas fa-key"></i>
                                        </div>
                                    </div>
                                    <input type="text" class="form-control" id="" placeholder="Mật khẩu">
                                </div>
                                <button type="button" class="btn btn-block btn-primary">Đăng nhập</button>
                                <hr>
                                <p>HOẶC</p>
                                <button type="button" class="btn btn-block btn-light"><i class="fab fa-facebook-square"></i>Đăng nhập bằng Facebook</button>
                                <a href="#exampleModalCenter" title="Mày quên mật khẩu à ?" data-toggle="modal">Quên mật khẩu ?</a>
                            </form>
                        </div>
                    </div>
                    <div class="form-login-register">
                        <p>Bạn không có tài khoản ? <a href="http://localhost/messenger-frontend/views/pages/register.php" title="Chưa có chức năng đăng ký. Đề nghị ấn tạm vào đăng nhập Facebook !">Đăng ký</a></p>
                    </div>
                    <div class="web-apps">
                        <h3>Tải ứng dụng</h3>
                        <div class="web-apps-thumbnai">
                            <img src="https://www.instagram.com/static/images/appstore-install-badges/badge_ios_vietnamese-vi.png/3025bd262cee.png" alt="">
                            <img src="https://www.instagram.com/static/images/appstore-install-badges/badge_android_vietnamese-vi.png/c36c88b5a8dc.png" alt="">
                        </div>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
            </div>
            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="modal-title" id="">
                                <i class="fas fa-lock fa-3x"></i>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-sub-header">
                            <p class="modal-sub-header-title">Bạn gặp sự cố khi đăng nhập?</p>
                            <p class="modal-sub-header-content">Hãy nhập tên người dùng hoặc email của bạn và chúng tôi sẽ gửi cho bạn liên kết để truy cập lại vào tài khoản.</p>
                        </div>
                        <div class="modal-body">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="">@</span>
                                </div>
                                <input type="text" class="form-control" placeholder="Email, điện thoại hoặc tên người dùng">
                            </div>
                            <button type="button" class="btn btn-block btn-primary">Gửi liên kết đăng nhập</button>
                            <hr>
                            <p>HOẶC</p>
                            <a href="http://localhost/messenger-frontend/views/pages/register.php" title="">Tạo tài khoản mới</a>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary btn-block" data-dismiss="modal">Quay lại đăng nhập</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</main>
<?php include "../layouts/footer.php" ?>