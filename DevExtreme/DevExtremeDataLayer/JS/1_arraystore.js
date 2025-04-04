$(document).ready(function () {
    var states = [
        { id: 1, state: "Alabama", capital: "Montgomery" },
        { id: 2, state: "Alaska", capital: "Juneau" },
        { id: 3, state: "Arizona", capital: "Phoenix" },
    ];

    var stores = new DevExpress.data.ArrayStore({
        key: "id",
        data: states,

        // events

        // errorHandler: function (error) {
        //     console.log("ERROR: ", error.message);
        // },
        onInserted: function (e) {
            console.log("Item added. (event)", e);

        },
        onInserting: function (e) {
            console.log("Item getting added. (event)", e);

        },
        // onLoading, onLoaded, onModified, onModifying
        onModified: function (e) {
            console.log("Store modified. (event)", e);
        },
        onModifying: function (e) {
            console.log("Store getting modified. (event)", e);
        },
        onPush: function (e) {
            console.log("Changes will be pushed now. (event)", e);
        },
        onRemoving: function (e) {
            console.log("Item is getting removed. (event)", e);
        },
        // onUpdated, onUpdating
    });

    // methods
    stores.byKey(1)
        .done(function (dataItem) {
            console.log("ByKey: ", dataItem);
        })
        .fail(function (error) {
            console.log("ByKey: ", error);
        });

    $("#selectBox").dxSelectBox({
        dataSource: stores,
        displayExpr: "state",
        valueExpr: "id", // Ensures the selected value is based on the ID
        placeholder: "Select a state...",
        searchEnabled: true // Enables search functionality in dropdown
    })

    setTimeout(() => {
        stores.insert({ id: 4, state: "Mexico", capital: "Venice" }).done(function () {
            console.log("Inserted.");
        });

        stores.update(3, { state: "New Arizona", capital: "Phoenix" }).done(function () {
            console.log("Item updated!");
        });

        stores.remove(2).done(function () {
            console.log("Item removed!");
        });

        stores.totalCount().done(function (count) {
            console.log("Count is: ", count);
        }).fail((err) => {
            console.log(er);
        })

        $("#selectBox").dxSelectBox("getDataSource").reload();  // arraystore needs to be manually reloaded.
    }, 2000);
})