(function ($) {
    $(document).ready(function () {
        $("[data-from]").each(function () {
            var valueSelector = this.getAttribute('data-from');
            var textSelector = this.getAttribute('data-text');
            var that = this;
            $(valueSelector).each(function (i) {
                var el = $(this);
                var textElement = el.parent().find(textSelector);
                $('<div></div>')
                .text(textElement.text())
                    .addClass('list-item')
                    .addClass('item-' + i)
                   .click(function () {
                       el.attr('checked', true);
                       __doPostBack(this.getAttribute('name') + '$' + this.getAttribute('value'));                       
                   })
                .appendTo(that);
                
            });
        });
    });
})(jQuery);