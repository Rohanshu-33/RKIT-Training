$(document).ready(function () {

    let selectedTechs = [];

    const getTechs = () => {
        $("#technologiesContainer .dx-checkbox").each(function () {
            let instance = $(this).dxCheckbox("instance");
            if (instance.option("value")) {
                selectedTechs.push(instance.option("text"))
            }
        })
    }

    const checkFullname = (params) => {
        const name = params.value.trim();
        return (name.split(/\s+/).length >= 2)
    }

    $("#fullNameContainer").dxTextBox({
        width: "20rem",
        height: "3rem",
        placeholder: "Enter fullname"
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Full name is required."
            },
            {
                type: "custom",
                message: "Improper format",
                validationCallback(params) {
                    return checkFullname(params);
                }
            }
        ],
        validationGroup: "loginGroup"
    })

    $("#emailContainer").dxTextBox({
        placeholder: "Enter email address",
        width: "20rem",
        height: "3rem",
        mode: "email",
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "please enter a value."
            },
            {
                type: "email",
                message: "Enter a valid email address."
            }
        ],
        validationGroup: "loginGroup"
    });

    $("#passwordContainer").dxTextBox({
        placeholder: "Enter password 6-16 characters",
        mode: "password",
        width: "20rem",
        height: "3rem"
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Password required"
            },
            {
                type: "stringLength",
                max: 16,
                min: 6,
                message: "Password should be of 6-16 characters."
            }
        ],
        validationGroup: "loginGroup"
    });

    $("#confirmPasswordContainer").dxTextBox({
        placeholder: "Re-enter your password",
        mode: "password",
        width: "20rem",
        height: "3rem"
    }).dxValidator({
        validationRules: [
            {
                type: "compare",
                comparisonType: "===",
                message: "Invalid password",
                comparisonTarget() {

                    return $("#passwordContainer").dxTextBox("instance").option("value");
                }

            }
        ],
        validationGroup: "loginGroup"
    });

    $("#resumeContainer").dxFileUploader({
        width: "20rem",
        height: "3rem",
        name: "resumeFile",
        uploadMode: "useButtons",
        uploadUrl: "https://api.escuelajs.co/api/v1/files/upload",
        allowedFileExtensions: [".html"],
    }).dxValidator({
        validationRules: [
            {
                type: "custom",
                message: "File should be less than 10kb.",
                validationCallback(params) {
                    console.log(params.value[0].size);
                    return params.value[0].size < 10240
                }
            }
        ],
        validationGroup: "loginGroup"
    })

    $("#genderContainer").dxRadioGroup({
        items: ["Male", "Female", "Others"],
        layout: "horizontal",
        name: "gender"
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Please select your gender."
            }
        ],
        validationGroup: "loginGroup"
    })

    const tech = ["C#", "JS", "JAVA", "PHP", "Python"];

    // Generate checkboxes dynamically
    tech.forEach(t => {
        $("<div>").dxCheckBox({
            text: t,
            value: false // Not selected by default
        }).appendTo("#technologiesContainer");
    });

    $("#dobContainer").dxDateBox({
        width: "20rem",
        height: "3rem",
        type: "date",
        max: new Date(),
        min: new Date(1900, 0, 1),
        pickerType: "calendar",
        applyValueMode: "useButtons",
        placeholder: "Enter date of birth",
        showClearButton: true,
        openOnFieldClick: true
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Select your date of birth."
            }],
        validationGroup: "loginGroup"
    });

    const cities = ["Vapi", "Surat", "Anand", "Ahmedabad"];

    $("#cityContainer").dxSelectBox({
        width: "20rem",
        height: "3rem",
        dataSource: cities,
        searchEnabled: true
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Enter your city of residence."
        }],
        validationGroup: "loginGroup"
    })

    $("#addressContainer").dxTextArea({
        width: "20rem",
        height: "8rem",
        placeholder: "Enter address",
        autoResizeEnabled: true
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Enter your full address."
        }],
        validationGroup: "loginGroup"
    })


    $("#submitContainer").dxButton({
        text: "Submit",
        type: "success",
        stylingMode: "contained",
        onClick: function () {
            const validationGroup = DevExpress.validationEngine.validateGroup("loginGroup");

            if (validationGroup.isValid) {
                // Fetch values
                const fullName = $("#fullNameContainer").dxTextBox("instance").option("value");
                const email = $("#emailContainer").dxTextBox("instance").option("value");
                const password = $("#passwordContainer").dxTextBox("instance").option("value");
                const confirmPassword = $("#confirmPasswordContainer").dxTextBox("instance").option("value");
                const resume = $("#resumeContainer").dxFileUploader("instance").option("value");
                const gender = $("#genderContainer").dxRadioGroup("instance").option("value");
                const dob = $("#dobContainer").dxDateBox("instance").option("value");
                const city = $("#cityContainer").dxSelectBox("instance").option("value");
                const address = $("#addressContainer").dxTextArea("instance").option("value");

                // Store in session storage
                sessionStorage.setItem("fullname", fullName);
                sessionStorage.setItem("email", email);
                sessionStorage.setItem("password", password);
                sessionStorage.setItem("confirmPassword", confirmPassword);
                sessionStorage.setItem("resume", resume);
                sessionStorage.setItem("gender", gender);
                sessionStorage.setItem("dob", dob);
                sessionStorage.setItem("city", city);
                sessionStorage.setItem("address", address);
                sessionStorage.setItem("techs", JSON.stringify(selectedTechs));

                alert("Done storing in session.");
            } else {
                DevExpress.ui.notify("Please fill all required fields correctly.", "error", 3000);
            }
        }
    });
})