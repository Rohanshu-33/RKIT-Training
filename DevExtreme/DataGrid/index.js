import { cars } from "./data.js";

$(document).ready(function () {

    const cities = ["Vapi", "Surat"];


    $("#dataGrid1").dxDataGrid({
        dataSource: cars,
        allowColumnReordering: true,
        columns: [  // only these many columns will be shown. rest all will get vanish
            {
                dataField: "CarID",
                fixed: true,  // this column will be sticked on left side of screen when scrolled horizontally for seeing right side columns.
                validationRules: [{ type: "required" }]
            },
            { dataField: "Model" },
            { dataField: "Make" },
            {
                dataField: "Year",
                // dataType: "date",
                width: 150,
                // visible: false
            },
            { dataField: "Color" },
            {
                dataField: "Availability",
            },
            { dataField: "PricePerDay" },
            {
                dataField: "Location",
                // groupIndex: 0,
            },
            {
                dataField: "Owner",
                // groupIndex: 1,

            },
            { dataField: "OwnerContact" },
            { dataField: "Description" }
        ],
        columnChooser: { enabled: false },
        columnAutoWidth: true,
        filterRow: { visible: true }, // inside the datagrid
        searchPanel: { visible: true },  // top right side
        groupPanel: { visible: true },
        editing: {
            mode: "popup",  // cell
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true,
            allowEditing: true
        },

        selection: { mode: "single" },
        onSelectionChanged: function (e) {
            console.log(e);
            e.component.byKey(e.currentSelectedRowKeys[0]).done(function (ele) {
                console.log(ele);
                if (ele) {
                    alert(`Selected car: ${ele.Model}`);
                }
            })
        },
        summary: {
            totalItems: [{  // groupItems needs groupIndex
                summaryType: "count",
                column: "Make"
            }]
        },

        masterDetail: {
            enabled: true,
            template: function (_, options) {
                const cars = options.data;
                const desc = $("<p>")
                    .text(`Description: ${cars.Description}`);
                return $("<div>").append(desc);
            }
        },

        customizeColumns: function (columns) {
            columns[0].width = 60;
            columns[1].width = 210;
        }
        // sorting, export remaining
    });

    $("#dataGrid2").dxDataGrid({
        dataSource: cars,
        allowColumnReordering: false,
        editing: {
            allowUpdating: true,
            allowDeleting: true,
            confirmDelete: false,
            allowAdding: true,
            mode: "batch"  // popup, cell, row, form
        },
        columnFixing: {
            enabled: true
        },
        columns: [
            { type: "adaptive" }, // Enables ellipsis button when columns are hidden
            { type: "drag", caption: "Drag" }, // Drag Column
            { type: "selection", width: 50 }, // Selection Column (Checkbox)
            {
                type: "buttons",
                // buttons: [
                //     {
                //         hint: "Edit",
                //         icon: "edit",
                //         onClick: function (e) {
                //             // write edit logic here
                //             alert("Editing Car: " + e.row.data.Model);
                //         }
                //     },
                //     {
                //         hint: "Delete",
                //         icon: "trash",
                //         onClick: function (e) {
                //             // write delete logic here
                //             alert("Deleting Car: " + e.row.data.Model);
                //         }
                //     }
                // ]
                buttons: ["edit", "delete"]
            },
            {
                caption: "Details",
                columns: ["CarID", "Model", "Color"]
            },
            {
                dataField: "Make",
                allowFixing: true,
                // fixed: true,
                // fixedPosition: "right",
                allowHiding: false
            },
            {
                dataField: "Year",
                caption: "Launch Year",
                width: 150,
                visible: true,
            },
            {
                dataField: "PricePerDay",
                dataType: "string",
                validationRules: [{
                    type: "numeric",
                    message: "Price should be numeric value."
                }]
            },
            { dataField: "Availability" },
            {
                dataField: "Location",
                lookup: {
                    dataSource: cities
                },
                headerCellTemplate: function (header, info) {
                    $('<div>')
                        .html(info.column.caption)
                        .css('font-size', '20px').css('color', 'red')
                        .appendTo(header);
                },
                // hidingPriority: 1
            },
            {
                dataField: "Owner",
            },
            {
                dataField: "OwnerContact",
                sortIndex: 0, sortOrder: "desc"
            },
            { dataField: "Description", allowEditing: false },
            {
                caption: "Calculated Tax",
                calculateCellValue: function (rowData) {
                    console.log(rowData);
                    return Math.ceil(rowData.Year * 0.01 * rowData.PricePerDay);
                },
                hidingPriority: 0
            }
        ],
        columnHidingEnabled: true,
        columnChooser: {
            enabled: true,
            mode: "dragAndDrop" // or "select"
        },

        // columns: [
        //     {
        //         caption: "----- First -----",
        //         columns: ["CarID", "Model", {
        //             caption: "----- Second -----",
        //             columns: ["Color", "Make", "Year", {
        //                 caption: "----- Third -----",
        //                 columns: ["PricePerDay", {
        //                     caption: "----- Fourth -----",
        //                     columns: ["Availability", "Location", "Owner"]
        //                 }]
        //             }]
        //         }]
        //     }
        // ],

        onInitNewRow: function (e) {
            e.data.Year = 2025
        },

        sorting: {
            mode: "multiple" // keep the shift key pressed. 'single', 'none'
        }, 
    });






    var dataGrid = $("#dataGrid2").dxDataGrid("instance");
    setTimeout(() => {
        // dataGrid.columnOption("OwnerContact", "sortIndex", undefined);  // removes sorting property
        dataGrid.clearSorting();  // removes all sorting
    }, 2000);




    // events:
    // onRowInserting
    // onRowInserted
    // onRowUpdating
    // onRowUpdated
    // onRowRemoving
    // onRowRemoved

    // onrowValidating: just before validation, you can add checks. this is triggered just before validation rule are applied.


    setTimeout(() => {
        $("#dataGrid2").dxDataGrid("addRow");
    }, 4000);



    $("#updateCellButton").dxButton({
        text: "Update Cell",
        onClick: function () {
            $("#dataGrid2").dxDataGrid("cellValue", 1, "Make", "BYD");
            $("#dataGrid2").dxDataGrid("saveEditData");
        }
    });



    $("#saveChangesButton").dxButton({
        text: "Save changes",
        onClick: function () {
            var dataGrid = $("#dataGrid2").dxDataGrid("instance");
            if (dataGrid.hasEditData()) {
                dataGrid.saveEditData().then(() => {
                    if (!dataGrid.hasEditData()) {
                        console.log("Updated successfully");

                    } else {
                        console.log("Error in updating value");
                    }
                });
            }
        }
    });

})