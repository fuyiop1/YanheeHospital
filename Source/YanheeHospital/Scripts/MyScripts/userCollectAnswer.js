(function (userCollectAnswer, $, undefined) {
    userCollectAnswer.initPage = function () {
        initEvents();
        initElements();
    }

    function initEvents() {
        $("input:radio[data-control]").click(function () {
            showHideControls($(this));
        });

        $("#instruction-entrance").colorbox({
            href: "../../Instruction.htm",
            width: 830,
            height: 500
        });

        $(".shorter-text-box-wrapper input:text").focus(function () {
            $(this).parent().find(".textbox-hint-wrapper").hide();
        });

        $(".shorter-text-box-wrapper input:text").blur(function () {
            var jqueryItem = $(this);
            if ($.trim(jqueryItem.val()) == "") {
                jqueryItem.parent().find(".textbox-hint-wrapper").show();
            } else {
                jqueryItem.parent().find(".textbox-hint-wrapper").hide();
            }
        });

        $("#return-button").click(function () {
            var targetUrl = $(this).data("target-url");
            if (targetUrl) {
                location.href = targetUrl;
            }
        });
    }

    function initElements() {
        $("input:radio[data-control]:checked").each(function () {
            showHideControls($(this));
        });

        if ($("#IsAdminViewAnswer").val().toLowerCase() == "true") {
            $("input:text, input:radio, input:checkbox, textarea, select").addClass("disabled").attr("disabled", "disabled");
        }

        $(".shorter-text-box-wrapper input:text").blur();

        $(".auto-height").each(function () {
            autoSizeTextarea(this);
        })
    }

    function autoSizeTextarea(item) {
        var height = 0;
        var style = item.style;
        var minHeight = 0;
        var maxHeight = 1000000;
        if (item.scrollHeight > minHeight) {
            if (maxHeight && item.scrollHeight > maxHeight) {
                height = maxHeight;
                style.overflowY = 'scroll';
            } else {
                height = item.scrollHeight;
                style.overflowY = 'hidden';
            }
            style.height = height + 'px';
        }
    }

    function showHideControls(item) {
        var controlName = item.data("control");
        var itemValue = item.val();
        var underControls = $("tr[data-under-control='" + controlName + "']");
        if (itemValue == "true") {
            underControls.show(1000);
        } else {
            underControls.find("input:radio[value]='false'").click();
            underControls.find("input:text").val("");
            underControls.hide();
        }
    }

} (window.userCollectAnswer = window.userCollectAnswer || {}, jQuery));