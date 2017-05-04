function CheckConditions() {
    jQuery('fieldset').show();
    jQuery("fieldset").each(function () {
        if (jQuery('tr', this).length > 0) {
            if (jQuery('tr:visible', this).length > 0) {
                jQuery(this).show();
            } else {
                jQuery(this).hide();
            }
        }
    });
}
var channelIds = {};
var SelectServiceUser = {
    channels: '',
    fieldPrefix: 'To',
    
    init: function (channels, fieldPrefix) {
        this.channels = channels;
        this.fieldPrefix = fieldPrefix;
        var allChannels = ['SMS', 'FTP', 'EMAIL', 'FAX'];
        var arrChannel = this.channels.split(',');
        for (var i = 0; i < arrChannel.length; i++) {
            var index = allChannels.indexOf(arrChannel[i]);
            if (index >= 0) {
                allChannels.splice(index, 1);
            }
            if (jQuery('#Label_' + this.fieldPrefix + arrChannel[i]).length > 0) {
                this.InitChannelTree(arrChannel[i]);
                jQuery('#Label_' + this.fieldPrefix + arrChannel[i]).append('<br/><a href="javascript:SelectServiceUser.selectUser(\'' + arrChannel[i] + '\')" class="linkbutton">选择用户</a>');
            }
        }
        jQuery.unique(arrChannel);
        for (var i = 0; i < allChannels.length; i++) {
            jQuery('#Container_' + this.fieldPrefix + allChannels[i]).hide();
            jQuery('label[for="Channel_' + allChannels[i] + '"]').hide();
            jQuery('#Channel_' + allChannels[i]).hide();
        }
        jQuery('.linkbutton,.easyui-linkbutton').linkbutton();
        CheckConditions();
    },
    selectUser: function (channel) {
        var url = '/ServiceUser/ServiceUserInfo/SelectUserByGroup?channel=' + channel;
        OpenThisMyDialog(url, '选择用户', 650, 450);
    },

    getServiceUserIds: function (channel) {
        return jQuery('#' + this.fieldPrefix + channel).val();
    },

    InitChannelTree: function (channel) {
        var text = jQuery("#" + this.fieldPrefix + channel + "_ShowValue").text();
        var au = jQuery('#' + this.fieldPrefix + channel).val();
        this.setServiceUser(au, text, channel);
    },

    setServiceUser: function (ids, names, channel) {
        var arrIds = new Array();
        var arrIdsTemp = ids.split(",");
        jQuery.unique(arrIdsTemp);
        for (var i = 0; i < arrIdsTemp.length; i++) {
            if (arrIdsTemp[i] != '') {
                arrIds.push(arrIdsTemp[i]);
            }
        }
        channelIds[channel] = arrIds;
        jQuery('#' + this.fieldPrefix + channel).val(arrIds.join(','));
        var arrNameTemp = names.split(",");
        var idUid = jQuery('#' + this.fieldPrefix + channel).val();
        var arrNames = new Array();
        for (var i = 0; i < arrNameTemp.length; i++) {
            if (arrNameTemp[i] != '') {
                arrNames.push(arrNameTemp[i]);
            }
        }
        if (arrNames.length > 0) {
            jQuery("#" + this.fieldPrefix + channel + "_ShowValue").html('<div id="div_ul"><ul><li class="ir_li"><img src="/Static/v1/images/remove.png"  data-channel="' + channel + '" class="ir" />' + arrNames.join('<li class="ir_li"><img src="/Static/v1/images/remove.png" data-channel="' + channel + '" class="ir"/>') + "</li></ul></div>");
        };
          
        var fieldPrefix = this.fieldPrefix;
        jQuery(".ir").click(SelectServiceUser_DelUser);
    },

    getServiceUserNames: function (channel) {
        var str = jQuery('#' + this.fieldPrefix + channel + '_ShowValue').html();
        jQuery('#' + this.fieldPrefix + channel + '_ShowValue ul li').each(function () {
            var vshu = jQuery(this).text();
            str = str.replace(jQuery(this).text(), vshu + ",");
        });
        return str;
    }
};

function SelectServiceUser_DelUser() {
    var index = jQuery(this).parents("li").index();
    var channelId = jQuery(this).attr('data-channel');
    if (index >= 0) {
        channelIds[channelId].splice(index, 1, "");
    }
    jQuery(this).parents("li").hide();
    jQuery('#' + SelectServiceUser.fieldPrefix + channelId).val(channelIds[channelId]
        .join(','));
}