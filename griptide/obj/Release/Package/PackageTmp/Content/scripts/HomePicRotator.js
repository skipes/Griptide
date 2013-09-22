// General variables
var $cntrParent;
var $newFeatureImg
var runPicRotator;
var totalCycleRunDuration = 1500;
var nextCycleCountdown = 4000;

// Processing Feature to Que
var F2QTypicalTime;
var F2QMediumTime;
var F2QShortTime;

// Processing Que to Feature
var Q2FTypicalTime;
var Q2FMediumTime;
var Q2FShortTime;


$(document).ready(function () {
    SetTimeDurations();
    runPicRotator = setInterval('slideImageToFeature()', nextCycleCountdown);
    
    $('#imageQue').delegate('.image', 'click', function (event) {
        if ($('#imageHolderContainer :animated').length > 0) {
            event.stopPropagation();
        } else {
            if ($(this).index() > 0) {
                MoveImageToFrontOfQue($(this));
            }

            setTimeout(function () {
                if (runPicRotator) {
                    console.log("interval cleared");
                    clearInterval(runPicRotator);
                }
                slideImageToFeature();
            }, 800);
        }
    });
});

function slideImageToFeature() {
    $cntrParent = $("#featureImage");
    $newFeatureImg = $('#imageQue .image:first');

    ProcessFeatureToQue();
    ProcessQueToFeature();
};

function ProcessFeatureToQue() {
    // Get the feature image and shrink it down and move it down into the end of the que.
    var $featureImg = $("#featureImage .image:first");
    var featureImagePos;
    var featureImageHeight;
    var $firstInQue = $("#imageQue .image:first");
    var imageQuePos = $firstInQue.position();
    $cntrParent.find('.image:first').css('float', 'right').animate();
    $cntrParent.find('.image:first').animate({ width: $newFeatureImg.width(), height: $newFeatureImg.height() }, {
        duration: F2QMediumTime, complete: function () {
            featureImagePos = $featureImg.position();
            featureImageHeight = $featureImg.height()
            //Create a clone to hold place during transition to absoulte positioning.
            $featureImg.clone().appendTo("#featureImage").addClass('image--hidden');
            $featureImg.width($("#featureImage .image:first").width()).height($("#featureImage .image:first"));
            $featureImg.css({
                'top': featureImagePos.top, 'left': featureImagePos.left - 10, 'position': 'absolute',
                'height': featureImageHeight
            });
            
            //Shrink the feature image and drop it down into the last spot of the image que.
            $featureImg.animate({ height: $("#imageQue .image:first").height() }, F2QShortTime);
            $featureImg.animate({ top: imageQuePos.top, }, {
                duration: F2QTypicalTime, complete: function () {
                    $featureImg.css({ float: 'right' });
                    $featureImg.animate({ width: $("#imageQue .image:first").width() }, F2QTypicalTime);
                    $featureImg.appendTo("#imageQue").css({ position: 'inherit', float: 'left' });
                    //$featureImg.slider();
                }
            });
        }
    });
}

function ProcessQueToFeature($chosenImage) {
    // Get the feature image from the que and slide it up to fill the feature image spot.
    var featurePos;
    var featureImgOrigWidth;
    var featureImgOrigHeight;
    var newFeaturePos = $newFeatureImg.position();

    var $featureImg = $("#featureImage .image:first");
    featurePos = $featureImg.position();
    featureImgOrigWidth = $featureImg.width();
    featureImgOrigHeight = $featureImg.height();
    
    //shrink feature image and move it up into the feature area.
    $newFeatureImg.animate({ width: $newFeatureImg.width() }, {
        duration: Q2FTypicalTime, complete: function () {
            
            // clone the new feature image to hold position while we pop this image out of the que
            $newFeatureImg.clone().addClass('image--hidden').prependTo("#imageQue").css('border', 'none');
            $newFeatureImg.css('position', 'absolute');
            $newFeatureImg.width($("#imageQue .image:first").width()).height($("#imageQue .image:first").height());
            $newFeatureImg.css({ 'top': newFeaturePos.top, 'left': newFeaturePos.left });
            $("#imageQue .image:first").hide(Q2FShortTime, function () { $("#imageQue .image:first").remove(); });
            /*** Slide image top top and append to the featureImage div. ***/
            $newFeatureImg.animate({ top: featurePos.top }, {
                duration: Q2FMediumTime, complete: function () {
                    $("#featureImage .image:last").remove();
                    $newFeatureImg.appendTo("#featureImage").css({position: 'inherit'});
                    $newFeatureImg.animate({ height: featureImgOrigHeight, width: featureImgOrigWidth }, Q2FShortTime);
                    $("#imageFeature .image:first").remove();
                }
            });

            
        }
    });
}

function MoveImageToFrontOfQue($selectedImage) {
    //Move the image to front of que to be processed up to feature image.
    $selectedImage.height($selectedImage.height());
    var origHeight = $selectedImage.height();
    var origWidth = $selectedImage.width();

    $selectedImage.animate({ width: 0, duration: 50 }, {    complete: function () {
                $selectedImage.hide();
                $selectedImage.prependTo("#imageQue");
                $selectedImage.show().animate({
                    width: origWidth, duration: 50
                });
            }
        }
    );
}


function SetTimeDurations() {
    // Processing Feature to Que
    F2QTypicalTime = totalCycleRunDuration / 3;
    F2QMediumTime = F2QTypicalTime * (4 / 5);
    F2QShortTime = F2QTypicalTime / 5;

    // Processing Que to Feature
    Q2FTypicalTime = totalCycleRunDuration / 3;
    Q2FShortTime = Q2FTypicalTime * (3/5);
    Q2FMediumTime = Q2FTypicalTime * (4/5);
}
    

