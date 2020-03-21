//$('#update-image').change(function () {
//    var file_data = $('#update-image').prop('files')[0];
//    var form_data = new FormData();
//    var token = $('input[name="__RequestVerificationToken"]').val();
//    form_data.append('avatar', file_data);
//    form_data.append('__RequestVerificationToken', token);

//    var url = window.location.href.split('/');
//    var baseUrl = url[0] + '//' + url[2];

//    $.ajax({
//        type: 'post',
//        url: '/Client/Post/PostUserAvatar',
//        dataType: 'json',
//        cache: false,
//        contentType: false,
//        processData: false,
//        data: form_data
//    }).done(function (datas) {
//        if (datas.status) {
//            var path = baseUrl + '/Images/' + datas.status;
//            $('#avatar').attr('src', path);
//        }
//    });
//});
let cropper = '';

function cropImgFunc(event) {
    $(".avatar-frame").css("display", "none");
    $(".avatar-frame-tools").css("display", "none");
    $("#avatar-saved").css("display", "block");
    $("#avatar-cancel").css("display", "block");
    $("#inputImg").css("display", "block");
    $(".ep-slider-bar").css("display", "block");
    let result = document.querySelector('#inputImg'),
        imgLoading = document.querySelector('#step-2-file');

    if (event.target.files.length) {
        // start file reader
        const reader = new FileReader();
        reader.onload = function (event) {
            if (event.target.result) {
                // create new image
                let img = document.createElement('img');
                img.id = 'image';
                img.src = event.target.result;
                img.width = 544;
                img.height = 300;
                // clean result before
                result.innerHTML = '';
                // append new image
                result.appendChild(img);
                // init cropper
                cropper = new Cropper(img, {
                    viewMode: 1,
                    dragMode: 'move',
                    aspectRatio: 1,
                    autoCropArea: 1,
                    minContainerWidth: 544,
                    minContainerHeight: 300,
                    center: false,
                    zoomOnWheel: false,
                    zoomOnTouch: false,
                    cropBoxMovable: false,
                    cropBoxResizable: false,
                    guides: false,
                    ready: function (event) {
                        this.cropper = cropper;
                    },
                    crop: function (event) {
                        //let imgSrc = this.cropper.getCroppedCanvas({
                        //  width: 170,
                        //  height: 170// input value
                        //}).toDataURL("image/png");
                    }
                });

                $(document).ready(function () {
                    $("#avatar-saved").click(function () {
                        cropper.getCroppedCanvas({
                            width: 170,
                            height: 170// input value
                        }).toBlob((blob) => {
                            var formData = new FormData();
                            var token = $('input[name="__RequestVerificationToken"]').val();

                            formData.append('__RequestVerificationToken', token); //form[0]
                            formData.append('nameImg', imgLoading.files[0].name); //fomr[1]

                            formData.append('croppedImg', blob); //file[0]

                            $.ajax({
                                type: 'post',
                                url: '/Client/Post/PostUserAvatar',
                                dataType: 'json',
                                cache: false,
                                contentType: false,
                                processData: false,
                                data: formData,
                                success: function (response) {
                                    if (response.status == true) {
                                        alert("You will now be redirected.");
                                        window.location = "/Client/Register/RegisterStep3";
                                    }
                                }
                            });
                        });
                    });
                });
                //$("#avatar-cancel").click(function () {
                //    var imgSrc = cropper.reset;
                //    imgPreview.src = "https://bdh131.files.wordpress.com/2012/10/freeman_defaultblue_bdh.gif";
                //});
            }
        };
        reader.readAsDataURL(event.target.files[0]);
        initSlideBar();
        resetSlideBar();
    }
}

function avatar_cancel() {
    $("#inputImg").css("display", "none");
    $(".ep-slider-bar").css("display", "none");
    $(".avatar-frame").css("display", "block");
    $(".avatar-frame-tools").css("display", "block");
    $("#avatar-saved").css("display", "none");
    $("#avatar-cancel").css("display", "none");
}
function resetSlideBar() {
    slideValGlobal = 0;
    $("#slider").slider("value", slideValGlobal);
}

function initSlideBar() {
    let zoomRatio = 0;
    $("#slider").slider({
        range: "min",
        min: 0,
        max: 1,
        step: 0.1,
        slide: function (event, ui) {
            let slideVal = ui.value;
            let zoomRatio = Math.round((slideVal - slideValGlobal) * 10) / 10;
            slideValGlobal = slideVal;
            cropper.zoom(zoomRatio);
        }
    });
};

$(document).ready(function () {
    $("#avatar-cancel").click(function () {
        avatar_cancel();
    });
});