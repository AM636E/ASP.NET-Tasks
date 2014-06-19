/// <reference path="F:\Projects\.NET\Lifecycle\Translator\Scripts/jquery-1.9.0.js" />
/// <reference path="F:\Projects\.NET\Lifecycle\Translator\Scripts/bootstrap.js" />
(function ($) {
    $(document).ready(function () {
        $("select").change(function () {
            console.log(this.getAttribute("name"));
            __doPostBack(this.getAttribute("name"), "");
        });
    });
})(jQuery);