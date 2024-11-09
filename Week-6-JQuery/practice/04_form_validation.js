const emailPattern = /^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]+$/;
const passwordPattern = /^[^\s]{8,20}$/;

$(document).ready(function () {
    $("#personalDetailsForm").submit(function(e){
        e.preventDefault()
        full_name = $("#name").val().trim()
        email = $("#email").val()
        pswd = $("#pswd").val()
        errors = ""
        success=true

        if(full_name === ""){
            errors += "Full name required.\n"
            success=false
        }
        if(!emailPattern.test(email)){
            errors += "Enter valid email-id.\n"
            success=false
        }
        if(!passwordPattern.test(pswd)){
            errors += "Enter password of length 8-20 characters without any whitespace.\n"
            success=false
        }

        if(!success){
            alert(errors)
        }
        else{
            alert("Form submitted successfully.")
        }
    })
})