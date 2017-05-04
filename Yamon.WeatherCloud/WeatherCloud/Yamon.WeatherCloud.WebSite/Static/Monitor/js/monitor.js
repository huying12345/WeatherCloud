var sectionCount = 1;
var interval_fullpage;
$(function () {
    loadSiteList();
    setInterval(function () {
        //loadSiteList();
        self.location.href = self.location.href;
    }, 60 * 1000);
});

function loadSiteList() {
    jQuery.ajax({
        url: '/api/Monitor/MonitorWebSite/GetMonitorWebSite?GroupID=' + groupId,
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

            var msg = '';
            if (group.monitortype == 'httptime' && group.monitortimetype == 2) {
                msg = '<p class="bxTime">当前数据时间：' + group.responsedatatime + '<br />应显示数据时间：' + group.shoulddatatime + '</p>';
            } else if (group.monitortype == 'httptime' && group.monitortimetype == 1) {
                msg = '<p class="bxTime">当前数据时间：' + group.responsedatatime + '<br />应显示此时间之后：' + group.shoulddatatime + '</p>';
            } else if (group.monitortype == 'server') {
                msg = '<p class="bxTime">最后监测时间：' + group.logtime + '<br />'+group.msg;
            } else {
                msg = '<p class="bxTime">最后成功时间：' + group.successtime + '<br />上次失败时间：' + group.errortime + '</p>';
            }
            group.errormsg = msg;
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
    window.open('/Monitor/MonitorNoticeLog/Grid1_Http?ModuleID=Monitor&ModelID=MonitorNoticeLog&Menu=MonitorNoticeLog_List&SiteID=' + siteId);
}


