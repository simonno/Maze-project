
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
            //var user =
            $.ajax({
                url: "api/Users",
                type: "GET",
                contentType: "application/json",
                data: { username: inputUsername, password: inputPassword },
                success: function (data) {
                    alert("funnnnn");
                },
                error: function () {
                    alert("error");
                }
            })

            //$.post("api/Users", inputUsername, inputPassword).done(function (data) {
            //    if (data.error == false) {
            //        var defaultNum = 5;
            //        var defaultAlgo = 0;//0 
            //        sessionStorage.setItem('user', inputUsername);

            //        sessionStorage.setItem('defaultRows', defaultNum);
            //        sessionStorage.setItem('defaultCols', defalutNum);
            //        sessionStorage.setItem('defaultAlgo', defaultAlgo);

            //        alert(data.msg);
            //    } else {
            //        alert(data.msg);
            //    }
            //});
        },
    });
});

//if (sessionStorage.getItem('user')) {

//    $(location).prop('href', 'http://localhost:50570/HomePage.html')
//}