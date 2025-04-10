﻿const dataObjects = [
    { name: "Amelia", birthYear: 1991, gender: "female" },
    { name: "Benjamin", birthYear: 1983, gender: "male" },
    { name: "Daniela", birthYear: 1987, gender: "female" },
    { name: "Lee", birthYear: 1981, gender: "male" }
];

const processedArray = DevExpress.data.query(dataObjects)
    .filter(["gender", "=", "female"])
    .sortBy("birthYear")
    .select("name", "birthYear")
    .toArray();

// console.log(processedArray);



// aggregate

var step = function (total, itemData) {
    // "total" is an accumulator value that should be changed on each iteration
    // "itemData" is the item to which the function is being applied
    return total + itemData;
};

var finalize = function (total) {
    // "total" is the resulting accumulator value
    return total / 1000;
};

DevExpress.data.query([10, 20, 30, 40, 50])
    .aggregate(0, step, finalize)
    .done(function (result) {
        // console.log(result); // outputs 0.15
    });

// aggregate for objects




// avg
DevExpress.data.query([1, 2, 3, 4, 5])
    .avg()
    .done(function (result) {
        // console.log(result);
    });

const objects = [{ id: 2, price: 22 }, { id: 6, price: 78 }]
DevExpress.data.query(objects)
    .avg("price")  // or select("price").avg()  // same for max() , min() , sum()
    .done(function (result) {
        // console.log(result);
    });




// count
DevExpress.data.query([10, 20, 30])
    .count()
    .done(function (result) {
        // console.log(result); // outputs 5
    });



// enumerate
const cars = ["BMW", "Mazda", "Volvo"];
DevExpress.data.query(cars)
    .enumerate()
    .done(function (res) {
        // console.log(res);
    })



// filter
const emp = [{ id: 1, name: "a" }, { id: 2, name: "b" }, { id: 3, name: "c" }]
let filteredData = DevExpress.data.query(emp)
    .filter([["id", "<", 3], "and", ["name", "=", "a"]])
    .toArray();

// console.log(filteredData);


// filter
filteredData = DevExpress.data.query([10, 20, 40, 50, 30])
    .filter(function (dataItem) {
        return dataItem < 25;
    })
    .toArray();

// console.log(filteredData);


// groupby
const fruits = [{ name: "guava", category: "fruit" }, { name: "apple", category: "fruit" }, { name: "tomato", category: "veggie" }]

const groupedResult = DevExpress.data.query(fruits)
    .groupBy("category")
    .toArray()

// console.log(groupedResult);

// slice

var dataObjs = [
    { name: "Amelia", birthYear: 1991, gender: "female" },
    { name: "Benjamin", birthYear: 1991, gender: "male" },
    { name: "Daniela", birthYear: 1987, gender: "female" },
    { name: "Lee", birthYear: 1981, gender: "male" }
];

var subset = DevExpress.data.query(dataObjs)
    .slice(1, 2)  // skip, take
    .toArray();

// console.log(subset);


// sortBy, thenBy
var sortedData = DevExpress.data.query(dataObjs)
    .sortBy("birthYear", true) // desc: true,  asc: false or no 2nd param
    .thenBy("name")
    .toArray();

console.log(sortedData);