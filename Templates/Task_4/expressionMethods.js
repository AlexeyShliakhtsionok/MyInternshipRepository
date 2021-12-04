var cacheInfo = [];
var recursionCache = [];

function stringAnalyze(string) {

  let regExp = /^[0-9\/\*\+\.\,\(\)\-]+$/igm; // Проверка входной строки

  if (regExp.test(string)) { // Если все ок, то...

    let regExpBrackets = /\([0-9\.\,\+\*\/\-]+\)/; // Определяем регексп для скобок
    if (!regExpBrackets.exec(string)) { // Выполняем проверку на наличие скобок
      var result = expressionCalculating(string); // Если в результате проверки false - вычисляем значение

      result.push(recursionCache);
      recursionCache = [];
      return result;

    } else {
      let pathOfString = regExpBrackets.exec(string); // Выделяем элементарное выражение в скобках
      let intermediateResult = expressionCalculating(pathOfString.join(""));

      recursionCache.push(intermediateResult[1]); 

      intermediateResult = intermediateResult[0];
      string = string.replace(pathOfString[0], `${intermediateResult}`); // Заменяем во входящей строке элементарную скобку на значение

      return stringAnalyze(string); // Запускаем метод еще раз
    }
  } else {
    alert("incorrect input!"); // Если не прошли проверку инпута, то алерт
  }
}

function expressionCalculating(string) {
  cacheInfo = []; //подумать
  
  let array = arrayCreating(string);

  let result = arrayProcessing(array);

  return result;
}

function arrayCreating(string) { // Форматирование строки исходя из всех возможных комбинаций операндов
  string = string.replace(/\,/igm, "."); // Замена запятых на точки для корректного вычисления десятичных чисел
  string = string.replace(/\*/igm, ` * `); // Простановка пробелов для последующего формирования массива
  string = string.replace(/\+/igm, ` + `); //
  string = string.replace(/\//igm, ` / `); //
  string = string.replace(/\-/igm, ` - `); //-----------------------------------------------------------
  string = string.replace(/^\(\s\-\s|^\s\-\s/igm, `! `); // Замена "-", не находящегося между двумя операндами
  string = string.replace(/\*\s\s\-/igm, `* !`); // Форматирование после открытия скобок, когда первое число является отрицательным
  string = string.replace(/\/\s\s\-/igm, `/ !`); //
  string = string.replace(/\+\s\s\-/igm, `+ !`); // 
  string = string.replace(/\s\-\s\s\-\s/igm, ` + `); //------------------------------------------------
  string = string.replace(/\(/igm, ``); // Удаление открывающей скобки
  string = string.replace(/\)/igm, ``); // Удаление закрывающей скобки
  let array = string.split(" "); // Формирование массива по разделителю
  array = array.reverse(); // Инверсия массива для соблюдения последовательности вычислений и реализации прохода по массиву справа налево с возможностью удаления индексов в текущем цикле
  return array;
}

function arrayProcessing(array) {

  for (let i = array.length - 1; i >= 0; i--) {
    if (array[i] === "!") {
      array[i - 1] = 0 - Number(array[i - 1]);
      array.splice(i, 1);
    }
  }

  for (let i = array.length - 1; i >= 0; i--) {
    if (array[i] === "*") {
      let resultArr = mMultiplication(array[i + 1], array[i - 1]);
      array[i - 1] = resultArr[0];
      array.splice(i, 2);
      (resultArr.length > 1) ? cacheInfo.push(resultArr[1]): "";
      resultArr = [];
    }
    if (array[i] === "/") {
      let resultArr = mDivision(array[i + 1], array[i - 1]);
      array[i - 1] = resultArr[0];
      array.splice(i, 2);
      (resultArr.length > 1) ? cacheInfo.push(resultArr[1]): "";
      resultArr = [];
    }
  }

  for (let i = array.length - 1; i >= 0; i--) {
    if (array[i] === "+") {
      let resultArr = mAddition(array[i + 1], array[i - 1]);
      array[i - 1] = resultArr[0];
      array.splice(i, 2);
      (resultArr.length > 1) ? cacheInfo.push(resultArr[1]): "";
      resultArr = [];
    }
    if (array[i] === "-") {
      let resultArr = mSubtraction(array[i + 1], array[i - 1]);
      array[i - 1] = resultArr[0];
      array.splice(i, 2);
      (resultArr.length > 1) ? cacheInfo.push(resultArr[1]): "";
      resultArr = [];
    }
  }

  let computation = array[0];
  let result = [];
  result.push(computation);
  result.push(cacheInfo);

  return result;
}