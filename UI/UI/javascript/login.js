$(function () {
    $(":button").click(function () {
        doLogin();
    });
    $("html").die().live("keydown", function (event) {
        if (event.keyCode == 13) {
            doLogin();
        }
    });
});

function doLogin() {
    var userName = $("#userName");
    var userPassword = $("#userPassword");
    var reg = /^\S{6,}$/;
    if (!reg.test(userName.val())) {
        userName[0].select();
        $.messager.show("消息提示", "登录名格式不正确！长度必须大于6位且不能有空格！", 2000);
        return false;
    }
    if (!reg.test(userPassword.val())) {
        userPassword[0].select();
        $.messager.show("消息提示", "登录密码格式不正确！长度必须大于6位且不能有空格！", 2000);
        return false;
    }
    $.post("/Login/Login", { "u_name": userName.val(), "u_password": userPassword.val() }, function (data) {
        if (data == "ok") {
            location.href = "page/index";
        }
        else {
            $.messager.show("消息提示", "登录名或登录密码不正确！", 2000);
        }
    });
}