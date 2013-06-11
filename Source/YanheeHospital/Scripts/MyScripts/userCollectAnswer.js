(function (userCollectAnswer, $, undefined) {

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

    userCollectAnswer.initPage = function () {
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

        $("input:radio[data-control]:checked").each(function () {
            showHideControls($(this));
        });

        if ($("#IsAdminViewAnswer").val().toLowerCase() == "true") {
            $("input, textarea, select").addClass("disabled").attr("disabled", "disabled");
        }

        $(".shorter-text-box-wrapper input:text").blur();
    }

} (window.userCollectAnswer = window.userCollectAnswer || {}, jQuery));