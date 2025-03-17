$(document).ready(function () {
    $("#numberBoxContainer").dxNumberBox({


        // options


        value: 15,
        min: 5,
        max: 55,
        showSpinButtons: true,
        showClearButton: true,
        step: 2,
        width: "15rem",
        height: "3rem",
        format: "0.00",
        mode: "number",  // tel, text
        rtlEnabled: false,
        stylingMode: "outlined", // filled, underlined
        // useLargeSpinButtons: true

        // methods and events same as previous widgets
    });
});