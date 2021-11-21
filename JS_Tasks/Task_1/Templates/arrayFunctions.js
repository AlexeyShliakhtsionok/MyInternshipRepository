class ArrayFunctions{

getMaxSubSum(array) {
    let maxSum = 0;
    for (let i = 0; i < array.length; i++) {
      let sumFixedStart = 0;
      for (let j = i; j < array.length; j++) {
        sumFixedStart += array[j];
        maxSum = Math.max(maxSum, sumFixedStart);
      }
    }
    return maxSum;
  }
  
  
getMaxSubSumFast(array) {
    let maxSum = 0;
    let partialSum = 0;
  
    for (let item of array) { 
      partialSum += item; 
      maxSum = Math.max(maxSum, partialSum);
      if (partialSum < 0) partialSum = 0;
    }
  
    return maxSum;
  }
  
getMaxValue(array) {
    let maxValue = array[0];
  
    for (let index = 0; index < array.length; index++) {
      if (maxValue < array[index]) {
        maxValue = array[index]
      }
    }
  
    return maxValue;
  }
  
getMinValue(array) {
    let minValue = array[0];
  
    for (let index = 0; index < array.length; index++) {
  
      if (minValue > array[index]) {
        minValue = array[index]
      }
    }
  
    return minValue;
  }
  
getMedianValue(array) {
    var half = Math.floor(array.length / 2);
    array.sort(function(a, b) { return a - b;});
  
    if (array.length % 2) {
      return array[half];
    } else {
      return (array[half] + array[half] - 1) / 2;
    }
  }
  
getIncreasingSequence(array){
    let sequence = new Array;
    let maxSequence = new Array;
    sequence.push(array[0]);
  
    for (let index = 1; index < array.length; index++) {
      if (array[index] < array[index-1]) {
        if(maxSequence.length < sequence.length) {maxSequence = sequence.slice()};
        sequence = [];
        sequence.push(array[index]);
      } else {
        sequence.push(array[index]);
      }
    }
    if(sequence.length > maxSequence.length){maxSequence = sequence.slice()};
    
  return maxSequence;
  
  }

}
