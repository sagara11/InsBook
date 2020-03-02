$(document).ready(function () {
    var event = ["#Ho", "#Ten", "#Email", "#Matkhau", "#XacnhanMatkhau", "#Ngaysinh", "#Gioitinh"];
    // email đăng ký đã tồn tại chưa 
    $("#Email").blur(function () {
        var email = $("#Email").val();
        alert("haha");
        $.ajax({
            url: "/Client/CheckEmail/Register",
            type: "post",
            dataType: "text",
            data: {
                email: email
            },
            success: function (result) {
                if (result.status) {
                    $("check-Email").val("<i class='fas fa-times'></i>");
                }
                else {
                    $("#check-Email").val("<i class='fas fa-checkcircle'></i>");
                }
            }
        });
    });
    // kiểm tra xác nhận mật khẩu
    $("#XacnhanMatkhau").blur(function () {
        var pass = $("#Matkhau").val();
        var confirm = $("#XacnhanMatkhau").val();

       
    });
    //kiểm tra sau khi bấm đăng kí
    $("#submit").click(function () {
        var count = 0;
        var value = [];
        var i = 0;
        event.forEach(event => event)
        {
            var value[i] = $(event).val();
            if (value[i]) {
                count += 1;
                $("#check-" + event).val("<i class='fas fa-checkcircle'></i>");
            }
            else {
                $("#check-" + event).val("<i class='fas fa-times'></i>");
            }
            i++;
        }
        if (count == event.length) {
            return true;
        }
        return false;
    });
});