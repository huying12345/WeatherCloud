//产品权限
function  SetDataPurview(value, row, index) {
    var url = "/Weather/WeatherNodes/SetDataPurview?UserID=" + row.UserID;
    url='javascript:OpenMyDialog("'+url+'", "设置数据权限", 500, 500);';
    return "<a href='" + url + "' style='color:red;'>数据权限</a>";
}



function RestoreUser() {
    var id = getSelectIds();
    if (id == "" || id == undefined)
        return;
    jQuery.messager.confirm('Confirm', '确定要还原[ ' + Data.ItemName + 'ID为' + id + ' ]的信息吗?', function (r) {
        if (r) {
            jQuery.ajax({
                type: 'post',
                dataType: 'text',
                url: 'Handler/UsersHandler.ashx?action=EmployeeDelete&type=update',
                data: { "ids": id },
                success: function (msg) {
                    if (msg == "1") {
                        alert("还原成功！");
                        ReloadData();
                    } else {
                        alert("还原失败：" + msg);
                        return;
                    }
                }
            });
        }
    });
}

function UserMutiDelete() {
    var id = getSelectIds();
    if (id == "" || id == undefined)
        return;
    jQuery.messager.confirm('Confirm', '确定要彻底删除[ ' + Data.ItemName + 'ID为' + id + ' ]的信息吗?', function (r) {
        if (r) {
            jQuery.ajax({
                type: 'post',
                dataType: 'text',
                url: 'Handler/UsersHandler.ashx?action=EmployeeDelete&type=delete',
                data: { "ids": id },
                success: function (msg) {
                    if (msg == "1") {
                        alert("删除成功！");
                        ReloadData();
                    } else {
                        alert("删除失败：" + msg);
                        return;
                    }
                }
            });
        }
    });
}


function SyncUsers() {
    $.ajax({
        url: "/api/UCenter/User/SyncOfWeiXin",
        type: "POST",
        dataType: 'json',
        success: function (data, textStatus, jqXHR) {
            ReloadData();
            alert(data.message);
        }
    });
}

function SyncUsersToDB() {
    $.ajax({
        url: "/api/UCenter/User/SyncloadUsersToDB",
        type: "POST",
        dataType: 'json',
        success: function (data, textStatus, jqXHR) {
            ReloadData();
            alert(data.message);
        }
    });
}
