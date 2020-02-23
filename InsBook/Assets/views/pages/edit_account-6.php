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
							<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/user-info-2.php">Cài đặt chung</a>
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
							<a class="nav-link active" href="http://localhost/messenger-frontend/views/pages/edit_account-6.php">Chi tiết về bạn</a>
						</li>
					</ul>

					<!-- Tab panes -->
					<div class="tab-content">
						<div class="tab-pane container fade" id="menu2-1">...</div>
						<div class="tab-pane container fade" id="menu2-2">...</div>
						<div class="tab-pane container fade" id="menu2-3">...</div>
						<div class="tab-pane container fade" id="menu2-4">...</div>
						<div class="tab-pane container fade" id="menu2-5">...</div>
						<div class="tab-pane container active" id="menu2-6">
							<div class="description">
								<h3>Giới thiệu về Vua</h3>
								<ul class="list-description">
									<li class="list-description-item">
										<div class="description-item-name">
											<p>Không thích mọi thứ về mọi mặt</p>
										</div>
										<div class="description-item-tools">
											<i class="far fa-edit"></i>
											<i class="far fa-trash-alt"></i>
										</div>
									</li>
								</ul>
								<div class="description-adding">
									<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Viết một số điều về chính bạn</span></button>

								</div>
							</div>
							<div class="nickname">
								<h3>Các tên khác</h3>
								<ul class="list-nickname">
									<li class="list-nickname-item">
										<div class="nickname-item-name">
											<p>Thắng Bếu</p>
											<p>Biệt danh</p>
										</div>
										<div class="nickname-item-tools">
											<i class="far fa-edit"></i>
											<i class="far fa-trash-alt"></i>
										</div>
									</li>
									<li class="list-nickname-item">
										<div class="nickname-item-name">
											<p>Hồ Thắng</p>
											<p>Tên giả</p>
										</div>
										<div class="nickname-item-tools">
											<i class="far fa-edit"></i>
											<i class="far fa-trash-alt"></i>
										</div>
									</li>
								</ul>
								<div class="nickname-adding">
									<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Thêm biệt danh, tên khai sinh,...</span></button>

								</div>
							</div>
							<div class="quote">
								<h3>Trích dẫn yêu thích</h3>
								<ul class="list-quote">
									<li class="list-quote-item">
										<div class="quote-item-name">
											<p>Never interrupt your enemy when he is making a mistake.</p>
											<p>Napoleon Bonaparte</p>
										</div>
										<div class="quote-item-tools">
											<i class="far fa-edit"></i>
											<i class="far fa-trash-alt"></i>
										</div>
									</li>
									<li class="list-quote-item">
										<div class="quote-item-name">
											<p>Vạn sự cụ bị, chích khiếm đông phong</p>
											<p>Gia Cát Lượng</p>
										</div>
										<div class="quote-item-tools">
											<i class="far fa-edit"></i>
											<i class="far fa-trash-alt"></i>
										</div>
									</li>
								</ul>
								<div class="quote-adding">
									<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Thêm câu trích dẫn yêu thích của bạn</span></button>

								</div>
							</div>
						</div>
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