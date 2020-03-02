$(document).ready(function () {
    var check = ["check-ho", "check-email", "check-matkhau", "check-mota", "check-ngaysinh", "check-gioitinh"];
    var 







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
        var ho = $("#ho").val();
        var ten = $("#ten").val();
        var email = $("#email").val();
        var matkhau1 = $("#matkhau").val();
        var matkhau2 = $("#mota").val();
        var ngaysinh = $("#ngaysinh").val();
        var gioitinh = $("#gioitinh").val();
        var xacnhan = $("#xacnhan").val();

        if (ho && ten && email && matkhau1 && matkhau2 && gioitinh && ngaysinh && xacnhan) {
            return true;
        }
        return false;
    });
});