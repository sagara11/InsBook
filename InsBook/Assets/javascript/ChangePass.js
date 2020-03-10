$("#CheckPass").blur(function() {
    if ($("#Pass").val() == $("#CheckPass").val()) {
        $("#check-CheckPass").attr("class", "success");
        $("#check-CheckPass").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
    }
    else {
        $("#check-CheckPass").attr("class", "errors");
        $("#check-CheckPass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
    }
});

//kiểm tra sau khi bấm đăng kí
$("#submit").on("click", function() {
    if ($("#Pass").val()) {
        if ($("#CheckPass").val()) {
            if ($("#Pass").val() == $("#CheckPass").val()) {
                $("#check-CheckPass").attr("class", "success");
                $("#check-CheckPass").html("<i class='fas fa-check-circle' style='opacity:1;visibility: visible'></i>");
                return true;
            }
            else return false;
        }
        else {
            $("#check-CheckPass").attr("class", "errors");
            $("#check-CheckPass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
            return false;
        }
    }
    else {
        $("#check-Pass").attr("class", "errors");
        $("#check-Pass").html("<i class='fas fa-times' style='opacity:1;visibility: visible'></i>");
        return false;
    }
});