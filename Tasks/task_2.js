button = document.getElementById("button")
button.addEventListener("click", displayDate)

function displayDate() {
    userInput = document.getElementById("input").value;
    let status = [];

    processingObj.forEach(item => {

        if (item.regExp.test(userInput)) {
            status.push(item.regExp.test(userInput))
            let content = item.func(userInput);
            contentHolder = document.querySelector("#content-holder");
            contentHolder.innerHTML = `${content}`;
        }
    });
    status = status.join();
    (status === "") ? alert("Incorrect input! Try again."): "";
}
