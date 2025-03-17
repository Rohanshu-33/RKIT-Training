$(document).ready(function () {

    $("#check-box").dxCheckBox({});


    $("#checkBoxContainer").dxCheckBox({
        text: "Coding?",
        enableThreeStateBehaviour: false,
        value: false,
        hint: "hovered item",
        iconSize: 50,
        onValueChanged: function (e) {    // this will run last. first, the instance"on" method will run
            const previousValue = e.previousValue;
            const currentValue = e.value;

            console.log(`Previous value: ${previousValue}, Current value: ${currentValue}`);

            if (e.value) {  // only when value is 'true'
                DevExpress.ui.notify("The CheckBox is checked", "success", 500);
            }

        }
    })

    // creating check box instance.
    let checkBoxInstance = $("#checkBoxContainer").dxCheckBox("instance")

    // using 'option' method of checkbox instance
    // checkBoxInstance.option("onValueChanged", greet2)  // this will run after the 'on' method. probably options get registered somewhere.

    // using 'on' method of checkbox instance
    checkBoxInstance.on("valueChanged", greet)


    function greet() {
        console.log("Greet method");

    }

    function greet2() {
        console.log("Greet method 2");

    }


    // registereing keyboard keys with the widget instance.
    function registerKeyHandlers() {
        console.log("h;loop");

        const checkBox = $("#checkBoxContainer").dxCheckBox("instance");
        checkBox.registerKeyHandler("backspace", function (e) {
            console.log(e);
            // The argument "e" contains information on the event
        });
        checkBox.registerKeyHandler("space", function (e) {
            console.log(e);
            // ...
        });
    }

    registerKeyHandlers();



    // API





    // options




    $("#checkBoxOptions").dxCheckBox({
        accessKey: "J",
        activeStateEnabled: true,
        disabled: false,
        elementAttr: {
            class: "bg-success",
            draggable: false,
        },
        focusStateEnabled: true,
        // height: "60px",
        hint: "hovered on the item",
        hoverStateEnabled: true,
        isValid: true,
        // iconSize: 60,
        name: "My-Checkbox",






        // below are the "Events". "on___"





        onContentReady: function () {
            console.log("Check box is ready");  // triggers after onInitialized. Fired once the widget is ready for interaction and rendered.

        },

        onDisposing: function () {
            console.log("Getting disposed... bye-bye");

        },

        onInitialized: function () {  // Fired after the widget is created and initialized, but before it is rendered and available for interaction.
            console.log("checkbox internally fully initialized.");
        },

        onOptionChanged: function (e) {
            //console.log(e); // will capture everything. use if statements!
            if (e.name === "value") {
                console.log(e);
            }
        },
        onValueChanged: function () {
            console.log("Checkbox value altered");

        },
        readOnly: false,
        rtlEnabled: true,  // text comes before the checkbox. "Useful"
        tabIndex: 1, // the first tab press will focus this checkbox
        text: "hello",
        validationStatus: "invalid",  // valid, pending
        validationErrors: [{ message: "message" }],
        value: true,  // checked
        visible: true,
        width: "200px"
    });





    // Methods 





    // Button to update the checkbox
    $("#updateButton").click(function () {
        // Start the batch update
        checkBoxInstance.beginUpdate();

        // Make multiple changes to the checkbox options
        checkBoxInstance.option("text", "Updated Text");
        checkBoxInstance.option("value", true);  // Change the value to checked

        // End the batch update (trigger re-render)
        checkBoxInstance.endUpdate();

        // Optional: Log to confirm updates
        console.log("CheckBox updated");
    });

    // default options - applies to all instances of dbCheckBox
    DevExpress.ui.dxCheckBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            // Here go the CheckBox properties
        }
    });

    // setTimeout(() => {
    //     checkBoxInstance.dispose();
    //     $("#checkBoxInstance").remove();  // remove html element from DOM
    // }, 2000);

    console.log("Element:\n", checkBoxInstance.element());  // returns html element

    setTimeout(() => {
        checkBoxInstance.focus();
    }, 2000);

    //checkBoxInstance.off("valueChanged", greet)

    // registerKeyHandler:
    /*
        backspace, tab, enter, excape, pageUp, pageDown, end, home, leftArrow,
        upArrow, rightArrow, downArrow, del, space, F, A, asterisk, minus

        if we add custom handler to these keys, default handler will be cancelled

    */

    setTimeout(() => {
        checkBoxInstance.repaint();  // do not reload the existing data
        checkBoxInstance.reset();
        checkBoxInstance.resetOption("text");
    }, 2000);
});