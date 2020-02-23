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
					<a class="nav-link active" href="http://localhost/messenger-frontend/views/pages/user-info-1.php"><i class="fas fa-rss-square"></i><span>Dòng thời gian</span></a>
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
				<div class="tab-pane container active" id="menu1">
					<div class="row">
						<div class="col-md-4">
							<div class="user-description">
								<div class="user-description-title">
									<a href="#" title="Giới thiệu"><i class="fas fa-globe-asia fa-2x"></i>
									<span>Giới thiệu</span></a>
								</div>
								<div class="user-description-content">
									<p class="user-quote">Trẻ không chơi già đổ đốn</p>
									<div class="user-description-detail">
										<ul>
											<li><i class="fas fa-briefcase"></i><span>Đang làm vua tại đất <b>Thái Bình</b></span></li>
											<li><i class="fas fa-graduation-cap"></i><span>Học Công Nghệ Thông Tin tại <b>Học viện Hoàng gia Cali</b></span></li>
											<li><i class="fas fa-home"></i><span>Sống tại <b>Hà Nội</b></span></li>
											<li><i class="fas fa-map-marker-alt"></i><span>Đến từ <b>Thái Bình</b></span></li>
											<li><i class="far fa-clock"></i><span>Tham gia ngày xx tháng xx năm xxxx</span></li>
											<li><i class="far fa-heart"></i><span>Tìm hiểu</span></li>
										</ul>
									</div>
								</div>
							</div>
							<div class="user-images">
								<div class="user-images-title">
									<a href="#" title="Ảnh"><i class="fas fa-camera-retro fa-2x"></i>
									<span>Ảnh</span></a>
								</div>
								<div class="user-images-content">
									<div class="row">
										<div class="col-md-4">
											<div class="user-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
										</div>
										<div class="col-md-4">
											<div class="user-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
										</div>
										<div class="col-md-4">
											<div class="user-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
										</div>
										<div class="col-md-4">
											<div class="user-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="user-friends">
								<div class="user-friends-title">
									<a href="#" title="Bạn bè"><i class="fas fa-user-friends fa-2x"></i>
									<span>Bạn bè</span></a>
								</div>
								<div class="user-friends-content">
									<div class="row">
										<div class="col-md-4">
											<div class="user-friend-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<a href="#" title="Phong Con">Phong Con</a>
										</div>
										<div class="col-md-4">
											<div class="user-friend-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<a href="#" title="Dũng Trọc">Dũng Trọc</a>
										</div>
										<div class="col-md-4">
											<div class="user-friend-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<a href="#" title="Thông Mặt Sẹo">Thông Mặt Sẹo</a>
										</div>
										<div class="col-md-4">
											<div class="user-friend-image">
												<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
											</div>
											<a href="#" title="Long Uchiha">Long Uchiha</a>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-md-8">
							<div class="user-newsfeed">
								<article class="post-box">
									<header class="post-title">
										<div class="user-avatar">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
										<a href="#" title="">Thắng Bếu</a>
									</header><!-- /header -->
									<div class="post-content">
										<p class="post-content-text">Im cho bố m học bài !</p>
										<div class="post-content-image">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
									</div>
									<div class="post-info">
										<section class="post-icons">
											<button type="button" class="btn btn-light"><i class="far fa-heart"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-paper-plane"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>
										</section>
										<section class="list-like">
											<button type="button" class="btn btn-light">123 lượt thích</button>
										</section>
										<section class="post-time">
											<p>2 giờ trước</p>
										</section>
										<div class="user-comments">
											<div class="comment-list">
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-2" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-2" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-1" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-1" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-3" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-3" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
										<section class="comment-bar">
											<div class="form-group">
												 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>
											</div>
											<button type="button" class="btn btn-light">Đăng</button>
										</section>
									</div>
								</article>
								<article class="post-box">
									<header class="post-title">
										<div class="user-avatar">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
										<a href="#" title="">Thắng Bếu </a>
									</header><!-- /header -->
									<div class="post-content">
										<p class="post-content-text">Im cho bố m học bài !</p>
										<div class="post-content-image">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
									</div>
									<div class="post-info">
										<section class="post-icons">
											<button type="button" class="btn btn-light"><i class="far fa-heart"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-paper-plane"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>
										</section>
										<section class="list-like">
											<button type="button" class="btn btn-light">123 lượt thích</button>
										</section>
										<section class="post-time">
											<p>2 giờ trước</p>
										</section>
										<div class="user-comments">
											<div class="comment-list">
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-2" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-2" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-1" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-1" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-3" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-3" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
										<section class="comment-bar">
											<div class="form-group">
												 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>
											</div>
											<button type="button" class="btn btn-light">Đăng</button>
										</section>
									</div>
								</article>
								<article class="post-box">
									<header class="post-title">
										<div class="user-avatar">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
										<a href="#" title="">Thắng Bếu</a>
									</header><!-- /header -->
									<div class="post-content">
										<p class="post-content-text">Im cho bố m học bài !</p>
										<div class="post-content-image">
											<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
										</div>
									</div>
									<div class="post-info">
										<section class="post-icons">
											<button type="button" class="btn btn-light"><i class="far fa-heart"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-comment"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-paper-plane"></i></button>
											<button type="button" class="btn btn-light"><i class="far fa-bookmark"></i></button>
										</section>
										<section class="list-like">
											<button type="button" class="btn btn-light">123 lượt thích</button>
										</section>
										<section class="post-time">
											<p>2 giờ trước</p>
										</section>
										<div class="user-comments">
											<div class="comment-list">
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-2" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-2" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-1" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-1" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="comment-item">
													<div class="comment-item-parent">
														<div class="user-ava">
																<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
														</div>
														<div class="comment-item-detail">
															<h3 class="user-name">thangho</h3>
															<span>Bla bla bla...</span>
															<div class="comment-item-info">
																<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																<button type="button" class="btn btn-light">123 lượt thích</button>
																<button type="button" class="btn btn-light">Trả lời</button>
															</div>
														</div>
														<div class="comment-item-tool">
															<i class="far fa-heart"></i>
														</div>
													</div>
													<div class="comment-item-childs"	>
														<button data-toggle="collapse" data-target="#demo-3" class="btn btn-light">Xem câu trả lời (1)</button>
														<div id="demo-3" class="collapse">
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
															<div class="comment-item-child">
																<div class="user-ava">
																		<img src="http://localhost/messenger-frontend/media/78834391_459110258126325_6149001856166133760_n.jpg" alt="">
																</div>
																<div class="comment-item-detail">
																	<h3 class="user-name">thangho</h3>
																	<span>Bla bla bla...</span>
																	<div class="comment-item-info">
																		<time datetime="2011-01-12" title="12 tháng 9 1945">2 giờ</time>
																		<button type="button" class="btn btn-light">123 lượt thích</button>
																		<button type="button" class="btn btn-light">Trả lời</button>
																	</div>
																</div>
																<div class="comment-item-tool">
																	<i class="far fa-heart"></i>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
										<section class="comment-bar">
											<div class="form-group">
												 <textarea class="form-control" placeholder="Thêm bình luận..." oninput="auto_grow(this)"></textarea>
											</div>
											<button type="button" class="btn btn-light">Đăng</button>
										</section>
									</div>
								</article>
							</div>
						</div>
					</div>
				</div>
				<div class="tab-pane container fade" id="menu2">...</div>
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