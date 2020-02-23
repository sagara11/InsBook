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
					<a class="nav-link" href="http://localhost/messenger-frontend/views/pages/user-info-2.php"><i class="far fa-user-circle"></i><span>Giới thiệu</span></a>
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
				<div class="tab-pane container fade" id="menu2">...</div>
				<div class="tab-pane container fade" id="menu3">...</div>
				<div class="tab-pane container fade" id="menu4">...</div>
				<div class="tab-pane container fade" id="menu5">...</div>
				<div class="tab-pane container fade" id="menu6">...</div>
				<div class="tab-pane container active" id="menu7">
					<div class="videos-list">
						<div class="row">
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
							<div class="col-md-3">
								<div class="videos-item">
									<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="" class="img-fluid">
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</main>
<?php include "../layouts/footer.php" ?>