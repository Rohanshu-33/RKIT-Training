$(document).ready(function(){

    // click event
    // $("#div-1").click(function(){
    //     alert("Div tag clicked")
    // })

    // event-bubbling will happen
    // $("#para-1").click(function(event){
        // event.stopPropagation()
    //     alert("Paragraph tag 1 clicked")
    // })

    // double click event
    // $("#para-2").dblclick(function(){
    //     $(this).css("font-size", "20px")
    // })

    // hover event
    // $("#para-3").hover(function(){
    //     alert("You entered in para 3.")
    // }, function(){
    //     alert("You left para 3.")
    // })

    // focus event (:text -> all input elements with type as text)
    $(":text").focus(function(){
        $(this).css("background-color", "grey")
    })
    
    // blur event
    $(":text").blur(function(){
        $(this).css("background-color", "white")
    })

    // on event
    $("img").on({
        mouseenter: function(){
          $(this).animate({
            width: "+=20%",
            height: "+=20%",
        }, 2000)
        },
        mouseleave: function(){
            $(this).animate({
                width: "-=20%",
                height: "-=20%",
            }, 3000)
        },
        click: function(){
          alert("You clicked on an image")
        }
      });


})