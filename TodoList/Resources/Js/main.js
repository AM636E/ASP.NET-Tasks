/// <reference path="F:\Projects\.NET\Lifecycle\TodoList\Scripts/bootstrap.js" />
/// <reference path="F:\Projects\.NET\Lifecycle\TodoList\Scripts/jquery-1.9.0.js" />

(function () {
    $(document).ready(function () {
        $("#cphBody_addTaskFrom_chkDeadline").click(function () {
            console.log($(this).attr('checked'));
        });

        $('[data-entity]').click(function (e) {
            e.preventDefault();
            PageMethods.GetTask(this.getAttribute('data-id'), ajaxReceiver, ajaxError);
        });
    });
    window.ajaxReceiver = function (result) {
        console.log(result);
    };

    window.ajaxError = function (result) {

    };
})(jQuery);