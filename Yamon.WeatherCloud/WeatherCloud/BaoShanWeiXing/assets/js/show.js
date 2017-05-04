var ShowNodeViewModel = function () {
     self = this;
    self.parentNodes = ko.observableArray([]);
    self.brotherNodes = ko.observableArray([]);
    self.nodeInfo = ko.observable({});
    self.issubscribe = ko.observable(true);
    self.subscribeNodes = ko.observableArray([]);
    self.init = function (parentId) {
        self.getNodeTree(parentId);
    };

    self.getNodeTree = function(nodeId) {
        $.ajax({
            url: '/api/Weather/WeatherNodes/GetMyNodesBrotherParentListByNodeID?UserID=' + userId + '&NodeID=' + nodeId,
            dataType: 'json',
            success: function(msg) {

                for (var i = 0; i < msg.parent.length; i++) {
                    self.parentNodes.push(msg.parent[i]);
                }
                for (var i = 0; i < msg.brother.length; i++) {
                    self.brotherNodes.push(msg.brother[i]);
                }
                self.nodeInfo = msg.node;
                self.issubscribe(msg.issubscribe);
                $('#title').text(self.nodeInfo.ParentID_ShowValue);
               
                $('.swiper-slide[nodeId="' + self.nodeInfo.NodeID + '"]').addClass("show_active");

                var i = msg.brother.length;
                if (i < 4) {
                    var j = (100 / i) + "%";
                    $(".swiper-slide").css("width", j);
                } else {
                    $(".swiper-slide").css("width", "25%");
                    $(".swiper-slide").each(function() {
                        if ($(this).text().trim().length > 10) {
                            $(this).css("width", "50%");
                        } else if ($(this).text().trim().length > 7) {
                            $(this).css("width", "40%");
                        }
                    });
                }
            }
        });
    };

    self.nodeClick = function (row) {
        location.href = '/Home2/Show/' + row.NodeID;
    }

    self.addSubscribeNode = function () {
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/SetDataSubscribeOne?',
            data: { "UserID": userId, "NodeID": self.nodeInfo.NodeID },
            success: function (msg) {
                if (msg.success) {
                    $.toast.prototype.defaults.duration = '1000';
                    $.toast('收藏成功！');
                    self.issubscribe(true);
                } else {
                    $.toast('已收藏！', 'cancel');
                }
            }
        });
    }
    self.removeSubscribeNode = function () {
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/CancelDataSubscribeOne?',
            data: { "UserID": userId, "NodeID": self.nodeInfo.NodeID },
            success: function (msg) {
                if (msg.success) {
                    $.toast.prototype.defaults.duration = '1000';
                    $.toast('取消成功！');
                    self.issubscribe(false);
                } else {
                    $.toast('取消失败！', 'cancel');
                }
            }
        });
    }
}
