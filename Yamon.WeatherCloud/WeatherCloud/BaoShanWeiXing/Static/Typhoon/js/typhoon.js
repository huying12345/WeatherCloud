var EARTH_RADIUS = 6378.1370;
var currfeauterLayer = L.featureGroup();
var map;
var xmlHttpRequest;

function addTileMap() {
    getLocation();
    map = L.map("mapid");
    L.tileLayer('http://webrd0{s}.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x={x}&y={y}&z={z}', {
        subdomains: ["1", "2", "3", "4"],
        maxZoom: 14,
        minZoom: 3
    }).addTo(map);
    map.on('zoomend', onMapLevelChange);
    map.setView([30, 120], 4);
    drawWarningLine();
}

function getyear() {
    $.ajax({
        cache: false,
        type: "Post",
        url: "/api/Weather/Typhoon/GetByYear",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (list) {
           
            for (var i = 0; i < list.length; i++) {
                var $con = $("#yearlist");
                var html = '<div class="weui_actionsheet_cell" onclick="changeyear(this)">' + list[i].year + '</div>';
                $con.append(html);
            }
            $("#year").text(list[0].year);
            tablechange();
        }
    });
}

function yearshow() {
    $("#actionSheet_wrap").show();
    $('#weui_actionsheet').addClass('weui_actionsheet_toggle');
}

function yearback() {
    $("#actionSheet_wrap").hide();
    $('#weui_actionsheet').removeClass('weui_actionsheet_toggle');
}

function changeyear(obj) {
    $("#year").text($(obj).text());
    tablechange();
    $("#actionSheet_wrap").hide();
}

$(document).ready(function () {
    addTileMap();
    getyear();
    getcurrenttyphoon();

    $("#tftuliShow-icon").toggle(function () {
        $("#tylegend").fadeIn();
        $("#tftuliShow-icon").addClass("tuliselect");
    }, function () {
        $("#tylegend").fadeOut();
        $("#tftuliShow-icon").removeClass("tuliselect");
    });

    $("#tuliclose").toggle(function () {
        $("#tylegend").fadeOut();
        $("#tftuliShow-icon").removeClass("tuliselect");
    }, function () {
        $("#tylegend").fadeOut();
        $("#tftuliShow-icon").removeClass("tuliselect");
    });

    $("#tflistShow-icon").toggle(function () {
        $("#typhoontable").fadeIn();
    }, function () {
        $("#typhoontable").fadeIn();
    });

    $("#tytableclose").toggle(function () {
        $("#typhoontable").fadeOut();
    }, function () {
        $("#typhoontable").fadeOut();
    });

    $("#tfhistoryShow-icon").toggle(function () {
        $("#tyhistory").fadeIn();
        $("#tfhistoryShow-icon").addClass("historyselect");
    }, function () {
        $("#tyhistory").fadeIn();
        $("#tfhistoryShow-icon").addClass("historyselect");
    });

    $("#currentty-icon").toggle(function () {
        window.location.reload();
    }, function () {
        window.location.reload();
    });

    $("#search").toggle(function () {
        getsearchid();
        removeallTyphoon();
        $("#tynametitle").empty();
        $("#tabletab").empty();
        var id = $("#searchtyphoonid").text().split("_");
      
        for (var i = 0; i < id.length - 1; i++) {
            drawtyphoonbyid(id[i]);
        }
        $("#tyhistory").fadeOut();
        $("#tfhistoryShow-icon").removeClass("historyselect");
        var code_Values = $('tr[class="currentselect"]');
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                $(code_Values[i]).removeClass("currentselect");
            }
        }
    }, function () {
        getsearchid();
        removeallTyphoon();
        $("#tynametitle").empty();
        $("#tabletab").empty();
        var id = $("#searchtyphoonid").text().split("_");
        for (var i = 0; i < id.length - 1; i++) {
            drawtyphoonbyid(id[i]);
        }
        $("#tyhistory").fadeOut();
        $("#tfhistoryShow-icon").removeClass("historyselect");
        var code_Values = $('tr[class="currentselect"]');
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                $(code_Values[i]).removeClass("currentselect");
            }
        }
    });

    $("#back").toggle(function () {
        clearsearch();
        $("#tyhistory").fadeOut();
        $("#tfhistoryShow-icon").removeClass("historyselect");
    }, function () {
        clearsearch();
        $("#tyhistory").fadeOut();
        $("#tfhistoryShow-icon").removeClass("historyselect");
    });

    $("#toolbarclose").toggle(function () {
        $("#toolbar").fadeOut();
        $("#toolbarhide").show();
    }, function () {
        $("#toolbar").fadeOut();
        $("#toolbarhide").show();
    });

    $("#toolbarshow").toggle(function () {
        $("#toolbar").fadeIn();
        $("#toolbarhide").hide();
    }, function () {
        $("#toolbar").fadeIn();
        $("#toolbarhide").hide();
    });
});

