$(document).ready(function () {

    var store = new DevExpress.data.CustomStore({
        key: "id",
        load: function () {
            let d = $.Deferred();
            $.ajax({
                url: "https://67b6b39807ba6e5908415d52.mockapi.io/api/dg-1/cars",
                method: "GET",
                dataType: "json"
            }).done(function (data) {
                d.resolve(data); // Load all fields
            }).fail(function (error) {
                d.reject("Data loading error: " + error.statusText);
            });
            return d.promise();
        },
        insert: function (values) {
            let d = $.Deferred();
            $.ajax({
                url: "https://67b6b39807ba6e5908415d52.mockapi.io/api/dg-1/cars",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(values)
            }).done(function (response) {
                d.resolve(response);
            }).fail(function (error) {
                d.reject("Insert error: " + error.statusText);
            });
            return d.promise();
        },
        update: function (key, values) {
            let d = $.Deferred();
            $.ajax({
                url: `https://67b6b39807ba6e5908415d52.mockapi.io/api/dg-1/cars/${key}`,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(values)
            }).done(function (response) {
                d.resolve(response);
            }).fail(function (error) {
                d.reject("Update error: " + error.statusText);
            });
            return d.promise();
        },
        remove: function (key) {
            let d = new $.Deferred();
            $.ajax({
                url: `https://67b6b39807ba6e5908415d52.mockapi.io/api/dg-1/cars/${key}`,
                method: "DELETE"
            }).done(function () {
                d.resolve();
            }).fail(function (error) {
                d.reject("Delete error: " + error.statusText);
            });
            return d.promise();
        },
    })


    $("#grid1").dxDataGrid({
        dataSource: store,
        allowColumnReordering: true,
        columns: [
            {
                dataField: "id",
                fixed: true,
                validationRules: [{ type: "required" }]
            },
            {
                dataField: "name"
            },
            {
                dataField: "brand"
            },
            {
                dataField: "color"
            },
            {
                dataField: "price",
                validationRules: [{
                    type: "numeric",
                    message: "Price should be numeric value."
                }]
            },
        ],
        filterRow: {
            visible: true
        },
        searchPanel: {
            visible: true
        },
        groupPanel: {
            visible: true
        },
        editing: {
            mode: "popup",  // cell
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true,
            allowEditing: true
        },
        summary: {
            totalItems: [
                {
                    summaryType: "count",
                    column: "id",
                    alignment: "left"
                },
                {
                    summaryType: "avg",
                    column: "price",
                    alignment: "right"
                }
            ]
        },
        masterDetail: {
            enabled: true,
            template: function (_, options) {
                const cars = options.data;
                const desc = $("<p>")
                    .html(`Description:<br>${cars.name}<br>${cars.brand}<br>${cars.color}<br>${cars.price}`);
                return $("<div>").append(desc);
            }
        },
        
        columnHidingEnabled: true,
        columnChooser: {
            enabled: true,
            mode: "dragAndDrop"
        },

        headerFilter: { visible: true, allowSearch: true },
        
        filterPanel: { visible: true },
        filterSyncEnabled: true,
        filterBuilder: {
            customOperations: [{
                name: "isBlack",
                caption: "Is Black",
                dataTypes: ["string"],
                hasValue: false,  // No user input required
                calculateFilterExpression: function (filterValue, field) {
                    return [field.dataField, "=", "color 1"]; 
                }
            }],
            filterValue: [["color", "isColor1"]] // Preload filter in UI
        },
        filterBuilderPopup: {
            width: 400,
            title: "Synchronized Filter"
        },

        paging: {
            enabled: true,
            pageSize: 5  // Default page size
        },

        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [2, 5, 10],
            showNavigationButtons: true,
            showInfo: true,
            infoText: "Page: {0} out of {1} ({2} items)"
        },

        selection: {
            mode: "multiple",
            selectAllMode: "page",
            allowSelectAll: true,
            showCheckBoxesMode: "always"
        },

        loadPanel: {
            height: 50,
            width: 50,
            indicatorSrc: "https://js.devexpress.com/Content/data/loadingIcons/rolling.svg"
        },

        repaintChangesOnly: true,

        export: {
            enabled: true,
            texts: {
                exportAll: "Get all",
                exportSelectedRows: "Get selected",
                exportTo: "Export now!"
            },
            allowExportSelectedData: true,
        },

        onExporting: function (e) {
            var workbook = new ExcelJS.Workbook();
            var worksheet = workbook.addWorksheet('Cars Data');

            DevExpress.excelExporter.exportDataGrid({
                worksheet: worksheet,
                component: e.component,
                selectedRowsOnly: true,  // Export only selected rows
                customizeCell: function (options) {
                    var { gridCell, excelCell } = options;

                    // Make the first row (header) bold
                    if (gridCell.rowType === "header") {
                        excelCell.font = { name: 'Arial', size: 12, italic: true, color: { argb: "FFFFFF" } }; // White text
                        excelCell.fill = {
                            type: "pattern",
                            pattern: "solid",
                            fgColor: { argb: "4F81BD" } // Blue background
                        };
                        excelCell.alignment = { horizontal: "center", vertical: "middle" };
                    }

                    if (gridCell.rowType === "data") {
                        var rowIndex = excelCell._row._number;
                        if (rowIndex % 2 === 0) {
                            excelCell.alignment = { horizontal: 'left' };
                            excelCell.font = { name: 'Arial', size: 12, color: { argb: "FFFFFF" } }; // White text
                            excelCell.fill = {
                                type: "pattern",
                                pattern: "solid",
                                fgColor: { argb: "000000" } // Black background
                            };
                        }
                        else {
                            excelCell.alignment = { horizontal: 'left' };
                            excelCell.font = { name: 'Arial', size: 12 }; // White text
                        }
                    }
                }
            }).then(function () {
                worksheet.columns.forEach(column => {
                    column.width = 20;
                });

                workbook.xlsx.writeBuffer().then(function (buffer) {
                    saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Cars-DataGrid.xlsx');
                });
            });

            e.cancel = true;
        }
    });
})