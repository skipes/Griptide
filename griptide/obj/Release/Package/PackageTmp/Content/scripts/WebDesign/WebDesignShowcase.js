$(document).ready(function () {
    $(".webDesignShowcase__scrollList_sample--overlay").click(function () {
        var $iframe = $(this).parent().find("iframe");
        var $span = $(this).parent().find("span");
        var iframeSrc = $iframe.attr("src");
        
        //reload the iframe with the new source
        $(".webDesignShowcase__feature iframe").attr("src", iframeSrc);

        //reload text
        var descHeight = $(".featureDescription").height();
        $(".featureDescription").animate({ height: 0 }, 200, function () {
            $(".featureDescription__spanHolder").html("");
            $(".featureDescription__spanHolder").append($span.clone());
        });
        
        $(".featureDescription").animate({ height: descHeight }, 200);
    });

    $(".webDesignShowcase__feature--overlay").click(function () {
        console.log("in");
        var $targetIFrame = $(this).parent().find("iframe");
        window.open($targetIFrame.attr("src"));
    });

    $(".webDesignShowcase__scrollList_sample--overlay:first").click();
});