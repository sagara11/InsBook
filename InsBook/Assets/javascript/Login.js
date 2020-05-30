$(function () {
    // Reference the auto-generated proxy for the hub.  
    var session = $.connection.chatHub;
    // Create a function that the hub can call back to display messages.
    session.client.CheckOnline = function (name, message) {
        // Add the message to the page. 
        $('#discussion').append('<li><strong>' + htmlEncode(name)
            + '</strong>: ' + htmlEncode(message) + '</li>');
    };
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub. 
            session.server.checkOnline($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment. 
            $('#message').val('').focus();
        });
    });
});