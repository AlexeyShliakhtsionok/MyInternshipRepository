button = document.getElementById("button");
button.addEventListener("click", stringProcessing);
button.setAttribute("hidden", true);

checkBox = document.getElementsByClassName("checkB");
for (let i = 0; i < checkBox.length; i++) {
    checkBox[i].addEventListener("click", getCurrentOption);
}

function stringProcessing() {

    const inputElement1 = document.querySelector("#stringLenght");
    const inputElement2 = document.querySelector("#stringNumber");
    inputElement1.classList.remove("incorrectInput");
    inputElement2.classList.remove("incorrectInput");

    let regExp = /^[0-9]+$/;
    var stringLenght = document.getElementById("stringLenght").value;
    var stringNumber = document.getElementById("stringNumber").value;

    (!regExp.test(stringLenght) && stringLenght !== "") ? inputElement1.classList.add("incorrectInput"): "";

    (!regExp.test(stringNumber) && stringNumber !== "") ? inputElement2.classList.add("incorrectInput"): "";

    stringLenght = Number(stringLenght);
    stringNumber = Number(stringNumber);
    userInput = document.getElementById("input").value;

    let stringNumberRegexp = /^([0-9]{1}|[0-1]([0-9]){1,5})$/;
    stringNumberState = stringNumberRegexp.test(stringNumber);

    if (!stringNumberState) {
        return alert("Incorrect input! Enter the value between 1 and 200000");
    }

    switch (currentOption) {
        case "wordTransfer":

            userInput = userInput.split(/\s/gm);

            if (stringLenght !== 0) {
                for (let i = 0; i < userInput.length; i++) {
                    let word;
                    word = userInput[i];
                    word = word.substr(0, stringLenght);
                    userInput[i] = word;
                }
            };

            (stringNumber !== 0) ? userInput.length = stringNumber: "";

            userInput = userInput.join(" ");
            userInput = userInput.replace(/\s/g, "</p> <p>");

            break;

        case "charTransfer":
            userInput = userInput.split("");
            for (let i = 0; i < userInput.length; i++) {
                userInput[i] = `<p>${userInput[i]}</p>`;
            }

            (stringNumber !== 0) ? userInput.length = stringNumber: "";

            userInput = userInput.join("");
            userInput = userInput.replace(/\s/gm, "_")

            break;

        case "sentenceTransfer":

            userInput = userInput.replace(/([\!\?]\s|(\.)+\s)/g, "$1|");

            userInput = userInput.split("|");


            if (stringLenght !== 0) {
                for (let i = 0; i < userInput.length; i++) {
                    let sentence;
                    sentence = userInput[i];
                    sentence = sentence.substr(0, stringLenght);
                    userInput[i] = sentence;
                }
            };

            (stringNumber !== 0) ? userInput.length = stringNumber: "";

            userInput = userInput.join("</p><p>");
            userInput = `<p>${userInput}</p>`;

            break;

        default:
            break;
    }
    contentHolder = document.querySelector("#content-holder");
    contentHolder.innerHTML = `${userInput}`;
}
