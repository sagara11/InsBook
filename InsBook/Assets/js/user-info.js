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
            url: '/Client/Personal/AddJob',
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
                    var html = '<li class="list-job-item congty-' + response.data + '">' +
                        '                                        <div class="job-item-thumbnail">' +
                        '                                            <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                        '                                        </div>' +
                        '                                        <div class="job-item-name">' +
                        '                                            <p>' + value[0] + '</p>';
                    if (!$("#congty-danglamviec").is(':checked')) {
                        var ketthuc = new Date(value[4])
                        html = html + '<span>' + value[1] + ' ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ',' + batdau.getFullYear() + ' đến ' + ketthuc.getDate() + ' tháng ' + (ketthuc.getMonth() + 1) + ',' + ketthuc.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    else {
                        html = html + '<span>' + value[1] + ' ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ',' + batdau.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    html = html + '</div>' +
                        '                                        <div class="job-item-tools">' +
                        '                                            <i class="far fa-edit" onclick="JobEditing(' + response.data + ')" id="show-job-editing-box"></i>' +
                        '                                            <i class="far fa-trash-alt" onclick="JobRemoving(' + response.data + ')" id="remove-job"></i>' +
                        '                                        </div>' +
                        '                                    </li>' +
                        '                                    <div class="job-editing-box congty-' + response.data + '-box">' +
                        '                                        <div class="row">' +
                        '                                           <div class="col-md-4">' +
                        '                                                <label for="edit-congty-ten-' + response.data + '">Công ty</label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group">' +
                        '                                                    <input type="text" class="form-control" id="edit-congty-ten-' + response.data + '" placeholder="Bạn đã làm việc ở đâu ?">' +
                        '                                                    <span class="errors" id="check-congty-ten-' + response.data + '"><i class="fas fa-times"></i></span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for="edit-congty-chucvu-' + response.data + '">Chức vụ</label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group">' +
                        '                                                    <input type="text" class="form-control" id="edit-congty-chucvu-' + response.data + '" placeholder="Chức danh của bạn là gì ?">' +
                        '                                                    <span class="errors" id="check-congty-chucvu-' + response.data + '"><i class="fas fa-times"></i></span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for="edit-congty-thixa-' + response.data + '">Thành phố/Thị xã</label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group">' +
                        '                                                    <input type="text" class="form-control edit-congty-thixa" id="edit-congty-thixa-' + response.data + '">' +
                        '                                                    <span class="errors" id="check-congty-thixa-' + response.data + '"><i class="fas fa-times"></i></span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for="edit-congty-mota-' + response.data + '">Mô tả</label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group">' +
                        '                                                    <textarea class="form-control" id="edit-congty-mota-' + response.data + '"></textarea>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for="">Khoảng thời gian</label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-check">' +
                        '                                                    <input class="form-check-input" type="checkbox" value="" id="edit-congty-danglamviec-' + response.data + '" onchange="Jobketthuc(' + response.data + ')">' +
                        '                                                    <label class="form-check-label" for="edit-congty-danglamviec-' + response.data + '">' +
                        '                                                        Tôi hiện đang làm việc ở đây' +
                        '                                                    </label>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for=""></label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group">' +
                        '                                                    <input type="date" class="form-control" id="edit-congty-batdau-' + response.data + '">' +
                        '                                                    <span class="errors" id="check-congty-batdau-' + response.data + '"><i class="fas fa-times"></i></span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <label for=""></label>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <div class="form-group" id="form-edit-congty-ketthuc-' + response.data + '">' +
                        '                                                    <input type="date" class="form-control" id="edit-congty-ketthuc-' + response.data + '">' +
                        '                                                    <span class="errors" id="check-congty-ketthuc-' + response.data + '"><i class="fas fa-times"></i></span>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                            <hr>' +
                        '                                            <div class="col-md-4">' +
                        '                                                <div class="form-group">' +
                        '                                                    <select id="edit-congty-baomat-' + response.data + '" class="form-control">' +
                        '                                                        <option selected value="0">Công khai</option>' +
                        '                                                        <option value="2">Bạn bè</option>' +
                        '                                                        <option value="3">Chỉ mình tôi</option>' +
                        '                                                    </select>' +
                        '                                                </div>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-6">' +
                        '                                                <button type="button" class="btn btn-primary" id="save-job-editing-box-' + response.data + '" onclick="SubmitEditJobBox(' + response.data + ')">Lưu thay đổi</button>' +
                        '                                                <button type="button" class="btn btn-light" id="close-job-editing-box-' + response.data + '" onclick="CloseEditJobBox(' + response.data + ')">Hủy</button>' +
                        '                                            </div>' +
                        '                                            <div class="col-md-2">' +
                        '' +
                        '                                            </div>' +
                        '                                        </div>' +
                        '                                        <button class="btn btn-light job-editing-closse congty-' + response.data + '-closse" type="button" onclick="CloseEditJobBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                        '                                    </div>';
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

function parseJsonDate(jsonDate) {

    var fullDate = new Date(parseInt(jsonDate.substr(6)));
    var twoDigitMonth = (fullDate.getMonth() + 1) + ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;

    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = fullDate.getFullYear() + "-" + twoDigitMonth + "-" + twoDigitDate;

    return currentDate;
};

function JobEditing(congty_id) {
    $(".congty-" + congty_id + "-box").css("display", "inline-block");

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();

    formData.append('__RequestVerificationToken', token); //form[0]
    formData.append('congty_id', congty_id);

    $.ajax({
        type: 'post',
        url: '/Client/Personal/EditJob',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status == true) {
                $("#edit-congty-ten-" + congty_id).val(response.data.tencongty);
                $("#edit-congty-chucvu-" + congty_id).val(response.data.chucvu);
                $("#edit-congty-thixa-" + congty_id).val(response.data.tendiadiem);
                $("#edit-congty-mota-" + congty_id).val(response.data.mota);
                if (response.data.ketthuc == null) {
                    $('#edit-congty-danglamviec-' + congty_id).prop('checked', true);
                    $("#form-edit-congty-ketthuc-" + congty_id).empty();
                    $("#form-edit-congty-ketthuc-" + congty_id).append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
                } else {
                    $('#edit-congty-danglamviec-' + congty_id).prop('checked', false);
                    $("#edit-congty-ketthuc-" + congty_id).val(parseJsonDate(response.data.ketthuc));

                }
                $("#edit-congty-batdau-" + congty_id).val(parseJsonDate(response.data.batdau));
                $("#edit-congty-baomat-" + congty_id).val(response.data.baomat);
            }
        }
    });
}

