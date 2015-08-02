/* globals $ */

/* 

 Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:
 * The UL must have a class `items-list`
 * Each of the LIs must:
 * have a class `list-item`
 * content "List item #INDEX"
 * The indices are zero-based
 * If the provided selector does not selects anything, do nothing
 * Throws if
 * COUNT is a `Number`, but is less than 1
 * COUNT is **missing**, or **not convertible** to `Number`
 * _Example:_
 * Valid COUNT values:
 * 1, 2, 3, '1', '4', '1123'
 * Invalid COUNT values:
 * '123px' 'John', {}, []
 */

function solve() {

    function validateSelector(selector) {
        if (selector === undefined) {
            throw {message: 'You must pass selector as parameter'};
        }
        if (typeof selector !== 'string') {
            throw {message: 'Selector must be a string'};
        }
    }

    function parseCount(count) {

        if (count === undefined) {
            throw {message: 'You must pass count as parameter'};
        }

        if (isNaN(count) || count === '' || Array.isArray(count)) {
            throw {message: 'Count must be a number'};
        }

        count = parseInt(count);

        if (count < 1) {
            throw {message: 'Count must be at least 1 or a higher number'};
        }

        return count;
    }
    return function (selector, count) {

        var elementsLength,
            $ulEl,
            $nodeEl,
            i,
            liClassName = 'list-item',
            liContent = 'List item #',
            ulClassName = 'items-list';

        validateSelector(selector);
        elementsLength = parseCount(count);

        $nodeEl = $(selector);

        if ($nodeEl === null) {

           return null;
        }

        $ulEl = $('<ul/>').addClass(ulClassName).appendTo($nodeEl);

        for (i = 0; i < elementsLength; i += 1) {
            $('<li/>').addClass(liClassName).text(liContent+i).appendTo($ulEl);
        }
    };
}

module.exports = solve;