button = document.getElementById("button");
button.addEventListener("click", ArrayProcessing);
button.setAttribute("hidden", true);

checkBox = document.getElementsByClassName("checkB");
for (let i = 0; i < checkBox.length; i++) {
  checkBox[i].addEventListener("click", getCurrentOption);
}

function ArrayProcessing() {

  let regexp = /^(-?((\d+\,)|(\d+\.\d+\,)))+(-?((\d+)|(\d+\.\d+)))$/;
  userInput = document.getElementById("input").value;

  if (regexp.test(userInput)) {
    arraySortObj.forEach(item => {
      if (item.id === currentOption) {
        contentHolder = document.querySelector("#content-holder");
        contentHolder.innerHTML = `<p class="display-text">Sorting of the array of numbers you entered is done using ${item.name}.</p>
      <p class="display-text"> Result: <p class="display-text">${item.func(userInput)}</p></p>`;
      }
    })
  } else {
    alert("Incorrect input!")
  }

};
