(function (userIndex, $, undefined) {

    userIndex.initPage = function () {
        $("#CurrentUser_Password").focus(function () {
            var jqueryItem = $(this);
            var str = $.trim(jqueryItem.val());
            if (str == "") {
                $(this).val(getRandomString(8));
            }
        });
    }

    function getRandomString(l) {
        var x = "123456789poiuytrewqasdfghjklmnbvcxzQWERTYUIPLKJHGFDSAZXCVBNM";
        var tmp = "";
        for (var i = 0; i < l; i++) {
            tmp += x.charAt(Math.ceil(Math.random() * 100000000) % x.length);
        }
        return tmp;
    }

    $(".user-delete-link").click(function () {
        return confirm("确认要删除用户[" + $(this).attr("username") + "]?");
    });

} (window.userIndex = window.userIndex || {}, jQuery));