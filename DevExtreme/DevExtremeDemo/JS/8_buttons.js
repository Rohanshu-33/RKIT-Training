$(document).ready(function () {
    $("#btn1").dxButton({
        text: "Click me!",
        type: "success", // 'back' 'danger' 'default' 'normal'
        stylingMode: "outlined",
        icon: "comment",
        useSubmitBehaviour: false,  // checks form validation of validation group. if onclick is present, it is triggered before validation and form submission
        onContentReady: function (e) {
            console.log("onContentReady Triggered:");
        }
    });

    // Get button instance
    let inst = $("#btn1").dxButton("instance");

    // Change icon after 5 seconds
    setTimeout(() => {
        inst.option("icon", "home"); // Changing icon dynamically
        console.log("Icon changed to home");
    }, 5000);
});