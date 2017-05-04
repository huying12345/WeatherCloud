jQuery(function () {

    jQuery('#imgSubscribe').click(function () {

       // jQuery("#imgSubscribe").linkbutton("disable");
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/SetDataSubscribeOne?',
            data: { "UserID": userId, "NodeID": nodeId },
            success: function (msg) {
                //jQuery("#imgSubscribe").linkbutton('enable');
                if (msg.success) {
                    //alert("操作成功！");
                    jQuery("#lblSubscribe").html("订阅成功！");
                } else {
                    //alert("操作失败：" + msg);
                    jQuery("#lblSubscribe").html("订阅失败！");
                }
            },
            error: function (error) {
                //jQuery("#imgSubscribe").linkbutton('enable');
            }
        });

    });
});
