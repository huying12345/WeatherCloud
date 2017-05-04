var tabmarginleft = 0;
var tabwidth = null;
var onlyNowtablocate = false;
$(document).ready(function () {
    $(".selecttabicon").bind("click", function () {
        if (typeof (this.href) != "undefined" && this.href != null && this.href != "" && this.href.indexOf("#") == -1) {
            return;
        }
        if (onlyNowtablocate) {
            if (this.id != "nowtablocate") {
                return;
            }
        }
        if (tabwidth == null) {
            tabwidth = $(window).width() / $(".selecttabicon").length - 2;
        }
        var index = 0;
        var instance = this;
        $(".selecttabicon").each(function () {
            index++;
            if (this == instance) {
                var imgwidth = $("#selecticon").width();
                if (imgwidth == 0) {
                    imgwidth = $("#selecticon")[0].width;
                }
                if (imgwidth == 0) {
                    imgwidth = 62;
                }
                $("#selecticon").css("left", tabmarginleft + tabwidth * (index - 0.5) - imgwidth / 2);
            }
        });

    });
    $("#nowtablocate").click();
});
