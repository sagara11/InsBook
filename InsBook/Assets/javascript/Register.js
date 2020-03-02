//kiểm tra sau khi bấm đăng kí
$("#submit").on("click", function (e) {
    //var ho = $().;
    var ids = ["#Ho", "#Ten", "#Email", "#Matkhau", "#XacnhanMatkhau", "#Ngaysinh", "#Gioitinh"];
    var count = 0;
    var value = [];
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $(id).val();
        if (value[i]) {
            count += 1;
            $("#check-"+ id).attr("class", "success");
            $("#check-" + id).html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
        }
        else {
            $("#check-" + id).attr("class", "errors");
            $("#check-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        }
        i++;
    });
    if (count == ids.length) {
        console.log("hahahah");
        return false;
    }
    return false;
});

// email đăng ký đã tồn tại chưa
$("#Email").blur(function () {
    var email = $("#Email").val();
    $.ajax({
        url: "/Client/Register/CheckEmail",
        type: "get",
        dataType: "text",
        data: {
            email: email
        },
        success: function (result) {
            if (result.status) {
                $("#check-Email").attr("class", "errors");
                $("#check-Email").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            }
            else {
                $("#check-Email").attr("class", "success");
                $("#check-Email").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
            }
        }
    });
});

// kiểm tra xác nhận mật khẩu
$("#XacnhanMatkhau").blur(function () {
    var pass = $("#Matkhau").val();
    var confirm = $("#XacnhanMatkhau").val();
    if (pass == confirm) {
        // $('.blue').removeClass('blue').addClass('green');
        // $("#td_id").toggleClass('change_me newClass');
        $("#check-XacnhanMatkhau").attr("class", "success");
        $("#check-XacnhanMatkhau").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
    } else {
        $("#check-XacnhanMatkhau").attr("class", "errors");
        $("#check-XacnhanMatkhau").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
    }
});


