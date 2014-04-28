﻿// 
/*
json时间转换
*/
function timeStamp2String(mytime) {
    if (mytime !=null) {
        var time = mytime.substring(6, mytime.length - 2);
        var datetime = new Date();
        datetime.setTime(time);
        var year = datetime.getFullYear();
        var month = datetime.getMonth() + 1 < 10 ? "0" + (datetime.getMonth() + 1) : datetime.getMonth() + 1;
        var date = datetime.getDate() < 10 ? "0" + datetime.getDate() : datetime.getDate();
        var hour = datetime.getHours() < 10 ? "0" + datetime.getHours() : datetime.getHours();
        var minute = datetime.getMinutes() < 10 ? "0" + datetime.getMinutes() : datetime.getMinutes();
        var second = datetime.getSeconds() < 10 ? "0" + datetime.getSeconds() : datetime.getSeconds();
        return year + "-" + month + "-" + date + " " + hour + ":" + minute + ":" + second;
    }
    else {
        return "";

    }
}
/*
load旋转
*/
function load(obj) {
    var $this = obj,
theme = $this.jqmData("theme") || $.mobile.loader.prototype.options.theme,
msgText = $this.jqmData("msgtext") || $.mobile.loader.prototype.options.text,
textVisible = $this.jqmData("textvisible") || $.mobile.loader.prototype.options.textVisible,
textonly = !!$this.jqmData("textonly");
    html = $this.jqmData("html") || "";
    $.mobile.loading("show", {
        text: msgText,
        textVisible: textVisible,
        theme: theme,
        textonly: textonly,
        html: html
    });
}
/*
String.format js
*/
String.format = function () {
    if (arguments.length == 0)
        return null;
    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
};