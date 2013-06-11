(function (userCollectAnswer, $, undefined) {

    userCollectAnswer.initPage = function () {
        $("input:radio[data-control]").click(function () {
            showHideControls($(this));
        });

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
            /*
            while (underControls.find("input[data-control]").size() > 0) {
            var subControlName = underControls.find("input[data-control]").data("control");
            var subUnderControls = $("tr[data-under-control='" + subControlName + "']");
            }
            */
        }

        $("input:radio[data-control]:checked").each(function () {
            showHideControls($(this));
        });

        if ($("#IsAdminViewAnswer").val().toLowerCase() == "true") {
            $("input, textarea, select").addClass("disabled").attr("disabled", "disabled");
        }

        $("#instruction-entrance").colorbox({
            href: "../../Instruction.htm",
            width: 830,
            height: 500
        });

    }

} (window.userCollectAnswer = window.userCollectAnswer || {}, jQuery));