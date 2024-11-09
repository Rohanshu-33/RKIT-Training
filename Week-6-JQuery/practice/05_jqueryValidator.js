$(document).ready(function() {
    $("#personalDetailsForm").validate({
        // Specify validation rules
        rules: {
            name: {
                required: true,
            },
            email: {
                required: true,
                email: true
            },
            pswd: {
                required: true,
                minlength: 8,
                maxlength: 20
            }
        },
        // Specify validation error messages as per the rules mentioned above
        messages: {
            name: {
                required: "Please enter your full name",
            },
            email: {
                required: "Please enter your email address",
                email: "Please enter a valid email address"
            },
            pswd: {
                required: "Please provide a password",
                minlength: "Password must be at least 8 characters long",
                maxlength: "Password must be no more than 20 characters long"
            }
        },
        // submithandler function runs if all the above validation passes
        submitHandler: function() {
            alert("Form submitted successfully!")
        }
    });
});
