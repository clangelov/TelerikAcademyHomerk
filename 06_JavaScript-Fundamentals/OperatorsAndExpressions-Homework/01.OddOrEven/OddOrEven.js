/* Problem 1. Odd or Even

Write an expression that checks if given integer is odd or even.

Examples:
n	Odd?
3	true
2	false
-2	false
-1	true
0	false
*/

var number = [3, 2, -2, -1, 0], //Feel free to add or remove numbers 
    numLength = number.length,
    i;

for (i = 0; i < number.length; i+=1) {
    if (number[i] % 2 === 0) {
        console.log('The number ' + number[i] + ' is even');
    } else {
        console.log('The number ' + number[i] + ' is odd');
    }
}