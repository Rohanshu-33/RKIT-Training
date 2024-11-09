$(document).ready(function(){
    
    // show
    $("#btn-show").click(function(){
        $("#img1").show(1000, "linear")
    })

    // hide
    $("#btn-hide").click(function(){
        $("#img1").hide(2000, "swing", function(){
            alert("Hide performed.")
        })
    })

    // toggle
    $("#btn-toggle").click(function(){
        $("#img1").toggle()
    })
    



    // fade-in
    $("#btn-fade-in").click(function(){
        $("#img2").fadeIn()
    })

    // fade-out
    $("#btn-fade-out").click(function(){
        $("#img2").fadeOut()
    })

    // fade-toggle
    $("#btn-fade-toggle").click(function(){
        $("#img2").fadeToggle()
    })


    
    // slide-toggle
    $("#btn-slide-toggle").click(function(){
        $("#img3").slideToggle()
    })

    // animate
    $("#btn-animate").click(function(){
        $("#img3").animate({
            scale: 2
        }, 5000)
    })

    // finish -> finishes the ongoing event and other queued events
    $("#btn-finish").click(function(){
        $("#img3").finish()
    })
})