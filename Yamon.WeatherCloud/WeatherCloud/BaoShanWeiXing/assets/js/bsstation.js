var bsViewModel = function () {
    var self = this;
    self.stationid = '58362';//宝山站号

    self.lines3 = ko.observableArray([]);//三级栏目
    self.stationListArray = ko.observableArray([]);
    self.init = function (parentId) {        
        self.stationList();
    };
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
        //self.stationtypes = "temp";
        self.nodesid = myPage.id;
        //默认类型
        if (self.nodesid == '113' ) {
            $("#station-temp").addClass("select");
            $(".station-temp").show();
            self.stationHour();
        }
        else if (self.nodesid == '114') {
            $("#station-rain").addClass("select");
            $(".station-rain").show();
            $(".rainhide").show();
            self.stationRainHour();
        }
        else if (self.nodesid == '115') {
            $("#station-wind").addClass("select");
            $(".station-wind").show();
            self.stationHour();
        }      

        //导航切换
        self.stationTableClick();
        $("#stationlist tr").click(function () {
            self.stationid = $(this).attr('id');
            if (self.stationtype == "station-rain") {
                self.stationRainHour();
            } else {
                self.stationHour();
            }
        })
    }
    //曲线图Echar
    self.countEchars = function (hour, temp, name, type) {
        var myChart = echarts.init(document.getElementById('world-map'));
        var max = 0, min =0;
        if (self.type == "station-wind") {
            min = temp[0].value;
            for (var i = 0; i < temp.length; i++) {
                if (max < temp[i].value) {
                    max = temp[i].value;
                } else if (min > temp[i].value) { min = temp[i].value; }
            }
        } else {
            min = temp[0];
            for (var i = 0; i < temp.length; i++) {
                if (max < temp[i]) {
                    max = temp[i];
                } else if (min > temp[i]) {
                    min = temp[i];
                }
            }
        }
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
                boundaryGap: true,
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
                type: 'value', scale: true, max:parseInt(max+2), min:parseInt(min-2),
                axisLine: {
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



}

