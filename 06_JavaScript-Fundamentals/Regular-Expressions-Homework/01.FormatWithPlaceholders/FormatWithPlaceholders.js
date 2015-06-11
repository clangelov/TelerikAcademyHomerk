/* Problem 1. Format with placeholders

Write a function that formats a string. The function should have placeholders, as shown in the example
Add the function to the String.prototype
*/

String.prototype.format = function (options) {

    var regex,
        input = this;

    for (var key in options) {
        regex = new RegExp('#{' + key + '}', 'g');
        input = input.replace(regex, options[key]);
    }

    return input;
}

console.log('Original text is: Hello, there! Are you #{name}? and Object is: { name: \'John\' }')
console.log('Changed text is: ' + 'Hello, there! Are you #{name}?'.format({ name: 'John' }));

console.log('Original text is: My name is #{name} and I am #{age}-years-old).format(options) and object is: {name: \'Johnny\', age: 21} ');
console.log('Changed text is: ' + 'My name is #{name} and I am #{age}-years-old)'.format({name: 'Johnny', age: 21}));