function getcurrenttyphoon() {
    $.ajax({
        cache: false,
        type: "Post",
        url: "/api/Weather/Typhoon/GetCurrentTyphoon",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (list) {
            
            if (list.length !== 0) {
                for (var i = 0; i < list.length; i++) {
                   
                    TyphoonDetail(list[i]);
                    showTyphooninfo(list[i]);
                    drawTyphoon(list[i]);
                }
            } else {
                $("#container").append('<div id="notf"><img src="/Static/Typhoon/images/notf.png" /></div>');
            }
        }
    });
}

function drawWarningLine() {
    var forcastLineGroup = L.layerGroup([]);
    var WarningPointArray_24 = new Array();
    WarningPointArray_24.push(L.latLng(0, 105));
    WarningPointArray_24.push(L.latLng(4.5, 113));
    WarningPointArray_24.push(L.latLng(11, 119));
    WarningPointArray_24.push(L.latLng(18, 119));
    WarningPointArray_24.push(L.latLng(22, 127));
    WarningPointArray_24.push(L.latLng(34, 127));
    var WarningPointArray_48 = new Array();
    WarningPointArray_48.push(L.latLng(0, 105));
    WarningPointArray_48.push(L.latLng(0, 120));
    WarningPointArray_48.push(L.latLng(15, 132));
    WarningPointArray_48.push(L.latLng(34, 132));
    forcastLineGroup.addLayer(L.polyline(WarningPointArray_24, { color: '#FFFF00', weight: 2 }));
    forcastLineGroup.addLayer(L.polyline(WarningPointArray_48, { color: '#0000FF', weight: 2 }));
    var Icon_24 = L.icon({
        iconUrl: '/Static/Typhoon/images/hour24.png',
        iconSize: [15, 89],
        iconAnchor: [22, 94],
        popupAnchor: [-3, -76],
        shadowSize: [68, 95],
        shadowAnchor: [22, 94]
    });

    var Icon_48 = L.icon({
        iconUrl: '/Static/Typhoon/images/hour48.png',
        iconSize: [15, 89],
        iconAnchor: [22, 94],
        popupAnchor: [-3, -76],
        shadowSize: [68, 95],
        shadowAnchor: [22, 94]
    });
    forcastLineGroup.addLayer(L.marker(L.latLng(28, 127), { icon: Icon_24 }));
    forcastLineGroup.addLayer(L.marker(L.latLng(25, 132), { icon: Icon_48 }));
    currfeauterLayer.addLayer(forcastLineGroup).addTo(map);
}

