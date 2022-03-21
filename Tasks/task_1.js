
button = document.getElementById("button");
button.addEventListener("click", ArrayProcessingFunction);
button.setAttribute("hidden", true);

checkBox = document.getElementsByClassName("checkB");
for (let i = 0; i < checkBox.length; i++) {
  checkBox[i].addEventListener("click", getCurrentOption);
}

function ArrayProcessingFunction() {

  userInput = document.getElementById("input").value;
  
  let regexp = /^(-?((\d+\,)|(\d+\.\d+\,)))+(-?((\d+)|(\d+\.\d+)))$/;

  if (regexp.test(userInput)) {
    arrayProcessingObj.forEach(item => {
      if (item.id === currentOption) {
        contentHolder = document.querySelector("#content-holder");
        contentHolder.innerHTML = `<p  class="display-text">The processing of the array of numbers you entered is done using ${item.name}</p></p>
    <p class="display-text"> Result: ${item.func(userInput)}</p>`;
      }
    });
  } else {
    alert("Incorrect input! Try again.")
  }
};
