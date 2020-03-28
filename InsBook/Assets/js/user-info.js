function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}
$("#show-job-adding-box").click(function () {
    $(".job-adding-box").css("display", "block");
    $(".job-adding").css("display", "none");
});
$("#close-job-adding-box").click(function () {
    $(".job-adding-box").css("display", "none");
    $(".job-adding").css("display", "block");
});
$(".job-closse").click(function () {
    $(".job-adding-box").css("display", "none");
    $(".job-adding").css("display", "block");
});
$("#show-university-adding-box").click(function () {
    $(".university-adding-box").css("display", "block");
    $(".university-adding").css("display", "none");
});
$("#close-university-adding-box").click(function () {
    $(".university-adding-box").css("display", "none");
    $(".university-adding").css("display", "block");
});
$(".university-closse").click(function () {
    $(".university-adding-box").css("display", "none");
    $(".university-adding").css("display", "block");
});
$("#show-highschool-adding-box").click(function () {
    $(".highschool-adding-box").css("display", "block");
    $(".highschool-adding").css("display", "none");
});
$("#close-highschool-adding-box").click(function () {
    $(".highschool-adding-box").css("display", "none");
    $(".highschool-adding").css("display", "block");
});
$(".highschool-closse").click(function () {
    $(".highschool-adding-box").css("display", "none");
    $(".highschool-adding").css("display", "block");
});
$("#show-country-lived-adding-box").click(function () {
    $(".country-lived-adding-box").css("display", "block");
    $(".country-lived-adding").css("display", "none");
});
$("#close-country-lived-adding-box").click(function () {
    $(".country-lived-adding-box").css("display", "none");
    $(".country-lived-adding").css("display", "block");
});
$(".country-lived-closse").click(function () {
    $(".country-lived-adding-box").css("display", "none");
    $(".country-lived-adding").css("display", "block");
});
$("#show-relationship-adding-box").click(function () {
    $(".relationship-adding-box").css("display", "block");
    $(".relationship-adding").css("display", "none");
});
$("#close-relationship-adding-box").click(function () {
    $(".relationship-adding-box").css("display", "none");
    $(".relationship-adding").css("display", "block");
});
$(".relationship-closse").click(function () {
    $(".relationship-adding-box").css("display", "none");
    $(".relationship-adding").css("display", "block");
});
$("#show-family-adding-box").click(function () {
    $(".family-adding-box").css("display", "block");
    $(".family-adding").css("display", "none");
});
$("#close-family-adding-box").click(function () {
    $(".family-adding-box").css("display", "none");
    $(".family-adding").css("display", "block");
});
$(".family-closse").click(function () {
    $(".family-adding-box").css("display", "none");
    $(".family-adding").css("display", "block");
});
$("#show-description-adding-box").click(function () {
    $(".description-adding-box").css("display", "block");
    $(".description-adding").css("display", "none");
});
$("#close-description-adding-box").click(function () {
    $(".description-adding-box").css("display", "none");
    $(".description-adding").css("display", "block");
});
$(".description-closse").click(function () {
    $(".description-adding-box").css("display", "none");
    $(".description-adding").css("display", "block");
});
$("#show-quote-adding-box").click(function () {
    $(".quote-adding-box").css("display", "block");
    $(".quote-adding").css("display", "none");
});
$("#close-quote-adding-box").click(function () {
    $(".quote-adding-box").css("display", "none");
    $(".quote-adding").css("display", "block");
});
$(".quote-closse").click(function () {
    $(".quote-adding-box").css("display", "none");
    $(".quote-adding").css("display", "block");
});
$("#show-nickname-adding-box").click(function () {
    $(".nickname-adding-box").css("display", "block");
    $(".nickname-adding").css("display", "none");
});
$("#close-nickname-adding-box").click(function () {
    $(".nickname-adding-box").css("display", "none");
    $(".nickname-adding").css("display", "block");
});
$(".nickname-closse").click(function () {
    $(".nickname-adding-box").css("display", "none");
    $(".nickname-adding").css("display", "block");
});

