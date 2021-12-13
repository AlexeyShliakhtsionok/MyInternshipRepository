
// Task_7 Average of even numbers

// 7.1 Example (implementation using 1-6 tasks)

// In order to implement this function we can use the filter and then use the linear fold function on array recieved from filter function
const arrayToFindEvenNumbersAverage = [7, 15, 8, 12, 1, 4, 25];


// Filter function
function callbackFilterFunction (currentValue, newArrayArg){
    if (currentValue % 2 === 0) {
        newArrayArg.push(currentValue);
    }
}

function filterImpementation(array, callbackFunct){
   
    if(!Array.isArray(array)){
        throw new Error("First argument is not an array");
    };

    for (let value of array) {
        if (!Number.isInteger(value)) {
            throw new Error("One of array elements is not a number");
        }
    };

    if(typeof callbackFunct !== "function"){
        throw new Error("Argument passed as callbackFunction is not a function");
    };

    let newArray = [];

    for (let i = 0; i < array.length; i++) {
        callbackFunct(array[i], newArray);
    }

    return newArray;
}

// LinearFold function
function linearFold(array, callbackFunc, initValue) {

    if(!Array.isArray(array)){
        throw new Error("First argument is not an array");
    };

    if(typeof callbackFunct !== "function"){
        throw new Error("Argument passed as callbackFunction is not a function");
    };

    for (let value of array) {
        if (!Number.isInteger(value)) {
            throw new Error("One of array elements is not a number");
        }
    };

    if(!Number.isInteger(initValue)){
        throw new Error("Argument passed as initValue is not a number");
    };

    let previousVal = initValue; 
    for (let i = 0; i < array.length; i++) { 
        previousVal = callbackFunc(previousVal, array[i]);
    }
    return previousVal/array.length;
}

function callbackSumPrevWithCurr(previouslyReturnedValue, currentValue) {
    return previouslyReturnedValue + currentValue;
}

// Test evaluation
let intermediate = filterImpementation(arrayToFindEvenNumbersAverage, callbackFilterFunction);
console.log("Filtered array: " + intermediate);

let averageResult = linearFold(filterImpementation(arrayToFindEvenNumbersAverage, callbackFilterFunction),callbackSumPrevWithCurr,0);
console.log("Filtered array: " + averageResult);


// 7.2 Example (Another implementation)

let someArr = [1,2,3,4,5,6,7,8,9,10];

function evenAverage(array){
    let count = 0;
    let accumulator = 0;

    for (let i = 0; i < array.length; i++) {
        if(array[i] % 2 === 0){
            count++;
            accumulator += array[i];
        }
    }

    return accumulator/count;
}

let evenAverageResult = evenAverage(someArr);
console.log(evenAverageResult);
