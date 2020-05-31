$(function () {
    // Reference the auto-generated proxy for the hub.
    var session = $.connection.sessionHub;
    session.client.Online = function (userID) {
        alert(userID);
    };

    $.connection.hub.start().done(function () {
        checkOnlineRT = function (data) {
            session.server.checkOnline(data);
        }
    });
});

function checkOnlineRT(data) {

}
function checkOnline(data) {
    checkOnlineRT(data)
}
