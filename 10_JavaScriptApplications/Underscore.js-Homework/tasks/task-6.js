/* 
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
    return function (books) {

        var sortedBooks = _.chain(books)
            .groupBy(function (book) {
                return book.author.firstName + ' ' + book.author.lastName;
            }).mapObject(function (value, key) {
                return {author: key, books: value.length};
            }).sortBy(function (item) {
                return -item.books;
            })
            .value();

        var maxNumber = _.first(sortedBooks).books;

        _.chain(sortedBooks)
            .filter(function (item) {
                return item.books == maxNumber;
            })
            .sortBy('author')
            .each(function (item) {
                console.log(item.author);
            });
    };
}

module.exports = solve;
