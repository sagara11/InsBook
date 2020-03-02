$(document).ready(function () {
    // message box
    $("#messenger").css("height", "50px");
    $(".messenger-body").css("display", "none");
    $(".messenger-reply").css("display", "none");

    // message section
    $('#people-message-btn').css('background-color', 'rgb(247, 247, 247)');
    $('#group-message').css('display', 'none');
    $('#group-message').css('width', '0px');

    $(".message-box").click(function () {
        $("#messenger").css("height", "400px");
        $(".messenger-body").css("display", "block");
        $(".messenger-reply").css("display", "flex");
    });

    $("#message-close").click(function () {
        $("#messenger").css("height", "50px");
        $(".messenger-body").css("display", "none");
        $(".messenger-reply").css("display", "none");
    });

    $('#group-message-btn').click(function () {
        $('#people-message-btn').css('background-color', 'white');
        $('#group-message-btn').css('background-color', 'rgb(247, 247, 247)');
        $('#group-message').css('display', 'block');
        $('#people-message').css('width', '0px');
        $('#group-message').css('width', '300px');
    });
    $('#people-message-btn').click(function () {
        $('#group-message-btn').css('background-color', 'white');
        $('#people-message-btn').css('background-color', 'rgb(247, 247, 247)');
        $('#group-message').css('width', '0px');
        $('#people-message').css('width', '300px');
    });
});