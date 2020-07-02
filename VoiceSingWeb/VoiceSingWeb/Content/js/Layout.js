/*用户登录模态框js*/
$("#login").click(function () {
    $(".hide-center").fadeIn("slow");
    $(".overCurtain").fadeIn("slow");
})
$("#toregister").click(function () {
    $(".hide-center").fadeOut("slow");
    $(".overCurtain").fadeOut("slow");
    $(".r-hide-center").fadeIn("slow");
    $(".r-overCurtain").fadeIn("slow");
})
$("#toforgetpwd").click(function () {
    $(".hide-center").fadeOut("slow");
    $(".overCurtain").fadeOut("slow");
    $(".f-hide-center").fadeIn("slow");
    $(".f-overCurtain").fadeIn("slow");
})
$("#f-close").click(function () {
    $(".f-hide-center").fadeOut("slow");
    $(".f-overCurtain").fadeOut("slow");
})
$("#close").click(function () {
    $(".hide-center").fadeOut("slow");
    $(".overCurtain").fadeOut("slow");
})
//登录密码显示与隐藏
$(".loginPassword").on("click", ".fa-eye-slash", function () {
    $(this).removeClass("fa-eye-slash").addClass("fa-eye");
    $(this).next().attr("type", "text");
});
$(".loginPassword").on("click", ".fa-eye", function () {
    $(this).removeClass("fa-eye").addClass("fa-eye-slash");
    $(this).next().attr("type", "password");
});
//找回密码显示与隐藏
$(".f-Pwd").on("click", ".fa-eye-slash", function () {
    $(this).removeClass("fa-eye-slash").addClass("fa-eye");
    $(this).next().attr("type", "text");
});

$(".f-Pwd").on("click", ".fa-eye", function () {
    $(this).removeClass("fa-eye").addClass("fa-eye-slash");
    $(this).next().attr("type", "password");
});
//登录状态
function LoginSuccess(data) {
    if (data == "success") {
        window.location.reload();
    }
    else {
        alert("用户账号或密码错误!");
    }
}

/*用户注册模态框js*/
$("#register").click(function () {
    $(".r-hide-center").fadeIn("slow");
    $(".r-overCurtain").fadeIn("slow");
})
$("#Haccount").click(function () {
    $(".r-hide-center").fadeOut("slow")
    $(".r-overCurtain").fadeOut("slow")
    $(".hide-center").fadeIn("slow");
    $(".overCurtain").fadeIn("slow");
})
$("#r-close").click(function () {
    $(".r-hide-center").fadeOut("slow")
    $(".r-overCurtain").fadeOut("slow")
})
//注册框密码显示与隐藏
$(".r-Pwd").on("click", ".fa-eye-slash", function () {
    $(this).removeClass("fa-eye-slash").addClass("fa-eye");
    $(this).next().attr("type", "text");
});

$(".r-Pwd").on("click", ".fa-eye", function () {
    $(this).removeClass("fa-eye").addClass("fa-eye-slash");
    $(this).next().attr("type", "password");
});

//注册输入验证
//号码输入框失去焦点时检验输入内容是否有效
$("#phone").blur(function () {
    // 利用正则表达式对输入数据匹配
    var phone = document.getElementById("phone").value;
    //匹配到一个非数字字符，则返回false 
    var expr = /\D/i;
    if (expr.test(phone)) {
        document.getElementById("phonecheck").innerHTML = "手机号格式错误";
        return false;
    }
    else if (phone == "") {
        document.getElementById("phonecheck").innerHTML = "手机号码不能为空";
        return false;
    }
    else if (phone.length != 11) {
        document.getElementById("phonecheck").innerHTML = "手机号码长度为11位";
        return false;
    }
    else {
        document.getElementById("phonecheck").innerHTML = null;
        return true;
    }
})
$("#phone").focus(function () {
    document.getElementById("phonecheck").innerHTML = null;
});
$("#password").blur(function () {
    var pwd = document.getElementById("password").value;
    if (pwd == "") {
        document.getElementById("passwordcheck").innerHTML = "请设置密码！";
        return false;
    }
    else if (pwd.length > 16 || pwd.length < 6) {
        document.getElementById("passwordcheck").innerHTML = "密码长度6~16位！";
        return false;
    }
    else {
        document.getElementById("passwordcheck").innerHTML = null;
        return true;
    }
});
$("#r-BSignIn").click(function () {
    var phone = document.getElementById("phone").value;
    var password1 = document.getElementById("password").value;
    var password2 = document.getElementById("confirmpassword").value;
    if (password1 != password2) {
        document.getElementById("confirmpasswordcheck").innerHTML = "两次密码输入不一致!";
        return false;
    }
    else if (password1 == "") {
        document.getElementById("passwordcheck").innerHTML = "请设置密码！";;
        return true;
    }
    else {
        return true;
    }
});
$("#confirmpassword").focus(function () {
    document.getElementById("confirmpasswordcheck").innerHTML = null;
});
//注册状态提示
function RegisterSuccess(data) {
    if (data == "success") {
        alert("注册成功！");
    }
    else if(data == "exist"){
        alert("该手机号已注册！");
    }
    else {
        alert("注册失败！");
    }
}

/*注销登录js*/
function Loginout(data) {
    alert(data);
    location.reload();
}

/*返回顶部js*/
function back() {
    h = $(window).height() - 500;
    t = $(document).scrollTop();
    if (t > h) {
        $('#gotop').show();
    } else {
        $('#gotop').hide();
    }
}
$(document).ready(function (e) {
    back();
    $('#gotop').click(function () {
        $("body,html").animate({
            "scrollTop": 0
        }, 500)
    })
});
$(window).scroll(function (e) {
    back();
})
function show_img() {
    $('#code_img').show();
}
function hide_img() {
    $('#code_img').hide();
}


//管理员登录
function AdminLoginCheck(data) {
    if (data == "success") {
        window.location = '../../Admin/Index';       
    }
    else
    {
        alert('账号或密码错误！');
    }
}