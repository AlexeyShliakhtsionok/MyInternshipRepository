const task = [
  {
    type: "subSum_N",
    text: "Найти непрерывный подмассив arr, сумма элементов которого максимальна. Функция должна возвращать только эту сумму. Сложность O(n)"
  },
  {
    type: "subSum_N2",
    text: "Найти непрерывный подмассив arr, сумма элементов которого максимальна. Функция должна возвращать только эту сумму. Сложность O(n^2)"
  },
  {
    type: "search",
    text: "Написать функционал поиска минимального, максимального, медианного значения в массиве."
    
  },
  {
    type: "selectionTask",
    text: "Написать функционал поиска возрастающей последовательности максимальной длины в исходном массиве."
  }
];

const $contextBox = document.querySelector(".main__content-box");

const links = document.querySelectorAll(".task-link");

links.forEach(element => {
  element.addEventListener("click", displayDescription);
});

function displayDescription() {
  let identify = this.getAttribute("id");
  let html = "";
  task.forEach(block => {
    if (block.type === identify) {

      html = `
    <div class="main__description">${block.text}</div>
    `
    }
  });

  $contextBox.innerHTML="",
  $contextBox.insertAdjacentHTML("beforeend", html)
}



























// function getMaxSubSum(array) {
//     let maxSum = 0; // если элементов не будет - возвращаем 0

//     for (let i = 0; i < array.length; i++) {
//       let sumFixedStart = 0;
//       for (let j = i; j < array.length; j++) {
//         sumFixedStart += array[j];
//         maxSum = Math.max(maxSum, sumFixedStart);
//       }
//     }

//     return maxSum;
//   }


//   function getMaxSubSumFast(array) {
//     let maxSum = 0;
//     let partialSum = 0;

//     for (let item of array) { // для каждого элемента массива
//       partialSum += item; // добавляем значение элемента к partialSum
//       maxSum = Math.max(maxSum, partialSum); // запоминаем максимум на данный момент
//       if (partialSum < 0) partialSum = 0; // ноль если отрицательное
//     }

//     return maxSum;
//   }