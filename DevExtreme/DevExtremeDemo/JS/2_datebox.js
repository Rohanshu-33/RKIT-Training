$(document).ready(function () {
    $("#dateBoxDemo").dxDateBox({
        type: "datetime", // date, time
        max: new Date(),
        min: new Date(1900, 0, 1),
        value: new Date(),
        pickerType: "rollers", // calendar, list
        displayFormat: "EEEE, d 'of' MMM", // "Tuesday, 16 of Oct" 
        useMaskBehavior: false,
        applyValueMode: "useButtons"  // instantly
    });


    // start and end date logic
    const startDate = $("#startDate").dxDateBox({
        value: new Date(),
        onValueChanged: function (e) {
            endDate.option("min", e.value);
        }
    }).dxDateBox("instance");
    const endDate = $("#endDate").dxDateBox({
        value: new Date(),
        onValueChanged: function (e) {
            startDate.option("max", e.value);
        }
    }).dxDateBox("instance");



    // options
    $("#dateBoxOptionsDemo").dxDateBox({
        value: new Date(),
        type: "time",
        acceptCustomValue: false,  // user can't type in the value directly.
        adaptivityEnabled: true,
        applyValueMode: "useButtons",
        applyButtonText: "Hello",  // needs applyvaluemode as useButtons
        cancelButtonText: "Bye-bye",
        dateOutOfRangeMessage: "The entered date is out of range. Thank You",
        dateSerializationFormat: "yyyy-MM-ddTHH:mm:ssx",// - date and time with timezone // use when default value is not given so that the picker understands the format.
        // "yyyy-MM-ddTHH:mm:ssZ" -  UTC date and time, "yyyy-MM-ddTHH:mm:ss" - local date and time, "yyyy-MM-dd" - local date
        disabledDates: [
            new Date("03/2/2025"),
            new Date("04/2/2025"),
            new Date("05/2/2025")
        ],
        interval: 20, // type as time and list as pickerType
        pickerType: "list",
        invalidDateMessage: "Invalid date.",





        // events




        onChange: function (e) {
            console.log("on change called", e);
        },
        onClosed: function () {
            console.log("on close called");

        },
        onCopy: function (e) {
            console.log("copied"); // also onCut, onEnterKey, FocusIn, FocusOut, KeyDown, KeyUp, onOpened, onPaste
        },
        openOnFieldClick: true, // Specifies whether a user can open the drop-down list by clicking a text field.
        placeholder: "placeholder",
        readonly: false,
        showAnalogClock: true, // only for type as datetime and picker as calendar
        showClearButton: true

    })




    let dateBoxInstance = $("#dateBoxOptionsDemo").dxDateBox("instance");


    // methods

    setTimeout(() => {
        dateBoxInstance.blur()
        dateBoxInstance.close()
        console.log(dateBoxInstance.element());

    }, 2000);




})