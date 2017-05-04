var menuList = {
    "menu": {
        "button": [
            {
                "sub_button": [
                    {
                        "url": "http://ihuan.zong.yamon.cn/m",
                        "type": "view",
                        "name": "关于我们"
                    },
                    {
                        "url": "http://ihuan.zong.yamon.cn/m",
                        "type": "view",
                        "name": "名人赠言"
                    },
                    {
                        "url": "http://ihuan.zong.yamon.cn/m",
                        "type": "view",
                        "name": "订单查询"
                    },
                    {
                        "key": "合作联系",
                        "type": "click",
                        "name": "合作联系"
                    }
                ],
                "name": "我"
            },
            {
                "url": "http://ihuan.zong.yamon.cn/m",
                "type": "view",
                "name": "立即下单"
            }
        ]
    },
    "conditionalmenu": null,
    "errcode": 0,
    "errmsg": null,
    "P2PData": null
}

$(function () {
    var viewModel = new MenuViewModel();
    ko.applyBindings(viewModel);
    viewModel.init(menuList.menu);
});

var SubButtonViewModel = function (model) {
    var self = this;
    self.name = ko.observable(model.name);
    self.type = ko.observable(model.type);
    self.key = ko.observable(model.key);
    self.url = ko.observable(model.url);
    self.isSelected = ko.observable(false);
}

var ButtonViewModel = function (model) {
    var self = this;
    self.name = ko.observable(model.name);
    self.type = ko.observable(model.type);
    self.key = ko.observable(model.key);
    self.url = ko.observable(model.url);
    self.isSelected = ko.observable(false);

    self.sub_button = ko.observableArray([]);
    self.init = function () {
        if (!model.sub_button) {
            for (var i = 0; i < 5; i++) {
                self.addSubButton();
            }
            return;
        }
        for (var i = model.sub_button.length; i < 5; i++) {
            self.addSubButton();
        }
        for (var i = 0; i < model.sub_button.length; i++) {
            self.sub_button.push(new SubButtonViewModel(model.sub_button[i]));
        }
    }
    self.addSubButton = function () {
        self.sub_button.push(new SubButtonViewModel({
            name: '',
            type: '',
            key: '',
            url: ''
        }));
    };
    self.sub_buttonList = function () {
        return $.map(self.sub_button(), function (line) {
            return line.name() ? {
                name: line.name(),
                type: line.type(),
                url: line.url(),
                key: line.key()
            } : undefined;
        });
    }
}
var MenuViewModel = function () {
    var self = this;
    self.button = ko.observableArray([]);
    self.init = function (model) {
        for (var i = 0; i < model.button.length; i++) {
            var buttonView = new ButtonViewModel(model.button[i]);
            buttonView.init();
            self.button.push(buttonView);
        }
        for (var i = model.button.length; i < 3; i++) {
            self.addButton();
        }
    };

    self.addButton = function () {
        var buttonView = new ButtonViewModel({
            name: '',
            type: '',
            key: '',
            url: '',
            sub_button: []
        });
        buttonView.init();
        self.button.push(buttonView);
    }

    self.setSelected = function (row) {
        for (var i = 0; i < self.button().length; i++) {
            self.button()[i].isSelected(false);
            for (var j = 0; j < self.button()[i].sub_button().length; j++) {
                self.button()[i].sub_button()[j].isSelected(false);
            }
        }
        row.isSelected(true);
    }

    self.save = function () {
        var jsonData = $.map(self.button(), function (line) {
            return line.name() ? {
                name: line.name(),
                type: line.type(),
                url: line.url(),
                key: line.key(),
                sub_button: line.sub_buttonList().length > 0 ? line.sub_buttonList() : undefined
            } : undefined;
        });

        var menuList = {
            "menu": {
                "button": jsonData
            },
            "conditionalmenu": null,
            "errcode": 0,
            "errmsg": null,
            "P2PData": null
        }
        console.log(JSON.stringify(menuList));
    }
}