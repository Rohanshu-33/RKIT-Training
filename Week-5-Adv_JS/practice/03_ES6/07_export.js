// Function to add two numbers
export function add(a, b) {
    return a + b;
}

// Function to subtract two numbers
export function subtract(a, b) {
    return a - b;
}

export const PI = 3.14;

// Default export (only have one default export is possible)
const defaultMessage = "Hello there!";
export default defaultMessage;

// for CommonJS write, 
// module.exports = {
    // default: add,
    // subtract,
// }

// or
// exports.add = function(){ }
