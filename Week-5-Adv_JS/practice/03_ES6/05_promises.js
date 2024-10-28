// A Promise is an object that represents the eventual completion (or failure) of an asynchronous operation and its resulting value. Promises are used to handle asynchronous operations in JavaScript, allowing for cleaner and more manageable code.

// A promise can be in any of the 3 states : fulfilled (operation is completed and is resolved), pending (operation still in process), rejected (operation got failed)

// Creating a promise:

let a=3
let b=4

let promise = new Promise((resolve, reject)=>{
    if(a<b){
        resolve("Promise is resolved.")
    }
    else{
        reject("Promise rejected.")
    }
})

promise.then((ans)=>{
    console.log(ans);
}).catch((err)=>{
    console.log(err);
}).finally(()=>{
    console.log("Finallly gets executed whether promise got resolved or rejected.");
})






// practical example:



// const request = fetch("https://www.google.com/")

// console.log(request);



// setTimeout(() => {
//     console.log(request);
// }, 1000);


// console.log("The main thread is continued to be executed.");

// request.then((data)=>{
//     console.log(data);
// }).catch((e)=>{
//     console.log("ERROR:\n", e);
// })