function drawTyphoon(json) {
    if (document.getElementById("notf")) {
        $("#notf").remove();
    }
    var jsonArray = json.points;
    var nodeIco = L.icon({
        iconUrl: "/Static/Typhoon/images/rotate.gif",
        iconSize: [32, 32],
        iconAnchor: [17, 17]
    });
    var lastMarker = L.marker([], { icon: nodeIco });
    var style = { color: '#ff0000', weight: 2, fillColor: "#ff8c00" };
    var level7Circle = L.circle([], 200, style);
    var level10Circle = L.circle([], 200, style);
    var level12Circle = L.circle([], 200, style);
    var typhoonLayer = L.layerGroup()
    typhoonLayer.typoonId = json.tfbh;
    var count = 0, T;
    function drawDynamicTyphoon() {
        var jsonArray = json.points;
        if (count < jsonArray.length) {
            var currArray = jsonArray[count], polyline;
            var lat = L.latLng(currArray.latitude, currArray.longitude);
            lastMarker = lastMarker.setLatLng(lat).addTo(map);
            var currColor = GetPointColor(currArray.speed);
            var circleIco = new MyCustomMarker(lat, { color: currColor, weight: 1, fillColor: currColor, fillOpacity: 1 }).addTo(map);
            var pophtml = getTyphoonPoupeText(currArray);
            circleIco.setRadius(4).bindPopup(pophtml, {
                showOnMouseOver: !0,
                closeButton: !1,
            });
            var circleIco2 = L.circleMarker(lat, { color: currColor, weight: 0, fillColor: currColor, fillOpacity: 0 }).addTo(map);
            circleIco2.setRadius(30).bindPopup(pophtml, {
                showOnMouseOver: !0,
                closeButton: !1,
            });

            if (count != 0) {
                var count1 = -1;
                for (var k = jsonArray.length - 1; k >= 0; k--) {
                    if (jsonArray[k].forecast != null) {
                        if (count1 == -1) {
                            count1 = k;
                        }
                    }
                };
                var lanArray = new Array();
                lanArray.push([jsonArray[count - 1].latitude, jsonArray[count - 1].longitude]);
                lanArray.push([currArray.latitude, currArray.longitude]);
                polyline = L.polyline(lanArray, { color: currColor, weight: 3 }).addTo(map).bringToBack();
                typhoonLayer.addLayer(polyline);
                level7Circle.setLatLng(lat).setRadius(currArray.radius7 * 1000);
                level10Circle.setLatLng(lat).setRadius(currArray.radius10 * 1000);
                level12Circle.setLatLng(lat).setRadius(currArray.radius12 * 1000);
                if (count == count1) {
                    var ybArray = currArray.forecast;
                    lastMarker.bindPopup(pophtml, {
                        showOnMouseOver: !0,
                        closeButton: !1,
                    });
                    if (ybArray) {
                        for (var i = 0; i < ybArray.length; i++) {
                            setting = ybArray[i].sets;
                            if (setting == "美国" || setting == "日本" || setting == "中国" || setting == "中国香港" || setting == "中国台湾" || setting == "韩国") {
                                drawYBTyoon(typhoonLayer, currArray.time, setting, lat, ybArray[i].points);
                                for (var n = 0; n < ybArray[0].points.length; n++) {
                                    var myIcon = L.divIcon({ iconSize: [0, 0], iconAnchor: [-8, 7], className: 'nameborder', html: '<span class="hdli">' + ybArray[0].points[n].time.replace(/T/g, " ").replace(/:00$/g, " ").replace(/^\d+-/g, " ") + '</span>' });
                                    var divmarker = L.marker([ybArray[0].points[n].latitude, ybArray[0].points[n].longitude], { icon: myIcon }).addTo(map);
                                    typhoonLayer.addLayer(divmarker);
                                }
                            }
                        }
                    }
                }
            } else {
                var myIcon = L.divIcon({ iconAnchor: [-16, 8], className: 'tycontitl', html: '<span class="tymm"><span class="tymmle"></span><span class="tymmri"></span>' + json.tfbh + json.name + '</span>' });
                var divmark = L.marker(lat, { icon: myIcon }).addTo(map);
                level7Circle.setLatLng(lat).setRadius(currArray.radius7 * 1000).addTo(map);
                level10Circle.setLatLng(lat).setRadius(currArray.radius10 * 1000).addTo(map);
                level12Circle.setLatLng(lat).setRadius(currArray.radius12 * 1000).addTo(map);
                typhoonLayer.addLayer(lastMarker).addLayer(divmark).addLayer(level7Circle).addLayer(level10Circle).addLayer(level12Circle);
            }
            typhoonLayer.addLayer(circleIco);
            typhoonLayer.addLayer(circleIco2);
            count++;
        } else {
            return;
        }
    }
    T = setInterval(function () { drawDynamicTyphoon() }, 1);
    currfeauterLayer.addLayer(typhoonLayer);
}

