$(document).ready(function () {
    const games = ["football", "cricket", "hockey"];

    const verificationMethod = [
        { text: "Aadhar Card", value: "1111 2222 3333", disabled: true },
        { text: "PAN Card", value: "F34562537H" },
        { text: "License", value: "GJ15-356456", visible: true }
    ]
    $("#radioGroup").dxRadioGroup({
        dataSource: verificationMethod,
        // items: [1,2,3],
        displayExpr: "text",
        valueExpr: "value",
        value: verificationMethod[2],
        layout: "horizontal",
        name: "radio-btn-name",
        onValueChanged: function (e) {
            console.log(e);
        }
    })

    $("#radioGroup2").dxRadioGroup({
        dataSource: [
            { text: "Low", color: "grey" },
            { text: "Normal", color: "green" },
            { text: "Urgent", color: "yellow" },
            { text: "High", color: "red" }
        ],
        itemTemplate: function (itemData, itemIndex, itemElement) {
            console.log(itemData);
            console.log(itemIndex);
            console.log(itemElement);

            itemElement.append(
                $("<div />").attr("style", "color:" + itemData.color)
                    .text(itemData.text)
            );
        }
    });
})