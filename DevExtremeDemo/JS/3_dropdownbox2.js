$(document).ready(function () {
    const jsonObj = [
        { "id": 1, "name": "Rohanshu" },
        { "id": 2, "name": "Meet" },
        { "id": 3, "name": "NK" }
    ];

    $("#dropDownBoxContainer").dxDropDownBox({
        accessKey: "G",
        activeStateEnabled: true,
        dataSource: jsonObj,
        valueExpr: "id",
        displayExpr: "name",
        placeholder: "Select a name...",
        showClearButton: true,
        deferRendering: true,
        displayValueFormatter: function (value) {
            return "Hello... " + value + "!";  // Format the value with a '$' symbol
        },
        onClosed: function () {
            console.log("Dropdown list closed.");

        },
        showDropDownButton: true,
        stylingMode: "outlined",  // underlined, filled
        visible: true,
        contentTemplate: function (e) {   // It defines the structure and functionality of the dropdown's popup content.
            const $container = $("<div>");
            // Create a List
            const $list = $("<div>").dxList({
                dataSource: e.component.option("dataSource"),
                selectionMode: "single",
                displayExpr: "name",
                onSelectionChanged: function (args) {
                    if (args.addedItems.length > 0) {
                        e.component.option("value", args.addedItems[0].id);
                    } else {
                        e.component.option("value", null);
                    }
                    e.component.close();
                }
            });

            // Create a Button
            const $button = $("<div>").dxButton({
                text: "Click Me",
                type: "success",
                onClick: function () {
                    alert("Button inside DropDownBox clicked!");
                }
            }).css({ "margin-top": "10px" });

            $container.append($list);
            $container.append($button);
            return $container;
        }
    });



    // demo for 'items' option
    $("#dropDownBoxContainer2").dxDropDownBox({
        items: [
            { value: 1, name: "Rohanshu" },
            { value: 2, name: "Meet" },
            { value: 3, name: "NK" }
        ],
        valueExpr: "value",     // Use 'value' as the value expression
        displayExpr: "text",    // Use 'text' as the display expression
        placeholder: "Select a name...",
        showClearButton: true,  // Optional: show a clear button
        deferRendering: true,    // Optional: load the dropdown content only when shown
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.option("items"),
                selectionMode: "multiple",
                showSelectionControls: true, // Adds checkboxes
                displayExpr: "name",
                onSelectionChanged: function (args) {
                    console.log(args);

                    if (args.addedItems.length > 0) {
                        e.component.option("value", args.selectedItems);
                    } else {
                        e.component.option("value", null);
                    }
                    e.component.close();
                }
            });
            return $list;
        }
    });




    // methods and events same as previous widgets



    const dropDownInstance = $("#dropDownBoxContainer").dxDropDownBox("instance");



    // drop down button
    $("#myDropDownButton").dxDropDownButton({
        text: "Sandra Johnson",
        icon: "user"
    });

});