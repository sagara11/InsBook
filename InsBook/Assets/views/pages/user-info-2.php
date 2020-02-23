<?php include "../layouts/header.php" ?>
<main>
	<div id="user-infomation">
		<div class="container">
			<div class="user-info-title">
				<?php include "../layouts/user-info.php" ?>
			</div>
			<!-- Nav tabs -->
			<ul class="nav nav-tabs">
				<li class="nav-item">
					<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/user-info-1.php"><i class="fas fa-rss-square"></i><span>Dòng thời gian</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link active" href="http://localhost/messenger-frontend/views/pages/user-info-2.php"><i class="far fa-user-circle"></i><span>Giới thiệu</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/user-info-3.php"><i class="fas fa-users"></i><span>Bạn bè</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/user-info-4.php"><i class="far fa-images"></i></i><span>Ảnh</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<span>Xem thêm</span>
					</a>
					<div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
						<a class="dropdown-item" href="http://localhost/messenger-frontend/views/pages/user-info-5.php">Lưu trữ</a>
						<a class="dropdown-item" href="http://localhost/messenger-frontend/views/pages/user-info-6.php">Bộ sưu tập</a>
						<a class="dropdown-item" href="http://localhost/messenger-frontend/views/pages/user-info-7.php">Video</a>
					</div>
				</li>
			</ul>

			<!-- Tab panes -->
			<div class="tab-content">
				<div class="tab-pane container fade" id="menu1">...</div>
				<div class="tab-pane container active" id="menu2">
					<ul class="nav nav-tabs flex-column">
						<li class="nav-item">
							<a class="nav-link active" href="http://localhost/messenger-frontend/views/pages/user-info-2.php">Cài đặt chung</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/edit_account-2.php">Đổi mật khẩu</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/edit_account-3.php">Công việc và học vấn</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/edit_account-4.php">Những nơi bạn đã sống</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/edit_account-5.php">Gia đình và các mối quan hệ</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/edit_account-6.php">Chi tiết về bạn</a>
						</li>
					</ul>

					<!-- Tab panes -->
					<div class="tab-content">
						<div class="tab-pane container active" id="menu2-1">
							<article class="change-profile">
								<div class="row">
									<div class="col-md-3">
										<div class="user-img">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
									</div>
									<div class="col-md-9">
										<h1 class="user-name">Thắng Bếu</h1>
										<button type="button" class="btn btn-primary">Thay đổi ảnh đại diện</button>
									</div>
									<div class="col-md-3">
										<label for="suaten">Tên</label>
									</div>
									<div class="col-md-3">
										<div class="form-group">
									    	<input type="text" class="form-control" id="suaten">
									  	</div>
									</div>
									<div class="col-md-1">
										<label for="suaho">Họ</label>
									</div>
									<div class="col-md-5">
										<div class="form-group">
									    	<input type="text" class="form-control" id="suaho">
									  	</div>
									</div>
									<div class="col-md-3">
										<label for="suaweb">Trang Web</label>
									</div>
									<div class="col-md-9">
										<div class="form-group">
									    	<input type="text" class="form-control" id="suaweb">
									  	</div>
									</div>
									<div class="col-md-3">
										<label for="suaemail">Email</label>
									</div>
									<div class="col-md-9">
										<div class="form-group">
									    	<input type="email" class="form-control" id="suaemail">
									  	</div>
									</div>
									<div class="col-md-3">
										<label for="suasdt">Số điện thoại</label>
									</div>
									<div class="col-md-9">
										<div class="form-group">
									    	<input type="text" class="form-control" id="suasdt">
									  	</div>
									</div>
									<div class="col-md-3">
										<label for="suangaysinh">Ngày sinh</label>
									</div>
									<div class="col-md-4">
										<div class="form-group">
									    	<input type="date" class="form-control" id="suangaysinh">
									  	</div>
									</div>
									<div class="col-md-2">
										<label for="suagioitinh">Giới tính</label>
									</div>
									<div class="col-md-3 sua-gioitinh">
										<div class="form-group">
										  	<select class="form-control" id="suagioitinh">
												<option>Nam</option>
												<option>Nữ</option>
											</select>
									  	</div>
									</div>
									<div class="col-md-3">
										
									</div>
									<div class="col-md-3 button-submit">
										<button type="button" class="btn btn-light">Cập nhật</button>
									</div>
									<div class="col-md-6 button-submit">
										<button type="button" class="btn btn-primary">Tạm thời vô hiệu hóa tài khoản</button>
									</div>
								</div>
							</article>
						</div>
						<div class="tab-pane container fade" id="menu2-2">...</div>
						<div class="tab-pane container fade" id="menu2-3">...</div>
						<div class="tab-pane container fade" id="menu2-4">...</div>
						<div class="tab-pane container fade" id="menu2-5">...</div>
						<div class="tab-pane container fade" id="menu2-6">...</div>
					</div>
				</div>
				<div class="tab-pane container fade" id="menu3">...</div>
				<div class="tab-pane container fade" id="menu4">...</div>
				<div class="tab-pane container fade" id="menu5">...</div>
				<div class="tab-pane container fade" id="menu6">...</div>
				<div class="tab-pane container fade" id="menu7">...</div>
			</div>
		</div>
	</div>
</main>
<?php include "../layouts/footer.php" ?>