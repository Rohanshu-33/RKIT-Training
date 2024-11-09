function validateForm(event) {

    event.preventDefault()

    const fullname = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const pswd = document.getElementById("pswd").value;
    const address = document.getElementById("address").value;
    const resume = document.getElementById("resume").value;
    const male = document.getElementById("male").checked;
    const female = document.getElementById("female").checked;
    let gender = null

    const namePattern = /^[a-zA-Z\s]+$/;
    const emailPattern = /^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]+$/;
    const passwordPattern = /^[^\s]{8,20}$/;

    if (!namePattern.test(fullname)) {
        alert("Enter a valid name (letters and spaces only).");
        return false;
    }
    sessionStorage.setItem("fullname",fullname);


    if (!emailPattern.test(email)) {
        alert("Enter a valid email.");
        return false;
    }
    sessionStorage.setItem("email", email);
    
    if (!passwordPattern.test(pswd)) {
        alert("Password must be 8-20 characters long with no spaces.");
        return false;
    }
    
    if (address.trim() === "") {
        alert("Address is required.");
        return false;
    }
    sessionStorage.setItem("address", address);

    if (resume === "") {
        alert("Please upload your resume.");
        return false;
    }

    if (!male && !female) {
        alert("Please select your gender.");
        return false;
    }
    gender = male ?  "male" : "female"
    sessionStorage.setItem("gender", gender);

    alert("Successful.")

    return true;
}


console.log("fullname : ", sessionStorage.getItem("fullname"));
console.log("email : ", sessionStorage.getItem("email"));
console.log("address : ", sessionStorage.getItem("address"));
console.log("gender : ", sessionStorage.getItem("gender"));


if(sessionStorage.getItem("fullname")){
    document.querySelector("#name").value = sessionStorage.getItem("fullname");
}

if(sessionStorage.getItem("address")){
    document.querySelector("#address").value = sessionStorage.getItem("address");
}

if(sessionStorage.getItem("email")){
    document.querySelector("#email").value = sessionStorage.getItem("email");
}

if(sessionStorage.getItem("gender")){
    document.querySelector(`#${sessionStorage.getItem("gender")}`).checked = true;
}


function clearData(){
    sessionStorage.clear();
    document.getElementById("name").value = "";
    document.getElementById("email").value = "";
    document.getElementById("pswd").value = "";
    document.getElementById("address").value = "";
    document.getElementById("resume").value = "";
    document.getElementById("male").checked = false;
    document.getElementById("female").checked = false;
    return true
}