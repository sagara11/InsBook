$('#update-image').change(function () {
    var file_data = $('#update-image').prop('files')[0];
    var form_data = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();
    form_data.append('avatar', file_data);
    form_data.append('__RequestVerificationToken', token);

    var url = window.location.href.split('/');
    var baseUrl = url[0] + '//' + url[2];

    $.ajax({
        type: 'post',
        url: '/Client/Post/PostUserAvatar',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: form_data
    }).done(function (datas) {
        if (datas.status) {
            var path = baseUrl + '/Images/' + datas.status;
            $('#avatar').attr('src', path);
        }
    });
});
