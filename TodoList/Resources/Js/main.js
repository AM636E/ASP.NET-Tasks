/// <reference path="F:\Projects\.NET\Lifecycle\TodoList\Scripts/bootstrap.js" />
/// <reference path="F:\Projects\.NET\Lifecycle\TodoList\Scripts/jquery-1.9.0.js" />
/// <reference path="F:\Projects\.NET\Lifecycle\TodoList\Scripts/jquery-ui-1.10.4.js" />

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
        var dialogTemplate = $('<div class="dialog tasks-dialog"></div>').append('<div class="content">' + result.Text + '</div>');        
        dialogTemplate.dialog({
            title: result.Title
        });

    };

    window.ajaxError = function (result) {
        console.log(result);
        var dialogTemplate = $('<div class="dialog tasks-dialog"></div>').append('<div class="content">' + result._message + '</div>');
        dialogTemplate.dialog({
            title: result._exceptionType
        });

    };
})(jQuery);