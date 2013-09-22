var imgIndex = null;
var visibleRange = 845;
var currGroup = 0;
var groupCount = 0;
// Array shows collective count of images for each group. ie, if group 1 has 4 items and group 2 has 5, the values look like this:
// groupImgCount[0] = 4, groupImgCount[1] = 9
var groupImgCount = new Array();
var fadeDelay = 200;

$(document).ready(function () {
    $(".graphicsViewer a").fancybox({
        openEffect: 'elastic',
        closeEffect: 'elastic',
        'type': 'image'
    });
    
    $(".graphicsPicScroller_Item").click(function () {
        var chosenImg = $(this);
        $(".graphicsPicScroller_Item").removeClass("activeImg");
        var selectedImgPath = chosenImg.attr("src");

        if ($(".graphicsViewer img").length > 0) {
            $(".graphicsViewer img").fadeOut(fadeDelay, function () {
                
                $(chosenImg).clone().appendTo(".graphicsViewer").hide().fadeIn(fadeDelay).removeAttr("class")
                    .addClass('graphicsView__Item').wrap('<a id="mainFeatureImage" href="' + selectedImgPath + '" />');

                $(this).remove();
            });
        } else {

            $(chosenImg).clone().appendTo(".graphicsViewer").hide().fadeIn(1500).removeAttr("class")
                .addClass('graphicsView__Item').wrap('<a id="mainFeatureImage" href="' + selectedImgPath + '" />');
        }
        
        var index = $(".graphicsPicScroller_Item").index(this) + 1;

        $(".picCounter").text(index);
        $(this).addClass("activeImg");
    });

    $(".rbutton").click(function () {
        DisplayNextGroup(true);
    });

    $(".lbutton").click(function () {
        DisplayNextGroup(false);
    });

    $(".graphicsPicScroller__itemContainer img:first").trigger('click');

    //$imgIndex = $(".graphicsPicScroller_Item");
    //SetVisibleGroups();
});

$(window).load(function () {
    SetVisibleGroups();
});

function SetVisibleGroups() {
    $imgIndex = $(".graphicsPicScroller_Item");
    var widthVal = 0;
    
    for (var i = 0; i < $imgIndex.length ; i++) {
        if (parseInt( widthVal + $imgIndex[i].width ) + 10 < visibleRange) {
            widthVal += $imgIndex[i].width + 10;
            $($imgIndex[i]).addClass("graphicsPicScrollerGroup" + groupCount);
            $("graphicsPicScrollerGroup" + groupCount).hide();
            //} else if (widthVal > visibleRange) {
        } else {
            groupImgCount[groupCount] = [i];
            groupCount++;
            $($imgIndex[i]).addClass("graphicsPicScrollerGroup" + groupCount);
            widthVal = $imgIndex[i].width + 10;;
        }
    }
    groupImgCount[groupCount] = $imgIndex.length;
    $(".graphicsPicScroller_Item").css("visibility", "visible");
    $(".graphicsPicScroller_Item").hide();
    $(".graphicsPicScroller__itemContainer img").hide();
    DisplayNextGroup(false);
}

function DisplayNextGroup(isRight) {
    if (isRight) {
        // only show next group if it's in range
        if (currGroup < groupCount) {
            $(".graphicsPicScrollerGroup" + currGroup).fadeOut(fadeDelay, function () {
                // Only call this callback one time.  We'll do this when the animation has been completed for all
                // of the elements in this batch.
                if ($(".graphicsPicScrollerGroup" + currGroup + ":animated").length === 0) {
                    currGroup++;
                    $(".graphicsPicScrollerGroup" + currGroup).fadeIn(fadeDelay);
                }
                DisplayNewImageRangeValues();  //Called here so we're sure animation is complete and currGroup is current.
            });
        }
    } else {
        if (currGroup > 0) {
            //hide current group
            $(".graphicsPicScrollerGroup" + currGroup).fadeOut(fadeDelay).promise().done(function () {
                // Only call this callback one time.  We'll do this when the animation has been completed for all
                // of the elements in this batch.
                if ($(".graphicsPicScrollerGroup" + currGroup + ":animated").length === 0) {
                    currGroup--;
                    $(".graphicsPicScrollerGroup" + currGroup).fadeIn(fadeDelay);
                    DisplayNewImageRangeValues(); //Called here so we're sure animation is complete and currGroup is current.
                }
            });
            
        } else {
            $(".graphicsPicScrollerGroup" + currGroup).delay(fadeDelay).fadeIn(fadeDelay);
            DisplayNewImageRangeValues();
        }
    }
    

}

function DisplayNewImageRangeValues() {
    //calculate the pic range being viewed
    var hiRange = 0;
    var loRange = 1;

    hiRange = parseInt(groupImgCount[currGroup]);

    //Get the value of the previous group and display that number plus one for the loRange.
    if (currGroup > 0) {
        loRange = parseInt(groupImgCount[parseInt(currGroup - 1)]) + 1;
    }

    $(".picHiRange").html(hiRange);
    $(".picLoRange").html(loRange);
}