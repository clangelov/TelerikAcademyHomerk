/* Problem 5. Appearance count

Write a function that counts how many times given number appears in given array.
Write a test function to check if the function is working correctly.
*/
var array = [],
    loops = 20, // You may edit the length of the array
    number,
    counter,
    i;

testTask(loops);

function testTask(loops) {

    array = randomNumbers(loops); // Random generated array with numbers between 1 and 5
    number = array[Math.random() * loops | 0]; // Picking a random position out of the array
    
    console.log('Initial array is: ' + array.join(', '));
    console.log('You can find the number ' + number + ' in this array ' + findOccurrence(array, number) + ' times');
}

function findOccurrence (array, number) {

    counter = 0;
    loops = array.length;

    for (i = 0; i < loops; i += 1) {

        if (array[i] === number) {
            counter += 1;
        }
    }

    return counter;
}

function randomNumbers(loops) {

    for (i = 0; i < loops; i += 1) {

        array.push((Math.random() * 5 + 1 ) | 0);
    }

    return array;
}