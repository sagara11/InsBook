<?php include '../layouts/header.php'; ?>
<main>
	<div id="step-2">
		<div class="container">
			<div class="row">
				<div class="col-md-2">
				</div>
				<div class="col-md-8">
					<div id="check-progress-div">
						<ul id="check-progress-bar">
							<li class="check-progress-item visited"><a href="http://localhost/messenger-frontend/views/pages/step-1.php">Thêm bạn bè</a></li>
							<li class="check-progress-item active"><a href="http://localhost/messenger-frontend/views/pages/step-2.php">Sửa ảnh đại diện</a></li>
							<li class="check-progress-item next"><a href="http://localhost/messenger-frontend/views/pages/step-3.php">Hoàn thành</a></li>
						</ul>
					</div>
				</div>
				<div class="col-md-2">
				</div>
				<div class="col-md-2">
					
				</div>
				<div class="col-md-8">
					<div class="add-new-avatar">
						<a href="http://localhost/messenger-frontend/views/pages/step-3.php" title="" class="btn btn-light button-tiep">Tiếp</a>
						<h3>Tải lên một ảnh đại diện</h3>
						<div class="row">
							<div class="col-md-6">
								<div class="avatar-frame">
									<img src="https://bdh131.files.wordpress.com/2012/10/freeman_defaultblue_bdh.gif" alt="">
								</div>
							</div>
							<div class=" col-md-6">
								<div class="d-flex align-items-center justify-content-center w-100 h-100">
									<div class="avatar-frame-tools">
										<button type="button" class="btn btn-success"><i class="far fa-images"></i>Thêm ảnh</button>
										<hr>
										<p class="hoac">Hoặc</p>
										<button type="button" class="btn btn-light"><span>Chụp ảnh</span><small>Bằng webcam của bạn</small></button>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-2">
					
				</div>
			</div>
		</div>
	</div>
</main>
<?php include '../layouts/footer.php'; ?>