//---------------------------CHINH SUA ANH DAI DIEN---------------
$("#change-profile-modal-2").on('hidden.bs.modal', function () {
    $("body").css("overflow", "hidden");
    $("#change-profile-modal-1").css("opacity", "1");
    $("#change-profile-file").val('');
});
$("#change-profile-modal-1").on('hidden.bs.modal', function () {
    $("body").css("overflow", "auto");
});
let cropper = '';

function cropAvaFunc(event) {
    $("#change-profile-modal-2").modal("show");
    $("#change-profile-modal-1").css("opacity", "0.75");

    let result = document.querySelector('#inputImg'),
        imgLoading = document.querySelector('#change-profile-file'),
        imgTitle = document.querySelector('#textarea-mota');
    if (event.target.files.length) {
        // start file reader
        const reader = new FileReader();
        reader.onload = function (event) {
            if (event.target.result) {
                // create new image
                let img = document.createElement('img');
                img.id = 'image';
                img.src = event.target.result;
                img.width = 660;
                img.height = 360;
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
                    minContainerWidth: 660,
                    minContainerHeight: 360,
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
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    $("#avatar-saved").click(function () {
                        cropper.getCroppedCanvas({
                            width: 170,
                            height: 170// input value
                        }).toBlob((blob) => {
                            var formData = new FormData();
                            var token = $('input[name="__RequestVerificationToken"]').val();

                            formData.append('__RequestVerificationToken', token); //form[0]
                            formData.append('nameImg', imgLoading.files[0].name); //fomr[1]
                            formData.append('imgTitle', imgTitle); //fomr[2]

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
                                        $(".user-img img").attr("src", baseUrl + "/Images/" + response.data);
                                        $(".user-ava img").attr("src", baseUrl + "/Images/" + response.data);

                                        $("#change-profile-modal-2").modal("hide");
                                        $("#change-profile-modal-1").modal("hide");
                                    }
                                }
                            });
                        });
                    });
                });
                $("#avatar-cancel").click(function () {
                    $("change-profile-modal-2").modal("hide");
                });
            }
        };
        reader.readAsDataURL(event.target.files[0]);
        initSlideBar();
        resetSlideBar();
    }
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
//---------------------------CHINH SUA CAI DAT CHUNG---------------
$("#capnhat").click(function () {
    changPhone();
});

function changPhone() {
    var phone = $("#suasdt").val();
    var checkPhone = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;

    if (phone == '' || $('#suasdt').is('[readonly]')) {
        ChangeProfile(phone);
    }
    else if (checkPhone.test(phone)) {
        $.ajax({
            url: "/Client/Personal/CheckPhone",
            type: "get",
            dataType: "json",
            data: {
                phone: phone
            },
            success: function (response) {
                if (response.status == true) {
                    $("#check-sdt").attr("key", "1");
                    $("#check-sdt").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
                    ChangeProfile(phone);
                }
                else {
                    $("#check-sdt").attr("key", "0");
                    $("#check-sdt").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
                    ChangeProfile(phone);
                }

            }
        });
    }
    else {
        $("#check-sdt").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
    }
}

