$(document).ready(function () {

    //$("#textArea").dxTextArea({ })

    $("#textArea").dxTextArea({
        width: "30rem",
        height: 40,
        spellCheck: true,
        //value: "The text that should not be edited",
        //readOnly: true,
        // maxLength: 5, // limits the input text length
        autoResizeEnabled: true,
        minHeight: 20,
        maxHeight: 200,
        // valueChangeEvent
        onChange: function (e) {
            console.log("change ", e);  // triggers at blur 
        },
        onInput: function (e) {
            console.log("input ", e);   // triggers at every character enetered
        },
    })
});