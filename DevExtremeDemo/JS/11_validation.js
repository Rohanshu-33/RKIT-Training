$(document).ready(function () {

    const promiseMethod = (params) => {
        const d = $.Deferred();
        setTimeout(() => {
            if (params.value === "Rohanshu") {
                d.resolve("resolved in set-timeout");
            }
            d.reject("Wrong username entered by the user.")
        }, 2000);
        console.log("returning", params);

        return d.promise();
    }


    const checkFirstLetter = (params) => {
        return params.value.charAt(0) === params.value.charAt(0).toUpperCase();
    }

    $("#nameContainer").dxTextBox({
        placeholder: "Enter your name",
        width: "20rem",
        height: "3rem",
    }).dxValidator({
        validationRules: [
            {
                type: "async",
                message: "Name is required",
                validationCallback(params) {
                    return promiseMethod(params);
                }
            },
            {
                type: "custom",
                message: "Name should have first letter as uppercase",
                reevaluate: true,
                validationCallback(params) {
                    console.log("custom", params);
                    return checkFirstLetter(params);
                }
            }],
        validationGroup: "loginGroup"
    });



    $("#numberBoxContainer").dxNumberBox({
        min: 0,
        showSpinButtons: true,
        showClearButton: true,
        width: "20rem",
        height: "3rem",
        stylingMode: "outlined",

    }).dxValidator({
        validationRules: [
            {
                type: "compare",
                comparisonType: ">=",
                message: "Age should be above or equal to 18",
                comparisonTarget() {  // renders first when component is initialized and then at every value change.
                    return 18;  // the value will directly be compared to this returned value.
                }
            },
            {
                type: "numeric",
                message: "number expected."
            }
        ]
    });




    $("#emailContainer").dxTextBox({
        placeholder: "Enter email address",
        width: "20rem",
        height: "3rem",
        mode: "email",
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "please enter a value"
            },
            {
                type: "email",
                message: "Enter a valid email address"
            }
        ],
        validationGroup: "loginGroup"
    });




    $("#passwordContainer").dxTextBox({
        placeholder: "Enter password 8-20 characters",
        mode: "password",
        width: "20rem",
        height: "3rem",
        minLength: 8,
        maxLength: 20,
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Entering password is required."
            }
        ]
    })

    $("#scoreContainer").dxNumberBox({
        showSpinButtons: true,
        showClearButton: true,
        width: "20rem",
        height: "3rem",
        stylingMode: "outlined",
        placeholder: "Score your Jquery knowledge out of 10"
    }).dxValidator({
        validationRules: [
            {
                type: "range",
                message: "Out of range",
                min: 0,
                max: 10
            }
        ]
    })
})