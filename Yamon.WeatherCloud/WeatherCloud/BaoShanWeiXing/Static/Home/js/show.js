function menu() {
    $('#myTab a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    })
    $("#left-hides").click(function () {
        $("#Index-left").hide(500);
        $("#left-hides").hide();
        $("#right-hides").show();
        $("#Index-Content").removeClass("col-xs-9");
        $("#Index-Content").addClass("col-xs-12");
    });
    $("#right-hides").click(function () {
        $("#Index-left").show(500);
        $("#left-hides").show();
        $("#right-hides").hide();
        $("#Index-Content").removeClass("col-xs-12");
        $("#Index-Content").addClass("col-xs-9");
    });
}
function menu1() {
    $('#myTab a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    })
    $("#left-hides").click(function () {
        $("#Index-left").hide(500);
        $("#left-hides").hide();
        $("#right-hides").show();

    });
    $("#right-hides").click(function () {
        $("#Index-left").show(500);
        $("#left-hides").show();
        $("#right-hides").hide();

    });
}

var fbsjContainMM = true;
var nd;
$(function () {
    var index = new indexViewModel();
    ko.applyBindings(index);
    index.init();
});

var indexViewModel = function () {
    var self = this;
    self.parentid = "";
    self.parentname = "";
    self.indextype = "";
    self.lines = ko.observableArray([]);//一级栏目
    self.lines2 = ko.observableArray([]);//二级栏目
    self.lines3 = ko.observableArray([]);//三级栏目
    self.images = ko.observableArray([]);
    self.imageslist = ko.observableArray();
    self.stationtype = "station-temp";
    self.stationListArray = ko.observableArray([]);
    self.color = ["#89D300", "#FF7356", "#05D276", "#06D276", "#879EFF", "#FCB612"];
    self.icon = ["&#xe60e", "&#xe60a", "&#xe609", "&#xe60b"];
    self.tabmarginleft = 10;
    self.nodesid = 0;
    self.stationid = '58362';
    self.timeout = -1;
    self.currentindex = 0;
    self.currentPlayindex = 0;
    self.interval;
    self.init = function () {
        self.menus1();
        self.parentid = $.query.get("ParentID");
        self.parentname = $.query.get("NodeName")
        self.MenuID = $.query.get("MenuID");
        self.nodesid = $.query.get("NodeID");
        self.indextype = $.query.get("IndexType");
        $("#Title1").text(self.parentname);

        if (self.MenuID == "112" || self.MenuID == "117" || self.MenuID == "122") {
            self.stationList();
        }
        if (self.MenuID == "117") {
            $("#station-xdsd").show();
        }
        if (self.nodesid == '139') {
            self.StationPM("139");
        }
        else if (self.nodesid == '140') {
            self.StationPM("140");
        }

        if (self.indextype == "2") {
            $("#index1-icon,.foot2-icon").show();
            $("#index2-icon,.foot1-icon").hide();

        }
        else {
            $("#index1-icon,.foot2-icon").hide();
            $("#index2-icon,.foot1-icon").show();
        }

    };

    //栏目菜单
    self.menus1 = function () {

        $.ajax({
            url: '/api/Weather/WeatherNodes/GetMyTreeGrid?UserID='+userId,
            dataType: 'json',
            success: function (msg) {
                if (msg.rows.length > 0) {
                    self.array = new Array();
                    for (var i = 0; i < msg.rows.length; i++) {
                        if (msg.rows[i].NodeID != "232") {
                            //底部栏目图标
                            if (msg.rows[i].NodeID == "8") {
                                msg.rows[i].icon = "&#xe605";
                            } else if (msg.rows[i].NodeID == "151") {
                                msg.rows[i].icon = "&#xe602";
                            } else if (msg.rows[i].NodeID == "190") {
                                msg.rows[i].icon = "&#xe606";
                            } else if (msg.rows[i].NodeID == "196") {
                                msg.rows[i].icon = "&#xe607";
                            } else if (msg.rows[i].NodeID == "219") {
                                msg.rows[i].icon = "&#xe604";
                            }

                            msg.rows[i].hrefs = "";//链接
                            msg.rows[i].color = "";//背景颜色
                            msg.rows[i].icons = "";//图标
                            msg.rows[i].isn = "1";//0下级为空，1为不为空
                            self.menu_1 = "";//二级菜单
                            self.menu_2 = "";//三级菜单
                            self.menu_3 = "";//四级菜单
                            self.menu_4 = "";
                            msg.rows[i].number = 0;
                            if (!msg.rows[i].children) {
                                continue;
                            }
                            for (var k = 0; k < msg.rows[i].children.length; k++) {
                                //二级栏目链接
                                msg.rows[i].children[k].hrefs = self.listhref(msg.rows[i].children[k].children[0], msg.rows[i].children[k].NodeName, msg.rows[i].children[k].ParentID, msg.rows[i].children[k].NodeID, msg.rows[i].children[k].NodeID);//二级栏目路径

                                //二级栏目图标和颜色
                                var numcolor = k % 6;
                                var numicons = k % 4;
                                msg.rows[i].children[k].color = self.color[numcolor];
                                msg.rows[i].children[k].icons = self.icon[numicons];
                                msg.rows[i].children[k].number = k % 3;

                                self.menu_1 = msg.rows[i].children[k];
                                if (self.menu_1.children != null) {//判断是否有下一级
                                    self.menu_1.isn = "1";
                                }
                                else {
                                    self.menu_1.isn = "0";
                                }
                                for (var p = 0; p < self.menu_1.children.length; p++) {
                                    self.menu_2 = msg.rows[i].children[k].children[p];//三级菜单
                                    if (k == 0) {//一级栏目路径
                                        msg.rows[i].hrefs = self.listhref(self.menu_2, self.menu_1.NodeName, self.menu_1.ParentID, self.menu_1.NodeID, self.menu_2.NodeID);
                                    }


                                    //三级栏目路径
                                    //
                                    var numcolor = p % 6;
                                    var numicons = p % 4;
                                    self.menu_2.color = self.color[numcolor];
                                    self.menu_2.icons = self.icon[numicons];
                                    self.menu_2.number = p % 3;
                                    //
                                    //三级栏目路径
                                    self.menu_2.hrefs = self.listhref(self.menu_2, self.menu_1.NodeName, self.menu_1.ParentID, self.menu_1.NodeID, self.menu_2.NodeID)
                                    //
                                    if (self.menu_2.children) {//判断是否有下一级
                                        self.menu_2.isn = "1";
                                        //四级级栏目路径
                                        if (self.MenuID != "") {
                                            self.lines3.push();

                                        }
                                        for (var l = 0; l < self.menu_2.children.length; l++) {
                                            self.menu_3 = msg.rows[i].children[k].children[p].children[l];

                                            //
                                            var numcolor = l % 6;
                                            var numicons = l % 4;
                                            self.menu_3.color = self.color[numcolor];
                                            self.menu_3.icons = self.icon[numicons];
                                            self.menu_3.isn = "0";
                                            self.menu_3.number = l % 3;
                                            //
                                            if (self.MenuID == self.menu_2.NodeID || self.MenuID == self.menu_1.NodeID) {
                                                self.lines3.push(self.menu_3);
                                            }
                                            self.menu_3.hrefs = self.listhref(self.menu_3, self.menu_1.NodeName, self.menu_1.ParentID, self.menu_2.NodeID, self.menu_3.NodeID);
                                            if (l == 0) {

                                                self.menu_2.hrefs = self.listhref(self.menu_3, self.menu_1.NodeName, self.menu_1.ParentID, self.menu_2.NodeID, self.menu_3.NodeID);
                                            }
                                        }
                                    }
                                    else {
                                        if (self.MenuID == self.menu_2.NodeID || self.MenuID == self.menu_1.NodeID) {
                                            self.lines3.push(self.menu_2);
                                        }
                                        self.menu_2.isn = "0";

                                    }
                                }
                                if (self.parentid == msg.rows[i].children[k].ParentID) {
                                    self.lines2.push(msg.rows[i].children[k]);

                                }

                            }
                            //   console.log(msg.rows[i])
                            self.lines.push(msg.rows[i]);

                        }
                    }

                    if (self.parentid != "") {
                        $("#tabbar-" + self.parentid).addClass("weui_bar_item_on")
                    }

                    if (self.nodesid == 138) {
                        $(".139").parent().addClass("select");
                    }
                    if (self.nodesid != "") {
                        $("." + self.nodesid).parent().addClass("select");
                    }
                    self.ImgLists();
                    self.touch();

                    $("#menu8").addClass('active');

                }
            }
        });
    }
    self.ImgLists = function () {
        self.url = "";

        if (self.MenuID == "178") {
            self.url = " /api/Weather/WeatherImg/GetProImg/259?parentid=" + self.MenuID;
            self.listload(self.url);
        }
        else if (self.MenuID == "174") {

            self.url = " /api/Weather/WeatherImg/GetProImg/245?parentid=" + self.MenuID;
            self.listload(self.url);
        }
        else {
            self.url = " /api/Weather/WeatherImg/GetImageList/" + self.nodesid;
            self.listload(self.url);
        }
    }
    //栏目滑动效果
    self.touch = function () {

        n = $('.line li a').size();
        self.menuClick();
        if (n > 4) {
            $("#uldiv").show();
            $("#tablediv").hide();
            var wh = 100 * n + "%";
            $('.line').width(wh);
            var lt = (50 / n / 2);
            if (n > 5) {
                lt = (90 / n / 2);
            }

            //var lt_li = lt + "%";
            //$('.line li').width(lt_li);
            var y = 0;
            var w = n / 2;
            $(".line li").each(function (i) {

                if (parseInt(self.nodesid) == parseInt($(this).attr('id'))) {
                    if (i > 2) {

                        y = -(i * 2);
                        $(".line").css({ '-webkit-transform': "translate(" + y + "%)", '-webkit-transition': '500ms linear 0s' });
                    }
                }
            });

            $(".line").swipe({
                swipeLeft: function () {

                    if (y <= -lt * w) {
                        alert('已经到最后页');
                    } else {
                        //alert(-lt*w)
                        y = y - lt;
                        var t = y + "%";

                        $(this).css({ '-webkit-transform': "translate(" + t + ")", '-webkit-transition': '500ms linear' });
                    }
                },
                swipeRight: function () {
                    if (y >= -1) {
                        alert('已经到第一页')
                    } else {
                        y = y + lt;
                        var t = y + "%";
                        $(this).css({ '-webkit-transform': "translate(" + t + ")", '-webkit-transition': '500ms linear' });
                    }

                }
            });
        } else {
            $("#uldiv").hide();
            $("#tablediv").show();

        }

    }
    //栏目切换
    self.menuClick = function () {
        $(".line li,.line td").click(function () {
            nodeId = $(this).children().attr('class');
            self.nodesid = $(this).children().attr('class');

            $(this).addClass("select").siblings().removeClass("select");
            try {

                if (self.nodesid == "114") {
                    self.stationimgtype = "rain";
                }
                else if (self.nodesid == "113") {
                    self.stationimgtype = "temp";
                }
                if (self.nodesid == "139") {
                    self.StationPM("139");
                }
                else if (self.nodesid == "140") {
                    self.StationPM("140");
                }

                self.ImgLists();

                $("#previousbutton").unbind("click");
                $("#nextbutton").unbind("click");
                $("#playbutton").unbind("click");

                self.ImgClick();

            } catch (e) {

            }

        });
    }



}