function drawYBTyoon(typhoonLayer, btime, setting, lastLan, array) {
    var color = getYBColor(setting);
    setting = getGJName(setting);
    for (var i = 0; i < array.length; i++) {
        var currArray = array[i], polyline;
        var lat = L.latLng(currArray.latitude, currArray.longitude);
        var currColor = GetPointColor(currArray.speed);
        var circleIco = new MyCustomMarker(lat, { color: currColor, weight: 1, fillColor: currColor, fillOpacity: 1 }).addTo(map);;
        var pophtml = getybTyphoonPoupeText(btime, setting, currArray);
        circleIco.setRadius(4).bindPopup(pophtml, {
            showOnMouseOver: !0,
            closeButton: !1,
        });
        var circleIco2 = L.circleMarker(lat, { color: currColor, weight: 0, fillColor: currColor, fillOpacity: 0 }).addTo(map);
        circleIco2.setRadius(30).bindPopup(pophtml, {
            showOnMouseOver: !0,
            closeButton: !1,
        });
        var lanArray = new Array();
        if (i == 0) {
            lanArray.push(lastLan);
            lanArray.push([currArray.latitude, currArray.longitude]);
        } else {
            lanArray.push([array[i - 1].latitude, array[i - 1].longitude]);
            lanArray.push([currArray.latitude, currArray.longitude]);
        }
        polyline = L.polyline(lanArray, { color: color, dashArray: "10,5", weight: 3 }).addTo(map).bringToBack();
        typhoonLayer.addLayer(polyline);
        typhoonLayer.addLayer(circleIco);
        typhoonLayer.addLayer(circleIco2);
    }
}



function getYBColor(source) {
    var color = "";
    if (source == "美国")
        color = "#ff8c00";
    else if (source == "日本")
        color = "#2B4678";
    else if (source == "中国")
        color = "#ff0000";
    else if (source == "中国香港")
        color = "#ffff00";
    else if (source == "中国台湾")
        color = "#3C7832";
    return color;
}


function getGJName(name) {
    if (name == "中国")
        return "中央气象台";
    else
        return name;
}

function GetPointColor(speed) {
    var b;
    if (speed >= 10.8 && speed < 17.1)
        b = "#00D5CB";
    else if (speed >= 17.1 && speed < 24.4)
        b = "#FCFA00";
    else if (speed >= 24.4 && speed < 32.6)
        b = "#FDAE0D";
    else if (speed >= 32.6 && speed < 41.4)
        b = "#FB3B00";
    else if (speed >= 41.5 && speed < 50.9)
        b = "#FC4d80";
    else if (speed >= 50.9)
        b = "#C2218E"
    else
        b = "#000000"
    return b
}

function TyphoonDetail(json) {
    var jsonArray = json.points;
    var html = "";
    var $con = $("#info");
    var tabhtml = '<li id="' + json.tfbh + '" style="" onclick="tabclick(this)">' + json.name + '(' + json.ename + ')' + '</li>';
    $("#tabletab").append(tabhtml);
    $("#currentinfo").find("tr:gt(0)").remove();
    $("#currentinfo").append('<tr><td>' + json.tfbh + '</td><td>' + json.name + '</td><td>' + json.ename + '</td><tr>');
    for (var i = jsonArray.length - 1; i >= 0; i--) {
        html += '<tr value ="' + jsonArray[i].longitude + ',' + jsonArray[i].latitude + '" time ="' + jsonArray[i].time.replace(/T/g, " ").replace(/:00$/g, " ").replace(/^\d+-/g, " ") + '" onclick = "infoclick(this)"><td>' + jsonArray[i].time.replace(/T/g, " ").replace(/:00$/g, " ").replace(/^\d+-/g, " ") + '</td><td>' + jsonArray[i].pressure + '</td><td>' + jsonArray[i].power + '</td><td>' + jsonArray[i].longitude + '°E</td><td>' + jsonArray[i].latitude + '°N</td><tr>';
    };
    $con.find("tr:gt(0)").remove();
    $con.append(html);
}
function tabletyphoonde(json) {
    var jsonArray = json.points;
    var html = "";
    var $con = $("#info");
    $("#currentinfo").find("tr:gt(0)").remove();
    $("#currentinfo").append('<tr><td>' + json.tfbh + '</td><td>' + json.name + '</td><td>' + json.ename + '</td><tr>');
    for (var i = jsonArray.length - 1; i >= 0; i--) {
        html += '<tr><td>' + jsonArray[i].time.replace(/T/g, " ").replace(/:00$/g, " ").replace(/^\d+-/g, " ") + '</td><td>' + jsonArray[i].pressure + '</td><td>' + jsonArray[i].power + '</td><td>' + jsonArray[i].longitude + '°E</td><td>' + jsonArray[i].latitude + '°N</td><tr>';
    };
    $con.find("tr:gt(0)").remove();
    $con.append(html);
    for (var i = jsonArray.length - 1; i > jsonArray.length - 2; i--) {
        map.setView([jsonArray[i].latitude, jsonArray[i].longitude], 4);
    }
}

