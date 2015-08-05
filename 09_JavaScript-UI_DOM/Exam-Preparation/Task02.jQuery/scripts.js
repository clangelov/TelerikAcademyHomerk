/* globals $ */
$.fn.gallery = function (inputCount) {

    var columNuber = inputCount || 4;
    columNuber = columNuber * 1;    

    var $divGallery = $('#gallery').addClass('gallery');
    var $divGalleryList = $('.gallery-list');
    var $currentCat = $('.current-image').children().first();
    var $nextCat = $('.next-image').children().first();
    var $prevCat = $('.previous-image').children().first();

    var divImageContainer = $('.image-container').each(function (index) {
        var $this = $(this);
        if (index % columNuber === 0) {
            $this.addClass('clearfix');
        }
    })

    var $divDisabler = $('<div/>').addClass('gallery').appendTo($divGallery);
    var $selectedDiv = $('.selected').hide();

    $divGalleryList.on('click', 'img', function (ev) {
        $divGalleryList.toggleClass('blurred');
        $divDisabler.toggleClass('disabled-background');
        var targetEl = $(ev.target);
        setImagesToCats(targetEl);
        $selectedDiv.show();
    });

    function setImagesToCats(targetEl) {

        $currentCat.attr('src', targetEl.attr('src'));
        var dataInfo = targetEl.attr('data-info') * 1;
        $currentCat.attr('data-info', dataInfo);        

        var nextindex = getNextIndex(dataInfo);
        var prevIndex = getPrevIndex(dataInfo);

        var nextAddress = $divGalleryList.find("[data-info='" + nextindex + "']");
        $nextCat.attr('src', nextAddress.attr('src'));
        $nextCat.attr('data-info', nextAddress.attr('data-info'));

        var prevAddress = $divGalleryList.find("[data-info='" + prevIndex + "']");
        $prevCat.attr('src', prevAddress.attr('src'));
        $prevCat.attr('data-info', prevAddress.attr('data-info'));
    }

    function getNextIndex(dataInfo) {
        if ((dataInfo + 1) > 12) {
            return 1;
        } else {
            return dataInfo + 1;
        }        
    }

    function getPrevIndex(dataInfo) {
        if ((dataInfo - 1) < 1) {
            return 12;
        } else {
            return dataInfo - 1;
        }
    }

    $currentCat.on('click', function () {
        $divGalleryList.toggleClass('blurred');
        $divDisabler.toggleClass('disabled-background');
        $selectedDiv.hide();
    })

    $nextCat.on('click', function (ev) {
        var tatgetEl = $(ev.target);
        setImagesToCats(tatgetEl);
    })

    $prevCat.on('click', function (ev) {
        var tatgetEl = $(ev.target);
        setImagesToCats(tatgetEl);
    })

    return this;
};