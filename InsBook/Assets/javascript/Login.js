$(function () {
    // Reference the auto-generated proxy for the hub.
    var session = $.connection.sessionHub;
    session.client.Online = function (userID) {
        $("#check-online-" + userID).html("Offline");
    };
    session.client.Login = function (userID) {
        $("#check-online-" + userID).html("Đang online");
    };

    $.connection.hub.start().done(function () {
        checkOnlineRT = function (data) {
            session.server.checkOnline(data);
        }

        checkLoginRT = function (data) {
            session.server.checkLogin(data)
        }
    });
});

function checkOnlineRT(data) {

}
function checkOnline(data) {
    checkOnlineRT(data)
}

function checkLoginRT(data) {

}
$(window).load(function () {
    var id = $(".user-name-login").attr('id');

    id = id.split("-");
    id = post_id[post_id.length - 1];

    checkLoginRT(id);
});