function ChangeProfile(phone) {
    var checkUnicode = /[^\u0000-\u007F]/;
    var checkNonUnicode = /^([a-zA-Z]+\s)*[a-zA-Z]+$/;

    var ids = ["ten", "ho", "ngaysinh", "gioitinh"];
    var count = 0;
    var value = [];
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#sua" + id).val();
        if (id === "ten") {
            if (checkUnicode.test(value[i]) || checkNonUnicode.test(value[i])) {
                $("#check-" + id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
                count += 1;
            }
            else {
                $("#check-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            }
        }
        else if (id === "ho") {
            if (checkUnicode.test(value[i]) || checkNonUnicode.test(value[i])) {
                $("#check-" + id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
                count += 1;
            }
            else {
                $("#check-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            }
        }
        else {
            count += 1;
        }
        i++;
    });
    if (count == ids.length && $("#check-sdt").attr("key") != 0) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        var i = 0;
        value.forEach(function (item) {
            formData.append(ids[i], item);
            i++;
        })
        formData.append('sdt', phone);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ChangeGeneralInforJson',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    $(".user-name").text(response.data);
                    if ($("#suasdt").val() != "") {
                        $("#suasdt").attr('readonly', true);
                        $("#suasdt").css('border-right', '1px solid #ced4da');
                        $("#suasdt").css('width', '483px');
                        $("#check-sdt").css("display", "none");
                    }
                    alert("Cập nhật thành công !");
                }
            }
        });
    }
}
//------------------------CONG VIEC VA HOC VAN-------------------
$('#congty-danglamviec').change(function () {
    if (this.checked) {
        $("#form-congty-ketthuc").empty();
        $("#form-congty-ketthuc").append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
    } else {
        $("#form-congty-ketthuc").empty();
        $("#form-congty-ketthuc").append("<input type='date' class='form-control' id='congty-ketthuc'><span class='errors' id='check-congty-ketthuc'><i class='fas fa-times'></i></span>");
    }
});

function JobAdding() {
    var ids = ["ten", "chucvu", "thixa", "batdau"];
    var count = 0;
    var value = new Array();
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#congty-" + id).val();
        if (value[i] != "") {
            $("#check-congty-" + id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            count += 1;
        }
        else {
            $("#check-congty-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        i++;
    });
    if (!$("#congty-danglamviec").is(':checked')) {
        count += 1;
        if ($("#congty-ketthuc").val() == "" || $("#congty-ketthuc").val() == undefined) {
            $("#check-congty-ketthuc").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-congty-ketthuc").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            value[i] = $("#congty-ketthuc").val()
        }
    }
    if (count == value.length) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        var i = 0;
        ids.forEach(function (item) {
            formData.append(item, value[i]);
            i++;
        })
        if (!$("#congty-danglamviec").is(':checked')) {
            formData.append('ketthuc', value[i]);
        }
        formData.append('baomat', $('#congty-baomat').val());
        formData.append('mota', $('#congty-mota').val())

        $.ajax({
            type: 'post',
            url: '/Client/Personal/AddJob_Edu',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    var batdau = new Date(value[3]);
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    var html = '<li class="list-job-item">' +
                        '                                        <div class="job-item-thumbnail">' +
                        '                                            <img src="' + baseUrl+'/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                        '                                        </div>' +
                        '                                        <div class="job-item-name">' +
                        '                                            <p>' + value[0] + '</p>';
                    if (!$("#congty-danglamviec").is(':checked')) {
                        var ketthuc = new Date(value[4])
                        html = html + '<span>' + value[1] + ' ' + batdau.getDay() + ' tháng ' + batdau.getMonth() + ',' + batdau.getFullYear() + ' đến ' + ketthuc.getDay() + ' tháng ' + ketthuc.getMonth() + ',' + ketthuc.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    else {
                        html = html + '<span>' + value[1] + ' ' + batdau.getDay() + ' tháng ' + batdau.getMonth() + ',' + batdau.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    html = html + '</div>' +
                        '                                        <div class="job-item-tools">' +
                        '                                            <i class="far fa-edit"></i>' +
                        '                                            <i class="far fa-trash-alt"></i>' +
                        '                                        </div>' +
                        '                                    </li>';

                    $(".list-job").append(html);
                    $(".job-adding-box").css("display", "none");
                    $(".job-adding").css("display", "block");
                    ids.forEach(function (i) {
                        $("#congty-" + i).val("");
                    })

                    $('#congty-danglamviec').prop('checked', false);
                    $("#form-congty-ketthuc").empty();
                    $("#form-congty-ketthuc").append("<input type='date' class='form-control' id='congty-ketthuc'><span class='errors' id='check-congty-ketthuc'><i class='fas fa-times'></i></span>");

                    $("#congty-ketthuc").val("");
                    $("#congty-mota").val("");
                    $("#congty-baomat").val("0");
                }
            }
        });
    }
}