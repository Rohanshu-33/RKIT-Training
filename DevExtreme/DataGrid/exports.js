import { cars } from "./data.js";

$(document).ready(function(){
    $("#grid1").dxDataGrid({
        dataSource: cars,

        export: {
            enabled: true,
            texts: {
                exportAll: "Get all",
                exportSelectedRows: "Get selected",
                exportTo: "Export now!"
            },
            allowExportSelectedData: true,
        },

        columns: [
            {
                caption: "Details",
                columns: ["CarID", "Model", "Color"]
            },
            {
                dataField: "Make",
            },
            {
                dataField: "Year",
                allowExporting: false
            }
        ],

        selection: {
            mode: "multiple",
            selectAllMode: "page", // or "allPages"
            allowSelectAll: true,
            showCheckBoxesMode: "always"    // or "onClick" | "none" | "onLongTap"
        },

        onExporting: function(e) { 
            var workbook = new ExcelJS.Workbook(); 
            var worksheet = workbook.addWorksheet('Cars Data'); 
            
            DevExpress.excelExporter.exportDataGrid({ 
                worksheet: worksheet, 
                component: e.component,
                selectedRowsOnly: true,  // Export only selected rows
                customizeCell: function(options) {
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
                        else{
                            excelCell.alignment = { horizontal: 'left' };           
                            excelCell.font = { name: 'Arial', size: 12 }; // White text
                        }
                    }
                } 
            }).then(function() {
                worksheet.columns.forEach(column => {
                    column.width = 20;
                });
        
                workbook.xlsx.writeBuffer().then(function(buffer) { 
                    saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Cars-DataGrid.xlsx'); 
                }); 
            }); 
        
            e.cancel = true; 
        }
        
    })
})