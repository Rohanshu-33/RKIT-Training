// forEach, map, reduce, filter

const arr = [2,5,3,4,7,6,8,1]

const brr = arr.map((ele)=>{
    return ele*2
})

const crr = arr.filter(function(ele){
    return ele > 4
})

console.log(crr);

const ans = arr.reduce((acc, curr)=>acc+curr, 0)
console.log(ans);

arr.forEach((value, key, arr_name)=>{
    console.log(`Value at index ${key} is ${value} of array [${arr_name}]`);
})