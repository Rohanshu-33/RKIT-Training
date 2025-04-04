$(document).ready(function () {
    var store = new DevExpress.data.CustomStore({
        // take and skip how?
        key: "id",
        load: function () {
            let d = $.Deferred();
            $.ajax({
                url: "https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/",
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
                url: "https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/",
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
                url: `https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/${key}`,
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
                url: `https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/${key}`,
                method: "DELETE"
            }).done(function () {
                d.resolve();
            }).fail(function (error) {
                d.reject("Delete error: " + error.statusText);
            });
            return d.promise();
        },

        byKey: function (key) {
            let d = new $.Deferred();
            $.get(`https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/${key}`)
                .done(function (dataItem) {
                    d.resolve(dataItem);
                });
            return d.promise();
        },

        // cacheRawData: true, // below raw is required
        loadMode: "raw", // processed
        errorHandler: function (error) {
            console.log("ERROR\n", error.message);
        },
        onInserted: function (e) {
            console.log("Data is inserted. ", e);
        },
        onInserting: function (e) {
            console.log("Data is being inserting. ", e);
        },
        onLoaded: function (e) {
            console.log("Data is loaded. ", e);
        },
        onLoading: function (e) {
            console.log("Data is being loading. ", e);
        },
        onModified: function (e) {
            console.log("Data is modified. ", e);
        },
        onModifying: function (e) {
            console.log("Data is being modifying. ", e);
        },
        onModified: function (e) {
            console.log("Data is being loading. ", e);
        },
        useDefaultSearch: true, // true for raw, false for processed bydefault
        // onPush, removed, removing, updated, updating

    });

    $("#dataGrid").dxDataGrid({
        dataSource: store,
        columnsAutoWidth: true,
        columnHidingEnabled: true,
        searchPanel: {
            visible: true,
            highlightCaseSensitive: true
        },
        editing: {
            mode: "popup",
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true
        },
        columns: [
            { dataField: "id", caption: "ID", allowEditing: false },
            { dataField: "name", caption: "Name" },
            { dataField: "email", caption: "Email" }
        ]
    });

    setTimeout(() => {
        store.byKey(1).done(function (data) {
            console.log("Fetched User:", data);
        });

        store.totalCount()
            .done(function (count) {
                console.log("count: ", count);

            })
            .fail(function (error) {
                console.log("error: ", error);
            });
    }, 3000);
});