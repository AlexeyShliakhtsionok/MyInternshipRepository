userInput = "";

checkBox = document.getElementsByClassName("checkB");
for (let i = 0; i < checkBox.length; i++) {
    checkBox[i].addEventListener("click", getCurrentOption);
}

button = document.getElementById("button");
button.addEventListener("click", checkTheString);
button.setAttribute("hidden", true);

function checkTheString() {
    let notation = new Notations();

    userInput = document.getElementById("input").value;

    let decimalResult;
    let binaryResult;
    let octalResult;
    let hexadecimalResult;

    switch (currentOption) {
        case ("binary"):
            if (regExpBin.test(userInput)) {
                decimalResult = notation.ConvertBinToDec(userInput);
                binaryResult = userInput;
                octalResult = notation.ConvertDecToOct(decimalResult);
                hexadecimalResult = notation.ConvertDecToHex(decimalResult);
            } else {
                alert("Incorrect input!");
            }
            break;

        case ("decimal"):
            if (regExpDec.test(userInput)) {
                decimalResult = userInput;
                binaryResult = notation.ConvertDecToBin(decimalResult);
                octalResult = notation.ConvertDecToOct(decimalResult);
                hexadecimalResult = notation.ConvertDecToHex(decimalResult);
            } else {
                alert("Incorrect input!");
            }
            break;

        case ("octal"):
            if (regExpOct.test(userInput)) {
                octalResult = userInput;
                decimalResult = notation.ConvertOctToDec(octalResult);
                binaryResult = notation.ConvertDecToBin(decimalResult);
                hexadecimalResult = notation.ConvertDecToHex(decimalResult);
            } else {
                alert("Incorrect input!");
            }
            break;

        case ("hexadecimal"):
            if (regExpHex.test(userInput)) {
                hexadecimalResult = userInput;
                decimalResult = notation.ConvertHexToDec(hexadecimalResult);
                octalResult = notation.ConvertDecToOct(decimalResult);;
                binaryResult = notation.ConvertDecToBin(decimalResult);

            } else {
                alert("Incorrect input!");
            }
            break;
    }

    contentHolder = document.querySelector("#content-holder");
    contentHolder.innerHTML = (
        `<ul class="result-window">
                    <il><p class="result">Binary notation: ${binaryResult}</p></il>
                    <il><p class="result">Octal notation: ${octalResult}</p></il>
                    <il><p class="result">Decimal notation: ${decimalResult}</p></il>
                    <il><p class="result">Hexadecimal notation: ${hexadecimalResult}</p></il>
            </ul>`);
}
