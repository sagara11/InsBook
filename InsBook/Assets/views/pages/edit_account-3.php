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
							<a class="nav-link active" href="http://localhost/messenger-frontend/views/pages/edit_account-3.php">Công việc và học vấn</a>
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
						<div class="tab-pane container fade" id="menu2-1">...</div>
						<div class="tab-pane container fade" id="menu2-2">...</div>
						<div class="tab-pane container active" id="menu2-3">
							<div class="jobs-and-educations">
								<div class="job">
									<h3>Công việc</h3>
									<ul class="list-job">
										<li class="list-job-item">
											<div class="job-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="job-item-name">
												<p>Công ty cổ phần truyền thông BTS</p>
											</div>
											<div class="job-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
										<li class="list-job-item">
											<div class="job-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="job-item-name">
												<p>Công ty cổ phần truyền thông BTS</p>
											</div>
											<div class="job-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
									</ul>
									<div class="job-adding">
										<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Thêm một nơi làm việc</span></button>

									</div>
								</div>
								<div class="university">
									<h3>Đại học</h3>
									<ul class="list-university">
										<li class="list-university-item">
											<div class="university-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="university-item-name">
												<p>Học viện kỹ thuạt quân sự MTA</p>
											</div>
											<div class="university-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
										<li class="list-university-item">
											<div class="university-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="university-item-name">
												<p>Học viện kỹ thuạt quân sự MTA</p>
											</div>
											<div class="university-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
									</ul>
									<div class="university-adding">
										<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Thêm một trường đại học</span></button>

									</div>
								</div>
								<div class="highschool">
									<h3>Trường trung học</h3>
									<ul class="list-highschool">
										<li class="list-highschool-item">
											<div class="highschool-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="highschool-item-name">
												<p>Trường THPT Xuân Đỉnh</p>
											</div>
											<div class="highschool-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
										<li class="list-highschool-item">
											<div class="highschool-item-thumbnail">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<div class="highschool-item-name">
												<p>Trường THPT Trần Phú</p>
											</div>
											<div class="highschool-item-tools">
												<i class="far fa-edit"></i>
												<i class="far fa-trash-alt"></i>
											</div>
										</li>
									</ul>
									<div class="highschool-adding">
										<button type="button" class="btn btn-light"><i class="far fa-plus-square"></i><span>Thêm một trường trung học</span></button>

									</div>
								</div>
							</div>
						</div>
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