MyCustomMarker = L.CircleMarker.extend({
    //a为html文本
    bindPopup: function (a, b) {
        b && b.showOnMouseOver && (L.CircleMarker.prototype.bindPopup.apply(this, [a, b]), this.off("click", this.openPopup, this), this.on("mouseover",
        function (a) {
            var c = a.originalEvent.fromElement || a.originalEvent.relatedTarget,
            d = this._getParent(c, "leaflet-popup");
            return d == this._popup._container ? !0 : (this.getRadius() >= 5 ? this.setRadius(10) : this.setRadius(7), this.openPopup(), null != b.latlng, void 0)
        },
        this), this.on("mouseout",
        function (a) {
            var c = a.originalEvent.toElement || a.originalEvent.relatedTarget;
            return this._getParent(c, "leaflet-popup") ? (L.DomEvent.on(this._popup._container, "mouseout", this._popupMouseOut, this), !0) : (this.getRadius() > 7 ? this.setRadius(6) : this.setRadius(4), null != b.latlng, this.closePopup(), void 0)
        },
        this))
    },
    _popupMouseOut: function (a) {
        this.getRadius() > 7 ? this.setRadius(6) : this.setRadius(4),
        L.DomEvent.off(this._popup, "mouseout", this._popupMouseOut, this);
        var b = a.toElement || a.relatedTarget;
        return this._getParent(b, "leaflet-popup") ? !0 : b == this._icon ? !0 : (this.closePopup(), void 0)
    },
    _getParent: function (a, b) {
        try {
            for (var c = a.parentNode; null != c;) {
                if (c.className && L.DomUtil.hasClass(c, b)) return c;
                c = c.parentNode
            }
            return !1
        } catch (d) {
            return !1
        }
    }
})

function getTyphoonPoupeText(currArray) {
    var pophtml = "<div class='popdecon'>";
    pophtml += '<p>时间：' + currArray.time.replace(/T/g, " ") + '</p>';
    pophtml += '<p>中心位置：' + currArray.longitude + '°E|' + currArray.latitude + '°N</p>';
    pophtml += '<p>最大风速：' + currArray.speed + 'm/s</p>';
    pophtml += '<p>强度：' + (currArray.strong ? currArray.strong : '--') + '</p>';
    pophtml += '<p>中心气压：' + (currArray.pressure ? currArray.pressure : '--') + 'Pa</p>';
    pophtml += '<p>移动速度：' + (currArray.move_speed ? currArray.move_speed : '--') + 'm/s</p>';
    pophtml += '<p>移动方向：' + (currArray.move_dir ? currArray.move_dir : '--') + '</p>';
    pophtml += '<p>七级风圈半径：' + (currArray.radius7 ? currArray.radius7 : '--') + 'km</p>';
    pophtml += '<p>十级风圈半径：' + (currArray.radius10 ? currArray.radius10 : '--') + 'km</p>';
    pophtml += '<p>十二级风圈半径：' + (currArray.radius12 ? currArray.radius12 : '--') + 'km</p>';
    pophtml += '</div>';
    return pophtml;
}

function getybTyphoonPoupeText(ybtime, setting, currArray) {
    var pophtml = "<div class='popdecon'>";
    pophtml += '<div><p>起报时间：' + ybtime.replace(/T/g, " ") + '</p>';
    pophtml += '<p>到达时间：' + currArray.time.replace(/T/g, " ") + '</p>';
    pophtml += '<p>中心位置：' + currArray.longitude + '°E|' + currArray.latitude + '°N</p>';
    pophtml += '<p>最大风速：' + currArray.speed + 'm/s</p>';
    pophtml += '<p>强度：' + (currArray.strong ? currArray.strong : '--') + '</p>';
    pophtml += '<p>中心气压：' + (currArray.pressure ? currArray.pressure : '--') + 'Pa</p>';
    pophtml += '<p>移动速度：' + (currArray.move_speed ? currArray.move_speed : '--') + 'm/s</p>';
    pophtml += '<p>移动方向：' + (currArray.move_dir ? currArray.move_dir : '--') + '</p>';
    pophtml += '<p>七级风圈半径：' + (currArray.radius7 ? currArray.radius7 : '--') + 'km</p>';
    pophtml += '<p>十级风圈半径：' + (currArray.radius10 ? currArray.radius10 : '--') + 'km</p>';
    pophtml += '<p>十二级风圈半径：' + (currArray.radius12 ? currArray.radius12 : '--') + 'km</p>';
    pophtml += '</div>';
    return pophtml;
}

