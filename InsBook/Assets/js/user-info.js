﻿function auto_grow(element) {
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

function CloseSchoolAddingBox(loaitruong) {
    $(".truonghoc-loai-" + loaitruong + "-adding").css("display", "block");
    $(".truonghoc-loai-" + loaitruong + "-adding-box").css("display", "none");
}
function ShowSchoolAddingBox(loaitruong) {
    $(".truonghoc-loai-" + loaitruong + "-adding").css("display", "none");
    $(".truonghoc-loai-" + loaitruong + "-adding-box").css("display", "block");
}

function CloseCountryAddingBox(loaidiadiem) {
    $(".diadiem-loai-" + loaidiadiem + "-adding").css("display", "block");
    $(".diadiem-loai-" + loaidiadiem + "-adding-box").css("display", "none");
}

function ShowCountryAddingBox(loaidiadiem) {
    $(".diadiem-loai-" + loaidiadiem + "-adding").css("display", "none");
    $(".diadiem-loai-" + loaidiadiem + "-adding-box").css("display", "block");
}

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


function CloseDetailInfoAddingBox(loaithongtin) {
    $(".ttct-loai-" + loaithongtin + "-adding").css("display", "block");
    $(".ttct-loai-" + loaithongtin + "-adding-box").css("display", "none");
}

function ShowDetailIndfoAddingBox(loaithongtin) {
    $(".ttct-loai-" + loaithongtin + "-adding").css("display", "none");
    $(".ttct-loai-" + loaithongtin + "-adding-box").css("display", "block");
}

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
        imgLoading = document.querySelector('#change-profile-file');
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
                            width: 710,
                            height: 480// input value
                        }).toBlob((blob) => {
                            var formData = new FormData();
                            var token = $('input[name="__RequestVerificationToken"]').val();

                            formData.append('__RequestVerificationToken', token); //form[0]
                            formData.append('nameImg', imgLoading.files[0].name); //fomr[1]
                            formData.append('imgTitle', $("#textarea-mota").val()); //fomr[2]

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

//------------------------TRUONG DAI HOC-------------------
function SchoolAddingketthuc(loaitruong) {
    if ($("#truonghoc-loai-" + loaitruong + "-danghoc").is(':checked')) {
        $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").empty();
        $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
    } else {
        $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").empty();
        $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").append("<input type='date' class='form-control' id='truonghoc-loai-" + loaitruong + "-ketthuc'><span class='errors' id='check-truonghoc-loai-" + loaitruong + "-ketthuc'><i class='fas fa-times'></i></span>");
    }
}

function SchoolAdding(loaitruong) {
    if (loaitruong == 3) {
        var ids = ["ten", "batdau", "chuyennganh"];
    }
    else if (loaitruong == 2) {
        var ids = ["ten", "batdau"];
    }
    var count = 0;
    var value = new Array();
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#truonghoc-loai-" + loaitruong + "-" + id).val();
        if (value[i] != "") {
            $("#check-truonghoc-loai-" + loaitruong + "-" + id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            count += 1;
        }
        else {
            $("#check-truonghoc-loai-" + loaitruong + "-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        i++;
    });
    if (!$("#truonghoc-loai-" + loaitruong + "-danghoc").is(':checked')) {
        count += 1;
        if ($("#truonghoc-loai-" + loaitruong + "-ketthuc").val() == "" || $("#truonghoc-loai-" + loaitruong + "-ketthuc").val() == undefined) {
            $("#check-truonghoc-loai-" + loaitruong + "-ketthuc").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-truonghoc-loai-" + loaitruong + "-ketthuc").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            value[i] = $("#truonghoc-loai-" + loaitruong + "-ketthuc").val()
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
        if (!$("#truonghoc-loai-" + loaitruong + "-danghoc").is(':checked')) {
            formData.append('ketthuc', value[i]);
        }
        formData.append('baomat', $("#truonghoc-loai-" + loaitruong + "-baomat").val());
        formData.append('mota', $("#truonghoc-loai-" + loaitruong + "-mota").val());
        formData.append('loaitruong', loaitruong);

        var haha = formData;
        $.ajax({
            type: 'post',
            url: '/Client/Personal/AddSchool',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    alert("Thêm thành công");
                    var batdau = new Date(value[1]);
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];
                    if (loaitruong == 3) {
                        var html = '<li class="list-university-item truonghoc-' + response.data + '">' +
                            '                                        <div class="university-item-thumbnail">' +
                            '                                            <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                            '                                        </div>' +
                            '                                        <div class="university-item-name">' +
                            '                                            <p>' + value[0] + '</p>';
                        if (!$("#truonghoc-loai-" + loaitruong + "-danghoc").is(':checked')) {
                            var ketthuc = new Date(value[3])
                            html = html + '<span>Tốt nghiệp khóa ' + ketthuc.getFullYear() + ' ' + value[2] + '</span>';
                        }
                        else {
                            html = html + '<span>Bắt đầu học từ ngày ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ', ' + batdau.getFullYear() + '  ' + value[2] + '</span>';
                        }
                        html = html + '                              </div>' +
                            '                                        <div class="university-item-tools">' +
                            '                                            <i class="far fa-edit" onclick="SchoolEditting(' + response.data + ', 3)" id="show-school-editing-box"></i>' +
                            '                                            <i class="far fa-trash-alt" onclick="SchoolRemoving(' + response.data + ', 3)" id="remove-school"></i>' +
                            '                                        </div>' +
                            '                                    </li>' +
                            '                                    <div class="school-editing-box truonghoc-' + response.data + '-box">' +
                            '                                        <div class="row">' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-ten-' + response.data + '">Trường học</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <input type="text" class="form-control" id="edit-truonghoc-ten-' + response.data + '" placeholder="Bạn đã học tập ở đâu ?">' +
                            '                                                    <span class="errors" id="check-truonghoc-ten-' + response.data + '"><i class="fas fa-times"></i></span>' +
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
                            '                                                    <input class="form-check-input" type="checkbox" value="" id="edit-truonghoc-datotnghiep-' + response.data + '" onclick="Schoolketthuc(' + response.data + ')">' +
                            '                                                    <label class="form-check-label" for="edit-truonghoc-datotnghiep-' + response.data + '">' +
                            '                                                        Tôi đang học tập ở đây' +
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
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-batdau-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-batdau-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for=""></label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group" id="form-edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-ketthuc-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-chuyennganh-' + response.data + '">Chuyên ngành</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <input type="text" class="form-control" id="edit-truonghoc-chuyennganh-' + response.data + '" onclick="GetCNName()">' +
                            '                                                    <span class="errors" id="check-truonghoc-chuyennganh-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-mota-' + response.data + '">Mô tả</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <textarea class="form-control" id="edit-truonghoc-mota-' + response.data + '"></textarea>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '' +
                            '                                            <hr>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <div class="form-group">' +
                            '                                                    <select id="edit-truonghoc-baomat-' + response.data + '" class="form-control">' +
                            '                                                        <option selected value="0">Công khai</option>' +
                            '                                                        <option value="1">Bạn bè</option>' +
                            '                                                        <option value="2">Chỉ mình tôi</option>' +
                            '                                                    </select>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <button type="button" class="btn btn-primary" id="save-school-editing-box-' + response.data + '" onclick="SubmitEditSchoolBox(' + response.data + ', 3)">Lưu thay đổi</button>' +
                            '                                                <button type="button" class="btn btn-light" id="close-school-editing-box-' + response.data + '" onclick="CloseEditSchoolBox(' + response.data + ')">Hủy</button>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                        </div>' +
                            '                                        <button class="btn btn-light school-editing-closse truonghoc-' + response.data + '-closse" type="button" onclick="CloseEditSchoolBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                                    </div>';
                        $(".list-university").append(html);
                    }
                    else if (loaitruong == 2) {
                        alert("haha");
                    }

                    $(".truonghoc-loai-" + loaitruong + "-adding").css("display", "block");
                    $(".truonghoc-loai-" + loaitruong + "-adding-box").css("display", "none");
                    ids.forEach(function (i) {
                        $("#truonghoc-loai-" + loaitruong + "-" + i).val("");
                    })

                    $('#truonghoc-loai-' + loaitruong + '-danghoc').prop('checked', false);
                    $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").empty();
                    $("#form-truonghoc-loai-" + loaitruong + "-ketthuc").append("<input type='date' class='form-control' id='truonghoc-loai-" + loaitruong + "-ketthuc'><span class='errors' id='check-truonghoc-loai-" + loaitruong + "-ketthuc'><i class='fas fa-times'></i></span>");

                    $('#truonghoc-loai-' + loaitruong + '-ketthuc').val("");
                    $('#truonghoc-loai-' + loaitruong + '-mota').val("");
                    $('#truonghoc-loai-' + loaitruong + '-baomat').val("0");
                }
            }
        });
    }
}

function SchoolEditting(truonghoc_id, loaitruong) {
    $(".truonghoc-" + truonghoc_id + "-box").css("display", "inline-block");

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();

    formData.append('__RequestVerificationToken', token); //form[0]
    formData.append('truonghoc_id', truonghoc_id);

    $.ajax({
        type: 'post',
        url: '/Client/Personal/EditSchool',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status == true) {
                $("#edit-truonghoc-ten-" + truonghoc_id).val(response.data.tentruonghoc);
                $("#edit-truonghoc-batdau-" + truonghoc_id).val(parseJsonDate(response.data.batdau));
                $("#edit-truonghoc-mota-" + truonghoc_id).val(response.data.mota);
                if (response.data.ketthuc == null) {
                    $('#edit-truonghoc-datotnghiep-' + truonghoc_id).prop('checked', true);
                    $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).empty();
                    $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
                } else {
                    $('#edit-truonghoc-datotnghiep-' + truonghoc_id).prop('checked', false);
                    $("#edit-truonghoc-ketthuc-" + truonghoc_id).val(parseJsonDate(response.data.ketthuc));

                }
                if (loaitruong == 3) {
                    $("#edit-truonghoc-chuyennganh-" + truonghoc_id).val(response.data.chuyennganh);
                }
                $("#edit-truonghoc-baomat-" + truonghoc_id).val(response.data.baomat);
            }
        }
    });
}

