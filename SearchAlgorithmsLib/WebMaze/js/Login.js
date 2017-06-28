
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
        submitHandler: function () {
            var inputUsername = $("#inputUsername").val();
            var inputPassword = $("#inputPassword").val();
            $.ajax({
                url: "api/Users",
                type: "GET",
                contentType: "application/json",
                data: { username: inputUsername, password: inputPassword },
                success: function (data) {
                    sessionStorage.setItem('user', inputUsername);
                    window.location.assign("HomePage.html")
                }
            })
        },
    });
});