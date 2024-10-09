// array initialization
const arr = [1, 2, "hlo"]
console.log("The first element in the array is : ", arr[0]);

// array element modification
arr[1] = 44.4
console.log("Array is : ", arr);

// array insertion
arr[5] = 4
console.log("Array is : ", arr);

// for-in loop
console.log("The for-in loop prints the index");
for (ele in arr) {
    console.log(ele);
}

// for-of loop
console.log("The for-of loop prints the values");
for (ele of arr) {
    console.log(ele);
}

// pushing an element in array
arr.push(23)

// size of array
console.log("Size of array is : ", arr.length, "arr : ", arr);

// entries method of array
for (const [key, value] of arr.entries()) {
    console.log("key : ", key, " value : ", value);
}

// array concatenation
const arr2 = [3, 4, 5]
console.log(arr.concat(arr2));

// filling the array with static element
arr.fill(3)
console.log(arr);

// flattening of complex array
const arr3 = [1, 2, 3, [4, 5, [6, 7, 8]]]
depth = 2
console.log("Array is :", arr3);
console.log("Flattend array is : ", arr3.flat(depth));
console.log("Flattend array is : ", arr3.flat(Infinity));


// index of an element in an array. If not found, -1 is returned
const ind = arr3.indexOf(2)
console.log("Index of 2 is : ", ind);

// join method in array
console.log(arr.join(''));
console.log(arr.join('--'));

// popping last element from the array
console.log("Popping : ", arr.pop())

const names = ["rohanshu", "meet", "navneet"]
// converting elements of array to a string
console.log(names.toString())

// slicing of array to return new sliced array
console.log(names.slice(1))

// splicing of array to remove these elements from the original array
console.log(names.splice(1));
console.log(names);

const numbers = [6, 4, 2, 4, 7, 4, 2, 9, 2, 5, 8]

// sorting of array
console.log(numbers.sort());
const fruits = ["kiwi", "banana", "mango"]
console.log(fruits.sort());
const elements = [8, , 2, "js", 1, 2, 4.4, "hello", "world"]
console.log(elements.sort());