function CloseEditSchoolBox(truonghoc_id) {
    $(".truonghoc-" + truonghoc_id + "-box").css("display", "none");
}

function Schoolketthuc(truonghoc_id) {
    if ($("#edit-truonghoc-datotnghiep-" + truonghoc_id).is(':checked')) {
        $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).empty();
        $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).append("<p style='margin-bottom:0; height: 35px;'> đến nay</p>");
    } else {
        $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).empty();
        $("#form-edit-truonghoc-ketthuc-" + truonghoc_id).append("<input type='date' class='form-control' id='edit-truonghoc-ketthuc-" + truonghoc_id + "'><span class='errors' id='check-truonghoc-ketthuc-" + truonghoc_id + "'><i class='fas fa-times'></i></span>");
    }
}

function SubmitEditSchoolBox(truonghoc_id, loaitruong) {
    if (loaitruong == 3) {
        var ids = ["ten", "batdau", "chuyennganh"];
    }
    else if (loaitruong == 2) {
        var ids = ["ten", "batdau"];
    }
    var count = 0;
    var value = new Array();
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#edit-truonghoc-" + id + "-" + truonghoc_id).val();
        if (value[i] != "") {
            $("#check-truonghoc-" + id + "-" + truonghoc_id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            count += 1;
        }
        else {
            $("#check-truonghoc-" + id + "-" + truonghoc_id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        i++;
    });
    if (!$("#edit-truonghoc-datotnghiep-" + truonghoc_id).is(':checked')) {
        count += 1;
        if ($("#edit-truonghoc-ketthuc-" + truonghoc_id).val() == "" || $("#edit-truonghoc-ketthuc-" + truonghoc_id).val() == undefined) {
            $("#check-truonghoc-ketthuc-" + truonghoc_id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-truonghoc-ketthuc-" + truonghoc_id).html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            value[i] = $("#edit-truonghoc-ketthuc-" + truonghoc_id).val()
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
        if (!$("#edit-truonghoc-datotnghiep-" + truonghoc_id).is(':checked')) {
            formData.append('ketthuc', value[i]);
        }
        formData.append('baomat', $('#edit-truonghoc-baomat-' + truonghoc_id).val());
        formData.append('mota', $('#edit-truonghoc-mota-' + truonghoc_id).val());

        formData.append('truonghoc_id', truonghoc_id);
        formData.append('loaitruong', loaitruong);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionEditSchool',
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
                    var batdau = new Date(value[1]);
                    if (loaitruong == 3) {
                        var html = '<li class="list-university-item truonghoc-' + response.data + '">' +
                            '                                        <div class="university-item-thumbnail">' +
                            '                                            <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                            '                                        </div>' +
                            '                                        <div class="university-item-name">' +
                            '                                            <p>' + value[0] + '</p>';
                        if (!$("#edit-truonghoc-datotnghiep-" + truonghoc_id).is(':checked')) {
                            var ketthuc = new Date(value[3])
                            html = html + '<span>Tốt nghiệp khóa ' + ketthuc.getFullYear() + ' ' + value[2] + '</span>';
                        }
                        else {
                            html = html + '<span>Bắt đầu học từ ngày ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ', ' + batdau.getFullYear() + '  ' + value[2] + '</span>';
                        }
                        html = html + '                              </div>' +
                            '                                        <div class="university-item-tools">' +
                            '                                            <i class="far fa-edit" onclick="SchoolEditting(' + response.data + ', 3)" id="show-school-editing-box"></i>' +
                            '                                            <i class="far fa-trash-alt" onclick="SchoolRemoving(' + response.data + ', 3)" id="remove-school"></i>' +
                            '                                        </div>' +
                            '                                    </li>';
                        htmlEdit = '                                    <div class="school-editing-box truonghoc-' + response.data + '-box">' +
                            '                                        <div class="row">' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-ten-' + response.data + '">Trường học</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <input type="text" class="form-control edit-truonghoc-ten" id="edit-truonghoc-ten-' + response.data + '" placeholder="Bạn đã học tập ở đâu ?">' +
                            '                                                    <span class="errors" id="check-truonghoc-ten-' + response.data + '"><i class="fas fa-times"></i></span>' +
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
                            '                                                    <input class="form-check-input" type="checkbox" value="" id="edit-truonghoc-datotnghiep-' + response.data + '" onclick="Schoolketthuc(' + response.data + ')">' +
                            '                                                    <label class="form-check-label" for="edit-truonghoc-datotnghiep-' + response.data + '">' +
                            '                                                        Tôi đang học tập ở đây' +
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
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-batdau-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-batdau-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for=""></label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group" id="form-edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-ketthuc-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-chuyennganh-' + response.data + '">Chuyên ngành</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <input type="text" class="form-control edit-truonghoc-chuyennganh" id="edit-truonghoc-chuyennganh-' + response.data + '" onclick="GetEditCNName()">' +
                            '                                                    <span class="errors" id="check-truonghoc-chuyennganh-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-mota-' + response.data + '">Mô tả</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <textarea class="form-control" id="edit-truonghoc-mota-' + response.data + '"></textarea>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '' +
                            '                                            <hr>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <div class="form-group">' +
                            '                                                    <select id="edit-truonghoc-baomat-' + response.data + '" class="form-control">' +
                            '                                                        <option selected value="0">Công khai</option>' +
                            '                                                        <option value="1">Bạn bè</option>' +
                            '                                                        <option value="2">Chỉ mình tôi</option>' +
                            '                                                    </select>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <button type="button" class="btn btn-primary" id="save-school-editing-box-' + response.data + '" onclick="SubmitEditSchoolBox(' + response.data + ', 3)">Lưu thay đổi</button>' +
                            '                                                <button type="button" class="btn btn-light" id="close-school-editing-box-' + response.data + '" onclick="CloseEditSchoolBox(' + response.data + ')">Hủy</button>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                        </div>' +
                            '                                        <button class="btn btn-light school-editing-closse truonghoc-' + response.data + '-closse" type="button" onclick="CloseEditSchoolBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                                    </div>';
                    }
                    else {
                        var html = '<li class="list-highschool-item truonghoc-' + response.data + '">' +
                            '                                        <div class="highschool-item-thumbnail">' +
                            '                                            <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                            '                                        </div>' +
                            '                                        <div class="highschool-item-name">' +
                            '                                            <p>' + value[0] + '</p>';
                        if (!$("#edit-truonghoc-datotnghiep-" + truonghoc_id).is(':checked')) {
                            var ketthuc = new Date(value[2])
                            html = html + '<span>Tốt nghiệp khóa ' + ketthuc.getFullYear() + ' </span>';
                        }
                        else {
                            html = html + '<span>Bắt đầu học từ ngày ' + batdau.getDate() + ' tháng ' + (batdau.getMonth() + 1) + ', ' + batdau.getFullYear() + ' </span>';
                        }
                        html = html + '                              </div>' +
                            '                                        <div class="highschool-item-tools">' +
                            '                                            <i class="far fa-edit" onclick="SchoolEditting(' + response.data + ', 2)" id="show-school-editing-box"></i>' +
                            '                                            <i class="far fa-trash-alt" onclick="SchoolRemoving(' + response.data + ', 2)" id="remove-school"></i>' +
                            '                                        </div>' +
                            '                                    </li>';
                        htmlEdit = ' <div class="school-editing-box truonghoc-' + response.data + '-box">' +
                            '                                        <div class="row">' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-ten-' + response.data + '">Trường học</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <input type="text" class="form-control edit-truonghoc-ten" id="edit-truonghoc-ten-' + response.data + '" placeholder="Bạn đã học tập ở đâu ?">' +
                            '                                                    <span class="errors" id="check-truonghoc-ten-' + response.data + '"><i class="fas fa-times"></i></span>' +
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
                            '                                                    <input class="form-check-input" type="checkbox" value="" id="edit-truonghoc-datotnghiep-' + response.data + '" onclick="Schoolketthuc(' + response.data + ')">' +
                            '                                                    <label class="form-check-label" for="edit-truonghoc-datotnghiep-' + response.data + '">' +
                            '                                                        Tôi đang học tập ở đây' +
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
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-batdau-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-batdau-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for=""></label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group" id="form-edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <input type="date" class="form-control" id="edit-truonghoc-ketthuc-' + response.data + '">' +
                            '                                                    <span class="errors" id="check-truonghoc-ketthuc-' + response.data + '"><i class="fas fa-times"></i></span>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <label for="edit-truonghoc-mota-' + response.data + '">Mô tả</label>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <div class="form-group">' +
                            '                                                    <textarea class="form-control" id="edit-truonghoc-mota-' + response.data + '"></textarea>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '' +
                            '                                            <hr>' +
                            '                                            <div class="col-md-4">' +
                            '                                                <div class="form-group">' +
                            '                                                    <select id="edit-truonghoc-baomat-' + response.data + '" class="form-control">' +
                            '                                                        <option selected value="0">Công khai</option>' +
                            '                                                        <option value="1">Bạn bè</option>' +
                            '                                                        <option value="2">Chỉ mình tôi</option>' +
                            '                                                    </select>' +
                            '                                                </div>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-6">' +
                            '                                                <button type="button" class="btn btn-primary" id="save-school-editing-box-' + response.data + '" onclick="SubmitEditSchoolBox(' + response.data + ', 2)">Lưu thay đổi</button>' +
                            '                                                <button type="button" class="btn btn-light" id="close-school-editing-box-' + response.data + '" onclick="CloseEditSchoolBox(' + response.data + ')">Hủy</button>' +
                            '                                            </div>' +
                            '                                            <div class="col-md-2">' +
                            '' +
                            '                                            </div>' +
                            '                                        </div>' +
                            '                                        <button class="btn btn-light school-editing-closse truonghoc-' + response.data + '-closse" type="button" onclick="CloseEditSchoolBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                                    </div>';
                    }
                    $(".truonghoc-" + truonghoc_id).replaceWith(html);
                    $(".truonghoc-" + truonghoc_id + "-box").replaceWith(htmlEdit);
                }
            }
        });
    }
}

