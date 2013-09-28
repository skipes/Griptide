var $colorBox = null;
var colorBox = new Object();
var setColorInterval;
var newColorVal = 0;
var colorMode = 1;
var randColorValCeiling = 4;

$(document).ready(function () {
    $(".stopMessage").hide();

    $colorBox = $("body .colorBox");
    colorBox = new ColorBox();
    setColorInterval = setInterval(function () {
        newColorVal = Math.floor((Math.random() * randColorValCeiling) + 1);
        var posOrNeg = Math.random() < 0.5 ? -1 : 1;
        newColorVal = newColorVal * posOrNeg;

        colorMode = Math.floor((Math.random() * 4) + 1);
        colorBox.IncreaseColor(colorMode, newColorVal);
    }, 50);
});

function ColorBox() {
    var currColor = $colorBox.css("background-color");
    currColor = currColor.replace(/[^0-9,]+/g, "");
    this.Red = parseInt(currColor.split(",")[0]);
    this.Green = parseInt(currColor.split(",")[1]);
    this.Blue = parseInt(currColor.split(",")[2]);

    this.GetBackgroundColor = GetBackgroundColor;
    function GetBackgroundColor() {
        null;
    }

    this.IncreaseColor = IncreaseColor;
    function IncreaseColor(colorOption, colorValue) {
        if (colorValue === null || colorValue === 0) {
            colorValue = 1;
        }

        if (colorOption == 0 || colorOption == 1) {
            if ((this.Red + colorValue) <= 250 &&
                (this.Red + colorValue) >= 0) {
                this.Red = this.Red + colorValue;
                $(".redVal").text(this.Red);
            }
        }
        if (colorOption == 0 || colorOption == 2) {
            if ((this.Green + colorValue) <= 250 &&
                (this.Green + colorValue) >= 0) {
                this.Green = this.Green + colorValue;
                $(".greenVal").text(this.Green);
            }
        }
        if (colorOption == 0 || colorOption == 3) {
            if ((this.Blue + colorValue) <= 250 &&
                (this.Blue + colorValue) >= 0) {
                this.Blue = this.Blue + colorValue;
                $(".blueVal").text(this.Blue);
            }
        }

        $colorBox.css("background-color", "rgb(" + this.Red +
                      ", " + this.Green +
                      ", " + this.Blue + ")");
        //if(this.Red >= 250 || this.Green >= 250 || this.Blue >= 250){
        //        clearInterval(setColorInterval);   
        //          $(".stopMessage").text("rgb(" + this.Red + ", " + this.Green + 
        //                                    this.Blue + ")");
        //}
    }
}