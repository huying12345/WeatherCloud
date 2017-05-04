var ShStationViewModel = function () {
    var self = this;
    self.stationid = '58362';
    self.id = '';
    self.lines3 = ko.observableArray([]);
    self.stationListArray = ko.observableArray([]);
    self.stationRainArray = ko.observableArray([]);
    self.stationWindArray = ko.observableArray([]);

    self.init = function (parentId) {
        self.stationHour();
        self.nodesid = myPage.id;
        if (self.nodesid == 94) {
            self.stationTempList('adminCodes=310000&staLevels=013');
        } else if (self.nodesid == '96') {
            self.stationRainHour('adminCodes=310000&staLevels=013');
        } else if (self.nodesid == '97') {
            self.stationWindHour('adminCodes=310000&staLevels=013');
        }
        else if (self.nodesid == 123) {
            self.stationTempList('adminCodes=310000,320000,330000&staLevels=013');
        } else if (self.nodesid == '124') {
            self.stationRainHour('adminCodes=310000,320000,330000&staLevels=013');
        } else if (self.nodesid == '125') {
            self.stationWindHour('adminCodes=310000,320000,330000&staLevels=013');
        }
    };
    //全市实况12小时变化曲线图
    self.stationHour = function () {
        $.ajax({
            url: '/api/Weather/Cimiss/GetStationDataByHour12?staIds=' + self.stationid,
            dataType: 'json',
            success: function (msg) {
                self.temp = new Array();
                self.hour = new Array();
                self.wind = new Array();
                self.rain = new Array();
                self.name = "";
                self.type = $(".select").attr("id");
               

                for (var i = msg.data.length-1; i >=0; i--){
                    if (msg.data[i].TEM != 999999) {
                        var timestart = new Date(Date.parse(msg.data[i].Datetime.replace(/-/g, "/"))).getHours();
                        self.temp.push(parseFloat(msg.data[i].TEM));
                        self.hour.push(timestart);
                        self.wind.push(parseFloat(msg.data[i].WIN_S_INST));
                        self.id = msg.data[i].Station_Name;
                        if (msg.data[i].PRE_1h >= 999990){
                            msg.data[i].PRE_1h = 0;
                        }
                        self.rain.push(parseFloat(msg.data[i].PRE_1h));
                    }
                }
                if (self.type == "station-temp"){
                    self.name = "气温（℃）" + self.id;
                    self.countEchars(self.hour, self.temp, self.name, "line");
                } else if (self.type == "station-wind"){
                    self.name = "风速（m/s）"+ self.id;
                    self.countEchars(self.hour, self.wind, self.name, "line");
                } else if (self.type == "station-rain"){
                    self.name = "降水量（mm）"+ self.id;
                    self.countEchars(self.hour, self.rain, self.name, "bar");
                }
            }
        });
    };
    //全市气温列表
    self.stationTempList = function (param){
        $.ajax({
            url: '/api/Weather/Cimiss/GetStationDataHourTem?' + param,
            dataType: 'json',
            success: function (msg) {
                for (var i = 0; i < msg.data.length; i++) {
                    self.stationListArray.push(msg.data[i]);
                }
                self.stationClick();
            }
        });
    };
    //全市风向雨量列表
    self.stationRainHour = function (param) {
        $.ajax({
            url: '/api/Weather/Cimiss/GetStationDataHourPRE?' + param,
            dataType: 'json',
            success: function (msg) {
                for (var i = 0; i < msg.data.length; i++) {
                    self.stationRainArray.push(msg.data[i]);
                }
                self.stationClick();
            }
        });
    };
    //全市风向风速列表
    self.stationWindHour = function (param) {
        $.ajax({
            url: '/api/Weather/Cimiss/GetStationDataHourDS?' + param,
            dataType: 'json',
            success: function (msg) {
                for (var i = 0; i < msg.data.length; i++) {
                    self.stationWindArray.push(msg.data[i]);
                }
                self.stationClick();
            }
        });
    };
    //页面点击事件
    self.stationClick = function () {
        $(".rainhide").hide();
        $(".station-temp").hide();
        $(".station-wind").hide();
        $(".station-rain").hide();
        self.nodesid = myPage.id;
        //气温
        if (self.nodesid == '94' || self.nodesid == '123') {
            $("#station-temp").addClass("select");
            $(".station-temp").show();
            self.stationHour();
        }
            //雨量
        else if (self.nodesid == '96'||self.nodesid == '124') {
            $("#station-rain").addClass("select");
            $(".station-rain").show();
            self.stationHour();
        }
            //相对湿度风
        else if (self.nodesid == '97'||self.nodesid == '125') {
            $("#station-wind").addClass("select");
            $(".station-wind").show();
            self.stationHour();
        }
        //曲线图切换
        self.stationTableClick();

        $("#stationlist tr").click(function () {
            self.stationid = $(this).attr('id');
            self.id = $(this).find('.stationName').text();
            self.stationHour();

        })
    }

    //全市自动站导航切换
    self.stationTableClick = function () {
        //导航切换
        $(".station-table tr td").click(function () {
            $(this).addClass("select").siblings().removeClass("select")
            $(".station-temp").hide();
            $(".station-wind").hide();
            $(".station-rain").hide();

            self.stationtype = $(this).attr('id')

            if (self.stationtype == "station-rain") {
                $(".rainhide").show();
            }
            else if (self.stationtype == "station-pressure") {
                location.href = "/Home/StationImgPlay?Type=Img&NodeName=" + self.parentname + "&ParentID=" + self.parentid + "&MenuID=" + self.MenuID + "#NodeID=" + self.nodesid;
            }
            else {
                $("#world-map").show();
                $("#station-tables").show();
                $("#nolist").hide();
                self.stationHour();
            }
            $("." + $(this).attr('id')).show();
        })
    }

    //曲线图Echarts
    self.countEchars = function (hour, temp, name, type) {
        var myChart = echarts.init(document.getElementById('world-map'));
        var max = 0, min = 0;
        min = temp[0];
        for (var i = 0; i < temp.length; i++) {
            if (max < temp[i]) {
                max = temp[i];
            } else if (min > temp[i]) {
                min = temp[i];
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
                type: 'value', scale: true, max: parseInt(max + 2), min: parseInt(min-2),
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
};


