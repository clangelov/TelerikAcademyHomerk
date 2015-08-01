/* globals $ */
/*

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neither `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (element, contents) {

        var contentResult,
            divEl,
            nodeEl,
            docFragment,
            divElClone,
            i,
            length;

        if (typeof element === undefined || contents === undefined) {
            throw new {message: 'You need to pass an valid parameter'};
        }

        // may use element instanceof HTMLElement as well
        if (typeof element !== 'string' && !element.nodeType === 1) {
            throw new {message: 'Parameter must be a string or node element'};
        }

        if (!Array.isArray(contents)) {
            throw new {message: 'Contents must be an Array'};
        }

        contents.forEach(function (contentElement) {
            if (typeof contentElement !== 'string' && typeof contentElement !== 'number') {
                throw new {message: 'Content must be a string or number'};
            }
        });

        if (typeof element === 'string') {

            nodeEl = document.getElementById(element);

            if (nodeEl === null) {
                throw new {message: 'You passed a non existing ID'};
            }

            nodeEl.innerHTML = '';

            divEl = document.createElement('div');
            docFragment = document.createDocumentFragment();

            for (i = 0, length = contents.length; i < length; i += 1) {

                divElClone = divEl.cloneNode(true);
                divElClone.innerHTML = contents[i];
                docFragment.appendChild(divElClone);
            }

            nodeEl.appendChild(docFragment);

        } else {

            nodeEl = element;

            nodeEl.innerHTML = '';

            contentResult = '';

            for (i = 0, length = contents.length; i < length; i += 1) {
                contentResult += '<div>' + contents[i] + '</div>';
            }

            nodeEl.innerHTML += contentResult;
        }
    };
};