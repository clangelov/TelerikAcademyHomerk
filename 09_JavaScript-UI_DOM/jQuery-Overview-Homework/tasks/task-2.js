/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {

    function validateSelector(selector) {
        if (selector === undefined) {
            throw {message: 'You must pass selector as parameter'};
        }

        if (typeof selector !== 'string') {
            throw {message: 'Selector must be a string'};
        }

        if (!$(selector).size()) {
            throw {message: 'Selector does not select any DOM elements'};
        }
    }

    function showOrHideElements() {

        var $targetEl = $(this),
            $nextEl = $targetEl.nextAll('.content').first();

        if ($nextEl.length === 0) {
            return;
        }

        if ($nextEl.css('display') === 'none') {
            $targetEl.text('hide');
            $nextEl.css('display', '');

        } else {
            $targetEl.text('show');
            $nextEl.css('display', 'none');
        }
    }

    return function (selector) {

        var $nodeEl,
            $buttons;

        validateSelector(selector);

        $nodeEl = $(selector);

        $buttons = $nodeEl.find('.button').each(function () {
            $(this).text('hide');
        });

        $nodeEl.on('click', '.button', showOrHideElements);

    };
}

module.exports = solve;