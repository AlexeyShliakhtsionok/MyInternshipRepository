// Task_6 Filter

const arrayToFilter = [7, 15, 8, 12, 1, 4, 25];

function callbackFilterFunction (currentValue, newArrayArg){
    if (currentValue > 10) {
        newArrayArg.push(currentValue);
    }
}

// 6.1 Example (function implementation)

function filterImpementation(array, callbackFunct){
   
    if(!Array.isArray(array)){
        throw new Error("First argument is not an array");
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

let result = filterImpementation(arrayToFilter, callbackFilterFunction);
console.log(result);

// 6.2 Example (JS implementation)

function jsCallbackFilterFunction(currentValue){
    if (currentValue > 10) {
        return currentValue;
    }
}

let jsImplementationResult = arrayToFilter.filter(jsCallbackFilterFunction);
console.log(jsImplementationResult);
