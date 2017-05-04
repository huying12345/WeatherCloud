$(document).ready(function () {


    function getMax(data) {
        tmp = data;
        if (tmp.length > 0) {
            var max = tmp[0];
            for (var i = 1; i < tmp.length; i++) {
                if (max < tmp[i]) max = tmp[i];
            }
            return max + 1;
        }
    }
    function getMin(data) {
        tmp = data;
        if (tmp.length > 0) {
            var min = tmp[0];
            for (var i = 1; i < tmp.length; i++) {
                if (min > tmp[i]) min = tmp[i];
            }
            return min - 10;
        }
    }
    function getHours(dateStr) {
        var myDate = new Date(Date.parse(dateStr.replace(/-/g, "/")))
        var hours = myDate.getHours();
        return hours + "时";
    }
    function showtime() {
        var now = new Date();
        var hours = now.getHours();
        var timeValue = ((hours >= 12) ? "day" : "night")
        return timeValue
    }

    function getWeek(dateStr) {
        var weekDay = ["周日", "周一", "周二", "周三", "周四", "周五", "周六"];
        var myDate = new Date(Date.parse(dateStr.replace(/-/g, "/")));
        return weekDay[myDate.getDay()];
    }

    function getMonth(dateStr) {
        var myDate = new Date(Date.parse(dateStr.replace(/-/g, "/")));
        var day = myDate.getDate();
        var month = myDate.getMonth() + 1;
        return month + "/" + day;
    }

    function getData(result) {
        this.heightdata = [];
        this.lowdata = [];
        this.getHeightData = getHeightData;
        this.getLowData = getLowData;
        function getHeightData() {
            var temper = [];
            if (result) {
                for (var i = 0; i < result.length && i < 5; i++) {
                    var temperRange = result[i].dq_temper;
                    var temperArray = [];
                    temperArray = temperRange.split("-");
                    if (temperArray) {
                        temper.push(parseInt(temperArray[1]));
                    }
                }

            }
            this.heightdata = temper;
        }
        function getLowData() {
            var temper = [];
            if (result) {
                for (var i = 0; i < result.length && i < 5; i++) {
                    var temperRange = result[i].dq_temper;
                    var temperArray = [];
                    temperArray = temperRange.split("-");
                    if (temperArray) {
                        temper.push(parseInt(temperArray[0]));
                    }
                }

            }
            this.lowdata = temper;
        }

    }


    var dw = document.documentElement.clientWidth;
    var ch = document.documentElement.clientHeight;
    var srceen = screen.height;
    var dh = dw * 1;
    
    $(".first_screen").css({ width: dw, height: srceen });
    $("#wrzs").css({ width: dw, height: 120 });
    $("#zs").css({ width: dw, height: 140 });
    function getEchars(obj, airdata, airmax, airmin) {
        var myChart = echarts.init(obj, "theme");
        option = {
            calculable: false,
            grid: {
                x: dw * 0.1,
                y: 20,
                x2: 10,
                y2: 0,
                width: dw * 0.8,
                height: 50,
                borderWidth: 0
            },
            xAxis: [
                   {
                       type: 'category',
                       boundaryGap: false,
                       splitArea: { show: false },
                       splitNumber: 0,
                       data: ['', '', '', '', '', ''],
                       splitLine: { show: false },
                       axisLabel: {
                           interval: 0,
                           textStyle: { fontSize: 12, color: '#fff', fontFamily: "Arial, Verdana, sans-serif", fontWeight: "lighter" }
                       },
                       axisLine: {
                           lineStyle: {
                               color: "#fff",
                               width: 0
                           }
                       },
                       axisTick: {
                           show: false
                       }
                   }
            ],
            yAxis: [
                   {
                       type: 'value',
                       boundaryGap: false,
                       splitArea: { show: false },
                       splitLine: { show: false },
                       splitNumber: 0,
                       min: airmin,
                       max: airmax,
                       axisLabel: {
                           show: false,
                           formatter: '{value}',
                           textStyle: {
                               fontSize: 12,
                               color: '#fff',
                               fontFamily: "Arial, Verdana, sans-serif",
                               fontWeight: "lighter"
                           }
                       },
                       axisLine: {
                           show: false
                       },
                       axisTick: {
                           show: false
                       }
                   }
            ],

            series: [
                {
                    name: 'zs',
                    type: 'line',
                    smooth: true,
                    color: '#ffffff',
                    itemStyle: {
                        normal: {
                            color: '#75e719',
                            lineStyle: {
                                color: '#f96126',
                                width: 1
                            },
                            label: {
                                show: true,
                                textStyle: {
                                    color: '#fff',
                                }
                            }
                        }
                    },
                    data: airdata,
                    symbol: "circle"
                }
            ]
        };
        myChart.setOption(option);
    }

    function getzxEchars(obj, data1, data2, wcmax, wcmin) {
        var myChart = echarts.init(obj, "macarons");
        option = {
            calculable: false,
            grid: {
                x: 25,
                y: 10,
                x2: 10,
                y2: 10,
                width: dw * 0.85,
                height: 140,
                borderWidth: 0
            },
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: false,
                    splitArea: { show: false },
                    splitNumber: 3,
                    show: false,
                    data: ['', '', '', '', '', ''],
                    splitLine: { show: false },
                    axisLabel: {
                        interval: 0,
                        textStyle: { fontSize: 12, color: '#fff', }
                    },
                    axisLine: {
                        lineStyle: {
                            color: "#fff",
                            width: 1
                        }
                    },
                    axisTick: {
                        show: false
                    }
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    boundaryGap: false,
                    splitArea: { show: false },
                    splitLine: { show: false },
                    splitNumber: 0,
                    min: wcmin,
                    max: wcmax,
                    axisLabel: {
                        show: false,
                        formatter: '{value}',
                        textStyle: { fontSize: 12, color: '#fff', fontFamily: "Arial, Verdana,sans-serif", fontWeight: "lighter" }
                    },
                    axisLine: {
                        show: false
                    },
                    axisTick: {
                        show: false
                    }
                }
            ],
            series: [
                {
                    name: '今天',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: '#ffffff',
                            lineStyle: {
                                color: '#ffffff',
                                width: 1
                            },
                            label: {
                                show: true,
                                formatter: '{c} °C',
                                textStyle: {
                                    color: '#ffffff',
                                }
                            }
                        }
                    },
                    data: data2
                },
                {
                    name: '温度',
                    type: 'line',
                    itemStyle: {
                        normal: {
                            color: '#ffffff',
                            lineStyle: {
                                color: '#ffffff',
                                width: 1
                            },
                            label: {
                                show: true,
                                position: "bottom",
                                formatter: '{c} °C',
                                textStyle: {
                                    color: '#ffffff',
                                }
                            }
                        }
                    },
                    data: data1,
                }
            ]
        };
        myChart.setOption(option);
    }

    $(".arrow").click(function () {
        $(".arrow").hide();
        $(window).scrollTop(srceen);
    });

    $(window).scroll(function () {
        if ($(window).scrollTop() == 0) {
            $(".arrow").show();
        }
        if ($(window).scrollTop() > 100) {
            $(".arrow").hide();
        }
    });

    var watchID;
    var geoLoc;
    var cityid = "";
    var token = "";
    var city = $("city").html();
    var openid = "";
   // getDSUpdate();
    getcityweather('31.19', '121.43');

    function getDatestr(date) {
        var myDate = new Date(Date.parse(date.replace(/-/g, "/")));
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        var day = myDate.getDate();
        var hours = myDate.getHours();
        var min = myDate.getMinutes();
        if (hours < 10) {
            hours = "0" + hours;
        }
        if (min < 10) {
            min = "0" + min;
        }
        return year + " 年 " + month + " 月 " + day + " 日 " + hours + " : " + min
    }
    //风向转换
    function windDirectionData(WindDirections) {
        var wind; var num;
        var d = [0, 0x2d, 90, 0x87, 180, 0xe1, 270, 0x13b, 360];
        var s = ["北风", "东北风", "东风", "东南风", "南风", "西南风", "西风", "西北风", "北风", "无风"];
        var direction = WindDirections;
        if (direction == "") {
            direction = "0";
        }
        for (var t = 0; t < 9; t++) {
            if (Math.abs(parseInt(direction) - d[t]) <= 22.5) {
                wind = s[t]
            }
        }
        return wind;
    }
    //预报时间
    function dateFarset(date){
        var myDate = new Date(Date.parse(date.replace(/-/g, "/")));
        var hours = myDate.getHours();
        var hoursthree = hours + 3;
        if (hours < 10) {
            hours = "0" + hours;
        }
        if (hoursthree < 10) {
            hoursthree = "0" + hoursthree;
        }
        return hours + "-" + hoursthree+"时预报:";
    }

    //三小时精细化预报天气图标
    function iconWeather(obj) {
        var str = "";
        if (obj.weather.indexOf("到") > 0) {
            var index = obj.weather.indexOf("到");
            str = "<img src='/Static/images/btqbg/" + obj.weather.substring(0, index) + ".png'>" + "<img src='/Static/images/btqbg/" + obj.weather.substring(index + 1) + ".png'>";
        } else if (obj.weather.indexOf("或") > 0) {
            var index = obj.weather.indexOf("或");
            str = "<img src='/Static/images/btqbg/" + obj.weather.substring(0, index) + ".png'>"
        }else {
            str = "<img src='/Static/images/btqbg/" + obj.weather + ".png'>";
        }
        return str;
    }
    function temperatureFromat(temp) {

        var tempList = temp.split("-");
        return tempList[0] + "<span>°C</span>" + " - " + tempList[1] + "<span>°C</span>";
    }
    //function showDS(position) {
    //    var lat = position.coords.latitude;
    //    var lon = position.coords.longitude;
    //    getcityweather(lat, lon);
    //}
    //function errorHandler(error) {
    //    getcityweather(0, 0);
    //}
    //function getDSUpdate() {
    //    if (navigator.geoDS) {
    //        navigator.geoDS.getCurrentPosition(showDS, errorHandler,
    //            { enableHighAccuracy: true, timeout: 5000, maximumAge: 3000 });
    //    } else {
    //        $("city").html("获取位置信息超时");
    //        alert("获取位置信息超时");           
    //    }
    //}
    //function oauthshow(res) {
    //    if (res == 0) {
    //        $('body').on('touchstart', function (e) {
    //            $(".ewm_popup").show();
    //        });
    //    }
    //}
    function getcityweather(lat, lon) {
        $("city").html("请稍后...");
        $.ajax({
            type: "post",
            url: "/Home/getLiveweather?",
            dataType: "JSON",
            success: function (res) {
                $("city").html("最近站点:" + res.DS[0].Station_Name);
                $(".first_screen_top p").html("发布:" + toLocale(res.DS[0].Datetime).toLocaleString());
                $(".first_screen_center .temp_div li").eq(0).find("p").html(res.DS[0].TEM + "<span>°C</span>");
             //   $(".first_screen_center .temp_div li").eq(1).html(dateFarset(res.yb["datatime"]) + iconWeather(res.yb) + res.yb["weather"] + "&nbsp;&nbsp;" + temperatureFromat(res.yb["temp"]));
                $("#humidity").text(res.DS[0].RHU == 999999 ? '--' : res.DS[0].RHU + " %");
                $("#airpress").text(res.DS[0].PRS == 999999 ? '--' : res.DS[0].PRS + " hPa");
                $("#wind").text(windDirectionData(res.DS[0].WIN_D_Avg_1mi));
                $("#windNum").text(res.DS[0].WIN_S_Avg_1mi);
                
            }
        });
    }

   

})
function toLocale(dstr) {

    var date = new Date(dstr);

    var hour = date.getHours();

    var h = hour + 8;
    date.setHours(h);

    return date;
}