// Task_3 Linear fold

// 3.1 Example (JS built-in implementation)

const testArray = [1, 2, 3, 4, 5]; // Test array

const callbackFunct = (previous, current) => previous + current;

let result = testArray.reduce(callbackFunct);
console.log(result); // 15


// 3.2 Example (function implementation)

function linearFold(array, callbackFunc, initValue) {
    // Validation block--------------
    const countCallbackArgs = 4; 
    if (!Array.isArray(array)) {
        throw new Error("First argument is not an array!");
    }
    for (let value of array) {
        if (!Number.isInteger(value)) {
            throw new Error("One of array elements is not a number");
        }
    }
    if (typeof callbackFunc !== "function") {
        throw new Error("First argument is not a function");
    }
    if (callbackFunc.length > countCallbackArgs) {
        throw new Error("Function callback has to accept 4 parameters");
    }
    
    // End of validation block--------------


    let previousVal = initValue; // Variable, that accumulate returned from callback functions values. Initialize by "initValue" on the first call of callback
    for (let i = 0; i < array.length; i++) { // Iteration thru the array applying callback on each index
        previousVal = callbackFunc(previousVal, array[i], i, array);
    }
    return previousVal;
}

function callbackSumPrevWithCurr(previouslyReturnedValue, currentValue) {
    return previouslyReturnedValue + currentValue;
}

let result__1 = linearFold(testArray, callbackSumPrevWithCurr, 0)
console.log("The result is: " + result__1);