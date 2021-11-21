
// Описание тасков и их тип (id)
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

// Создание объекта класса ArrayFunctions, содержащего методы
const arrClass = new ArrayFunctions();

// Переменная для хранения элемента html, в которые будет рендериться контент
const $contextBox = document.querySelector(".main__content-box");

// Переменная для хранения ссылок из хидера
const links = document.querySelectorAll(".task-link");

// Переменная для хранения id активной ссылки
var identificator = "";

// Эвенты на ссылки
links.forEach(element => {
  element.addEventListener("click", displayTask);
});

// Функция отображения задачи
function displayTask() {

  identificator = this.getAttribute("id");
  let html = "";

  task.forEach(block => {
    if (block.type === identificator) {

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

// Функция получения результата
function getSolution() {
  var userInput = document.querySelector("#input");
  var array = userInput.value;
  array = array.split(",").map(Number);
  let result = document.getElementById("main__solution-result");

  switch (identificator) {
    case "subSum_N":
      result.innerHTML = (`<div class="result-text">Максимальная сумма непрерывного подмассива равна: </div><div class="result">${arrClass.getMaxSubSumFast(array)}</div>`)
      break;

    case "subSum_N2":
      result.innerHTML = (`<div class="result-text">Максимальная сумма непрерывного подмассива равна: </div><div class="result">${arrClass.getMaxSubSum(array)}</div>`)
      break;

    case "search":
      result.innerHTML = (`<div class="result-text"><ul><li class="result-item">Максимальное значение: ${arrClass.getMaxValue(array)}</li><li class="result-item">Минимальное значение: ${getMinValue(array)}</li><li class="result-item">Медианное значение: ${getMedianValue(array)}</li></ul></div>`)
      break;

    case "selectionTask":
      result.innerHTML = (`<div class="result-text">Наибольшая возрастающая последовательность: </div><div class="result">${arrClass.getIncreasingSequence(array)}</div>`)
      break;

    default:
      break;
  }

}