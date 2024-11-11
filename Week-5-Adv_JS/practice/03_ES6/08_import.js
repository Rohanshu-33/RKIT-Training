// Importing named exports
import { add, subtract, PI } from './07_export.js';

// Importing default export
import defaultMessage from './07_export.js';


// for CommonJS don't write "type": "module" in pckg.json.
// const math_operations = require('08_export.js')
// math_operations.default(2,3)
// math_operations.subtract(7,4)

const sum = add(5, 3);
const sub = subtract(10, 4);

console.log("Addition is :", sum); // Output: Addition is : 8
console.log("Subtraction is :", sub); // Output: Subtraction is : 6
console.log("Value of Pi:", PI); // Output: Value of Pi: 3.14
console.log(defaultMessage); // Output: Hello from the math module!
