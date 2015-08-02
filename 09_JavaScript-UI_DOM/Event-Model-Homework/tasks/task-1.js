/* globals $ */

/*
 Create a function that takes an id or DOM element and:
 If an id is provided, select the element
 Finds all elements with class button or content within the provided element
 Change the content of all .button elements with "hide"
 When a .button is clicked:
 Find the topmost .content element, that is before another .button and:
 If the .content is visible:
 Hide the .content
 Change the content of the .button to "show"
 If the .content is hidden:
 Show the .content
 Change the content of the .button to "hide"
 If there isn't a .content element after the clicked .button and before other .button, do nothing
 Throws if:
 The id is either not a string or does not select any DOM element
 The provided DOM element is non-existant
 */

function solve() {

    function validateSelector(selector) {
        if (selector === undefined) {
            throw {message: 'You need to pass an valid selector'};
        }
        if (typeof selector !== 'string') {
            throw {message: 'Parameter must be a string'};
        }
    }

    function hideOrShowElements(ev) {
        var targetEl = ev.target,
            nextEl = targetEl.nextElementSibling,
            contentEl;

        if (nextEl === null || nextEl.className === 'button') {
            return;
        }

        while (nextEl) {
            if (nextEl.className === 'content') {
                contentEl = nextEl;
                break;

            } else {
                nextEl = nextEl.nextElementSibling;
            }
        }

        if (contentEl.style.display === '') {
            targetEl.innerHTML = 'show';
            contentEl.style.display = 'none';
        } else {
            targetEl.innerHTML = 'hide';
            contentEl.style.display = '';
        }
    }

    return function (selector) {

        var nodeEl,
            buttonEls,
            len,
            i;

        validateSelector(selector);

        nodeEl = document.getElementById(selector);

        if (nodeEl === null) {
            throw {message: 'You passed a non existing ID'};
        }

        buttonEls = nodeEl.getElementsByClassName('button');

        for (i = 0, len = buttonEls.length; i < len; i += 1) {
            buttonEls[i].innerHTML = 'hide';
        }

        nodeEl.addEventListener('click', hideOrShowElements);
    };
}

module.exports = solve;