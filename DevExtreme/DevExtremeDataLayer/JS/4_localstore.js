$(document).ready(function () {
    var STORAGE_KEY = "my-local-data";

    // Load from localStorage (if exists)
    var storedData = localStorage.getItem(STORAGE_KEY);
    var states = storedData ? JSON.parse(storedData) : [
        { id: 1, state: "Alabama", capital: "Montgomery", region: "South" },
        { id: 2, state: "Alaska", capital: "Juneau", region: "West" },
        { id: 3, state: "Arizona", capital: "Phoenix", region: "West" }
    ];

    var localStore = new DevExpress.data.LocalStore({
        key: "id",
        name: STORAGE_KEY,
        data: states,
        immediate: true
    });

    var ds = new DevExpress.data.DataSource({
        store: localStore,
        group: "region"
    });

    $("#selectBox").dxSelectBox({
        width: "20rem",
        height: "3rem",
        dataSource: ds,
        displayExpr: "state",
        valueExpr: "id",
        searchEnabled: true,
        grouped: true
    });

    // Insert a new record after 2 seconds
    setTimeout(() => {
        var newRecord = {
            id: 6,
            state: "Florida",
            capital: "Tallahassee",
            region: "South"
        };

        localStore.insert(newRecord).done(() => {
            ds.load(); // Refresh the data in the UI

            // Save updated data to localStorage
            // localStore.load().done((data) => {
            //     localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
            // });
        });
    }, 2000);
});