function SchoolRemoving(school_id, loaitruong) {
    var result = confirm("Bạn chắc chắc muốn xóa!");
    if (result == true) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('school_id', school_id);
        formData.append('loaitruong', loaitruong);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionDeleteSchool',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    $(".truonghoc-" + school_id).remove();
                    $(".truonghoc-" + school_id + "-box").remove();
                }
            }
        });
    } else {
        alert("Bạn đã ấn hủy!");
    }
}

//-------------------------NHUNG NOI DA SONG-------------------
function CountryAdding(loaidiadiem) {
    if ($("#diadiem-loai-" + loaidiadiem + "-ten").val() == "") {
        $("#check-diadiem-loai-" + loaidiadiem + "-ten").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
    }
    else {
        $("#check-diadiem-loai-" + loaidiadiem + "-ten").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append("ten", $("#diadiem-loai-" + loaidiadiem + "-ten").val());
        formData.append("baomat", $("#diadiem-loai-" + loaidiadiem + "-baomat").val());
        formData.append("loaidiadiem", loaidiadiem);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/AddLocation',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    alert("Thêm thành công");
                    var url = window.location.href.split('/');
                    var baseUrl = url[0] + '//' + url[2];

                    var html = '<li class="list-country-item diadiem-' + response.data + '">' +
                        '                                <div class="country-item-thumbnail">' +
                        '                                    <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                        '                                </div>' +
                        '                                <div class="country-item-name">' +
                        '                                    <p>' + $("#diadiem-loai-" + loaidiadiem + "-ten").val() + '</p>';
                    if (loaidiadiem == 0) {
                        html = html + '<p>Tỉnh/Thành phố hiện tại</p>';
                    }
                    else if (loaidiadiem == 1) {
                        html = html + '<p>Quê quán</p>';
                    }
                    else if (loaidiadiem == 2) {
                        html = html + '<p></p>';
                    }
                    html = html + '                      </div>' +
                        '                                <div class="country-item-tools">' +
                        '                                    <i class="far fa-edit" onclick="CountryEditting(' + response.data + ', ' + loaidiadiem + ')"></i>' +
                        '                                    <i class="far fa-trash-alt" onclick="CountryRemoving(' + response.data + ', ' + loaidiadiem + ')"></i>' +
                        '                                </div>' +
                        '                            </li>';
                    var editHtml = '                <div class="country-editing-box diadiem-' + response.data + '-box">' +
                        '                                <div class="row">' +
                        '                                    <div class="col-md-4">' +
                        '                                        <label for="edit-diadiem-' + response.data + '-ten">Tỉnh/Thành phố hiện tại</label>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-6">' +
                        '                                        <div class="form-group">' +
                        '                                            <input type="text" class="form-control diadiem-ten" id="edit-diadiem-' + response.data + '-ten" placeholder="Nhập địa điểm bạn đang sống">' +
                        '                                            <span class="errors" id="check-diadiem-' + response.data + '-ten"><i class="fas fa-times"></i></span>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-2">' +
                        '' +
                        '                                    </div>' +
                        '' +
                        '                                    <hr>' +
                        '                                    <div class="col-md-4">' +
                        '                                        <div class="form-group">' +
                        '                                            <select id="edit-diadiem-' + response.data + '-baomat" class="form-control">' +
                        '                                                <option value="0" selected>Công khai</option>' +
                        '                                                <option value="1">Bạn bè</option>' +
                        '                                                <option value="2">Chỉ mình tôi</option>' +
                        '                                            </select>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-6">' +
                        '                                        <button type="button" class="btn btn-primary" onclick="SubmitEditCountryBox(' + response.data + ', ' + loaidiadiem + ')">Lưu thay đổi</button>' +
                        '                                        <button type="button" class="btn btn-light" id="close-country-editing-box" onclick="CloseCountryEditBox(' + response.data + ', ' + loaidiadiem + ')">Hủy</button>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-2">' +
                        '' +
                        '                                    </div>' +
                        '                                </div>' +
                        '                                <button class="btn btn-light country-closse" type="button" onclick="CloseCountryEditBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                        '                            </div>';
                    if (loaidiadiem == 2) {
                        html = html + editHtml;
                        $(".list-country-" + loaidiadiem).append(html);
                        $(".diadiem-loai-" + loaidiadiem + "-adding-box").css("display", "none");
                        $(".diadiem-loai-" + loaidiadiem + "-adding").css("display", "block");

                        $("#diadiem-loai-" + loaidiadiem + "-ten").val("");
                        $("#diadiem-loai-" + loaidiadiem + "-baomat").val("0");
                    }
                    else {
                        $("#diadiem-loai-" + loaidiadiem + "-ten").val("");
                        $("#diadiem-loai-" + loaidiadiem + "-baomat").val("0");

                        $(".diadiem-loai-" + loaidiadiem + "-adding-box").replaceWith(editHtml);
                        $(".diadiem-loai-" + loaidiadiem + "-adding").replaceWith(html);
                    }
                }
            }
        });
    }
}
function CountryEditting(diadiem_id, loaidiadiem) {
    $(".diadiem-" + diadiem_id + "-box").css("display", "inline-block");

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();

    formData.append('__RequestVerificationToken', token); //form[0]
    formData.append('diadiem_id', diadiem_id);

    $.ajax({
        type: 'post',
        url: '/Client/Personal/EditLocation',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status == true) {
                $("#edit-diadiem-" + diadiem_id + "-ten").val(response.data.tendd);
                $("#edit-diadiem-" + diadiem_id + "-baomat").val(response.data.baomat);
            }
        }
    });
}

