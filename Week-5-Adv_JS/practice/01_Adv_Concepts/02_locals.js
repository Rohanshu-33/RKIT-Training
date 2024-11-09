
// check whether login credentials are in localstorage or not and accordingly navigate the user

function handleLogin(){
    const email = document.getElementById("email").value;
    const pswd = document.getElementById("password").value;

    const emailPattern = /^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]+$/;
    const passwordPattern = /^[^\s]{8,20}$/;

    if (!emailPattern.test(email)) {
        alert("Enter a valid email.");
        return false;
    }

    if (!passwordPattern.test(pswd)) {
        alert("Password must be 8-20 characters long with no spaces.");
        return false;
    }

    localStorage.setItem("email", email);
    localStorage.setItem("password", pswd);

    document.cookie = `email=${encodeURIComponent(email)}; expires= Thu, 30 Oct 2024 12:00:00 UTC; path=/;`;
    
    return true;
}


function checkAuths(){
    const email = localStorage.getItem('email');
    const pswd = localStorage.getItem('password');
    
    if(!(email && pswd)){
        window.location.href = "./login.html";
    }
    return true;
}

function checkAuths2(){
    const email = localStorage.getItem('email');
    const pswd = localStorage.getItem('password');
    
    if(email && pswd){
        window.location.href = "./index.html";
    }
    return true;
}

function handleLogout(){
    localStorage.clear()
    window.location.href = "./login.html";
}