
var NodeViewModel = function () {
    var self = this;
    self.nodes = ko.observableArray([]);
  
    self.subscribeNodes = ko.observableArray([]);
    self.init = function (parentId) {
        self.getNodeTree(parentId);
        self.getSubscribeNodes();
    };

    self.getNodeTree = function (parentId) {
        $.ajax({
            url: '/api/Weather/WeatherNodes/GetMyTreeGrid?UserID=' + userId + '&ParentID=' + parentId,
            dataType: 'json',
            success: function (msg) {
                for (var i = 0; i < msg.rows.length; i++) {
                    self.nodes.push(msg.rows[i]);
                    if (i == 0) {
                        $('title').text(msg.rows[i].ParentID_ShowValue);
                        $('.title').text(msg.rows[i].ParentID_ShowValue);
                    }
                }
            }
        });
    }

    self.getSubscribeNodes = function () {
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/GetDataSubscribe',
            data: { "UserID": userId },
            success: function (msg) {
                for (var i = 0; i < msg.data.length; i++) {
                    self.subscribeNodes.push(msg.data[i]);
                }
            }
        });
    }
    self.addSubscribeNode = function (row) {     
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/SetDataSubscribeOne?',
            data: { "UserID": userId, "NodeID": row.NodeID },
            success: function (msg) {
                if (msg.success) {
                    $.toast.prototype.defaults.duration = '1000';
                    $.toast('收藏成功！');
                    self.subscribeNodes.push(row);
                    
                } else {
                    $.toast('已收藏！', 'cancel');
                }
            }
        });
    }
    self.removeSubscribeNode = function (row) {
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: '/api/Weather/WeatherNodesSubscribe/CancelDataSubscribeOne?',
            data: { "UserID": userId, "NodeID": row.NodeID },
            success: function (msg) {
                if (msg.success) {
                    $.toast.prototype.defaults.duration = '1000';
                    $.toast('取消成功！');
                    self.subscribeNodes.remove(row);
                } else {
                    $.toast('取消失败！', 'cancel');
                }
            }
        });
    };
}
