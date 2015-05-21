/* Problem 8. Trapezoid area

Write an expression that calculates trapezoid's area by given sides a and b and height h.

Examples:
a	    b	    h	    area
5	    7	    12	    72
2	    1	    33	    49.5
8.5	    4.3	    2.7	    17.28
100	    200	    300	    45000
0.222	0.333	0.555	0.1540125
*/

//Feel free to add or remove numbers, but there must be an equal number of numbers in sideA, sideB and height
var sideA = [5, 2, 8.5, 100, 0.222],
    sideB = [7, 1, 4.3, 200, 0.333],
    height = [12, 33, 2.7, 300, 0.555],
    loops = sideA.length,
    i;

for (i = 0; i < loops; i += 1) {
    if (sideA[i] !== undefined && sideB[i] !== undefined && height[i] !== undefined) {
        console.log('Trapezoid with A = ' + sideA[i] + ', B = ' + sideB[i] +
            ' and heigth = ' + height[i] + ' has an area of ' + ((sideA[i] + sideB[i]) / 2) * height[i]);
    }
}