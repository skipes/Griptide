function swapImages(pi_nextImg) {
    var $active;
    var $next;
    if (!pi_nextImg) {
        $active = $('#PicViewer .active');
        $next = ($('#PicViewer .active').next('img').length > 0) ? $('#PicViewer .active').next() : $('#PicViewer img:first');
    } else {
        //alert('active: ' + $('#viewer .active').attr("src"));
        $active = $('#PicViewer .active');
        //var $next = ($('#viewer').children('.activeImg').find("src", pi_nextImg));
        $next = $("#PicViewer img[src='" + pi_nextImg + "']:first");
        //alert('next: ' + $next.attr("src"));
    }

//    // slide arrow to current image
//    var imgSrc = $next.attr('src');
//    var $subImg = $("#subViewer img[src='" + imgSrc + "']");
//    var width = $subImg.width();
//    var position = $subImg.position();

//    var slide = (position.left + (width / 2) - 30);
//    if (slide > position.left) {
//        slide = '+' + slide;
//    } else {
//        slide = '-' + slide;
//    }

//    $('#hoverArrow').animate({
//        left: slide
//    });


    $active.fadeOut(function () {
        $active.removeClass('active');
        $next.fadeIn().addClass('active');
    });

}

$(document).ready(function () {

//    // expand/collapse homepage.
//    $("#home").click(function () {
//        $("viewer").remove();

//        var getHeight = $("#viewer").height();
//        //alert(getHeight);

//        if (getHeight > 100) {
//            $("#viewer").animate({
//                "height": "100px"
//            }, 900).delay(200);
//        } else {
//            $("#viewer").animate({
//                "height": "480px"
//            }, 700).delay(200);
//        }
//    });

    timerID = setInterval('swapImages(null)', 3000);

//    $('#subViewer img').click(function () {
//        var imgSrc = $(this).attr('src');
//        //var $clickImg = $("#viewer img[src='" + imgSrc + "']");
//        //alert($clickImg.attr('id'));
//        clearInterval(timerID);
//        swapImages(imgSrc);
//    });

});
	