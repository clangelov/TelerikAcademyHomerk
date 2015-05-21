/* Problem 9. Point in Circle and outside Rectangle

Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

Examples:
x	    y	    inside K & outside of R
1	    2	    yes
2.5	    2	    no
0	    1	    no
2.5	    1	    no
2	    0	    no
4	    0	    no
2.5	    1.5	    no
2	    1.5	    yes
1	    2.5	    yes
-100	-100	no
*/

//Feel free to add or remove numbers, but there must be an equal number of numbers in PointX and PointY
var pointX = [1, 2.5, 0, 2.5, 2, 4, 2.5, 2, 1, -100],
    pointY = [2, 2, 1, 1, 0, 0, 1.5, 1.5, 2.5, -100],
    loops = pointX.length,
    circleK = 3,
    i;

for (i = 0; i < loops; i+=1) {
    if (isInCircle(pointX[i], pointY[i]) && outsideRect(pointX[i], pointY[i])) {
        console.log('The point with X = ' + pointX[i] + ' and Y = ' + pointY[i] + ' is in the Circle and outside the Rectangle');
    } else {
        console.log('The point with X = ' + pointX[i] + ' and Y = ' + pointY[i] + ' is NOT in the Circle and outside the Rectangle');
    }
}

function isInCircle(pointX, pointY) {
    return (((pointX-1) * (pointX-1) + (pointY-1) * (pointY-1)) <= (circleK * circleK));
}
function outsideRect(pointX, pointY) {
    return (-1 < pointX) ^ (pointX > 5) ^ (-1 < pointY) ^ (pointY > 1);
}
