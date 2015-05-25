/* PronumBlem 2. Multiplication Sign

Write a script that shows the sign (+, - or 0) of the product of three real numnumBers, without calculating it.
Use a sequence of if operators.

Examples:
a	b	    c	    result
5	2	    2	    +
-2	-2	    1	    +
-2	4	    3	    -
0	-2.5	4	    0
-1	-0.5	-5.1	-
*/

//Feel free to add or remove numbers, but there must be an equal number of numbers in numA, numB and numC
var numA = [5, -2, -2, 0, -1],
    numB = [2, -2, 4, -2.5, -0.5],
    numC = [2, 1, 3, 4, -5.1],
    loops = numA.length,
    i;

for (i = 0; i < loops; i += 1) {

    findAndPrintResult(numA[i], numB[i], numC[i]);
}

function findAndPrintResult(numA, numB, numC) {

    if (!numA || !numB || !numC) {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in 0');
    } else if ((numA < 0) && (numB < 0) && (numC < 0)) {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in "-"');
    } else if ((numA > 0) && ((numB < 0) ^ (numC < 0))) {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in "-"');
    } else if ((numB > 0) && ((numA < 0) ^ (numC < 0))) {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in "-"');
    } else if ((numC > 0) && ((numA < 0) ^ (numB < 0))) {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in "-"');
    } else {
        console.log(numA + ' * ' + numB + ' * ' + numC + ' results in "+"');
    }
}