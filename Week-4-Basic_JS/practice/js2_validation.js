function validateForm() {
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const pswd = document.getElementById("pswd").value;
    const address = document.getElementById("address").value;
    const resume = document.getElementById("resume").value;
    const male = document.getElementById("male").checked;
    const female = document.getElementById("female").checked;

    const namePattern = /^[a-zA-Z\s]+$/;
    const emailPattern = /^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]+$/;
    const passwordPattern = /^[^\s]{8,20}$/;

    if (!namePattern.test(name.trim())) {
        alert("Enter a valid name (letters and spaces only).");
        return false;
    }

    if (!emailPattern.test(email)) {
        alert("Enter a valid email.");
        return false;
    }

    if (!passwordPattern.test(pswd)) {
        alert("Password must be 8-20 characters long with no spaces.");
        return false;
    }

    if (address.trim() === "") {
        alert("Address is required.");
        return false;
    }

    if (resume === "") {
        alert("Please upload your resume.");
        return false;
    }

    if (!male && !female) {
        alert("Please select your gender.");
        return false;
    }

    return true;
}
