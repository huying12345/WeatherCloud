var sectionCount = 1;
var interval_fullpage;
$(function () {
    $('.navbar-header').html('运维监控系统');
    loadSiteList();
    setInterval(function () {
        //loadSiteList();
        self.location.href = self.location.href;
    }, 60 * 1000);
});

function loadSiteList() {
    jQuery.ajax({
        url: '/api/Monitor/MonitorGroup/GetMonitorGroupList?r=' + new Date(),
        type: 'get',
        dataType: 'json',
        success: function (data) {
            loadHtml(data);
        }
    });
}

function loadHtml(data) {
    try {
        $('#dowebok').fullpage.destroy('all');
        window.clearInterval(interval_fullpage); //清除定时器
    } catch (e) {
    }

    $('#dowebok').html('');
    var rowCount = 9;
    sectionCount = Math.ceil(data.length / rowCount);
    if (sectionCount == 0) {
        sectionCount = 1;
    }
    for (var i = 0; i < sectionCount; i++) {
        $('#dowebok').append('<div class="section"><div id="section' + i + '" class="row section-content"></div></div>');
        for (var j = 0; j < rowCount; j++) {
            if (j + (i * rowCount) >= data.length) {
                break;
            }
            var group = data[j + (i * rowCount)];
            if (group.status == 1) {
                group.color = '#80CA5B';
            } else if (group.status == 2) {
                group.color = '#FFD24D';
            } else {
                group.color = '#E16644';
            }
            var html = template('template_widget', group);
            $('#section' + i).append(html);
        }
    }
    var clientHeight = parseInt($(window).height() - 200);
    $('.thumbnail').css('height', parseInt(clientHeight / 3));
    fullPage();
}

function fullPage() {

    $('#dowebok').fullpage({
        sectionsColor: ['#2094E9', '#1bbc9b', '#4BBFC3', '#7BAABE', '#f90', '#1bbc9b', '#4BBFC3', '#7BAABE', '#f90'],
        navigation: sectionCount > 1,
        continuousVertical: true
    });
    interval_fullpage = setInterval(function () {
        $.fn.fullpage.moveSectionDown();
    }, 10000); //定时滚动
}

function showDetail(siteId) {
    window.open('/Monitor/Monitor/monitor/' + siteId);
}