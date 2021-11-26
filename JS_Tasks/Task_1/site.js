// Объект обработки массивов
const arrayProcessingObj = [{
    name: "SubSumm task",
    id: "subSum_N",
    func: (array) => {
      var s_timeN = performance.now()*1000;
      array = array.split(",").map(Number);
      let maxSum = 0;
      for (let i = 0; i < array.length; i++) {
        let sumFixedStart = 0;
        for (let j = i; j < array.length; j++) {
          sumFixedStart += array[j];
          maxSum = Math.max(maxSum, sumFixedStart);
        }
      };
      var e_timeN = performance.now()*1000 - s_timeN;

      return `сумма: ${maxSum}, время выполнения: ${e_timeN} мкс.`;
    }

  },
  {
    name: "SubSumm task_N2",
    id: "subSum_N2",
    func: (array) => {
      var s_timeN2 = performance.now()*1000;
      array = array.split(",").map(Number);
      let maxSum = 0;
      let partialSum = 0;

      for (let item of array) {
        partialSum += item;
        maxSum = Math.max(maxSum, partialSum);
        if (partialSum < 0) partialSum = 0;
      }


      var e_timeN2 = performance.now()*1000 - s_timeN2;
      
      return `сумма: ${maxSum}, время выполнения: ${e_timeN2}  мкс.`;
    }

  },
  {
    name: "Search task",
    id: "search",
    func: (array) => {

      array = array.split(",").map(Number);

      let maxValue = array[0];
      for (let index = 0; index < array.length; index++) {
        if (maxValue < array[index]) {
          maxValue = array[index]
        }
      }

      let minValue = array[0];
      for (let index = 0; index < array.length; index++) {

        if (minValue > array[index]) {
          minValue = array[index]
        }
      }

      var half = Math.floor(array.length / 2);
      array.sort(function (a, b) {
        return a - b;
      });

      if (array.length % 2) {
        return `Максимальное значение: ${maxValue} Минимальное значение: ${minValue}; Медианное значение: ${array[half]}`;
      } else {
        return `Максимальное значение: ${maxValue} Минимальное значение: ${minValue}; Медианное значение: ${(array[half] + array[half] - 1) / 2}`;
      }
    }
   },
  {
    name: "Selection task",
    id: "selectionTask",
    func: (array) => {
      array = array.split(",").map(Number);
      let sequence = new Array;
      let maxSequence = new Array;
      sequence.push(array[0]);

      for (let index = 1; index < array.length; index++) {
        if (array[index] < array[index - 1]) {
          if (maxSequence.length < sequence.length) {
            maxSequence = sequence.slice()
          };
          sequence = [];
          sequence.push(array[index]);
        } else {
          sequence.push(array[index]);
        }
      }
      if (sequence.length > maxSequence.length) {
        maxSequence = sequence.slice()
      };

      return maxSequence;
    }
  }
];

// Переменная - объект рендеринга
var contentHolder = document.getElementById("content-holder");

// Ивент на кнопку загрузки и изначальное ее сокрытие
const button = document.getElementById("button");
button.addEventListener("click", ArrayProcessingFunction);
button.setAttribute("hidden", true);

// Переменная и добавление ивентов к checkBox'ам (опциям)
const checkBox = document.getElementsByClassName("checkB");
for (let i = 0; i < checkBox.length; i++) {
  checkBox[i].addEventListener("click", getCurrentOption);
}

// Переменная под выбранную опцию
var currentOption;
// Переменная для последующего хранения пользовательского ввода
var userInput;

// Функция получения выбранной опции, блокировки множественного выбора и активации кнопки загрузки
function getCurrentOption() {
  currentOption = this.getAttribute("id");
  (this.checked !== true) ? button.setAttribute("hidden", true): button.removeAttribute("hidden");

  if (this.checked === true) {
    for (let i = 0; i < checkBox.length; i++) {
      (checkBox[i].checked === false) ? checkBox[i].disabled = true: "";
    }
  } else {
    currentOption = "";
    for (let i = 0; i < checkBox.length; i++) {
      checkBox[i].disabled = false;
    }
  }
}


function ArrayProcessingFunction() {
  // Получение пользовательского ввода
  userInput = document.getElementById("input").value;

  var regexp = /^[0-9\,\.]+$/;
  if (regexp.test(userInput)){
    arrayProcessingObj.forEach(item => {
      if (item.id === currentOption) {
        contentHolder.innerHTML = `<p>Обработка введенного Вами массива чисел (${userInput}) выполнена при помощи ${item.name}.</p>
      <p> Результат: ${item.func(userInput)}</p>`;
      }
    });
  } else {
    alert("Некорректный ввод!")
  } 
};