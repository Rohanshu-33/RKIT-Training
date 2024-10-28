// async and await are syntactic sugar built on top of promises that allow you to write asynchronous code in a more readable and synchronous-like manner.

// async keyword is used to declare a function as asynchronous. An async function always returns a promise. If resolved, "await" returns the resolved value.
// If rejected, error is returned which can be handled using try-catch block.

// The major advantage of using async-await is that it enhances readability and error handling becomes easier (try-catch block)

async function fetchApi(){
    try{
        const response = await fetch("https://www.google.com")
        if(response){
            console.log("Promise is resolved.");
        }
    }
    catch(e){
        console.log("ERROR : Promise is rejected.\n", e);
    }
}

console.log("Before fetching.");

fetchApi()

console.log("After fetching 1.");
console.log("After fetching 2.");
console.log("After fetching 3.");