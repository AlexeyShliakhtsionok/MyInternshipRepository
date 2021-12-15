// 9. Task_9 First

//9.1 Example (function implementation)
function firstInArray(array, callbackFunct, condition) {
  let index = 0;

  for (let i = 0; i < array.length && index === 0; i++) {
    index = callbackFunct(array[i], i, condition);
  }
  if (index === 0) {
    return console.log(
      'There are no values in the array that satisfy the condition',
    );
  }
  return console.log(
    `The value that satisfy the condition is in the array at index ${index}`,
  );
}

function searchCondition(currentValue, valueIndex, conditionFunct) {
  if (conditionFunct(currentValue)) {
    return valueIndex;
  }
  return 0;
}

const conditionForArrayElement_1 = (x) => Number.isInteger(x);
const conditionForArrayElement_2 = (x) => typeof x === 'string';
const conditionForArrayElement_3 = (x) => typeof x === 'function';

let arr = [
  'a',
  'b',
  'c',
  4,
  5,
  6,
  function (x) {
    return x * 2;
  },
];

firstInArray(arr, searchCondition, conditionForArrayElement_1);
firstInArray(arr, searchCondition, conditionForArrayElement_2);
firstInArray(arr, searchCondition, conditionForArrayElement_3);
