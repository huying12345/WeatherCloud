
var PMViewModel = function () {
    var self = this;
    self.stationid = '58362';
    self.lines3 = ko.observableArray([]);//三级栏目
    self.init = function (parentId) {
        self.StationPM();
    };
    //pm2_5和pm10
    self.StationPM = function (id) {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStaionsPM/',
            dataType: 'json',
            success: function (msg) {

                self.name = "24小时曲线图";
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


}