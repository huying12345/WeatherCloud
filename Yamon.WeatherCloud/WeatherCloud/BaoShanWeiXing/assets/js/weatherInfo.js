$(function () {
    var viewModel = new WeatherInfoViewModel();
    ko.applyBindings(viewModel, document.getElementById("weatherPanel"));
    viewModel.init();
})
var WeatherInfoViewModel = function () {
    var self = this;
    self.TMax = '-';
    self.TMin = '-';
    self.weak = '-';
    self.AQI = '-';
    self.Quality = '-';
    self.PreciptationP = '-';
   
    self.stationWeather = ko.observable({
        Station_Name: '',
        TEM: '',
        WIN_D_Avg_1mi: '-',
        WIN_S_Avg_1mi:'-',
        Datetime: '',
        PRE: '',       
        RHU: '',
        TMax: '-',
        TMin: '-',
        weak: '-',
        AQI:'',
        Quality: '-',
        PreciptationP:'-'
    });
    self.nodeWeather = ko.observableArray([]);
    self.tomorrowWeather = ko.observableArray([]);
    self.nodeWeather2 = ko.observableArray([]);
    self.quality = ko.observable({});

    self.init = function () {
        self.TenDayForecastList();
        self.GetStationData();
        self.GetAQI();
    };
    //今明两天天气
    self.GetStationData = function () {
        $.ajax({
            url: '/api/Weather/Cimiss/GetStationDataNowByStaIds',
            dataType: 'json',
            data: { "staIds": 58362 },
            success: function (msg) {
                if (msg.success) {
                    msg.data.TMax = self.TMax;
                    msg.data.TMin = self.TMin;
                    msg.data.weak = self.weak;
                    msg.data.Quality = self.Quality;
                    msg.data.AQI = self.AQI;
                    msg.data.PreciptationP = self.PreciptationP;
                    self.stationWeather(msg.data);
                }
            }
        })
    };
    //空气质量
    self.GetAQI = function () {
        $.ajax({
            url: '/api/Weather/WeatherData/GetAQI',
            dataType: 'json',
            success: function (msg) {
                if(msg.success){
                    self.GetStationData();
                    self.Quality = msg.data.Quality;
                    //.substring(0,1) + msg.data.Quality.substring(2)
                    self.AQI = msg.data.AQI;
                    self.quality(msg.data);

                } else {
                    alert(msg.message);
                }
            }
        })
    };
    
    //十天天气预报
    self.TenDayForecastList = function () {
        $.ajax({
            url: '/api/Weather/WeatherData/TenDayForecastList',
            dataType: 'json',
            success: function (msg) {
                self.GetStationData();
                var maxTemp = [], maxTemp1=[];
                var minTemp = [], minTemp1=[];
             
                for (var i = 0; i < msg.data.length; i++) {
                    if (msg.data[i].TMax != -99999 || msg.data[i].TMin != -99999) {
                        maxTemp.push(msg.data[i].TMax);
                        minTemp.push(msg.data[i].TMin);
                    }
                    else {
                        continue;
                    }
                    if (i == 0) {
                        self.TMax = msg.data[i].TMax;
                        self.TMin = msg.data[i].TMin;
                        self.weak = msg.data[i].weak;
                        self.PreciptationP = msg.data[i].PreciptationP;
                    }
                    if (i == 1) {
                        self.tomorrowWeather.push(msg.data[i]);
                    }
                    if (i < 5) {
                        self.nodeWeather.push(msg.data[i]);
                    } else {
                        self.nodeWeather2.push(msg.data[i]);
                    }
                }
                if(myPage.action == 'weatherInfo') {
                    self.initChart(maxTemp, minTemp,'main');
                }
            }
        })
    };
   
    //气温曲线图
    self.initChart = function (maxTemp, minTemp,id) {
        var myChart = echarts.init(document.getElementById(id));
        var option = {
            tooltip: {
                trigger: 'axis'
            },
            xAxis: {
                show: false,
                type: 'category',
                boundaryGap: false,
                data: []
            },
            yAxis: {
                show: false,
            },
            series: [
                {
                    name: '最高气温',
                    type: 'line',
                    smooth: true,
                    symbolSize:5,
                    symbol: 'circle',
                    showAllSymbol: true,
                    itemStyle: {
                        normal: {
                            color: '#fff',
                            borderWidth: 0.3,
                            label: {
                                show: true,
                                formatter: '{c}°',
                                position: 'top',
                                textStyle: {
                                    fontWeight: '100',
                                    fontSize: '16',
                                    color: '#fff'
                                }
                            },
                            lineStyle: {
                                color: '#fff',
                                width: 2
                            }
                        }
                    },
                    data: maxTemp,
                    markLine: {}
                },
                {
                    name: '最低气温',
                    type: 'line',
                    smooth: true,
                    symbolSize:5,
                    symbol: 'circle',
                    showAllSymbol: true,
                    itemStyle: {
                        normal: {
                            color: '#fff',
                            borderWidth: 0.3,
                            label: {
                                show: true,
                                formatter: '{c}°',
                                position: 'bottom',
                                textStyle: {
                                    fontWeight: '100',
                                    fontSize: '16',
                                    color: '#fff'
                                }
                            },
                            lineStyle: {
                                color: '#fff',
                                width: 2
                            }
                        }
                    },
                    data: minTemp,
                    markLine: {}
                }
            ]
        };
        myChart.setOption(option);
        window.onresize = myChart.resize;
    };
}
