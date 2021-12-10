// Task_5 Map

// 5.1 Example (Function implementation)


function mapImpementation(array, callbackFunct){
   
    // Validation block start -------------------
    if (!Array.isArray(array)) {
        throw new Error ("The first argument of mapImpementation is not an array.")
    };

    if (!typeof callbackFunct === "function") {
        throw new Error ("The second argument of mapImpementation is not a function.");
    }

    if (array.lenght == 0) {
        throw new Error ("Arrad doesn't contains any values.")
    };
    // Validation block end ---------------------

    let length = array.length;
    let newArray = [];

    for (let i = 0; i < length; i++) {
        newArray.push(callbackIndexManipulation(array[i]));
    }

    return newArray;
}

function callbackIndexManipulation(currentValue){
    return currentValue * 2;
}

var testArrayMap = [1, 2, 3, 4, 5, 6];

let mapResult = mapImpementation(testArrayMap);

console.log(mapResult);

// 5.2 Example (JS implementation)

let jsImplementationresult = testArrayMap.map(callbackIndexManipulation);
console.log(jsImplementationresult);
