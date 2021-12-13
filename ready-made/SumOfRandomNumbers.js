
function linearUnfold(callbackFunction) {
    let arr = [],
        state = 0,
        value;
    while (state !== 10) {
        value = callbackFunction();
        arr.push(value);
        state++;
    }
    return arr;
}

function funcWithRandomValue() {
    let value = Math.floor(Math.random() * 10);
    return value;
}

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
        throw new Error("Function callback has to accept not more 4 parameters");
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




let testArr = linearUnfold(funcWithRandomValue);
console.log(testArr);

let result_Task8 = linearFold(testArr, callbackSumPrevWithCurr, 0);

console.log(result_Task8);



