$('#update-image').change(function () {
    
    var file_data = $('#update-image').prop('files')[0];
    var form_data = new FormData();
    var token = $('input[name="__RequestVerificationToken"]').val();
    form_data.append('avatar', file_data);
    form_data.append('__RequestVerificationToken', token);
    
    console.log(token);

    $.ajax({
        type: 'post',
        url: '/Client/Post/PostUserAvatar',
        dataType: 'json',
        cache: false,
        contentType: false,
        processData: false,
        data: form_data,
        success: function (data) {
            //data = $.parseJSON(data);
            //phần đầu web góc tay phải
            //$('#header-img').attr('src', data.customer.avatar);
        },
        error: function (error) {
            console.log('error');
        }
    });
});
