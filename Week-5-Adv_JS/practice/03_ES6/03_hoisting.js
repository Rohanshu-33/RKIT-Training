hello() //function is exxecuted.
console.log(hello)  // whole function definition is logged without knowing the function definition at this point.
// How all these 3 above happens? Bcoz of execution context.

// console.log(f1) --> error: cannot access before initialization bcoz now it is treated as a variable with value as undefined.
// console.log(f2) --> same error as above
// f1() --> same error as above

// named function declaration
function hello(){
    console.log("hello")
}

// arrow function
const f1 = ()=>{
    console.log("f1");
}

// anonymous function expression
const f2 = function(){
    console.log("f2");
}