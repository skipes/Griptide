$(document).ready(function () {
    AdjustLoadingText();
    $(".floater").each(function (index) {
        var box = this;
        //assign a random color
        var rgbVals = GetRandVals();
        $(this).css('background-color', ( 'rgba('+ rgbVals[0] + "," + rgbVals[1] + "," + rgbVals[2] + ", 5)" ) );
        setTimeout(function () {
            Cycle($(box))
        }, index * 300);

    });
});

var totalDuration = 2000;
var quarterDuration = totalDuration / 4;
function Cycle(box) {
    setInterval(function () {
        var slideRight = $(".jugglerMain").width() - box.width();
        var slideDown = $(".jugglerMain").height() - box.height();
        $(box).animate({ left: slideRight }, quarterDuration).animate({ top: slideDown }, quarterDuration);
        $(box).animate({ left: '0' }, quarterDuration).animate({ top: '0' }, quarterDuration);
        if ($(".jugglerMain__loadingText").is(":visible")) {
            $(".jugglerMain__loadingText").fadeOut();
        }
    }, totalDuration);
}

function GetRandVals() {
    // get a random value (0 - 255) for each R,G,and B.
    var rgb = new Array();

    for (var i = 0; i < 3; i++) {
        rgb.push(Math.round(Math.random() * (255 - 0) + 0));
    }
    return rgb;
}

function AdjustLoadingText() {
    //Center the span to shift left, based on its element size.
    var newMargin = $(".jugglerMain__loadingText").width();
    $(".jugglerMain__loadingText").css("margin-left", ( parseInt( (newMargin / 2) * -1) ) );
}