/* Problem 2. HTML binding

Write a function that puts the value of an object into the content/attributes of HTML tags.
Add the function to the String.prototype
*/

String.prototype.bind = function (string, object) {
    var addContent,
        addHref,
        addClass,
        result = this;

    for (var key in object) {
        addContent = new RegExp('(<.*data-bind-content="' + key + '".*>)(.*)(<.*>)', 'g'),
        addHref = new RegExp('(<.*data-bind-href="' + key + '")', 'g'),
        addClass = new RegExp('(data-bind-class="' + key + '")', 'g');

        result = result.replace(addContent, function (none, opening, content, closing) {
            content = object[key];
            return opening + content + closing;
        })
            .replace(addHref, function (none, content) {
                return content + ' href="' + object[key] + '"';
            })
            .replace(addClass, 'data-bind-class="' + object[key] + '"');
    }
    return result;
};

console.log('Original text is: <div data-bind-content="name"></div> and Object is: { name: \'Steven\' }')
console.log('Changed text is: ' + '<div data-bind-content="name"></div>'.bind('', { name: 'Steven' }));

console.log('Original text is: <a data-bind-content="name" data-bind-href="link" data-bind-class="name"></div> and Object is { name: \'Elena\', link: \'http://telerikacademy.com\' } ');
console.log('Changed text is: ' + '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></div>'.bind('', { name: 'Elena', link: 'http://telerikacademy.com' }));