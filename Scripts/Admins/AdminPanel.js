///////////////////////////////////////////// EVENT HANDLERS:

$(function () {

    $('a.panel_menu_item').click(function () {

        if (!$(this).hasClass('panel_menu_item_selected')) {
            $('.panel_sub_menu').slideUp(250);
            $(this).next('div').slideDown(250);
            $('.panel_menu_item_selected').removeClass('panel_menu_item_selected').addClass('panel_menu_item');
            $(this).removeClass('panel_menu_item').addClass('panel_menu_item_selected');
        }
        else {

            $(this).next('div').slideUp(250);
            $(this).removeClass('panel_menu_item_selected').addClass('panel_menu_item');

        }

    });

});

/////////////////////////////////////////////// FUNCTIONS: