

function ReadXML() {
    $.ajax({
        url: "/Home/ReadXml",
        type: "Post",
        success: function (data) {
            debugger
            alert(data);
        },
        error: function () {
            alert("服务器异常");
        }
    })
}

$('#editable-select').editableSelect({
    effects: 'slide'
});

function editable(select1) {
    if (select1.value == "") {
        var newvalue = prompt("请输入", "其他");
        if (newvalue) {
            addSelected(select1, newvalue, newvalue);
        }
    }
}

function addSelected(fld1, value1, text1) {
    if (document.all) {
        var Opt = fld1.document.createElement("OPTION");
        Opt.text = text1;
        Opt.value = value1;
        fld1.options.add(Opt);
        Opt.selected = true;
    } else {
        var Opt = new Option(text1, value1, false, false);
        Opt.selected = true;
        fld1.options[fld1.options.length] = Opt;
    }
}

////判断数组是否重复
//$(function () {
//    var ary = new Array("111", "22", "33", "111","222","56656","22","33");
//    var nary = ary.sort();
//    for (var i = 0; i < ary.length; i++) {
//        if (nary[i] == nary[i + 1]) {
//            alert("数组重复内容：" + nary[i]);
//        }
//    }
//})

// 验证身份证号码
function isCardNo(card) {
    debugger
    if (card && card != "") {
        var pattern = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
        if (pattern.test(card)) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}


function JQAjaxData() {
    var param = {};
    $.ajax({
        url: "/Home/SomeData",
        type: "Post",
        datatype: "Json",
        data: { param: 555 },
        success: function (data) {
            debugger
            var res = data;
        },
        error: function () {
            alert("服务器异常");
        }
    })
}