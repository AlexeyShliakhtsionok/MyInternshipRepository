var mainHeaderItems = document.getElementsByClassName("taskLink");

const arrayProcessingObj = [{
        name: "SubSumm task",
        id: "subSum_N",
        func: (array) => {
            var start_timeN = performance.now() * 1000;
            array = array.split(",").map(Number);
            let maxSum = 0;
            for (let i = 0; i < array.length; i++) {
                let sumFixedStart = 0;
                for (let j = i; j < array.length; j++) {
                    sumFixedStart += array[j];
                    maxSum = Math.max(maxSum, sumFixedStart);
                }
            };
            var end_timeN = performance.now() * 1000 - start_timeN;

            return `<p class="display-text">sum: ${maxSum}, lead time: ${end_timeN} μs.</p>`;
        }
    },
    {
        name: "SubSumm task_N2",
        id: "subSum_N2",
        func: (array) => {
            var startTimeN2 = performance.now() * 1000;
            array = array.split(",").map(Number);
            let maxSum = 0;
            let partialSum = 0;

            for (let item of array) {
                partialSum += item;
                maxSum = Math.max(maxSum, partialSum);
                if (partialSum < 0) partialSum = 0;
            }

            var processingTimeN2 = performance.now() * 1000 - startTimeN2;

            return `<p class="display-text">sum: ${maxSum}, lead time: ${processingTimeN2}  μs.</p>`;
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
                return `<p class="display-text">Max value: ${maxValue} Min value: ${minValue}; Median value: ${array[half]}</p>`;
            } else {
                return `<p class="display-text">Max value: ${maxValue} Min value: ${minValue}; Median value: ${(array[half] + array[half] - 1) / 2}</p>`;
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

const processingObj = [{
        regExp: /^(?:\d{4}[\,\.\s\/\-](?:(?:(?:(?:0[13578]|1[02])[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|3[01]))|(?:(?:0[469]|11)[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|30))|(?:02[\,\.\s\/\-](?:0[1-9]|1[0-9]|2[0-8]))))|(?:(?:\d{2}(?:0[48]|[2468][048]|[13579][26]))|(?:(?:[02468][048])|[13579][26])00)[\,\.\s\/\-]02[\,\.\s\/\-]29)$/,
        func: (string) => {
            let year = string.substr(0, 4);
            let month = string.substr(5, 2);
            let day = string.substr(8, 2);
            var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
            return `${year} ${months[Number(month)-1]} ${day}`;
        }
    },
    {
        regExp: /^wideDateFormat:(?:\d{4}[\,\.\s\/\-](?:(?:(?:(?:0[13578]|1[02])[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|3[01]))|(?:(?:0[469]|11)[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|30))|(?:02[\,\.\s\/\-](?:0[1-9]|1[0-9]|2[0-8]))))|(?:(?:\d{2}(?:0[48]|[2468][048]|[13579][26]))|(?:(?:[02468][048])|[13579][26])00)[\,\.\s\/\-]02[\,\.\s\/\-]29)$/i,
        func: (string) => {
            let dateStr = string.substr(15);
            let dateRegexp = /^(000|00)/;
            if (dateRegexp.test(dateStr)) {

                let year = dateStr.substr(0, 4);
                let month = dateStr.substr(5, 2);
                let day = dateStr.substr(8, 2);
                year = Number(year);
                month = Number(month);
                day = Number(day);
                let date = new Date();

                date = date.setFullYear(year, month - 1, day);

                return new Date(date);

            } else {
                let options = {
                    weekday: "long",
                    era: "short",
                    year: "numeric",
                    month: "long",
                    day: "numeric"
                };
                let date = new Date(dateStr);
                return date.toLocaleDateString("en-US", options);
            }
        }
    },
    {
        regExp: /^fromNow:(?:\d{4}[\,\.\s\/\-](?:(?:(?:(?:0[13578]|1[02])[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|3[01]))|(?:(?:0[469]|11)[\,\.\s\/\-](?:0[1-9]|[1-2][0-9]|30))|(?:02[\,\.\s\/\-](?:0[1-9]|1[0-9]|2[0-8]))))|(?:(?:\d{2}(?:0[48]|[2468][048]|[13579][26]))|(?:(?:[02468][048])|[13579][26])00)[\,\.\s\/\-]02[\,\.\s\/\-]29)$/i,
        func: (string) => {
            let dateStr = string.substr(8);

            let dateRegexp = /^(000|00)/;
            if (dateRegexp.test(dateStr)) {

                let year = dateStr.substr(0, 4);
                let month = dateStr.substr(5, 2);
                let day = dateStr.substr(8, 2);
                year = Number(year);
                month = Number(month);
                day = Number(day);
                let currentTime = new Date();
                let elapsedTime = new Date();
                elapsedTime = elapsedTime.setFullYear(year, month - 1, day);
                let elapsedDays = currentTime - elapsedTime;
                elapsedDays = Math.trunc(elapsedDays / 86400000);

                return `${elapsedDays} day(s) from this moment.`;
            } else {

                let elapsedTime = new Date() - new Date(dateStr);
                let elapsedDays = Math.trunc(elapsedTime / 86400000);

                return `${elapsedDays} day(s) from this moment.`;
            }
        }
    }
];

const arraySortObj = [{
        name: "Bubble sort",
        id: "bubble",
        func: (array) => {
            array = array.split(",").map(Number);
            var count = array.length;
            let startTime = performance.now() * 1000;
            for (var i = 0; i < count - 1; i++) {
                for (var j = 0; j < count - 1 - i; j++) {
                    if (array[j + 1] < array[j]) {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            array = `[${array.join(", ")}]`;
            let processingTime = performance.now() * 1000 - startTime;
            return `${array} <p>Sorted in ${processingTime} μs</p>`;
        }
    },
    {
        name: "Selection sort",
        id: "selection",
        func: (array) => {
            array = array.split(",").map(Number);
            var count = array.length;
            let startTime = performance.now() * 1000;
            for (var i = 0; i < count - 1; i++) {
                var min = i;
                for (var j = i; j < count; j++) {
                    (array[j] < array[min]) ? min = j: "";
                }
                var temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
            let processingTime = performance.now() * 1000 - startTime;
            array = `[${array.join(", ")}]`;
            return `${array} <p>Sorted in ${processingTime} μs</p>`;
        }
    },
    {
        name: "Insertion sort",
        id: "insertion",
        func: (array) => {
            array = array.split(",").map(Number);
            var length = array.length;
            let startTime = performance.now() * 1000;
            for (var i = 0; i < length; i++) {
                var temp = array[i],
                    j = i - 1;
                while (j >= 0 && array[j] > temp) {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
            let processingTime = performance.now() * 1000 - startTime;
            array = `[${array.join(", ")}]`;
            return `${array} <p>Sorted in ${processingTime} μs</p>`;
        }
    },
    {
        name: "SimpleCounting sort",
        id: "counting",
        func: (array) => {
            array = array.split(",").map(Number);
            var length = array.length;
            let count = [];
            let newArray = [];
            let startTime = performance.now() * 1000;
            for (var i = 0; i < length; i++) count[i] = 0;
            for (var i = 0; i < length - 1; i++) {
                for (var j = i + 1; j < length; j++) {
                    if (array[i] < array[j]) count[j]++;
                    else count[i]++;
                }
            }
            for (var i = 0; i < length; i++) newArray[count[i]] = array[i];

            let processingTime = performance.now() * 1000 - startTime;
            newArray = `[${newArray.join(", ")}]`;
            return `${newArray} <p>Sorted in ${processingTime} μs</p>`;
        }
    }
]

var button;
var userInput;
var contentHolder;

var enteryPoint = 0;

for (let i = 0; i < mainHeaderItems.length; i++) {
    mainHeaderItems[i].addEventListener("click", displayTask, false);
}

var insertionArea = document.querySelector(".main__content-box");

var tasks = [{
        id: "arrayTask",
        scriptSrc: "Tasks/task_1.js",
        html: `<div class="main__content-body">
  <div class="main__content-inputInfo">
      <p class="text">Select operation, enter an array (separated by commas) and click "Upload"</p>

      <div class="main__options">
          <ul class="options">
              <li class="options-item">
                  <p>SubSum O(n)</p><input type="checkbox" id="subSum_N" class="checkB">
              </li>
              <li class="options-item">
                  <p>SubSum O(n<sup>2</sup>)</p><input type="checkbox" id="subSum_N2" class="checkB">
              </li>
              <li class="options-item">
                  <p>Search</p><input type="checkbox" id="search" class="checkB">
              </li>
              <li class="options-item">
                  <p>SelectionTask</p><input type="checkbox" id="selectionTask" class="checkB">
              </li>
          </ul>
      </div>

      <div class="main__content-inputArea">
          <input type="text" class="text-input" id="input" placeholder="insert array here" value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">

  </div>
</div>`
    },
    {
        id: "dateTask",
        scriptSrc: "Tasks/task_2.js",
        html: `<div class="main__content-body">

  <div class="main__content-inputInfo">
      <p class="text">Enter the date template and press "Upload"!</p>
      <div class="main__content-additionalInfo">
          Avaliable templates:
          <ul class="templates">
              <li>
                  <p>- YYYY(-./ )MM(-./ )DD = YYYY Month DD</p>
              </li>
              <li>
                  <p>- wideDateFormat:YYYY(-./ )MM(-./ )DD  = DayOfWeek YYYY Month DD</p>
              </li>
              <li>
                  <p>- fromNow:YYYY(-./ )MM(-./ )DD</p>
              </li>
          </ul>
      </div>
      <div class="main__content-inputArea">
          <input type="text" class="text-input" id="input" placeholder="insert date here" value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">

  </div>
</div>`
    },
    {
        id: "textTask",
        scriptSrc: "Tasks/task_3.js",
        html: `<div class="main__content-body">

  <div class="main__content-inputInfo">
      <p class="text">Select formatting options, enter your text and click "Upload"</p>

      <div class="main__options">
          <ul class="options">
              <li class="options-item">
                  <p>Maximum line size, char.</p><input type="text" id="stringLenght">
              </li>
              <li class="options-item">
                  <p>Maximum number of lines, pcs.</p><input type="text" id="stringNumber">
              </li>
              <li class="options-item">
                  <p>Word wrap</p><input type="checkbox" id="wordTransfer" class="checkB">
              </li>
              <li class="options-item">
                  <p>Symbol wrap</p><input type="checkbox" id="charTransfer" class="checkB">
              </li>
              <li class="options-item">
                  <p>Sentence wrap</p><input type="checkbox" id="sentenceTransfer"
                      class="checkB">
              </li>
              <li class="options-item">
                  <p>No wrap</p><input type="checkbox" id="noTransfer" class="checkB">
              </li>
          </ul>
      </div>

      <div class="main__content-inputArea">
          <input type="text" class="text-input" id="input" placeholder="insert text here" value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">

  </div>
</div>`
    },
    {
        id: "stringTask",
        scriptSrc: "Tasks/task_4.js",
        html: `<div class="main__content-body">
  <div class="main__content-inputInfo">
      <p class="text">Enter a mathematical expression and click "Upload"</p>
      <div class="main__content-inputArea">
          <input type="text" class="text-input" id="input" placeholder="insert string here" value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">
      
  </div>
</div>`
    },
    {
        id: "sortTask",
        scriptSrc: "Tasks/task_5.js",
        html: `<div class="main__content-body">
  <div class="main__content-inputInfo">
      <p class="text">Select a sorting method, enter an array and click "Upload"</p>

      <div class="main__options">
          <ul class="options">
              <li class="options-item">
                  <p>Bubble sort</p><input type="checkbox" id="bubble" class="checkB">
              </li>
              <li class="options-item">
                  <p>Selection sort</p><input type="checkbox" id="selection" class="checkB">
              </li>
              <li class="options-item">
                  <p>Insertion sort</p><input type="checkbox" id="insertion" class="checkB">
              </li>
              <li class="options-item">
                  <p>Simple counting sort</p><input type="checkbox" id="counting" class="checkB">
              </li>
          </ul>
      </div>

      <div class="main__content-inputArea">
          <input type="text" class="text-input" id="input" placeholder="insert array here" value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">

  </div>
</div>`
    },
    {
        id: "convertTask",
        scriptSrc: "Tasks/task_6.js",
        html: `<div class="main__content-body">

  <div class="main__content-inputInfo">
      <p class="text">Select the required notation system, enter the number, click "Upload" to get the result </p>
      <div class="main__notation">
          <ul class="notation">
              <li class="notation-item"><p>Binary </p><input type="checkbox" id="binary" class="checkB"></li>
              <li class="notation-item"><p>Octal </p><input type="checkbox" id="octal" class="checkB"></li>
              <li class="notation-item"><p>Decimal </p><input type="checkbox" id="decimal" class="checkB"></li>
              <li class="notation-item"><p>Hexadecimal </p><input type="checkbox" id="hexadecimal" class="checkB"></li>
          </ul>
      </div>
      
      <div class="main__content-inputArea">
          <input type="text" class="array-input" id="input" placeholder="insert number here"
              value="">
          <input type="button" id="button" value="Upload">
      </div>

  </div>
  <div class="main__content-solution" id="content-holder">

  </div>
</div>`
    }
]

function displayTask() {

    let currentTask = this.getAttribute("id");

    tasks.forEach(task => {
        if (task.id === currentTask) {
            insertionArea.innerHTML = "";
            insertionArea.insertAdjacentHTML("beforeend", task.html);
            addScript(task.scriptSrc);
        };
    });
}

function addScript(src) {
    removeScript();
    var script = document.createElement("script");
    script.async = false;
    script.src = src;
    script.setAttribute("src", src);
    document.head.appendChild(script);
    enteryPoint++;
}

function removeScript() {
    if (enteryPoint !== 0) {
        var tags = document.getElementsByTagName("script");
        tags[0].parentNode.removeChild(tags[0]);
    }
}