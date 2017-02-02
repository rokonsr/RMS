//Slider for home page

$(function () {
    SyntaxHighlighter.all();
});
$(window).load(function () {
    $('.flexslider').flexslider({
        animation: "slide",
        start: function (slider) {
            $('body').removeClass('loading');
        }
    });
});

// Show modal without postback
function ShowModalPopup() {
    $find("mpe").show();
    return false;
}
function HideModalPopup() {
    $find("mpe").hide();
    return false;
}