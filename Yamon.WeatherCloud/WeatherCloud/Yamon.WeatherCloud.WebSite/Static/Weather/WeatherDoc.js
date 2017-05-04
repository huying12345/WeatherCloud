$(function () {
    $("#tt").wrap('<div id="FormDiv" class="col-md-6"></div>');
    $("#FormDiv").wrap('<div class="row"></div>');
    $("#FormDiv").after('<div class="col-md-6"><div id="WordOpen" style="text-align:left"><iframe id="show" src="" style="width:100%;height:100%;display:none;border:none;"></iframe></div></div>');

})

function Grid_ClickRow_My(rowIndex, rowData) {
    //$("#tt").datagrid('clearSelections');
    //$("#tt").datagrid('selectRecord', rowData.ID);
    if (rowData.hasOwnProperty("InfoPath")) {
        jQuery("#WordOpen").css("height", document.documentElement.clientHeight - 140);
        var url = "/" + rowData.InfoPath.replace(".doc", ".pdf");
        jQuery("#show").css("display", "");
        jQuery("#show").attr("src", url);
    } else if (rowData.hasOwnProperty("InfoDetail")) {
        jQuery("#WordOpen").css("height", document.documentElement.clientHeight - 160);
        jQuery("#show").css("display", "");
        var html = "<pre>" + rowData.InfoDetail + "</pre>";
        $(document.getElementById('show').contentWindow.document.body).html(html);
    }
}