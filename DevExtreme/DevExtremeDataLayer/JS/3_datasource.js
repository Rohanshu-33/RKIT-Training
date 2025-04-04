$(document).ready(function () {
    // const fruits = ["guava", "banana", "apple", "mango"];
    const fruits = [
        {
            id: 1,
            name: "apple",
            category: "a"
        },
        {
            id: 2,
            name: "banana",
            category: "a"
        },
        {
            id: 3,
            name: "avocado",
            category: "b"
        },
        {
            id: 4,
            name: "mango",
            category: "b"
        }
    ];

    const ds = new DevExpress.data.DataSource({
        store: fruits,
        type: "array",
        key: "id",
        // filter: [["name", "=", "apple"], "or", ["name", "startswith", "m"]],
        group: "category",
        map: function (item) {
            return {
                id: item.id,
                name: item.id + "--" + item.name
            };
        },
        onChanged: function (e) {
            console.log("On changed: ", e);
        },
        onLoadError: function (error) {
            console.log("Failed to load data:\n", error.message);
        },
        onLoadingChanged: function (e) {  // when data loading status changes
            console.log("On loading changed: ", e);
        },
        paginate: true,
        pageSize: 2,
        searchExpr: ["name"],
        requireTotalCount: true,
        reshapeOnPush: true,
        searchOperation: "endswith",
        sort: [
            "Position",
            { selector: "name", desc: false }
        ],

    });

    setTimeout(() => {
        ds.store().push([{
            type: "insert",
            data: { id: 5, name: "papaya", category: "a" }
        }]);
        ds.repaint();  // dont do reload here. else data will be gone


        // methods

        console.log("Filters: ", ds.filter());
        console.log("Is last page: ", ds.isLastPage());
        console.log("Is loaded? ", ds.isLoaded());
        console.log("Is loading? ", ds.isLoading());
        console.log("Items: ", ds.items());
        console.log("Keys: ", ds.key());

        ds.pageIndex(2);
        ds.load();

        console.log("Pagination? ", ds.paginate());
        console.log("Total Count: ", ds.totalCount());

    }, 2000);

    $("#selectBox").dxSelectBox({
        width: "20rem",
        height: "3rem",
        dataSource: ds,
        displayExpr: "name",
        valueExpr: "id",
        searchEnabled: true,
        grouped: true
    })
});