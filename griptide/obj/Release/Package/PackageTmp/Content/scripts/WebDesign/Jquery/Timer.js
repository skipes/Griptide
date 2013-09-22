var timer = 0;
var timeRemain = 0
var timeInterval = 0;
var setTimeDisplay = null;

$(document).ready(function () {
    timer = 10000;
    timeRemain = timer;
    timeInterval = 53;
    decimals = 2;

    $(".timerDisplay").text(parseFloat(Math.floor(timer) / 1000).toFixed(decimals));
    //SetTimer();

    $(".playButton").click(function () {
        clearTimeout(setTimeDisplay);
        //timeRemain = timer;
        SetTimer();
    });

    $(".pauseButton").click(function () {
        clearTimeout(setTimeDisplay);
    });

    $(".resetButton").click(function () {
        clearTimeout(setTimeDisplay);
        timeRemain = timer;
        $(".meterFill").css("background-color", "rgb(0%, 100%, 0%)");
        $(".timerDisplay").text(parseFloat(Math.floor(timer) / 1000).toFixed(decimals));
        $(".meterEmpty").height("0%");
    });
});

function SetTimer() {
    timeRemain = parseFloat(timeRemain - timeInterval, 10);
    if (timeRemain > 0) {
        var newHeight = 100 - ((timeRemain / timer) * 100);
        $(".meterEmpty").height(newHeight + "%");

        //Gradient based on height.  Go from Green -> yellow -> red.
        if (newHeight <= 50) {
            $(".meterFill").css("background-color",
                                "rgb(" + (newHeight * 2) + "%,100%, 0%)");
        } else {
            $(".meterFill").css("background-color",
                                "rgb(100%," + ((100 - newHeight) * 2) + "%, 0%)");
        }

        var newVal = parseFloat(Math.floor(timeRemain) / 1000).toFixed(decimals);
        if (newVal > 0) {
            $(".timerDisplay").text(parseFloat(newVal));
        }
        setTimeDisplay = setTimeout(function () { SetTimer(); }, timeInterval);
    } else {
        $(".meterEmpty").height("100%");
        $(".timerDisplay").text("0.000");
        clearTimeout(setTimeDisplay);
    }
}
