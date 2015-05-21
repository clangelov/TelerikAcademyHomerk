/* Problem 3. Rectangle area

Write an expression that calculates rectangle’s area by given width and height.
Examples:

width	height	area
3	    4	    12
2.5	    3	    7.5
5	    5       25
*/

var width = [3, 2.5, 5], //Feel free to add or remove numbers, but
    height = [4, 3, 5], // there must be an equal number of numbers in width and height
    loops = width.length,
    i;

for (i = 0; i < loops; i++) {
    if (width[i] !== undefined && height[i] !== undefined) {
        console.log('The area of rectangle with width of ' + width[i] + ' and height of '
            + height[i] + ' is ' + width[i] * height[i]);
    }    
}

