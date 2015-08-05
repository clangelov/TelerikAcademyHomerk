$.fn.tabs = function () {
    
    var $tabs = this;

    $tabs.addClass('tabs-container');

    clearContent($tabs);

    function clearContent($tabs) {
        $tabs.find('.tab-item-content').each(function () {
            var $element = $(this);
            $element.parent('.tab-item').removeClass('current');
            $element.hide();
        })
    }   

    $tabs.on('click', '.tab-item-title', function (ev) {
        var $element = $(this);
        clearContent($tabs);
        $element.parent('.tab-item').addClass('current');
        $element.next().show();
    })

    return this;

};