function CloseEditJobBox(congty_id) {
    $(".congty-" + congty_id + "-box").css("display", "none");
}

function Jobketthuc(congty_id) {
    if ($("#edit-congty-danglamviec-" + congty_id).is(':checked')) {
        $("#form-edit-congty-ketthuc-" + congty_id).empty();
        $("#form-edit-congty-ketthuc-" + congty_id).append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
    } else {
        $("#form-edit-congty-ketthuc-" + congty_id).empty();
        $("#form-edit-congty-ketthuc-" + congty_id).append("<input type='date' class='form-control' id='edit-congty-ketthuc-" + congty_id + "'><span class='errors' id='check-congty-ketthuc-" + congty_id + "'><i class='fas fa-times'></i></span>");
    }
}

function SubmitEditJobBox(congty_id) {
    var ids = ["ten", "chucvu", "thixa", "batdau"];
    var count = 0;
    var value = new Array();
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#edit-congty-" + id + "-" + congty_id).val();
        if (value[i] != "") {
            $("#check-congty-" + id + "-" + congty_id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            count += 1;
        }
        else {
            $("#check-congty-" + id + "-" + congty_id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        i++;
    });
    if (!$("#edit-congty-danglamviec-" + congty_id).is(':checked')) {
        count += 1;
        if ($("#edit-congty-ketthuc-" + congty_id).val() == "" || $("#edit-congty-ketthuc-" + congty_id).val() == undefined) {
            $("#check-congty-ketthuc-" + congty_id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-congty-ketthuc-" + congty_id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            value[i] = $("#edit-congty-ketthuc-" + congty_id).val()
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
        if (!$("#edit-congty-danglamviec-" + congty_id).is(':checked')) {
            formData.append('ketthuc', value[i]);
        }
        formData.append('baomat', $('#edit-congty-baomat-' + congty_id).val());
        formData.append('mota', $('#edit-congty-mota-' + congty_id).val());

        formData.append('congty_id', congty_id);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionEditJob',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    alert("Cập nhật thành công");

                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    var batdau = new Date(value[3]);
                    var html = '<li class="list-job-item congty-' + response.data + '">' +
                        '                                        <div class="job-item-thumbnail">' +
                        '                                            <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                        '                                        </div>' +
                        '                                        <div class="job-item-name">' +
                        '                                            <p>' + value[0] + '</p>';
                    if (!$("#edit-congty-danglamviec-" + congty_id).is(':checked')) {
                        var ketthuc = new Date(value[4]);
                        html = html + '<span>' + value[1] + ' ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ',' + batdau.getFullYear() + ' đến ' + ketthuc.getDate() + ' tháng ' + (ketthuc.getMonth() + 1) + ',' + ketthuc.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    else {
                        html = html + '<span>' + value[1] + ' ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ',' + batdau.getFullYear() + ' ' + value[2] + '</span>';
                    }
                    html = html + '                              </div>' +
                        '                                        <div class="job-item-tools">' +
                        '                                            <i class="far fa-edit" onclick="JobEditing(' + response.data + ')" id="show-job-editing-box"></i>' +
                        '                                            <i class="far fa-trash-alt" onclick="JobRemoving(' + response.data + ')" id="remove-job"></i>' +
                        '                                        </div>' +
                        '                                  </li>';

                    $(".congty-" + congty_id).replaceWith(html);
                }
            }
        });
    }
}

function JobRemoving(congty_id) {
    var result = confirm("Bạn chắc chắc muốn xóa!");
    if (result == true) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('congty_id', congty_id);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionDeleteJob',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    $(".congty-" + congty_id).remove();
                    $(".congty-" + congty_id + "-box").remove();
                }
            }
        });
    } else {
        alert("Bạn đã ấn hủy!");
    }

}








