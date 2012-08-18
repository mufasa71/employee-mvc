/* Author:

*/
function doKickstart() {
    $('.icon').each(function () {
        $(this).append('<span aria-hidden="true">' + $(this).attr('data-icon') + '</span>')
		.css('display', 'inline-block');

    });
    $('input[type=checkbox]').addClass('checkbox');
    $('ul').find('li:first-child').addClass('first');
    $('ul').find('li:last-child').addClass('last');
    $('hr').before('<div class="clear">&nbsp;</div>');
}




