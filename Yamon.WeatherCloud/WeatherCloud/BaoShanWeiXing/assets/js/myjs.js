$(function () {
    var imgArr = [];
    var timeArr = [];
    var len = imgArr.length;
    $('.Show_table').hide();
    var onoff = true;
    $('#Show_change').on('click', function () {
        if (onoff) {
            $('.Show_table').show(500);
        } else {
            $('.Show_table').hide(500);
        }
        onoff = !onoff;
    });
    //获取雷达图
    $.getJSON('/api/Weather/WeatherImg/GetDataList/' + myPage.id, function (result) {
      
        for (var i = 0; i < result.data.length; i++) {
            if (myPage.NodeType == 8)//文本栏目
            {
                $('#show_time').text(result.data[i].DataTime);
                $('#input_hidden').text(result.data[i].InfoDetail.replace("             ", ""));
            } else {
                imgArr.push(result.data[i].InfoPath);
                timeArr.push(result.data[i].DataTime);
                $('img[id="imgshow"]').attr('src', imgArr[0]);
                $('#show_time').text(timeArr[0]);
            }
        }
        len = imgArr.length;
    });
    //图片切换
    $('#previousbutton').on('click', function () {
        prev();
    });
    $('#nextbutton').on('click', function () {
        next();
    });
    var show_autoplay = null;
    $("#playbutton").on('click', function () {
        var arr = ['iconfont icon-pause', 'iconfont icon-play']
        var cls = $('span[id="playbutton"]').attr('class');
        if (cls == arr[1]) {
            show_autoplay = setInterval(function () { next(); }, 1000);
            $('span[id="playbutton"]').attr('class', arr[0]);
        } else {
            $('span[id="playbutton"]').attr('class', arr[1]);
            clearInterval(show_autoplay);
        }
    });
    function next() {
        var src = $('img[id="imgshow"]').attr("src");
        var index = imgArr.indexOf(src);
        if (index == 0) {
            $('img[id="imgshow"]').attr("src", imgArr[len - 1]);
            $('#show_time').text(timeArr[len - 1]);
        } else {
            $('img[id="imgshow"]').attr("src", imgArr[index - 1]);
            $('#show_time').text(timeArr[index - 1]);
            index = index - 1;
        }
    };
    function prev() {
        var src = $('img[id="imgshow"]').attr("src");
        var index = imgArr.indexOf(src);
        if (index == len - 1) {
            $('img[id="imgshow"]').attr("src", imgArr[0]);
            $('#show_time').text(timeArr[0]);
        } else {
            $('img[id="imgshow"]').attr("src", imgArr[index + 1]);
            $('#show_time').text(timeArr[index + 1]);
            index = index + 1;
        }
    };
})
