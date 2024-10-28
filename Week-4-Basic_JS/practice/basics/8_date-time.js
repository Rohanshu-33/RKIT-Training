//year, month, date, hour, minute, seconds, milliseconds
let specificDate = new Date(2024, 9, 28, 18, 30, 61, 0);
console.log("Specific date is : ", specificDate);

let fromString = new Date("2024-10-28T10:30:00");
console.log("Date from string is : ", fromString);

let fromTimestamp = new Date(1726800567999);
console.log("Date from time stamp is : ", fromTimestamp);

let currentDate = new Date()
console.log("Current date is : ", currentDate);

console.log("Year is : ", currentDate.getFullYear());
console.log("Month is : ", currentDate.getMonth());
console.log("Date is : ", currentDate.getDate());
console.log("Day is : ", currentDate.getDay());  //1,2,3,4,5,6,7 are the output values. 1 means monday
console.log("Time in milliseconds is : ", currentDate.getTime());
console.log("Millisecond is : ", currentDate.getMilliseconds());
console.log("Minute is : ", currentDate.getMinutes());
console.log("Hour is : ", currentDate.getHours());
console.log("UTC Hour is : ", currentDate.getUTCHours());

console.log("Readable format : ", currentDate.toString());
console.log("Date format : ", currentDate.toDateString());
console.log("ISO format : ", currentDate.toISOString());
console.log("Time format : ", currentDate.toTimeString());

