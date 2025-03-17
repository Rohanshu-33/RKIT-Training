$(document).ready(function () {
    const fruits = ["Apple", "Banana", "Cherry", "Date", "Elderberry"];

    $("#dropDownBoxContainer").dxDropDownBox({
        items: fruits, // Array of fruits
        placeholder: "Select fruits...", // Placeholder text
        value: [], // Initialize with no selected values

        // Define content template
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.option("items"), // Data source from the items
                selectionMode: "multiple", // Enable multiple selection
                showSelectionControls: true, // Show selection controls (checkboxes)
                displayExpr: "this", // Display item text (same as value in simple array)
                selectedItems: e.component.option("value"), // Bind selected items
                onSelectionChanged: function (args) {
                    console.log(args);

                    let selectedValues = e.component.option("value");
                    selectedValues.push(args.addedItems[0]);
                    if (args.removedItems.length > 0) {
                        selectedValues = selectedValues.filter(fruit => fruit !== args.removedItems[0]);
                    }
                    console.log(selectedValues);

                    e.component.option("value", selectedValues);
                }
            });

            return $list;
        }
    });
});