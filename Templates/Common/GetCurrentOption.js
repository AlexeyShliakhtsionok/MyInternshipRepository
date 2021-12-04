
var checkBox;
var currentOption;

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