function numbersAdditing(a, b) {
    return a + b;
}

function lazyEvaluationMemozed(funct) {

    var args = arguments,
        result,
        lazyEvaluation = funct.bind.apply(funct, args);

    return function () {
        if (result) {
            console.log("Fitched from the cache");
            return result
        }
        console.log("Processing...");
        result = lazyEvaluation()
        return result;
    }
}

let evaluatedFunction = lazyEvaluationMemozed(numbersAdditing, 41, 22);

let firstResult = evaluatedFunction();
let secondResult = evaluatedFunction();

