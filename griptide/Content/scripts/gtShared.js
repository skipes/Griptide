$(document).ready(function () {
    $('.menu_l, .menu_r').hover(
                      function () {
                          //console.log("hoverIn");
                          origColor = $(this).find("span").css("color");
                          $(this).find("span").css("color", "#FFF");
                      },
                      function () {
                          //console.log("hoverOut");
                          console.log(origColor);
                          $(this).find("span").css("color", "#999");
                      });

    $('.menu').css('text-decoration', 'dotted');
});