function CloseCountryEditBox(diadiem_id) {
    $(".diadiem-" + diadiem_id + "-box").css("display", "none");
}

function SubmitEditCountryBox(diadiem_id, loaidiadiem) {
    if ($("#edit-diadiem-" + diadiem_id + "-ten").val() == "") {
        $("#check-diadiem-" + diadiem_id + "-ten").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
    }
    else {
        $("#check-diadiem-" + diadiem_id + "-ten").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append("ten", $("#edit-diadiem-" + diadiem_id + "-ten").val());
        formData.append("baomat", $("#edit-diadiem-" + diadiem_id + "-baomat").val());
        formData.append("loaidiadiem", loaidiadiem);
        formData.append("diadiem_id", diadiem_id);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionEditLocation',
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

                    var html = '<li class="list-country-item diadiem-' + response.data + '">' +
                        '                                <div class="country-item-thumbnail">' +
                        '                                    <img src="' + baseUrl + '/Images/22904751_688560231353134_2748711313877205190_o.jpg" alt="">' +
                        '                                </div>' +
                        '                                <div class="country-item-name">' +
                        '                                    <p>' + $("#edit-diadiem-" + diadiem_id + "-ten").val() + '</p>';
                    if (loaidiadiem == 0) {
                        html = html + '<p>Tỉnh/Thành phố hiện tại</p>';
                    }
                    else if (loaidiadiem == 1) {
                        html = html + '<p>Quê quán</p>';
                    }
                    else if (loaidiadiem == 2) {
                        html = html + '<p></p>';
                    }
                    html = html + '                      </div>' +
                        '                                <div class="country-item-tools">' +
                        '                                    <i class="far fa-edit" onclick="CountryEditting(' + response.data + ', ' + loaidiadiem + ')"></i>' +
                        '                                    <i class="far fa-trash-alt" onclick="CountryRemoving(' + response.data + ', ' + loaidiadiem + ')"></i>' +
                        '                                </div>' +
                        '                            </li>';
                    var editHtml = '                <div class="country-editing-box diadiem-' + response.data + '-box">' +
                        '                                <div class="row">' +
                        '                                    <div class="col-md-4">' +
                        '                                        <label for="edit-diadiem-' + response.data + '-ten">Tỉnh/Thành phố hiện tại</label>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-6">' +
                        '                                        <div class="form-group">' +
                        '                                            <input type="text" class="form-control diadiem-ten" id="edit-diadiem-' + response.data + '-ten" placeholder="Nhập địa điểm bạn đang sống">' +
                        '                                            <span class="errors" id="check-diadiem-' + response.data + '-ten"><i class="fas fa-times"></i></span>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-2">' +
                        '' +
                        '                                    </div>' +
                        '' +
                        '                                    <hr>' +
                        '                                    <div class="col-md-4">' +
                        '                                        <div class="form-group">' +
                        '                                            <select id="edit-diadiem-' + response.data + '-baomat" class="form-control">' +
                        '                                                <option value="0" selected>Công khai</option>' +
                        '                                                <option value="1">Bạn bè</option>' +
                        '                                                <option value="2">Chỉ mình tôi</option>' +
                        '                                            </select>' +
                        '                                        </div>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-6">' +
                        '                                        <button type="button" class="btn btn-primary" onclick="SubmitEditCountryBox(' + response.data + ', ' + loaidiadiem + ')">Lưu thay đổi</button>' +
                        '                                        <button type="button" class="btn btn-light" id="close-country-editing-box" onclick="CloseCountryEditBox(' + response.data + ', ' + loaidiadiem + ')">Hủy</button>' +
                        '                                    </div>' +
                        '                                    <div class="col-md-2">' +
                        '' +
                        '                                    </div>' +
                        '                                </div>' +
                        '                                <button class="btn btn-light country-closse" type="button" onclick="CloseCountryEditBox(' + response.data + ')"><i class="fas fa-times"></i> Hủy</button>' +
                        '                            </div>';

                    $(".diadiem-" + diadiem_id).replaceWith(html);
                    $(".diadiem-" + diadiem_id + "-box").replaceWith(editHtml);
                }
            }
        });
    }
}

