$(document).ready(function () {
    var check = ["#check-ho", "#check-email", "#check-matkhau", "#check-mota", "#check-ngaysinh", "#check-gioitinh"];
    var event = ["#ho", "#ten", "#email", "#matkhau", "#mota", "#ngaysinh", "#gioitinh"];
    for()






    // kiểm tra xác nhận mật khẩu
    $("#mota").blur(function () {
        var pass = $("#matkhau").val();
        var confirm = $("#mota").val();
        if (pass != confirm) {
            $("#mota").val("");
        }
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
                $("#ch").val("<i class='fas fa-checkcircle'></i>");
            }
            else {
                $("#mota").val("<i class='fas fa-times'></i>");
            }
            i++;
        }

        if (count == event.length) {
            return true;
        }
        return false;
    });
});