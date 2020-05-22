// tạo đối tượng check
var check = {
    email: function () { // hàm checkemail
        var email = $("#EmailForgetPass").val();
        $.ajax({
            url: "/Client/ForgetPass/CheckEmail",
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
                    $("#check-forgetPass").attr("class", "success");
                    $("#check-forgetPass").attr("key", "1");
                    $("#check-forgetPass").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
                }
                else {
                    $("#check-forgetPass").attr("class", "errors");
                    $("#check-forgetPass").attr("key", "0");
                    $("#check-forgetPass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
                }
            }
            else {
                $("#check-forgetPass").attr("class", "errors");
                $("#check-forgetPass").attr("key", "0");
                $("#check-forgetPass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            }
        });
    }
};

//kiểm tra sau khi bấm đăng kí
$("#submit").on("click", function () {
    if ($("#EmailForgetPass").val()) {
        check.email();
        if ($("#check-forgetPass").attr("key") == 1) {
            $("#check-forgetPass").attr("class", "success");
            $("#check-forgetPass").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
            return true;
        }
        else return false;
    }
    else {
        $("#check-forgetPass").attr("class", "errors");
        $("#check-forgetPass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        $("#check-forgetPass").focus();
        return false;
    }
});

// email đăng ký đã tồn tại chưa
$("#EmailForgetPass").blur(function () {
    check.email();
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

// hàm check số điện thoại
function isPhone($phoneStr) {
    var vnf_regex = /((09|03|07|08|05)+([0-9]{8})\b)/g;

    if (vnf_regex.test($phoneStr) == false) {
        return false;
    } else {
        return true
    }
}
