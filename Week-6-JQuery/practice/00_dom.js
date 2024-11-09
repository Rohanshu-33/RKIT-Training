$(document).ready(function () {

    // append
    $("#btn1").click(function () {
        $("#div1").append("<p>This is appended paragraph.</p>")
    })

    // prepend
    $("#btn2").click(function () {
        $("#div1").prepend("<p>This is prepended paragraph.</p>")
    })

    // css
    $("#btn3").click(function () {
        $("#div1").css("color", "red").css("font-size", "40px")
    })

    // after
    $("#btn4").click(function () {
        $("#div1").after("<p>This is paragraph after div.</p>")
    })

    // empty
    $("#btn5").click(function () {
        $("#div1").empty()
    })

    // remove  --> different from empty. This removes element from DOM itself.
    $("#btn6").click(function () {
        $("#div1").remove()
    })

    // text
    $("#btn7").click(function () {
        alert($("#div1").text())
    })

    // html
    $("#btn8").click(function () {
        alert($("#div1").html())
    })

    // val --> won't work as it is specifically for input tags, textarea and select tags.
    // $("#btn9").click(function(){
    //     alert($("#div1").val())      
    // })


    // add class
    $("#btn10").click(function () {
        $("#div1").addClass("container")
    })

    // add attribute
    $("#btn11").click(function () {
        $("#div1").attr("draggable", "True")
    })

})