function CountryRemoving(diadiem_id, loaidiadidem) {
    var result = confirm("Bạn chắc chắc muốn xóa!");
    if (result == true) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('diadiem_id', diadiem_id);
        formData.append('loaidiadidem', loaidiadidem);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionDeleteLocation',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    if (loaidiadidem == 2) {
                        $(".diadiem-" + diadiem_id).remove();
                        $(".diadiem-" + diadiem_id + "-box").remove();
                    } else {

                        var add = '<div class="country-adding diadiem-loai-' + loaidiadidem + '-adding">' +
                            '                                <button type="button" class="btn btn-light" id="show-country-adding-box" onclick="ShowCountryAddingBox(' + loaidiadidem + ')"><i class="far fa-plus-square"></i><span>Thêm tỉnh/thành phố hiện tại</span></button>' +
                            '                            </div>';
                        var add_box = '                  <div class="country-adding-box diadiem-loai-' + loaidiadidem + '-adding-box">' +
                            '                                <div class="row">' +
                            '                                    <div class="col-md-4">' +
                            '                                        <label for="diadiem-loai-' + loaidiadidem + '-ten">Tỉnh/Thành phố hiện tại</label>' +
                            '                                    </div>' +
                            '                                    <div class="col-md-6">' +
                            '                                        <div class="form-group">' +
                            '                                            <input type="text" class="form-control diadiem-ten" id="diadiem-loai-' + loaidiadidem + '-ten" placeholder="Nhập địa điểm bạn đang sống">' +
                            '                                            <span class="errors" id="check-diadiem-loai-' + loaidiadidem + '-ten"><i class="fas fa-times"></i></span>' +
                            '                                        </div>' +
                            '                                    </div>' +
                            '                                    <div class="col-md-2">' +
                            '' +
                            '                                    </div>' +
                            '' +
                            '                                    <hr>' +
                            '                                    <div class="col-md-4">' +
                            '                                        <div class="form-group">' +
                            '                                            <select id="diadiem-loai-' + loaidiadidem + '-baomat" class="form-control">' +
                            '                                                <option value="0" selected>Công khai</option>' +
                            '                                                <option value="1">Bạn bè</option>' +
                            '                                                <option value="2">Chỉ mình tôi</option>' +
                            '                                            </select>' +
                            '                                        </div>' +
                            '                                    </div>' +
                            '                                    <div class="col-md-6">' +
                            '                                        <button type="button" class="btn btn-primary" onclick="CountryAdding(' + loaidiadidem + ')">Lưu thay đổi</button>' +
                            '                                        <button type="button" class="btn btn-light" id="close-country-adding-box" onclick="CloseCountryAddingBox(' + loaidiadidem + ')">Hủy</button>' +
                            '                                    </div>' +
                            '                                    <div class="col-md-2">' +
                            '' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <button class="btn btn-light country-closse" type="button" onclick="CloseCountryAddingBox(' + loaidiadidem + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                            </div>';

                        $(".diadiem-" + diadiem_id).replaceWith(add);
                        $(".diadiem-" + diadiem_id + "-box").replaceWith(add_box)
                    }
                }
            }
        });
    } else {
        alert("Bạn đã ấn hủy!");
    }
}
//-------------------------THONG TIN CHI TIET-------------------
function DetailInfoAdding(loaithongtin) {
    if (loaithongtin == 0) {
        if ($("#ttct-loai-" + loaithongtin + "-gioithieu").val() == "") {
            $("#check-ttct-loai-" + loaithongtin + "-gioithieu").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-ttct-loai-" + loaithongtin + "-gioithieu").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("gioithieu", $("#ttct-loai-" + loaithongtin + "-gioithieu").val());
            formData.append("baomat", $("#ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);

            $.ajax({
                type: 'post',
                url: '/Client/Personal/AddDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Thêm thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#ttct-loai-" + loaithongtin + "-gioithieu").val() + '</p>' +
                            '                                    <p></p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';
                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-gioithieu">Giới thiệu về bản thân</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="edit-ttct-loai-' + loaithongtin + '-gioithieu" placeholder="Nhập lời giới thiệu về bạn"></textarea>' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-gioithieu"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';
                        $(".user-description-three").append('<h1 class="user-description-three-gioithieu">' + $("#ttct-loai-" + loaithongtin + "-gioithieu").val() + '</h1>');

                        $(".ttct-loai-" + loaithongtin + "-adding").replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-adding-box").replaceWith(editHtml);

                    }
                }
            });
        }
    }
    else if (loaithongtin == 1) {
        if ($("#ttct-loai-" + loaithongtin + "-ten").val() == "") {
            $("#check-ttct-loai-" + loaithongtin + "-ten").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-diadiem-loai-" + loaithongtin + "-ten").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("ten", $("#ttct-loai-" + loaithongtin + "-ten").val());
            formData.append("baomat", $("#ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);
            formData.append("loaibietdanh", $("#ttct-loai-" + loaithongtin + "-loaibietdanh").val())

            $.ajax({
                type: 'post',
                url: '/Client/Personal/AddDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Thêm thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#ttct-loai-" + loaithongtin + "-ten").val() + '</p>' +
                            '                                    <p>' + $("#ttct-loai-" + loaithongtin + "-loaibietdanh option:selected").text() + '</p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';
                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-loaibietdanh">Loại tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-loaibietdanh" class="form-control loaibietdanh">' +
                            '                                            <option selected value="0">Biệt danh</option>' +
                            '                                            <option value="1">Tên thời con gái</option>' +
                            '                                            <option value="2">Cách viết tên khác</option>' +
                            '                                            <option value="3">Tên sau kết hôn</option>' +
                            '                                            <option value="4">Họ và tên bố</option>' +
                            '                                            <option value="5">Tên khai sinh</option>' +
                            '                                            <option value="6">Tên cũ</option>' +
                            '                                            <option value="7">Tên có chức danh</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-ten">Tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input type="text" class="form-control" id="edit-ttct-loai-' + loaithongtin + '-ten">' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-ten"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".user-description-three").append('<h1 class="user-description-three-bietdanh">' + $("#ttct-loai-" + loaithongtin + "-ten").val() + '</h1>');

                        $(".ttct-loai-" + loaithongtin + "-adding").replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-adding-box").replaceWith(editHtml);

                    }
                }
            });
        }
    }
    else if (loaithongtin == 2) {
        count = 0;
        if ($("#ttct-loai-" + loaithongtin + "-trichdan").val() == "") {
            $("#check-ttct-loai-" + loaithongtin + "-trichdan").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            count += 1;
        }
        else {
            $("#check-ttct-loai-" + loaithongtin + "-trichdan").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        }
        if ($("#ttct-loai-" + loaithongtin + "-tacgia").val() == "") {
            $("#check-ttct-loai-" + loaithongtin + "-tacgia").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            count += 1;
        }
        else {
            $("#check-ttct-loai-" + loaithongtin + "-tacgia").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        }
        if (count == 0) {
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("trichdan", $("#ttct-loai-" + loaithongtin + "-trichdan").val());
            formData.append("tacgia", $("#ttct-loai-" + loaithongtin + "-tacgia").val());
            formData.append("baomat", $("#ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);

            $.ajax({
                type: 'post',
                url: '/Client/Personal/AddDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Thêm thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#ttct-loai-" + loaithongtin + "-trichdan").val() + '</p>' +
                            '                                    <p>' + $("#ttct-loai-" + loaithongtin + "-tacgia").val() + '</p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';

                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-trichdan">Trích dẫn yêu thích</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="edit-ttct-loai-' + loaithongtin + '-trichdan"></textarea>' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-trichdan"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-tacgia">Tác giả</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input class="form-control" id="edit-ttct-loai-' + loaithongtin + '-tacgia">' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-tacgia"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".ttct-loai-" + loaithongtin + "-adding").replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-adding-box").replaceWith(editHtml);
                    }
                }
            });
        }
    }
}
function DetailInfoEditting(loaithongtin) {
    $(".ttct-loai-" + loaithongtin + "-editing-box").css("display", "inline-block");

    var formData = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();

    formData.append('__RequestVerificationToken', token); //form[0]
    formData.append("loaithongtin", loaithongtin);

    $.ajax({
        type: 'post',
        url: '/Client/Personal/EditDetailInfo',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            if (response.status == true) {
                if (loaithongtin == 0) {
                    $("#edit-ttct-loai-" + loaithongtin + "-gioithieu").val(response.data);
                }
                else if (loaithongtin == 1) {
                    var datas = response.data.split('@');
                    $("#edit-ttct-loai-" + loaithongtin + "-loaibietdanh").val(datas[0]);
                    $("#edit-ttct-loai-" + loaithongtin + "-ten").val(datas[1]);
                }
                else if (loaithongtin == 2) {
                    var datas = response.data.split('@');
                    $("#edit-ttct-loai-" + loaithongtin + "-trichdan").val(datas[0]);
                    $("#edit-ttct-loai-" + loaithongtin + "-tacgia").val(datas[1]);
                }
            }
        }
    });
}

