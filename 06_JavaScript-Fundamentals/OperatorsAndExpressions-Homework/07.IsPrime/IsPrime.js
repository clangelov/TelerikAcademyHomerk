/* Problem 7. Is prime

Write an expression that checks if given positive integer number n (n ≤ 100) is prime.

Examples:
n	Prime?
1	false
2	true
3	true
4	false
9	false
37	true
97	true
51	false
-3	false
0	false
*/
var number = [1, 2, 3, 4, 9, 37, 97, 51, -3, 0], // Feel free to add or remove numbers
    numLength = number.length,
    i,
    divisor;

for (i = 0; i < numLength; i+=1) {
    console.log('Number ' + number[i] + ' is Prime: ' + isPrime(number[i]));
}

function isPrime(number) {

    if (number < 2) {
        return false;
    }

    for (divisor = 2; divisor <= Math.sqrt(number); divisor += 1) {
        if (!(number % divisor)) {
            return false;
        }
    }

    return true;
}