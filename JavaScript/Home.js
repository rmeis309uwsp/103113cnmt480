//Collapse/expand item descriptions
$('.nav-toggle').click(function () {
    var collapse_content_selector = $(this).attr('href');
    var toggle_switch = $(this);
    $(collapse_content_selector).toggle(function () {
        if ($(this).css('display') == 'none') {
            // Switch "down" arrow to "right" arrow when closing div
            // toggle_switch.html.replace('&#9660;', '&#9654;');
        } else {
            // Switch "right" arrow to "down" arrow when opening div
            //  toggle_switch.html.replace('&#9654;', '&#9660;');
        }
    });
});

//Adding zebra stripes to item list
$('.itemcontainer:odd').addClass('graytitle');