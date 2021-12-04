
button = document.getElementById("button");
button.addEventListener("click", getUserInput);

function getUserInput() {
    var userInput = document.getElementById("input").value;
    var result = stringAnalyze(userInput);

    let temporaryArray = [];
    for (let i = 0; i < result[2].length; i++) {
        for (let j = 0; j < result[2][i].length; j++) {
            temporaryArray.push(result[2][i].join());
        }
    }
    for (let i = 0; i < temporaryArray.length; i++) {
        result[1].push(temporaryArray[i]);
    }

    contentHolder = document.querySelector("#content-holder");
    contentHolder.innerHTML = `<p>The result of entered expression is: ${result[0]}</p><p>Operations fetched from the cache:</p><p>${result[1].join("<p></p>")}</p>`;
}
