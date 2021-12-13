// // 11. Task_10 Lazy Loading of functions 

// //11.1 Example (by using JS-implemented bind and apply) https://blog.gypsydave5.com/posts/2015/3/21/basic-lazy-evaluation-and-memoization-in-javascript/




// function makeItLazyEvaluated(funct){
//     return funct.bind.apply(funct, arguments);
// }

// function numbersAdditing(a,b){
//     return a + b;
// }

// let evaluatedFunction = makeItLazyEvaluated(numbersAdditing, 41, 22);

// console.log(evaluatedFunction);

// let result = evaluatedFunction(); // Call by need

// console.log(result);

//Memoization

// Example



function numbersAdditing(a,b){
     return a + b;
    }

function lazyEvalMemo (fn) {
    var args = arguments;
    var result;
    var lazyEval = fn.bind.apply(fn, args);
    return function () {
      if (result) {
        console.log("I remember this one!");
        return result
      }
      console.log("Let me work this out for the first time...");
      result = lazyEval()
      return result;
    }
  }




let evaluatedFunction = lazyEvalMemo(numbersAdditing, 41, 22);
let evaluatedFunction1 = lazyEvalMemo(numbersAdditing, 1, 2);

let firstResult = evaluatedFunction();

let secondResult = evaluatedFunction();