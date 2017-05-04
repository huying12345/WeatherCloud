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
        self.parentname = "宝山自动站实况" //$.query.get("NodeName")
        self.MenuID = $.query.get("MenuID");
        self.nodesid =  $.query.get("NodeID");
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

    self.menuHref = function (id) {
        alert(id)
    }
    //栏目链接
    self.listhref = function (msg, parentName, parentid, menuid, nodename) {

        self.hrefs = "";
        self.str = "&NodeName=" + parentName + "&ParentID=" + parentid + '&MenuID=' + menuid + '#NodeID=' + nodename;
        if (msg.NodeType == "6") {
            self.hrefs = "/Home/Station?Type=Img" + self.str;
        }
        else if (menuid == '138') {
            self.hrefs = "/Home/StationPM?Type=Img" + self.str;

        }
        else if (msg.NodeType == "1") {
            self.hrefs = "/Home/ImgPlay?Type=Img" + self.str;

        }
        else if (msg.NodeType == "3") {
            self.hrefs = "/Home/TyphoonLine?Type=TyphoonLine" + self.str;
        }
        else if (msg.NodeType == "8") {

            self.hrefs = "/Home/Text?Type=Text" + self.str;
        }
        else if (msg.NodeType == "10") {

            self.hrefs = "/Home/Product?Type=Product" + self.str;
        }
        else {
            self.hrefs = "";
        }

        return self.hrefs;
    }

    //图片播放
    self.listload = function (urls) {

        self.type = "Img"; //$.query.get("Type");

        var district = $(".select a").attr("nodeid");

        var info = "";
        $.ajax({
            url: urls,
            dataType: 'json',
            success: function (msg) {

                self.allimages = msg;

                self.images = ko.observableArray();

                if (self.MenuID != "178" && self.MenuID != "174") {
                    for (var i = 0; i < self.allimages.length; i++) {
                        self.allimages[i].DataTime = self.allimages[i].DataTime.replace(/.*年/, "");
                        self.allimages[i].InfoPath = self.allimages[i].InfoPath;
                        self.images.push(self.allimages[i]);
                    }
                    $("#imgshow").attr("src", self.images()[0].InfoPath);

                    $("#fbsj").html(self.images()[0].DataTime);
                    if (info == "") {
                        $("#imageinfo").parent().hide();
                    }
                    else {
                        $("#imageinfo").parent().show();
                        $("#imageinfo").html('<div style="margin-left:10px; margin-right:10px"><p style="line-height:26px; font-family:宋体">' + info + '</p></div>');
                    }

                }
                else {
                    for (var i = 0; i < self.allimages.length; i++) {
                        self.allimages[i].DataTime = self.allimages[i].DataTime.replace(/.*年/, "");
                        self.allimages[i].InfoPath = self.allimages[i].path + ".gif";
                        self.images.push(self.allimages[i]);
                    }
                    self.listloads();
                }
                self.ImgClick();
            }
        });

    }

    //图片播放1
    self.listloads = function () {
        var info = "";
        self.imageslist = ko.observableArray();

        $.each(self.images(), function (i) {

            if (self.nodesid == self.images()[i].nodeid) {

                self.imageslist.push(self.images()[i]);
            }

        });

        $("#imgshow").attr("src", self.imageslist()[0].InfoPath);

        $("#fbsj").html(self.imageslist()[0].DataTime);
        if (info == "") {
            $("#imageinfo").parent().hide();
        }
        else {
            $("#imageinfo").parent().show();
            $("#imageinfo").html('<div style="margin-left:10px; margin-right:10px"><p style="line-height:26px; font-family:宋体">' + info + '</p></div>');
        }

        //  console.log(self.imageslist())
    }

    //图片切换
    self.ImgClick = function () {
        if (self.MenuID != "178" && self.MenuID != "174") {
            self.array = self.images();
        } else {
            self.array = self.imageslist();
        }
        self.StopGraph(self.array);
        $("#previousbutton").click(function () {

            self.prevImage(self.array)
        });
        $("#nextbutton").click(function () {
            self.nextImage(self.array)
        });
        $("#playbutton").click(function () {
            self.play(100, true, self.array);
        });
    }

    //上一张
    self.nextImage = function (images) {

        if (self.currentPlayindex <= 0) {
            self.currentPlayindex = images.length - 1;
        }
        else {
            self.currentPlayindex--;
        }
        var currentImage = images[self.currentPlayindex];
        document.getElementById("imgshow").src = currentImage.InfoPath;
        $("#fbsj").html(currentImage.DataTime);
        $(".minselect").removeClass("minselect");
        //$("#" + currentImage.type.replace("临近天气", "")).addClass("minselect");
    }
    //下一张
    self.prevImage = function (images) {

        //   console.log(images)
        //   console.log(self.currentPlayindex)
        if (self.currentPlayindex >= images.length - 1) {
            self.currentPlayindex = 0;
        }
        else {
            self.currentPlayindex++;
        }
        var currentImage = images[self.currentPlayindex];
        document.getElementById("imgshow").src = currentImage.InfoPath;
        $("#fbsj").html(currentImage.DataTime);
        $(".minselect").removeClass("minselect");
        //$("#" + currentImage.type.replace("临近天气", "")).addClass("minselect");
    }

    //播放（停止）
    self.play = function (num, restart, images) {

        if (restart) {

            //    console.log(self.timeout+","+1)
            if (self.timeout > 0)
                clearTimeout(self.timeout);
            if ($("#playbutton").attr("src").indexOf("play") >= 0) {

                if (num > images.length) {

                    num = 0;
                }
                //  console.log(5 + "," + num);
                $("#playbutton").attr("src", "/Static/ImgPlay/Images/pause.png");
                self.timeout = setTimeout(function () {
                    self.play(num, false, images);
                }, 500);
            }
            else {
                //   console.log(6);
                $("#playbutton").attr("src", "/Static/ImgPlay/Images//play.png");
            }
        }
        else if (!document.getElementById("imgshow").complete) {
            //  console.log(3);
            self.timeout = setTimeout(function () {
                self.play(num, false, images);
            }, 100);
        }
        else if (num < images.length) {
            //   console.log(32);
            document.getElementById("imgshow").src = images[num].InfoPath;
            $("#fbsj").html(images[num].DataTime);

            num++;
            self.currentPlayindex = num;
            self.timeout = setTimeout(function () {
                self.play(num, false, images);
            }, 1000);

        }
        else {
            //   console.log(2);
            document.getElementById("imgshow").src = images[0].InfoPath;

            $("#fbsj").html(images[0].DataTime);
            $("#playbutton").attr("src", "/Static/ImgPlay/Images//play.png");
            self.timeout = -1;
        }
    }

    self.StopGraph = function (images) {

        document.getElementById("imgshow").src = images[0].InfoPath;

        $("#fbsj").html(images[0].DataTime);
        $("#playbutton").attr("src", "/Static/ImgPlay/Images//play.png");

        if (self.timeout > 0) {
            clearTimeout(self.timeout);
        }
        self.timeout = -1;

    }
    self.stationListArray = ko.observableArray([]);

    //宝山自动站列表
    self.stationList = function () {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStationList?',
            dataType: 'json',
            success: function (msg) {
                self.strs = "";
                for (var i = 0; i < msg.length; i++) {
                    self.strs = msg[i].maxtemp1;

                    if (self.strs == "") {
                        msg[i].rainhidden = "rainhide";

                    }
                    else {
                        msg[i].rainhidden = "";

                    }
                    self.stationListArray.push(msg[i]);

                }
                self.stationClick();

            }
        });
    }

    //宝山自动站曲线图
    self.stationHour = function () {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStationHours/' + self.stationid,
            dataType: 'json',
            success: function (msg) {
                self.hour = new Array();
                self.temp = new Array();
                self.wind = new Array();
                self.windlive = new Array();
                self.name = "";
                self.type = $(".select").attr("id");

                for (var i = 0; i < msg.length; i++) {
                    self.temp.push(parseFloat(msg[i].temperature));
                    self.hour.push(msg[i].hour);
                    self.wind.push(parseFloat(msg[i].winddir));
                    self.windlive.push(parseFloat(msg[i].windlevelinstant));
                }
                var dataX = ["北风", "东北风", "东风", "东南风", "南风", "西南风", "西风", "西北风", "北风", "无风"];
                self._data = new Array();
                for (var k = 0; k < self.wind.length; k++) {

                    self._data.push({ value: self.windlive[k], symbol: '~/Static/Home/Images/g.png' })
                }

                if (self.type == "station-temp") {
                    self.name = "气温(℃)";
                    self.countEchars(self.hour, self.temp, self.name, "line");
                }
                else if (self.type == "station-wind") {
                    self.name = "风向风速(m/s)";
                    self.countEchars(self.hour, self._data, self.name, "line");
                }

            }
        });
    }
    //宝山自动站雨量曲线图
    self.stationRainHour = function () {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStationRainHours/' + self.stationid,
            dataType: 'json',
            success: function (msg) {
                self.hour = new Array();
                self.rain = new Array();
                self.name = "";
                self.type = $(".select").attr("id");

                self.name = "降水量(mm)";

                for (var i = 0; i < msg.length; i++) {
                    self.rain.push(parseFloat(msg[i].rainhour));
                    self.hour.push(msg[i].hour);
                }

                self.countEchars(self.hour, self.rain, self.name, "bar");
            }
        });
    }
    //自动站页面点击事件

    self.stationClick = function () {
        $(".rainhide").hide();
        $(".station-temp").hide();
        $(".station-wind").hide();
        $(".station-rain").hide();
        self.stationtypes ="temp";// $.query.get("stationtype");
        //默认类型
        if (self.nodesid == '113' || self.stationtypes == "temp") {
            $("#station-temp").addClass("select");
            $(".station-temp").show();
            self.stationHour();
        }
        else if (self.nodesid == '114' || self.stationtypes == "rain") {
            $("#station-rain").addClass("select");
            $(".station-rain").show();
            $(".rainhide").show();
            self.stationRainHour();
        }
        else if (self.nodesid == '115' || self.stationtypes == "wind") {

            $("#station-wind").addClass("select");
            $(".station-wind").show();
            self.stationHour();
        }
        else if (self.nodesid == '116' || self.stationtypes == "njd") {
            $("#station-njd").addClass("select");
            //$(".station-njd").show();
            //self.stationHour();
            $("#world-map").hide();
            $("#station-tables").hide();
            $("#nolist").show();
        }

        //导航切换
        self.stationTableClick();
        self.stationDZMClick();
        $("#stationlist tr").click(function () {
            self.stationid = $(this).attr('id');
            if (self.stationtype == "station-rain") {
                self.stationRainHour();
            } else {
                self.stationHour();
            }
            //alert($(this).attr('id'))
        })
    }
    //自动站导航切换
    self.stationTableClick = function () {
        //导航切换
        $(".station-table tr td").click(function () {
            $(this).addClass("select").siblings().removeClass("select")
            $(".station-temp").hide();
            $(".station-wind").hide();
            $(".station-rain").hide();

            self.stationtype = $(this).attr('id')
            if (self.stationtype == "station-rain") {
                self.stationRainHour();
                $(".rainhide").show();
            } else if (self.stationtype == "station-njd") {
                $("#world-map").hide();
                $("#station-tables").hide();
                $("#nolist").show();
            }
            else if (self.stationtype == "station-dzm") {
                location.href = "/Home/StationImgPlay?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "#NodeID=" + self.nodesid;
            }
            else {
                $("#world-map").show();
                $("#station-tables").show();
                $("#nolist").hide();
                $(".rainhide").hide();
                self.stationHour();

            }
            $("." + $(this).attr('id')).show();
        })
    }

    //自动站等值面图导航切换
    self.stationDZMClick = function () {
        $(".stationdzm tr td").click(function () {
            if (self.stationtype == "station-rain") {
                location.href = "/Home/Station?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "&NodeID=" + self.nodesid + "#stationtypes=rain";
            } else if (self.stationtype == "station-njd") {
                location.href = "/Home/Station?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "&NodeID=" + self.nodesid + "#stationtypes=njd";
            }

            else if (self.stationtype == "station-wind") {
                location.href = "/Home/Station?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "&NodeID=" + self.nodesid + "#stationtypes=wind";
            }
            else if (self.stationtype == "station-temp") {
                location.href = "/Home/Station?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "&NodeID=" + self.nodesid + "#stationtype=temp";
            }
            $("." + $(this).attr('id')).show();
        })
    }
    //曲线图Echars
    self.countEchars = function (hour, temp, name, type) {

        var myChart = echarts.init(document.getElementById('world-map'));

        // 指定图表的配置项和数据
        var option = {
            title: {
                text: name,
                textStyle: {
                    color: '#000'
                },
            },
            tooltip: {
                trigger: 'axis'
            },

            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                borderColor: '#000',
                containLabel: true
            },
            toolbox: {
                feature: {
                    saveAsImage: {}
                }
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data: hour,
                axisLine: {
                    show: true,
                    onZero: true,
                    lineStyle: {
                        color: '#000'
                    },
                },
            },
            yAxis: {
                type: 'value',
                axisLine: {
                    //show: true,
                    //onZero: true,
                    lineStyle: {
                        color: '#000'
                    },
                },
            },
            series: [
                {
                    name: name,
                    type: type,
                    smooth: true,//是否曲线
                    stack: name,
                    data: temp,
                    itemStyle: {

                        normal: {

                            color: "#89D300",

                        }
                    }
                }
            ]
        };

        myChart.setOption(option);
    }

    //pm2_5和pm10
    self.StationPM = function (id) {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStaionsPM/',
            dataType: 'json',
            success: function (msg) {

                self.name = "";
                self.pm10 = new Array();
                self.pm2_5 = new Array();
                self.hour = new Array();
                for (var i = 0; i < msg.length; i++) {
                    self.pm10.push(parseFloat(msg[i].pm10));
                    self.pm2_5.push(parseFloat(msg[i].pm2_5));
                    self.hour.push(msg[i].hour);
                }
                if (id == '139') {
                    self.countEchars(self.hour, self.pm2_5, self.name, "line");
                }
                else {
                    self.countEchars(self.hour, self.pm10, self.name, "line");
                }

            }
        });
    }


}