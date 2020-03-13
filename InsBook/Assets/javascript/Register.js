// tạo đối tượng check
var check = {
    email: function () { // hàm checkemail
        var email = $("#Email").val();
        $.ajax({
            url: "/Client/Register/CheckEmail",
            type: "get",
            dataType: "text",
            data: {
                email: email
            }
        }).done(function (results) {
            var result = $.parseJSON(results);
            var checkemail = isEmail(email);
            if (checkemail) {
                if (result.status) {
                    $("#check-Email").attr("class", "errors");
                    $("#check-Email").attr("key", "0");
                    $("#check-Email").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
                }
                else {
                    $("#check-Email").attr("class", "success");
                    $("#check-Email").attr("key", "1");
                    $("#check-Email").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
                }
            }
            else {
                $("#check-Email").attr("class", "errors");
                $("#check-Email").attr("key", "0");
                $("#check-Email").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            }
        });
    },
    pass: function () { // hàm check mật khẩu
        var pass = $("#Matkhau").val();
        var confirm = $("#XacnhanMatkhau").val();
        if (pass == confirm) {
            // $('.blue').removeClass('blue').addClass('green');
            // $("#td_id").toggleClass('change_me newClass');
            $("#check-XacnhanMatkhau").attr("class", "success");
            $("#check-XacnhanMatkhau").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
            return true;
        } else {
            $("#check-XacnhanMatkhau").attr("class", "errors");
            $("#check-XacnhanMatkhau").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            return false;
        }
    }
};

//kiểm tra sau khi bấm đăng kí
$("#submit").on("click", function () {
    var ids = ["checkbox", "Gioitinh", "Ngaysinh", "XacnhanMatkhau", "Matkhau", "Email", "Ten", "Ho"];
    var count = 0;
    var value = [];
    var i = 0;
    ids.forEach(function (id) {
        value[i] = $("#" + id).val();
        if (value[i]) {
            if (id === "Email") {
                check.email();
                if ($("#check-" + id).attr("key") == 1) {
                    count += 1;
                }
            }
            else if (id === "XacnhanMatkhau") {
                if (check.pass()) {
                    count += 1;
                }
            }
            else {
                count += 1;
                $("#check-" + id).attr("class", "success");
                $("#check-" + id).html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
            }
        }
        else {
            $("#check-" + id).attr("class", "errors");
            $("#check-" + id).html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            $("#" + id).focus();
        }
        i++;
    });
    if (count == ids.length) {
        return true;
    }
    return false;
});

// email đăng ký đã tồn tại chưa
$("#Email").blur(function () {
    check.email();
});

// kiểm tra xác nhận mật khẩu
$("#XacnhanMatkhau").blur(function () {
    check.pass();
});

// hàm check email
function isEmail(emailStr) {
    var emailPat = /^(.+)@(.+)$/;
    var specialChars = "\\(\\)<>@,;:\\\\\\\"\\.\\[\\]";
    var validChars = "\[^\\s" + specialChars + "\]";
    var quotedUser = "(\"[^\"]*\")";
    var ipDomainPat = /^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/;
    var atom = validChars + '+';
    var word = "(" + atom + "|" + quotedUser + ")";
    var userPat = new RegExp("^" + word + "(\\." + word + ")*$");
    var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$");
    var matchArray = emailStr.match(emailPat);

    if (matchArray == null) {
        return false;
    }

    var user = matchArray[1];
    var domain = matchArray[2];

    if (user.match(userPat) == null) {
        return false;
    }

    var IPArray = domain.match(ipDomainPat);

    if (IPArray != null) {
        for (var i = 1; i <= 4; i++) {
            if (IPArray[i] > 255) {
                return false;
            }
        }
        return true;
    }

    var domainArray = domain.match(domainPat);

    if (domainArray == null) {
        return false;
    }

    var atomPat = new RegExp(atom, "g");
    var domArr = domain.match(atomPat);
    var len = domArr.length;

    if (domArr[domArr.length - 1].length < 2 || domArr[domArr.length - 1].length > 3) {
        return false;
    }

    if (len < 2) {
        return false;
    }
    return true;
}
function is_email($str) {
    return (!preg_match("/^([a-z0-9\+_\-]+)(\.[a-z0-9\+_\-]+)*@([a-z0-9\-]+\.)+[a-z]{2,6}$/ix", $str)) ? false : true;
}
// hàm check số điện thoại
function isPhone($phoneStr) {
    var vnf_regex = /((09|03|07|08|05)+([0-9]{8})\b)/g;

    if (vnf_regex.test($phoneStr) == false) {
        return false;
    } else {
        return true
    }
}
