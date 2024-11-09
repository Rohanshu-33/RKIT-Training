$(document).ready(function () {
    const arr = [1, 2, 3, 4, 5]
    $("#original_arr").html(`Original array : ${arr.join(",")}`)

    // map
    $("#b1").click(function () {
        let ans = $.map(arr, function (val, key) {
            return `${key} : ${val}`
        });
        console.log(ans);
        $("#answer_arr").html(`<br/>Map :<br/> ${ans.join(" , ")}`)
    })

    // grep
    $("#b2").click(function () {
        let ans = $.grep(arr, function (val, key) {
            return val > 3
        });
        $("#answer_arr").html(`<br/>Filter :<br/> ${ans.join(" , ")}`)
    })

    // each
    $("#b3").click(function () {
        $("#answer_arr").html("<br/>Each :")
        $.each(arr, function (key, val) {
            $("#answer_arr").append(`<br/>${key} : ${val}`)
        });
    })

    // extends
    $("#b4").click(function () {
        const userDetails = {
            login: true,
            cart: { "watch": "WTC34235", "tshirt": "CLTH59782" }
        };

        // userDetails = [1,23]
        // userSettings = [3,5]

        const userSettings = {
            theme: "dark",
            cookies: false
        };

        const finalSettings = $.extend(true, [], userDetails, userSettings);
        console.log(finalSettings);
    })

    // merge
    $("#b5").click(function () {
        const arr2 = [4, 5, 6, 7, 8];
        $.merge(arr, arr2);
        $("#answer_arr").html(`<br/>Merge :<br/> ${arr.join(", ")}`)
    })

    // slice
    $("#b6").click(function () {
        const ans = $(arr).slice(2, 4)
        console.log(ans); // it will be a jQuery object
    })

})