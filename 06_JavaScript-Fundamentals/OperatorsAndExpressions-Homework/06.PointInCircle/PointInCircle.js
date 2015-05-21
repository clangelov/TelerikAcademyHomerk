/* Problem 6. Point in Circle

Write an expression that checks if given point P(x, y) is within a circle K(O, 5).

Examples:
x	    y	    inside
0	    1	    true
-5	    0	    true
-4	    5	    false
1.5	    -3	    true
-4	    -3.5	false
100	    -30	    false
0	    0	    true
0.2	    -0.8	true
0.9	    -4.93	false
2	    2.655	true
*/

var circleK = 5,
//Feel free to add or remove numbers, but there must be an equal number of numbers in PointX and PointY
    pointX = [0, -5, -4, 1.5, -4, 100, 0, 0.2, 0.9, 2],
    pointY = [1, 0, 5, -3, -3.5, -30, 0, -0.8, -4.93, 2.655],
    loops = pointX.length,
    i,
    isInside;

for (i = 0; i < loops; i += 1) {
    if (pointX[i] !== undefined && pointY[i] !== undefined) {
        isInside = ((pointX[i] * pointX[i] + pointY[i] * pointY[i]) <= (circleK * circleK));
        console.log('The point with X = ' + pointX[i] + ' and Y = ' + pointY[i] + ' is in the circle: ' + isInside);
    }
}

