const fruitss = ["Apples", "Oranges", "Lemons", "Pears", "Pineapples"];

$(document).ready(function () {
    $("#dropDownBoxContainer").dxDropDownBox({
        value: fruitss[0],
        dataSource: fruitss,
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.option("dataSource"),
                selectionMode: "single",
                onSelectionChanged: function (arg) {
                    console.log(arg);
                    e.component.option("value", arg.addedItems[0]);
                    e.component.close();
                }
            });
            return $list;
        }
    });


    const customers = [
        { ID: 1, companyName: "Premier Buy", city: "Dallas", phone: "(233)2123-11" },
        { ID: 2, companyName: "ElectrixMax", city: "Naperville", phone: "(630)438-7800" },
        // ...
    ];
    const selectedValue = customers[0].ID;
    $("#dropDownBoxContainer2").dxDropDownBox({
        value: selectedValue,
        valueExpr: "ID",
        displayExpr: "companyName",
        dataSource: new DevExpress.data.ArrayStore({
            data: customers,
            key: "ID"
        }),
        contentTemplate: function (e) {
            const $dataGrid = $("<div>").dxDataGrid({
                dataSource: e.component.option("dataSource"),
                columns: ["companyName", "city", "phone"],
                height: 265,
                selection: { mode: "single" },
                selectedRowKeys: [selectedValue],
                onSelectionChanged: function (selectedItems) {
                    const keys = selectedItems.selectedRowKeys,
                        hasSelection = keys.length;
                    e.component.option("value", hasSelection ? keys[0] : null);
                    e.component.close();
                }
            });
            return $dataGrid;
        }
    });

    const fruits = [
        { id: 1, text: "Apples", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" },
        { id: 2, text: "Oranges", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" },
        { id: 3, text: "Lemons", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" },
        { id: 4, text: "Pears", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" },
        { id: 5, text: "Pineapples", image: "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7" }
    ];
    $("#dropDownBoxContainer").dxDropDownBox({
        value: fruits[0],
        dataSource: new DevExpress.data.DataSource({
            store: new DevExpress.data.ArrayStore({ data: fruits, key: "id" }),
        }),
        dropDownOptions: {
            title: "Fruits",
            showTitle: true,
            fullScreen: true,
            showCloseButton: true
        },
        dropDownButtonTemplate: function () {
            return $("<img />").attr("src", "https://th.bing.com/th/id/OIP.6f5ZEeT1bM05vEOyFk2a7AHaHa?w=198&h=197&c=7&r=0&o=5&pid=1.7");
        },
        fieldTemplate: function (value, fieldElement) {
            return $("<div class='custom-item' />").append(
                $("<img />").attr("src", value.image),
                $("<div class='product-name' />").dxTextBox({ value: value.text, readOnly: true })
            );
        },
        contentTemplate: function (e) {
            const list = $("<div>").dxList({
                dataSource: e.component.option("dataSource"),
                selectionMode: "single",
                onSelectionChanged: function (arg) {
                    e.component.option("value", arg.addedItems[0]);
                    e.component.close();
                }
            });
            return list;
        }
    });
})