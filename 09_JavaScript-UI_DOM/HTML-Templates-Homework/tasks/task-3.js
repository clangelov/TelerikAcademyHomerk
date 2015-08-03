function solve() {

    return function () {
        $.fn.listview = function (data) {

            var $this = $(this),
                compiledTemplate,
                template = $("#" + $this.attr('data-template')).html(),
                $documentFragment = $(document.createDocumentFragment());

            compiledTemplate = handlebars.compile(template);

            data.forEach(function (element) {
                $documentFragment.append(compiledTemplate(element));
            });

            $this.append($documentFragment);

            return this;
        };
    };
}

module.exports = solve;