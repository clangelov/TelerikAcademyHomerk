/* Problem 2. Divisible by 7 and 5

Write a boolean expression that checks for given integer if it can be divided (without remainder)
by 7 and 5 in the same time.

Examples:
n	Divided by 7 and 5?
3	false
0	true
5	false
7	false
35	true
140	true
*/

var number = [3, 0, 5, 7, 35, 140], //Feel free to add or remove numbers
    numLength = number.length,
    i;

for (i = 0; i < numLength; i+=1) {
    if (number[i] % 35 === 0) {
        console.log('The number ' + number[i] + ' can be divided by 7 and 5 at the same time');
    } else {
        console.log('The number ' + number[i] + ' can NOT be divided by 7 and 5 at the same time');
    }
}

