var sms_old_text = "";
/////////////////////////////////////////
$(function () {
    ///// sms text changed:
    $('.settings_item .textbox').keyup(function (e) {
        var newText = $(this).val();
        if (sms_old_text != newText) {
            show_sms_length($(this).attr('id').split('tb_')[1]);
        }
        sms_old_text = newText;
    });

    ///// checked changed:
    $('.settings_item .checkbox').change(function (e) {
        var fieldName = $(this).parent().next('div').find('textarea').attr('id').split('tb_')[1];
        var checked = $("[id*=ch_" + fieldName + "]").attr('checked');
        if (!checked) {
            $("[id*=tb_" + fieldName + "]").addClass('disabled_textbox');
            $("[id*=tb_" + fieldName + "]").attr('readonly', 'readonly');
        }
        else {
            $("[id*=tb_" + fieldName + "]").removeClass('disabled_textbox');
            $("[id*=tb_" + fieldName + "]").attr('readonly', '');
        }
    });
});
///////////////////////////////////////// FUNCTIONS:
function show_sms_length(fieldName) {
    var smsText = $("[id*=" + "tb_" + fieldName + "]").val();
    var sms_count = parseInt(smsText.length / 70) + (smsText.length % 70 == 0 ? 0 : 1);
    $("[id*=" + "lbl_" + fieldName + "]").text(smsText.length + "/" + sms_count);
}

function hide_response_message() {
    $('[id*=msg_responseSettings]').hide();
    return tru;
}

function hide_inform_message() {
    $('[id*=pnl_message_inform_settings]').hide();
    return tru;
}