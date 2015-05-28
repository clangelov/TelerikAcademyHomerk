/* Problem 2. Reverse number

Write a function that reverses the digits of given decimal number.

Example:
input	output
256	    652
123.45	54.321
*/

var array = [256, 123.45, 6000, 5001, 3.14],
    loops = array.length,
    number,
    reversed,
    i;

for (i = 0; i < loops; i += 1) {

    console.log('The number ' + array[i] + ' reversed is ' + reverseNumber(array[i]));
}

function reverseNumber(number) {

    number = number.toString();
    reversed = '';

    for (i = number.length - 1; i >= 0; i -= 1) {
        reversed += number[i];
    }

    return reversed * 1;
}