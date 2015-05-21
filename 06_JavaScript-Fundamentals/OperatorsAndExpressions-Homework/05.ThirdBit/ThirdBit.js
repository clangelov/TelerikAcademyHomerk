/* Problem 5. Third bit

Write a boolean expression for finding if the bit #3 (counting from 0) of a given integer.
The bits are counted from right to left, starting from bit #0.
The result of the expression should be either 1 or 0.

Examples:
n	    binary representation	bit #3
5	    00000000 00000101	    0
8	    00000000 00001000	    1
0	    00000000 00000000	    0
15	    00000000 00001111	    1
5343	00010100 11011111	    1
62241	11110011 00100001       0
*/

var number = [5, 8, 0, 15, 5343, 62241], //Feel free to add or remove numbers
    numLength = number.length,
    position = 3,
    mask = 1 << position,
    i,
    numberAndMask,
    bit;

for (i = 0; i < numLength; i += 1) {
    numberAndMask = number[i] & mask;
    bit = numberAndMask >> position;
    console.log('Bit #3 in ' + number[i] + ' with binary representation ' + number[i].toString(2) + ' is ' + bit);
}