const regExpBin = /^(0|1)+$/;
const regExpDec = /^[0-9]+$/;
const regExpOct = /^([0-7]|[0-7]+)$/;
const regExpHex = /^0x[0-9a-f]+$/i;

class Notations{

    ConvertBinToDec(userInput) {

        let array = userInput.split("").map(Number);
        array.reverse();
        let result = 0;
        for (let i = 0; i < array.length; i++) {
            (array[i] === 1) ? result += Math.pow(2, i): "";
        }
        return result;
    }

    ConvertDecToBin(userInput) {

        let number = Number(userInput);
        let binaryNumber = [];

        do {
            binaryNumber.push(number % 2);
            number /= 2;
            number = Math.trunc(number);

        } while (number > 1);

        binaryNumber.push(number);
        binaryNumber.reverse();
        binaryNumber = binaryNumber.join("");

        return binaryNumber;
    }

    ConvertDecToOct(userInput) {
        let number = Number(userInput);
        let octalNumber = [];

        do {
            octalNumber.push(number % 8);
            number /= 8;
            number = Math.trunc(number);
        } while ((number / 8) > 1);

        if (number === 8) {
            octalNumber.push(0);
            octalNumber.push(1);
        } else {
            octalNumber.push(number)
        }

        octalNumber.reverse();
        octalNumber = octalNumber.join("");

        return octalNumber;
    }

    ConvertOctToDec(userInput) {

        let array = userInput.split("").map(Number);
        array.reverse();
        let result = 0;

        for (let i = 0; i < array.length; i++) {
            result += array[i] * Math.pow(8, i);
        }
        return result;
    }

    ConvertDecToHex(userInput) {
        let number = Number(userInput);
        let hexNumber = [];

        do {
            hexNumber.push(number % 16);
            number /= 16;
            number = Math.trunc(number);
        } while ((number / 16) > 1);

        if (number === 16) {
            hexNumber.push(0);
            hexNumber.push(1);
        } else {
            hexNumber.push(number)
        }

        hexNumber.reverse();

        for (let i = 0; i < hexNumber.length; i++) {
            switch (hexNumber[i]) {
                case 10:
                    hexNumber[i] = "A";
                    break;
                case 11:
                    hexNumber[i] = "B";
                    break;
                case 12:
                    hexNumber[i] = "C";
                    break;
                case 13:
                    hexNumber[i] = "D";
                    break;
                case 14:
                    hexNumber[i] = "E";
                    break;
                case 15:
                    hexNumber[i] = "F";
                    break;

                default:
                    break;
            }
        }

        hexNumber = hexNumber.join("");

        return hexNumber;
    }

    ConvertHexToDec(userInput) {
        let result = parseInt(userInput, 16);
        return result;
    }


}