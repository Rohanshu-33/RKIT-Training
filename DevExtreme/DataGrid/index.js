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
                visible: false
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
        columnAutoWidth: true,  // adaptive column.. given minWidth, prevents this column for shrinking. used to prevent horizontal scrolling 
        filterRow: { visible: true }, // inside the datagrid
        searchPanel: { visible: true },  // top right side
        groupPanel: { visible: true },
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            texts: {
                editRow: "Modify",
                saveRowChanges: "Confirm",
                cancelRowChanges: "Undo",
                addRow: "New Entry"
            },
            popup: {
                title: "Editing a Record",
                showTitle: true,
                width: 500,
                height: 400,
                position: "center"
            },
            form: {
                colCount: 2
            }
        },

        selection: { mode: "single" },
        onSelectionChanged: function (e) {
            console.log(e);
            e.component.byKey(e.currentSelectedRowKeys[0]).done(function (ele) {
                console.log(ele);
                // if (ele) {
                //     alert(`Selected car: ${ele.Model}`);
                // }
            })
        },
        summary: {
            totalItems: [
                {
                    summaryType: "count",  // sum, min, max, avg
                    column: "Model",
                    alignment: "center",
                    customizeText: function (e) {
                        return `Count is : ${e.value}`;
                    }
                },
                {
                    summaryType: "sum",
                    column: "PricePerDay",
                    showInColumn: "Owner",
                    alignment: "right"
                }
            ],
            groupItems: [{
                column: "PricePerDay",  // whose data need to be aggregated
                summaryType: "avg",
                alignByColumn: true,
                showInGroupFooter: true,
                showInColumn: "PricePerDay",
                name: "Group Summary of PricePerDay",
                customizeText: function (e) {
                    return `Avg. of PPD is : ${e.value}`;
                }
            }]
        },

        sortByGroupSummaryInfo: [{    
            summaryItem: "Group Summary of PricePerDay",  // or "avg" | 0 | "PricePerDay"
            sortOrder: "desc" // or "asc"
        }],

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
    });

    $("#dataGrid2").dxDataGrid({
        dataSource: cars,
        allowColumnReordering: false,
        editing: {
            allowUpdating: true,
            allowDeleting: true,
            confirmDelete: true,
            allowAdding: true,
            mode: "batch",  // popup, cell, row, form
            startEditAction: "dblClick",
            selectTextOnEditStart: true
        },
        columnFixing: {
            enabled: true
        },
        columns: [
            { type: "adaptive" }, // Enables ellipsis button when columns are hidden
            { type: "drag", caption: "Drag" }, // Drag Column
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
                sortIndex: 0, sortOrder: "desc",
                allowFiltering: true,
                filterOperations: ["contains", "="],  // allowed filters on ths column
                selectedFilterOperation: "=", // default filter to be applied
                // filterValue: "Enter value of filter here", // undefined by-default


                // filterType: "exclude", // or "include"
                // filterValues: ["Value to exclude from the header filter."],
                headerFilter: { allowSearch: false },
                
                
                allowSearch: false
                
                
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
        columnHidingEnabled: true,  // adaptive row. if screen size is small, colunn will go in the adaptive row instead of horizontal scrolling
        columnChooser: {  // allows to hide/show columns as per our wish
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

        // allowColumnSorting: true,
        sorting: {
            ascendingText: "Sort A → Z",
            descendingText: "Sort Z → A",
            clearText: "Remove Sorting"
        },

        sorting: {
            mode: "multiple", // keep the shift key pressed. 'single', 'none'
            showSortIndexes: true
        },

        // filterRow: { visible: true },
        filterRow: {
            visible: true,
            applyFilter: "onClick"  // auto, enterKey
        },

        headerFilter: { visible: true, allowSearch: true },


        // searchPanel: { visible: true },
        // searchPanel: {
        //     visible: true,
        //     text: "BMW"
        // }


        // filterSyncEnabled: true, // If a user changes the filter expression in the filter panel or filter builder, the changes are reflected in the filter row and header filter, and vice versa. Set the filterSyncEnabled property to false to disable this synchronization

        filterPanel: { visible: true },  // bottom left of grid
        filterSyncEnabled: true,
        filterBuilder: {
            customOperations: [{
                name: "isBlack",
                caption: "Is Black",
                dataTypes: ["string"],
                hasValue: true,
                calculateFilterExpression: function (filterValue, field) {
                    console.log("field is ", field);
                    
                    return [field.dataField, "=", filterValue];
                }
            }]
        },
        filterBuilderPopup: {
            width: 400,
            title: "Synchronized Filter"
        },


        paging: {
            enabled: true,
            pageSize: 5 // Default page size
        },

        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [2, 5, 10],
            showNavigationButtons: true,
            showInfo: true,
            infoText: "Page: {0} out of {1} ({2} items)"
        },

        // scrolling: {
        //     mode: "standard" // or "virtual" | "infinite"  // standard not working with paging
        // },

        // scrolling: {
        //     useNative: true
        // }

        // height: 400,


        scrolling: {
            useNative: false,
            scrollByContent: true,
            scrollByThumb: true,
            showScrollbar: "onHover" // or "onScroll" | "always" | "never"
        },

        // grouping: {
        //     contextMenuEnabled: true  // do right click on any column
        // },

        grouping: {
            contextMenuEnabled: true,
            expandMode: "rowClick",  // or "buttonClick"  // click on grouped column name or on the side button which comes
            autoExpandAll: false  // after grouping, nothing will be in expanded mode. only the grouped column name will be visible
            // autoExpandGroup --> at column level. same as above
        },

        groupPanel: {
            visible: true   // or "auto"
        },

        keyExpr: "CarID",
        // selection: {
        //     mode: "multiple" // or "single" | "none"
        // }
        
        selection: {
            mode: "multiple",
            selectAllMode: "page", // or "allPages"
            allowSelectAll: true,
            showCheckBoxesMode: "onClick"    // or "always" | "none" | "onLongTap"
        },

        selectedRowKeys: [1, 5, 18],  // CarID  -> it is keyExpr in my grid


        onContentReady: function (e) {
            // Selects the first visible row
            e.component.selectRowsByIndexes([0]); // selects the row of corresponding index
        },

        onSelectionChanged: function (e) { // Handler of the "selectionChanged" event
            var currentSelectedRowKeys = e.currentSelectedRowKeys;
            var currentDeselectedRowKeys = e.currentDeselectedRowKeys;
            var allSelectedRowKeys = e.selectedRowKeys;
            var allSelectedRowsData = e.selectedRowsData;

            console.log(currentSelectedRowKeys);
            console.log(currentDeselectedRowKeys);
            console.log(allSelectedRowKeys);
            console.log(allSelectedRowsData);

        },

        loadPanel: {
            height: 100,
            width: 250,
            indicatorSrc: "https://js.devexpress.com/Content/data/loadingIcons/rolling.svg"
        },



        // other options
        // errorRowEnabled: false,
        // focusedRowEnabled: true,
        // keyboardNavigation: {
        //     enabled: false  // default true
        //     enterKeyAction: 'moveFocus',
        //     enterKeyDirection: 'row',
        //     editOnKeyPress: true,
        // },
        // noDataText: "Currently nothing to show in datagrid",
        onCellClick: function (e) {
            console.log("click", e);
        },

        onCellDblClick: function (e) {
            console.log("dbl click", e);
        },

        // onCellHoverChanged
        // onCellPrepared
        repaintChangesOnly: true,

        columnRenderingMode: "virtual",

        onRowClick: function () {
            console.log("row clicked");  // triggered after onCellClick

        }

    });



    // $("#dataGridContainer").dxDataGrid("clearGrouping");  // --> to ungroup data by all columns



    // var totalPageCount = $("#dataGrid2").dxDataGrid("instance").pageCount();
    // console.log("Total pages: ", totalPageCount);  // doubt.. showing '1' only


    // $("#dataGrid2").dxDataGrid("instance").searchByText("white");

    // $("#dataGrid2").dxDataGrid("instance").filter([
    //     [ "Price Per Day", ">", 100 ],
    //     "and",
    //     [ "Price Per Day", "<=", 2000 ]
    // ]);

    // var filterExpression = $("#dataGrid2").dxDataGrid("instance").getCombinedFilter(true);
    // console.log(filterExpression);


    // $("#dataGrid2").dxDataGrid("instance").clearFilter("search");


    var dataGrid = $("#dataGrid2").dxDataGrid("instance");

    console.log("column props: ", dataGrid.columnOption(2));
    console.log("column props: ", dataGrid.columnOption(2, "visible"));
    console.log("column props: ", dataGrid.columnOption(2, {
        // options here
    }));

    // dataGrid.beginCustomLoading();
    // ...

    setTimeout(() => {
        // dataGrid.columnOption("OwnerContact", "sortIndex", undefined);  // removes sorting property
        // dataGrid.deleteColumn(5);
        dataGrid.clearSorting();  // removes all sorting
        // dataGrid.endCustomLoading();
    }, 2000);




    // -> events of crud in datagrid:
    // onRowInserting
    // onRowInserted
    // onRowUpdating
    // onRowUpdated
    // onRowRemoving
    // onRowRemoved

    // -> events of grouping
    // onRowExpanding
    // onRowExpanded
    // onRowCollpasing
    // onRowCollpased


    // onrowValidating: just before validation, you can add checks. this is triggered just before validation rule are applied.


    // setTimeout(() => {
    //     $("#dataGrid2").dxDataGrid("addRow");
    // }, 4000);



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


    $("#button").dxButton({
        text: "Show Filter Builder",
        onClick: function () {
            dataGrid.option("filterBuilderPopup", { visible: true });
        }
    });

}) 