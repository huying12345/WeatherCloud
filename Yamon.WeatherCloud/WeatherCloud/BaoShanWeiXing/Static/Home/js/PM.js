$(function () {
    var index = new PMViewModel();
    ko.applyBindings(index);
    index.init();
});

var PMViewModel = function () {
    self.init = function () {
        self.stationRainHour();
    };
    self.StationPM = function () {
        $.ajax({
            url: '/api/ZDZ/zdzStation/GetStaionsPM/',
            dataType: 'json',
            success: function (msg) {
        
                self.name = "";
                self.rain = new Array();
                self.hour = new Array();
                for (var i = 0; i < msg.length; i++) {
                    self.rain.push(parseFloat(msg[i].pm2_5));
                    self.hour.push(msg[i].hour);
                }

                self.PMEchars(self.hour, self.rain, self.name, "line");
            }
        });
    }
    self.PMEchars = function (hour, temp, name, type) {

        var myChart = echarts.init(document.getElementById('world-pm'));

        // 指定图表的配置项和数据
        var option = {
            title: {
                text: name,
                textStyle: {

                    color: '#000',

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

                        color: '#000',

                    },

                },
            },
            yAxis: {
                type: 'value',
                axisLine: {

                    //show: true,
                    //onZero: true,
                    lineStyle: {

                        color: '#000',

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