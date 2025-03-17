$(document).ready(function () {

    // ---------------------------- creating and configuring a component ----------------------------------------

    $("#buttonContainer").dxButton({
        text: "Click me!",
        type: "success",
        onClick: function () {
            alert("Hello world!");
        }
    });

    $("#inputBox").dxTextBox({
        placeholder: "Type something...",
        onValueChanged: function (e) {
            console.log("New value:", e.value);
        }
    });


    // --------------------------------------- get a widget instance -----------------------------------------

    const buttonInstance = $("#buttonContainer").dxButton("instance");
    console.log("Instance: ", buttonInstance);

    // Change button text dynamically
    buttonInstance.option("text", "New Text");

    // get the option current value
    // console.log(buttonInstance.option("text"));        

    // ------------------------------------- get and set options ---------------------------------------

    // // get single property
    // var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
    // var dataSource = dataGridInstance.option("dataSource");
    // var editMode = dataGridInstance.option("editing.mode");
    // // ---------- or ----------
    // var dataSource = $("#dataGridContainer").dxDataGrid("option", "dataSource");
    // var editMode = $("#dataGridContainer").dxDataGrid("option", "editing.mode");



    // // get all properties

    // var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
    // var dataGridOptions = dataGridInstance.option();
    // // ---------- or ----------
    // var dataGridOptions = $("#dataGridContainer").dxDataGrid("option");



    // // set a single property

    // var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
    // dataGridInstance.option("dataSource", []);
    // dataGridInstance.option("editing.mode", "batch");
    // // ---------- or ----------
    // $("#dataGridContainer").dxDataGrid("option", "dataSource", []);
    // $("#dataGridContainer").dxDataGrid("option", "editing.mode", "batch");

    // // set several properties

    // var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
    // dataGridInstance.option({
    //     dataSource: [],
    //     editing: {
    //         mode: "cell"
    //     }
    // });
    // // ---------- or ----------
    // $("#dataGridContainer").dxDataGrid({
    //     dataSource: [],
    //     editing: {
    //         mode: "cell"
    //     }
    // });


    // ------------------------------------------------- call methods -----------------------------------------------
    const inputInstance = $("#inputBox").dxTextBox("instance");
    setTimeout(() => {
        inputInstance.reset();
    }, 3000);


    $("#inputBox2").dxTextBox({
        placeholder: "Enter your name...",
        onFocusIn: function () {
            console.log("Input field focused!");
        },
        onFocusOut: function () {
            console.log("Input field lost focus!");
        }
    });


    // ------------------------------------------------- handle events -----------------------------------------------


    // destroying a component
    setTimeout(() => {
        $("#inputBox").dxTextBox("dispose");
    }, 4000);

})