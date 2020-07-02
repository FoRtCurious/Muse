
//回顶部
document.onscroll = function () {
    var sTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop
    if (sTop > 100) {
        document.getElementsByClassName("toTop")[0].style.display = "block";
    } else {
        document.getElementsByClassName("toTop")[0].style.display = "none";
    }
    if (sTop > 800) {
        $(".topbar").slideDown(300);
    } else {
        $(".topbar").slideUp(300);
    }
}
$(".toTop").click(function () {
    $("body,html").animate({
        "scrollTop": 0
    }, 500)
})

//放大镜
//function $id(id) {
//    return document.getElementById(id)
//}
//var box = document.querySelectorAll(".main-top-left")[0],
//    small = document.querySelectorAll(".imgbox")[0],
//    mask = $id("mask"),
//    big = document.querySelectorAll(".bigimg")[0],
//    bigImg = document.querySelectorAll(".bigimg img")[0],
//    smallImg = $id("smallImg");
//small.onmouseover = function () {
//    mask.style.display = "block";
//    big.style.display = "block";
//    bigImg.onmouseenter = function () {
//        mask.style.display = "none";
//        big.style.display = "none";
//    }
//}
//small.onmouseout = function () {
//    mask.style.display = "none";
//    big.style.display = "none";
//}
//small.onmousemove = function (e) {
//    var e = e || event;
//    var x = e.pageX - box.offsetLeft - mask.offsetWidth / 2;
//    var y = e.pageY - box.offsetTop - mask.offsetHeight / 2;
//    var maxL = smallImg.offsetWidth - mask.offsetWidth;
//    var maxT = smallImg.offsetHeight - mask.offsetHeight;
//    x = x < 0 ? 0 : (x > maxL ? maxL : x);
//    y = y < 0 ? 0 : (y > maxT ? maxT : y);
//    mask.style.left = x + "px";
//    mask.style.top = y + "px";
//    var bigImgLeft = x * (bigImg.offsetWidth - big.offsetWidth) / (smallImg.offsetWidth - mask.offsetWidth);
//    var bigImgTop = y * (bigImg.offsetHeight - big.offsetHeight) / (smallImg.offsetHeight - mask.offsetHeight);
//    bigImg.style.left = -bigImgLeft + "px";
//    bigImg.style.top = -bigImgTop + "px";
//}
$(".smnav ul li").click(function () {
    $(this).addClass("active").siblings().removeClass();
    smallImg.src = this.children[0].src;
    bigImg.src = this.children[0].src;
    $(".main .main-top .main-top-right .basic .color-select ul li").eq($(this).attr("index")).addClass("active").siblings().removeClass();
})

$(".main .main-top .main-top-right .basic .num ul li").click(function () {
    if ($(this).html() == "+") {
        document.querySelectorAll(".main .main-top .main-top-right .basic .num ul input")[0].value++;
    } else {
        if (document.querySelectorAll(".main .main-top .main-top-right .basic .num ul input")[0].value == 1) {
            document.querySelectorAll(".main .main-top .main-top-right .basic .num ul input")[0].value = 1;
        } else {
            document.querySelectorAll(".main .main-top .main-top-right .basic .num ul input")[0].value--;
        }
    }
})
$(".main .taocan ul li").click(function () {
    $(this).addClass("active").siblings().removeClass();
    var index = $(this).attr("index")
    document.querySelectorAll(".main .taocan img")[0].src = `../../Content/images/shopping/home/${index}.png`
})

$('.searchbox').keydown(function (e) {
    console.log(123);
    if (e.keyCode == 13) {
        var search = $(this).find('#search').val();
        window.location.href = "../../Shopping/List?search=" + search;
    }
})