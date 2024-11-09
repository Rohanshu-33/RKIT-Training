$(document).ready(function(){

    // element selector
    // $("h1").mouseover(function(){
    //     alert($("h1").text())
    // })

    // class selector
    // $(".content-para-class-1").mouseover(function(){
    //     alert($(".content-para-class-1").text())
    // })

    // id selector
    // $("#content-heading-1").mouseover(function(){
    //     alert($("#content-heading-1").text())
    // })

    // mixed selector
    // $("h1, .content-para-class-1, #content-heading-1").click(function(){
    //     $(this).css("visibility", "hidden")
    // })


    // other selectors

    // selects the first 'li' element of first 'ul'
    $("ul li:first").css("color", "red")
    
    // selects the first 'li' element of every 'ul'
    $("ul li:first-child").css("background-color", "cyan")

})