function CloseDetailInfoEditBox(loaithongtin) {
    $(".ttct-loai-" + loaithongtin + "-editing-box").css("display", "none");
}

function SubmitEditDetailInfoBox(loaithongtin) {
    if (loaithongtin == 0) {
        if ($("#edit-ttct-loai-" + loaithongtin + "-gioithieu").val() == "") {
            $("#check-edit-ttct-loai-" + loaithongtin + "-gioithieu").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-edit-ttct-loai-" + loaithongtin + "-gioithieu").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("gioithieu", $("#edit-ttct-loai-" + loaithongtin + "-gioithieu").val());
            formData.append("baomat", $("#edit-ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);

            $.ajax({
                type: 'post',
                url: '/Client/Personal/ActionEditDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Cập nhật thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#edit-ttct-loai-" + loaithongtin + "-gioithieu").val() + '</p>' +
                            '                                    <p></p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';
                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-gioithieu">Giới thiệu về bản thân</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="edit-ttct-loai-' + loaithongtin + '-gioithieu" placeholder="Nhập lời giới thiệu về bạn"></textarea>' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-gioithieu"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".user-description-three-gioithieu").replaceWith('<h1 class="user-description-three-gioithieu">' + $("#edit-ttct-loai-" + loaithongtin + "-gioithieu").val() + '</h1>');

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);

                    }
                }
            });
        }
    }
    else if (loaithongtin == 1) {
        if ($("#edit-ttct-loai-" + loaithongtin + "-ten").val() == "") {
            $("#check-edit-ttct-loai-" + loaithongtin + "-ten").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-edit-diadiem-loai-" + loaithongtin + "-ten").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("ten", $("#edit-ttct-loai-" + loaithongtin + "-ten").val());
            formData.append("baomat", $("#edit-ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);
            formData.append("loaibietdanh", $("#edit-ttct-loai-" + loaithongtin + "-loaibietdanh").val())

            $.ajax({
                type: 'post',
                url: '/Client/Personal/ActionEditDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Cập nhật thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#edit-ttct-loai-" + loaithongtin + "-ten").val() + '</p>' +
                            '                                    <p>' + $("#edit-ttct-loai-" + loaithongtin + "-loaibietdanh option:selected").text() + '</p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';
                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-loaibietdanh">Loại tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-loaibietdanh" class="form-control loaibietdanh">' +
                            '                                            <option selected value="0">Biệt danh</option>' +
                            '                                            <option value="1">Tên thời con gái</option>' +
                            '                                            <option value="2">Cách viết tên khác</option>' +
                            '                                            <option value="3">Tên sau kết hôn</option>' +
                            '                                            <option value="4">Họ và tên bố</option>' +
                            '                                            <option value="5">Tên khai sinh</option>' +
                            '                                            <option value="6">Tên cũ</option>' +
                            '                                            <option value="7">Tên có chức danh</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-ten">Tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input type="text" class="form-control" id="edit-ttct-loai-' + loaithongtin + '-ten">' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-ten"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".user-description-three-bietdanh").replaceWith('<h1 class="user-description-three-bietdanh">' + $("#edit-ttct-loai-" + loaithongtin + "-ten").val() + '</h1>');

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);

                    }
                }
            });
        }
    }
    else if (loaithongtin == 2) {
        count = 0;
        if ($("#edit-ttct-loai-" + loaithongtin + "-trichdan").val() == "") {
            $("#check-edit-ttct-loai-" + loaithongtin + "-trichdan").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            count += 1;
        }
        else {
            $("#check-edit-ttct-loai-" + loaithongtin + "-trichdan").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        }
        if ($("#edit-ttct-loai-" + loaithongtin + "-tacgia").val() == "") {
            $("#check-edit-ttct-loai-" + loaithongtin + "-tacgia").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            count += 1;
        }
        else {
            $("#check-edit-ttct-loai-" + loaithongtin + "-tacgia").html("<i class='fas fa-times' style='opacity:0;visibility: hidden'></i>");
        }
        if (count == 0) {
            var formData = new FormData();
            var token = $('input[name="__RequestVerificationToken"]').val();

            formData.append('__RequestVerificationToken', token); //form[0]
            formData.append("trichdan", $("#edit-ttct-loai-" + loaithongtin + "-trichdan").val());
            formData.append("tacgia", $("#edit-ttct-loai-" + loaithongtin + "-tacgia").val());
            formData.append("baomat", $("#edit-ttct-loai-" + loaithongtin + "-baomat").val());
            formData.append("loaithongtin", loaithongtin);

            $.ajax({
                type: 'post',
                url: '/Client/Personal/ActionEditDetailInfo',
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    if (response.status == true) {
                        alert("Cập nhật thành công");

                        var html = '<ul class="list-detail-info ttct-loai-' + loaithongtin + '">' +
                            '                            <li class="list-detail-info-item">' +
                            '                                <div class="detail-info-item-name">' +
                            '                                    <p>' + $("#edit-ttct-loai-" + loaithongtin + "-trichdan").val() + '</p>' +
                            '                                    <p>' + $("#edit-ttct-loai-" + loaithongtin + "-tacgia").val() + '</p>' +
                            '                                </div>' +
                            '                                <div class="detail-info-item-tools">' +
                            '                                    <i class="far fa-edit" onclick="DetailInfoEditting(' + loaithongtin + ')"></i>' +
                            '                                    <i class="far fa-trash-alt" onclick="DetailInfoRemoving(' + loaithongtin + ')"></i>' +
                            '                                </div>' +
                            '                            </li>' +
                            '                        </ul>';

                        var editHtml = '             <div class="detail-info-editing-box ttct-loai-' + loaithongtin + '-editing-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-trichdan">Trích dẫn yêu thích</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="edit-ttct-loai-' + loaithongtin + '-trichdan"></textarea>' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-trichdan"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="edit-ttct-loai-' + loaithongtin + '-tacgia">Tác giả</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input class="form-control" id="edit-ttct-loai-' + loaithongtin + '-tacgia">' +
                            '                                        <span class="errors" id="check-edit-ttct-loai-' + loaithongtin + '-tacgia"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="edit-ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="SubmitEditDetailInfoBox(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-editing-box" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoEditBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);
                    }
                }
            });
        }
    }
}

