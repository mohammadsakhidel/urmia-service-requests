///////////////////////////////////////////// EVENT HANDLERS:

$(function () {

    ///// Load:
    $('.panel_menu_reports').next('div').show();
    $('.panel_menu_reports').removeClass('panel_menu_item').addClass('panel_menu_item_selected');

});

/////////////////////////////////////////////// FUNCTIONS:
function ready_for_showing_chart() {
    var selectedVlaue = $('[id*=cmb_ChartType]').val();
    if (selectedVlaue.toString() == "0") {
        $('[id*=pnl_Chart]').hide();
        $('[id*=pnl_OrganSelector]').hide();
        return false;
    }
    else if (selectedVlaue.toString() == "1") {
        $('[id*=pnl_Chart]').hide();
        $('[id*=pnl_OrganSelector]').hide();
    }
    else if (selectedVlaue.toString() == "2") {
        $('[id*=pnl_Chart]').hide();
        $('[id*=pnl_OrganSelector]').fadeIn(300);
        return false;
    }
    return true;
}