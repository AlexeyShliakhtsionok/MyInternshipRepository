
// Task_7 Average of even numbers

// 7.1 Example (implementation using 1-6 tasks)
const arrayToFindEvenNumbersAverage = [7, 15, 8, 12, 1, 4, 25];

function callbackFilterFunction (currentValue, newArrayArg){
    if (currentValue % 2 === 0) {
        newArrayArg.push(currentValue);
    }
}

function filterImpementation(array, callbackFunct){
   
    let newArray = [];

    for (let i = 0; i < array.length; i++) {
        callbackFunct(array[i], newArray);
    }

    return newArray;
}

function linearFold(array, callbackFunc, initValue) {
    let previousVal = initValue; 
    for (let i = 0; i < array.length; i++) { 
        previousVal = callbackFunc(previousVal, array[i]);
    }
    return previousVal/array.length;
}

function callbackSumPrevWithCurr(previouslyReturnedValue, currentValue) {
    return previouslyReturnedValue + currentValue;
}

let intermediate = filterImpementation(arrayToFindEvenNumbersAverage, callbackFilterFunction);
console.log(intermediate);


let averageResult = linearFold(filterImpementation(arrayToFindEvenNumbersAverage, callbackFilterFunction),callbackSumPrevWithCurr,0);
console.log(averageResult);


let something = [1,2,3,4,5,6,7,8,9,10];

function evenAverage(array){
    let count = 0;
    let accumulator = 0;

    for (let i = 0; i < array.length; i++) {
        if(array[i] % 2 === 0){
            count++;
            accumulator += array[i]
        }
    }

    return accumulator/count;
}

let evenAverageResult = evenAverage(something);
console.log(evenAverageResult);