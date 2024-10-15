console.log(document.cookie);
function showCookieData(){
    const cookieData = document.cookie;
    alert(`Cookie details : ${cookieData}`);
}

function deleteCookieData(){
    document.cookie = "email=; expires= Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    console.log(document.cookie);
    alert("Cookie deleted")
}