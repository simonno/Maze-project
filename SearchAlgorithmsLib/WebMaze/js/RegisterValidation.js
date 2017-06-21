
$(document).ready(function () {
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        }
    });

    $.validator.addMethod('strongPassword', function (value, element) {
        return this.optional(element) || (value.lenght >= 6 && /\d/.test(value) && /[a-z]/i.test(value));
    }, 'your password must be at least 6 characters long and contain at least one digit and one latter.')

    // validate signup form on keyup and submit
    $("#registerForm").validate({
        rules: {
            username: {
                required: true,
                minlength: 2
            },
            password: {
                required: true,
                minlength: 6
            },
            verifiedPassword: {
                required: true,
                equalTo: "#id_password"
            },
            email: {
                required: true,
                email: true
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
            verifiedPassword: {
                required: "Repeat your password",
                equalTo: "Enter the same password as above"
            },
            email: {
                required: "Please enter a valid email address",
            },
        },

        submitHandler: function () {
            var username = $("#id_username").val();
            var password = $("#id_password").val();
            var email = $("#id_email").val();

            var user = {
                Username: username,
                Password: password,
                Email: email,
                Losses: 0,
                Wins: 0
            }


            $.post("api/Users", user).done(function () {
                $("#registerForm").fadeOut("slow", function () {
                    $("#massage").text("Thank you for registering");
                })
            });
        },
    });
});
