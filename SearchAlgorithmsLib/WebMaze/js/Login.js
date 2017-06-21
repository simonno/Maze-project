
$(document).ready(function () {
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        }
    });

    // validate signup form on keyup and submit
    $("#loginForm").validate({
        rules: {
            username: {
                required: true,
                minlength: 2
            },
            password: {
                required: true,
                minlength: 6
            },
        },
        messages: {
            username: {
                required: "Enter a username",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
            },
            password: {
                required: "Provide a password",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
            },
        },
        // specifying a submitHandler prevents the default submit, good for the demo
        submitHandler: function () {
            var inputUsername = $("#inputUsername").val();
            var inputPassword = $("#inputPassword").val();

            $.ajax({
                url: "api/Users",
                type: 'POST',
                data: { username: inputUsername, inputPassword: inputPassword },
                dataType: 'json',
                success: function (data) {
                    if (data.error == false) {
                        sessionStorage.setItem('user', inputUsername);
                        alert(data.msg);
                    } else {
                        alert(data.msg);
                    }
                }
            });
        },
    });
});

//if (sessionStorage.getItem('user')) {

//    $(location).prop('href', 'http://localhost:50570/HomePage.html')
//}