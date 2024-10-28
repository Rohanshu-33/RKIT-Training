let a = 5
let b = "5"

// loose check. type conversion happens if possible
console.log(a==b);

// strict check. no type conversion happen
console.log(a===b, "\n");


// loose check. type conversion happens if possible
console.log(a!=b);

// strict check. no type conversion happen
console.log(a!==b);