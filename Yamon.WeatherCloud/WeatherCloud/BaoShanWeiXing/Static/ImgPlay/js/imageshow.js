var fbsjContainMM = false;
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
function DrawImage(ImgD) {

    var image = new Image();
    image.src = ImgD.src;


    var FitWidth = $(window).width() * 0.95;
    var FitHeight = 300;

    if (image.width > 0 && image.height > 0) {
        if (image.width / image.height >= FitWidth / FitHeight) {
            if (image.width > FitWidth) {
                ImgD.width = FitWidth;
                ImgD.height = (image.height * FitWidth) / image.width;
            }
            else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = "原图片大小(" + image.width + "×" + image.height + ")";
        }
        else {
            if (image.height > FitHeight) {
                ImgD.height = FitHeight;
                ImgD.width = (image.width * FitHeight) / image.height;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = "原图片大小(" + image.width + "×" + image.height + ")";
        }
    }
}
$(document).ready(function () {

    if (typeof (images) != "undefined" && images != null && images.length > 0 && document.getElementById("imgshow") != null) {

        document.getElementById("imgshow").src = images[0].path;
        $("#fbsj").html("上海中心气象台" + images[0].fbsj + "");
    }
    if (document.getElementById("imgshow") != null)
        DrawImage(document.getElementById("imgshow"), $(window).width(), 300);
});
