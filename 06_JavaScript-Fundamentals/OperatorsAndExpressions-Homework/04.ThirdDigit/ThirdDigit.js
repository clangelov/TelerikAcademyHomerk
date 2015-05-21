/* 
Problem 4. Third digit

Write an expression that checks for given integer if its third digit (right-to-left) is 7.

Examples:
n	    Third digit 7?
5	    false
701	    true
1732	true
9703	true
877	    false
777877	false
9999799	true
 */

var number = [5, 701, 1732, 9703, 877, 777877, 9999799], //Feel free to add or remove numbers
    numLength = number.length,
    i;

for (i = 0; i < numLength; i+=1) {
    console.log('The third digit (right-to-left) in ' + number[i] + ' is 7: '
        + (((number[i] / 100) | 0) % 10 === 7) + '!');
}
