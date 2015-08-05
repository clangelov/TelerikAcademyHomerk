// Create a dropdown list by a given select

function solve() {
	
    return function (selector) {

        var $container = $('<div/>').addClass('dropdown-list'),
            $select = $(selector).hide().appendTo($container),
            $currentOption = $('<div/>').addClass('current').text('Select a value').appendTo($container),
            $optionsContainer = $('<div/>').addClass('options-container').css('position', 'absolute').hide().appendTo($container);

        $select.find('option').each(function (index) {
            var $this = $(this),
                currentDataValue = $this.val(),
                currentText = $this.text(),
                currentDiv;

            currentDiv = $('<div/>')
                .appendTo($optionsContainer)
                .addClass('dropdown-item')
                .attr('data-value', currentDataValue)
                .attr('data-index', index)
                .text(currentText)
                .click(function () {
                    $currentOption.val(currentDataValue);
                    $currentOption.text(currentText);
                    $optionsContainer.hide();
                    $select.val(currentDataValue);
                });
        });

        $currentOption.click(function(){
            $optionsContainer.toggle();
            $currentOption.text('Select a value');
        });

        $(document.body).append($container);

        return this;
    };
}

module.exports = solve;