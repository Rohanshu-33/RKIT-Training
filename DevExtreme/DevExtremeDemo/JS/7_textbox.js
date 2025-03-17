$(document).ready(function () {
    $("#textBox").dxTextBox({
        width: "20rem",
        height: "3rem",
        value: "The value that should not be edited",
        readOnly: true
    })

    $("#textBox2").dxTextBox({
        width: "20rem",
        height: "3rem",
        mode: "password", // search, text | tel, email, url -> changes will be seen on mobile devices
        // valueChangeEvent: "keyup", // Triggers on every key press -> determines which type of event will trigger onValueChanged event.
        onValueChanged: function (e) {
            console.log("New Value:", e.value);
        },
        placeholder: "Enter password",
        maxLength: 10,
    });

    $("#textBox3").dxTextBox({
        width: "20rem",
        height: "3rem",
        mask: "$FHNZZ", // Include '$' directly
        maskRules: {
            // Ensure F only allows uppercase letters
            F: /[A-Z]/,
            H: /[0-9]/,
            N: ['$', '%', '&', '@'] // Allowed special characters
        },
        useMaskedValue: false,
        showMaskMode: "always", // Mask always visible
        onValueChanged: function (e) {
            const maskedValue = $("#textBox3").dxTextBox("option", "text");
            const unmaskedValue = $("#textBox3").dxTextBox("option", "value");
            console.log(maskedValue, ' ', unmaskedValue);
        }
    });

});