function DetailInfoRemoving(loaithongtin) {
    var result = confirm("Bạn chắc chắc muốn xóa!");
    if (result == true) {
        var formData = new FormData();
        var token = $('input[name="__RequestVerificationToken"]').val();

        formData.append('__RequestVerificationToken', token); //form[0]
        formData.append('loaithongtin', loaithongtin);

        $.ajax({
            type: 'post',
            url: '/Client/Personal/ActionDeleteDetailInfo',
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                if (response.status == true) {
                    alert("Xóa thành công");
                    if (loaithongtin == 0) {

                        var html = '<div class="detail-info-adding ttct-loai-' + loaithongtin + '-adding">' +
                            '                            <button type="button" class="btn btn-light" id="show-detail-info-adding-box" onclick="ShowDetailIndfoAddingBox(' + loaithongtin + ')"><i class="far fa-plus-square"></i><span>Viết một số điều về chính bạn</span></button>' +
                            '                        </div>';
                        var editHtml = '<div class="detail-info-adding-box ttct-loai-' + loaithongtin + '-adding-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="ttct-loai-' + loaithongtin + '-gioithieu">Giới thiệu về bản thân</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="ttct-loai-' + loaithongtin + '-gioithieu" placeholder="Nhập lời giới thiệu về bạn"></textarea>' +
                            '                                        <span class="errors" id="check-ttct-loai-' + loaithongtin + '-gioithieu"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="DetailInfoAdding(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-adding-box" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);

                        $(".user-description-three-gioithieu").remove();
                    }
                    else if (loaithongtin == 1) {

                        var html = '<div class="detail-info-adding ttct-loai-' + loaithongtin + '-adding">' +
                            '                            <button type="button" class="btn btn-light" id="show-detail-info-adding-box" onclick="ShowDetailIndfoAddingBox(' + loaithongtin + ')"><i class="far fa-plus-square"></i><span>Thêm biệt danh, tên khai sinh,...</span></button>' +
                            '                        </div>';
                        var editHtml = '<div class="detail-info-adding-box ttct-loai-' + loaithongtin + '-adding-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="ttct-loai-' + loaithongtin + '-loaibietdanh">Loại tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="ttct-loai-' + loaithongtin + '-loaibietdanh" class="form-control loaibietdanh">' +
                            '                                            <option selected value="0">Biệt danh</option>' +
                            '                                            <option value="1">Tên thời con gái</option>' +
                            '                                            <option value="2">Cách viết tên khác</option>' +
                            '                                            <option value="3">Tên sau kết hôn</option>' +
                            '                                            <option value="4">Họ và tên bố</option>' +
                            '                                            <option value="5">Tên khai sinh</option>' +
                            '                                            <option value="6">Tên cũ</option>' +
                            '                                            <option value="7">Tên có chức danh</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-3">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="ttct-loai-' + loaithongtin + '-ten">Tên</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input type="text" class="form-control" id="ttct-loai-' + loaithongtin + '-ten">' +
                            '                                        <span class="errors" id="check-ttct-loai-' + loaithongtin + '-ten"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="DetailInfoAdding(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-adding-box" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);


                        $(".user-description-three-bietdanh").remove();
                    }
                    else if (loaithongtin == 2) {
                        var html = '<div class="detail-info-adding ttct-loai-' + loaithongtin + '-adding">' +
                            '                            <button type="button" class="btn btn-light" id="show-detail-info-adding-box" onclick="ShowDetailIndfoAddingBox(' + loaithongtin + ')"><i class="far fa-plus-square"></i><span>Thêm câu trích dẫn yêu thích của bạn</span></button>' +
                            '                        </div>';

                        var editHtml = '<div class="detail-info-adding-box ttct-loai-' + loaithongtin + '-adding-box">' +
                            '                            <div class="row">' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="ttct-loai-' + loaithongtin + '-trichdan">Trích dẫn yêu thích</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <textarea class="form-control" id="ttct-loai-' + loaithongtin + '-trichdan"></textarea>' +
                            '                                        <span class="errors" id="check-ttct-loai-' + loaithongtin + '-trichdan"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                                <div class="col-md-4">' +
                            '                                    <label for="ttct-loai-' + loaithongtin + '-tacgia">Tác giả</label>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <div class="form-group">' +
                            '                                        <input class="form-control" id="ttct-loai-' + loaithongtin + '-tacgia">' +
                            '                                        <span class="errors" id="check-ttct-loai-' + loaithongtin + '-tacgia"><i class="fas fa-times"></i></span>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '' +
                            '                                <hr>' +
                            '                                <div class="col-md-4">' +
                            '                                    <div class="form-group">' +
                            '                                        <select id="ttct-loai-' + loaithongtin + '-baomat" class="form-control">' +
                            '                                            <option selected value="0">Công khai</option>' +
                            '                                            <option value="1">Bạn bè</option>' +
                            '                                            <option value="2">Chỉ mình tôi</option>' +
                            '                                        </select>' +
                            '                                    </div>' +
                            '                                </div>' +
                            '                                <div class="col-md-6">' +
                            '                                    <button type="button" class="btn btn-primary" onclick="DetailInfoAdding(' + loaithongtin + ')">Lưu thay đổi</button>' +
                            '                                    <button type="button" class="btn btn-light" id="close-detail-info-adding-box" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')">Hủy</button>' +
                            '                                </div>' +
                            '                                <div class="col-md-2">' +
                            '' +
                            '                                </div>' +
                            '                            </div>' +
                            '                            <button class="btn btn-light detail-info-closse" type="button" onclick="CloseDetailInfoAddingBox(' + loaithongtin + ')"><i class="fas fa-times"></i> Hủy</button>' +
                            '                        </div>';

                        $(".ttct-loai-" + loaithongtin).replaceWith(html);
                        $(".ttct-loai-" + loaithongtin + "-editing-box").replaceWith(editHtml);
                    }
                }
            }
        });
    } else {
        alert("Bạn đã ấn hủy!");
    }
}