/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(arr) {

    if (!arr) {
        throw { message: 'No Parameters are passed to the function'};
    }

    if (arr.length == 0) {
        return null;
    }


    if (arr.some(function (element) { return element === null || isNaN(element) } )) {
        throw  {message: 'Not all elements of the array are numbers'};
    }

    arr = arr.map(Number);

    return arr.reduce(function(sum, element){ return sum += element}, 0);
}

module.exports = sum;

// Second Solution

function sumArrNumbers(arr) {

    var i,
        len,
        sum = 0;

    if (!arr) {
        throw { message: 'No Parameters are passed to the function'};
    }

    if (arr.length == 0) {
        return null;
    }

    for (i = 0, len = arr.length; i < len; i += 1) {

        if (isFinite(arr[i])) {
            sum += (parseFloat(arr[i])); // for better performance use +arr[i] /or arr[i]*1 
        } else {
            throw {message: 'Not all elements of the array are numbers'};
        }
    }

    return sum;
}