$(document).ready(function () {

    //Load data when scrolling
    $(window).scroll(function () {
        if ($(window).scrollTop() >= $(document).height() - $(window).height()) {
            var response = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13",]
            response.forEach(function (item) {
                console.log(item);
                var rows = "<div class='posts-item'>"
                    + "<div class='posts-item-content'>"
                    + "<h3>" + item + "</h3>"
                    + "</div>"
                    + "</div>";
                $('#newsfeed').append(rows);
            });
        }
    });
    //--------------------------------------------------------------------------------------
});

//<div class='post-box' id='post-2'>
//<div class='post-title'>
//<div class='post-info'>
//<img height='50px' width='50px' class='rounded rounded-circle' src='~/Assets/media/78834391_459110258126325_6149001856166133760_n.jpg' alt='>
//<p>name</p>
//</div>
//<div class='post-option' data-target='#post-option-modal2' data-toggle='modal'>
//&#8230;
//</div>
//<div class='modal post-option-modal fade' id='post-option-modal2'>
//<div class='modal-dialog modal-dialog-centered'>
//<div class='modal-content'>
//<div class='modal-body'>
//<ul>
//<li>
//<a class='report' href='>Báo cáo</a>
//</li>
//<li>
//<a href='>Bỏ theo dõi</a>
//</li>
//</ul>
//</div>
//</div>
//</div>
//</div>
//</div>
//<div class='post-content' data-toggle='modal' data-target='#post-2-modal'>
//<img class='img-fluid' src='~/Assets/media/78834391_459110258126325_6149001856166133760_n.jpg' alt='>
//</div>
//<div class='post-socialfunction'>
//<div class='like-comment'>
//<div id='heart-2' onclick='heart('heart-2')' class='like-comment-heart'>
//<i class='fa fa-heart-o heart' aria-hidden='true'></i>
//</div>
//<i class='fa fa-comment-o' aria-hidden='true'></i>
//<i data-toggle='modal' data-target='#post-2-share' class='fa fa-paper-plane-o' aria-hidden='true'></i>
//</div>
//<div class='like-number'>
//200 likes
//</div>
//<div class='post-caption'>
//Caption
//</div>
//<div class='post-comment'>
//<p class='comment-name'>Name</p>
//<p>comment....</p>
//</div>
//</div>
//<div class='post-usercomment'>
//<input class='form-control' type='text' placeholder='Thêm bình luận...'>
//<button>Đăng</button>
//</div>
//<!-- Modal -->
//<div class='post-box-modal modal fade' id='post-2-modal'>
//<div class='modal-dialog modal-dialog-centered'>
//<div class='modal-content'>
//<div class='col-7'>
//<div class='post-content'>
//<img class='img-fluid' src='~/Assets/media/78834391_459110258126325_6149001856166133760_n.jpg' alt='>
//</div>
//</div>
//<div class='col-5'>
//<div class='post-title'>
//<img height='50px' width='50px' class='rounded rounded-circle' src='~/Assets/media/78834391_459110258126325_6149001856166133760_n.jpg' alt='>
//<p>name</p>
//</div>
//<div class='post-socialfunction'>
//<div class='post-caption'>
//Caption
//</div>
//<div class='like-comment'>
//<div onclick='heart('heart-2')' class='like-comment-heart'>
//<i class='fa fa-heart-o heart' aria-hidden='true'></i>
//</div>
//<i class='fa fa-comment-o' aria-hidden='true'></i>
//<i data-toggle='modal' data-target='#post-2-share' class='fa fa-paper-plane-o' aria-hidden='true'></i>
//</div>
//<div class='like-number'>
//200 likes
//</div>
//<div class='post-comment'>
//<p class='comment-name'>Name</p>
//<p>comment....</p>
//</div>
//</div>
//<div class='post-usercomment'>
//<input class='form-control' type='text' placeholder='Thêm bình luận...'>
//<button>Đăng</button>
//</div>
//</div>
//</div>
//</div>
//</div>
//<!-- Share modal -->
//<div class='share-modal modal fade' id='post-2-share'>
//<div class='modal-dialog modal-dialog-centered'>
//<div class='modal-content'>
//<div class='share-header'>
//<p>Chia sẻ ngay lên dòng thời gian</p>
//<p data-dismiss='modal'>&times;</p>
//</div>
//<div class='share-body'>
//<input class='form-control' type='text' placeholder='Nói gì đó về nội dung này...'>
//<div class='share-content'>
//<img class='img-fluid' src='~/Assets/media/78834391_459110258126325_6149001856166133760_n.jpg' alt='>
//</div>
//</div>
//<div id='post-2-taginput' class='tag-input'>
//<input class='form-control' type='text' placeholder='Gắn thẻ bạn bè'>
//</div>
//<div id='post-2-locationinput' class='location-input'>
//<input class='form-control' type='text' placeholder='Bạn đang ở đâu?'>
//</div>
//<div class='share-footer'>
//<div class='footer-option'>
//<button onclick='tag('post-2')' id='post-2-tag'>Gắn thẻ mọi người</button>
//<button onclick='location_open('post-2')' id='post-2-location'>Thêm vị trí</button>
//</div>
//<div class='footer-submit'>
//<button data-dismiss='modal'>Hủy</button>
//<button class='share-submit'>Đăng</button>
//</div>
//</div>
//</div>
//</div>
//</div>
//</div>
