

    document.onscroll = function () {
        var sTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop
        if (sTop > 100) {
            document.getElementsByClassName("toTop")[0].style.display = "block"
        } else {
            document.getElementsByClassName("toTop")[0].style.display = "none"
        }
    }
    $(".toTop").click(function () {
        $("body,html").animate({
            "scrollTop": 0
        }, 500)
    })


    
    
   
    