const task = [{
    type: "subSum_N",
    text: "Найти непрерывный подмассив arr, сумма элементов которого максимальна. Функция должна возвращать только эту сумму. Сложность O(n)",
  },
  {
    type: "subSum_N2",
    text: "Найти непрерывный подмассив arr, сумма элементов которого максимальна. Функция должна возвращать только эту сумму. Сложность O(n^2)",
  },
  {
    type: "search",
    text: "Написать функционал поиска минимального, максимального, медианного значения в массиве.",
  },
  {
    type: "selectionTask",
    text: "Написать функционал поиска возрастающей последовательности максимальной длины в исходном массиве.",
  }
];

const $contextBox = document.querySelector(".main__content-box");
const links = document.querySelectorAll(".task-link");
var identify = "";

links.forEach(element => {
  element.addEventListener("click", displayTask);
});


function displayTask() {

  identify = this.getAttribute("id");
  let html = "";

  task.forEach(block => {
    if (block.type === identify) {

      html = `
    <div class="main__description">${block.text}</div>

    <div class="main__content-body">

    <div class="main__content-inputInfo">
        <p class="whatToDo">Введите массив чисел (в качестве разделителя используйте запятую)</p>
        <div class="main__content-inputArea">
            <input type="text" class="array-input" id="input" placeholder="insert array here" value="">
            <input type="button" class="button" value="Загрузить"></input>
        </div>
        
    </div>
      <div class="main__content-solution">
        <div id="main__solution-result">
          
        </div>
        
      </div>
  </div>`
    }
  });

  $contextBox.innerHTML = "";
  $contextBox.insertAdjacentHTML("beforeend", html);

  let submitBtn = document.querySelector(".button");
  submitBtn.addEventListener("click", getSolution);
}









function getSolution() {
  var userInput = document.querySelector("#input");
  var array = userInput.value;
  array = array.split(",").map(Number);
  let result = document.getElementById("main__solution-result");

  switch (identify) {
    case "subSum_N":
      result.innerHTML = (`<div class="result-text">Максимальная сумма непрерывного подмассива равна: </div><div class="result">${getMaxSubSumFast(array)}</div>`)
      break;

    case "subSum_N2":
      result.innerHTML = (`<div class="result-text">Максимальная сумма непрерывного подмассива равна: </div><div class="result">${getMaxSubSum(array)}</div>`)
      break;

    case "search":
      result.innerHTML = (`<div class="result-text"><ul><li>Максимальное значение: ${getMaxValue(array)}</li><li>Минимальное значение: ${getMinValue(array)}</li></ul></div>`)
      break;
  
    case "selectionTask":
      result.innerHTML = ("")
      break;

      default:
      break;
  }
  if (identify === "") {
    
  } else {
    
  }



 
  console.log(result);

}




function getMaxSubSum(array) {
  let maxSum = 0; // если элементов не будет - возвращаем 0

  for (let i = 0; i < array.length; i++) {
    let sumFixedStart = 0;
    for (let j = i; j < array.length; j++) {
      sumFixedStart += array[j];
      maxSum = Math.max(maxSum, sumFixedStart);
    }
  }

  return maxSum;
}


function getMaxSubSumFast(array) {
  let maxSum = 0;
  let partialSum = 0;

  for (let item of array) { // для каждого элемента массива
    partialSum += item; // добавляем значение элемента к partialSum
    maxSum = Math.max(maxSum, partialSum); // запоминаем максимум на данный момент
    if (partialSum < 0) partialSum = 0; // ноль если отрицательное
  }

  return maxSum;
}

function getMaxValue(array) {
  let maxValue = array[0];

  for (let index = 0; index < array.length; index++) {
    if (maxValue < array[index]) {
      maxValue = array[index]
    }
  }

  return maxValue;
}

function getMinValue(array) {
  let minValue = array[0];

  for (let index = 0; index < array.length; index++) {

    if (minValue > array[index]) {
      maxValue = array[index]
    }
  }

  return minValue;
}

function getMedianValue(array) {
  let medianValue;
  Array.prototype.sort(array);
  if ((array.length%2) === 0) {
    medianValue = array[((array.length/2 + 1) + array.length/2)/2]
  } else {
    medianValue = array[(array.length/2) + 1];
  }
  
  return medianValue;
}

function getIncreasingSequence(array){
  let sequence = [];
  
}