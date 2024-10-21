let str = "rohanshu banodha";

// Log the original string
console.log(str); // Output: rohanshu banodha

// Get the character at index 2
console.log(str.charAt(2)); // Output: 'h'

// Get the length of the string
console.log(str.length); // Output: 16

// Replace the substring 'banodha' with 'anil banodha'
console.log(str.replace('banodha', 'anil banodha')); 
// Output: rohanshu anil banodha

// Convert the entire string to uppercase
console.log(str.toUpperCase()); 
// Output: ROHANSHU BANODHA

// Check if the string ends with the letter 'a'
console.log(str.endsWith('a')); 
// Output: true

// Check if the string includes the substring 'anil'
console.log(str.includes('anil')); 
// Output: false

// Repeat the string twice
console.log(str.repeat(2)); 
// Output: rohanshu banodharohanshu banodha

// Extract a substring starting from index 3 to index 12 (non-inclusive)
console.log(str.slice(3, 12)); 
// Output: anshu ban

// Search for the first occurrence of 'a' in the string
console.log(str.search('a')); 
// Output: 1 (the first 'a' is at index 1)