function removeSelectTypoon(id) {
    currfeauterLayer.eachLayer(function (layer) {
        if (layer.typoonId == id)
            layer.eachLayer(function (sulayer) {
                map.removeLayer(sulayer);
            })
    })
}
function removeallTyphoon() {
    currfeauterLayer.eachLayer(function (layer) {
        layer.eachLayer(function (sulayer) {
            map.removeLayer(sulayer);
        })
    })
}

function tablechange() {
    var year = $("#year").text();
    $.ajax({
        cache: false,
        type: "Post",
        url: "/api/Weather/Typhoon/GetTyphoonByYear/" + year,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (list) {
          
            var $con = $("#list");
            $con.find("tr:gt(0)").remove();
            var html = "";
            for (var i = 0; i < list.length; i++) {
                html += '<tr onclick="select(this)"><td><input type="checkbox" name="check" style="display:none" onchange="typhoon(this)"/></td><td>' + list[i].tfbh + '</td><td>' + list[i].name + '</td><td>' + list[i].ename + '</td></tr>';
            }
            $con.append(html);
        }
    });
};

//历史台风选择
function select(obj) {
    $(obj).addClass("currentselect")
    var s = $(obj).children("td").eq(0).children(":first");
    var ss = s[0].checked.toString();
    if ($(obj).css("background-color") == "rgba(0, 0, 0, 0)") {
        obj.style.background = '#6495ED';
        obj.style.color = '#fff';
        obj.id = "historytr";
        if (ss == "false") {
            $(s[0]).attr("checked", true);
        }
    }
    else if ($(obj).css("background-color") == "rgb(100, 149, 237)") {
        obj.style.background = '#fff';
        obj.style.color = '#000';
        obj.id = "";
        if (ss == "true") {
            $(s[0]).attr("checked", false);
            $(obj).removeClass("currentselect");
        }
    }
    else if ($(obj).css("background-color") == "rgb(255, 255, 255)") {
        obj.style.background = '#6495ED';
        obj.style.color = '#fff';
        obj.id = "historytr";
        if (ss == "false") {
            $(s[0]).attr("checked", true);
        }
    }
    var k = 0;
    var tr_Values = $('tr[id="historytr"]');
    if (tr_Values) {
        for (var i = 0; i < tr_Values.length; i++) {
            k++;
        }
        if (k > 3) {
            $('#dialog2').show();
        }
    };
}

function drawtyphoonbyid(id) {
 
    $.ajax({
        cache: false,
        type: "Post",
        url: "/api/Weather/Typhoon/GetTyphoonByID/"+id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            drawTyphoon(json[0]);
            TyphoonDetail(json[0]);
        }
    });
}

function clearsearch() {
    $("searchtyphoonid").empty();
    var code_Values = $('tr[class="currentselect"]');

    if (code_Values.length) {
        for (var i = 0; i < code_Values.length; i++) {
            $(code_Values[i]).removeClass("currentselect");
            select(code_Values[i]);
            var s = $(code_Values[i]).children("td").eq(0).children(":first");
            s[0].checked = false;
            var $con = $("#currentinfo");
            $con.find("tr:gt(0)").remove();
        }
    }
}

function onMapLevelChange(e) {
    var currentZoom = map.getZoom();
  
    if (currentZoom <= 5) {
        $(".hdli").hide();
    }
    else {
        $(".hdli").show();
    }
}

function alertclose() {
    $("a").addClass("weui_dialog_ft_active");
    $('#dialog2').hide();
}

function tabclick(obj) {
    var sno = obj.id.valueOf();
    $("#tabletab li").removeClass("select");
    $(obj).addClass("select");
    $.ajax({
        cache: false,
        type: "Post",
        url: "/Home/GetTyphoonLineAction?method=gettyphoonbyid",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{sno:'" + sno + "'}",
        success: function (response) {
            var json = eval(response.d);
            tabletyphoonde(json[0])
        }
    });
}

