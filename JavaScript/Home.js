$('.nav-toggle').click(function () {
    var collapse_content_selector = $(this).attr('href');
    var toggle_switch = $(this);
    $(collapse_content_selector).toggle(function () {
        if ($(this).css('display') == 'none') {
            // toggle_switch.html.replace('&#9660;', '&#9654;');
        } else {
            //  toggle_switch.html.replace('&#9654;', '&#9660;');
        }
    });
});