function getsearchid() {
    $("#searchtyphoonid").empty();
    var $con = $("#info");
    $("#currentinfo").find("tr:gt(0)").remove();
    $con.find("tr:gt(0)").remove();
    var code_Values = $('tr[id="historytr"]');
    if (code_Values.length) {
        for (var i = 0; i < code_Values.length; i++) {
            var s = $(code_Values[i]).children();
            var sno = $(s[1]).text();
            $("#searchtyphoonid").append(sno + "_");
        }
    }
}

//获取当前地理位置
function getLocation() {
    var lat1 = document.getElementById("currentlat");
    var lon1 = document.getElementById("currentlon");
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    }
    else {
        alert("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    $("#currentlat").text(position.coords.latitude);
    $("#currentlon").text(position.coords.longitude);
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            alert("User denied the request for Geolocation.")
            break;
        case error.POSITION_UNAVAILABLE:
            alert("Location information is unavailable.")
            break;
        case error.TIMEOUT:
            alert("The request to get user location timed out.")
            break;
        case error.UNKNOWN_ERROR:
            alert("An unknown error occurred.")
            break;
    }
}

function showTyphooninfo(json) {
    var lat1 = $("#currentlat").text();
    var lon1 = $("#currentlon").text();
    var jsonArray = json.points;
    for (var i = jsonArray.length - 1; i > jsonArray.length - 2; i--) {
        //        var popup = L.popup();
        //        popup.closeButton = !0;
        //        var c = "<div class='lastpopDiv'>" + json.name + "(" + json.ename + ")" + "<br> 最新时间：" + jsonArray[i].time.replace(/T/g," ").replace(/:00$/g," ").replace(/^\d+-/g," ") + "<br>中心位置：" + jsonArray[i].longitude +'°E|'+jsonArray[i].latitude + '°N' + "<br>风速：" + jsonArray[i].speed + "米/秒" + "<br>气压：" + jsonArray[i].pressure + "帕 </div>";
        //        popup.setLatLng([jsonArray[i].latitude, jsonArray[i].longitude]).setContent(c).addTo(map);
        map.setView([jsonArray[i].latitude, jsonArray[i].longitude], 6);
        $("#tynametitle").append(json.tfbh + json.name);
        $("#tynametitle").append("<br><span style='font-size:10px;'>等级：" + jsonArray[i].strong + "</span>");
        var lat2 = jsonArray[i].latitude;
        var lon2 = jsonArray[i].longitude;
        var _lat1 = (Math.PI / 180) * lat1;
        var _lat2 = (Math.PI / 180) * lat2;
        var _lon1 = (Math.PI / 180) * lon1;
        var _lon2 = (Math.PI / 180) * lon2;
        var d = Math.round(Math.acos(Math.sin(_lat1) * Math.sin(_lat2) + Math.cos(_lat1) * Math.cos(_lat2) * Math.cos(_lon2 - _lon1)) * EARTH_RADIUS);
        if (lat1 == "") {
            $("#tynametitle").append("<br><span style='font-size:10px;'>距离当前地点：" + "----" + "km</span><br>");
        } else {
            $("#tynametitle").append("<br><span style='font-size:10px;'>距离当前地点：" + d + "km</span><br>");
        }
    }
}

var infomyIcon, infodivmark = L.marker();
function infoclick(obj) {

    map.removeLayer(infodivmark);

    var code_Values = $('tr[class="infoselect"]');

    if (code_Values.length) {
        for (var i = 0; i < code_Values.length; i++) {
            $(code_Values[i]).removeClass("infoselect");
        }
    };

    var l = $(obj).attr("value").split(",");
    map.setView([Number(l[1]), Number(l[0])], map.getZoom());
    $(obj).addClass('infoselect');
    infomyIcon = L.divIcon({ iconAnchor: [-16, 10], className: 'tycontitl', html: '<span class="tymm"><span class="tymmle"></span><span class="tymmri"></span>' + $(obj).attr("time") + '</span>' });
    infodivmark = L.marker([Number(l[1]), Number(l[0])], { icon: infomyIcon }).addTo(map);

}

