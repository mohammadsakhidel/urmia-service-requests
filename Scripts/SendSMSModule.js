var numbers_old_text = "";
var sms_old_text = "";
///////////////////////////////////////////// EVENT HANDLERS:

$(function () {

    ///// sms text changed:
    $('[id*=tb_Text]').keyup(function (e) {
        var newText = $(this).val();
        if (sms_old_text != newText) {
            show_sms_length(newText);
        }
        sms_old_text = newText;
    });

    ///// numbers text changed:
    $('[id*=tb_Numbers]').keyup(function (e) {
        var newText = $(this).val();
        if (numbers_old_text != newText) {
            show_lines_count(newText);
        }
        numbers_old_text = newText;
    });

    ///// show book selector:
    $('[id*=btn_book_numbers]').click(function () {
        $('#div_book_selector').slideToggle(250);
    });

    ///// toggle search citizen
    $('#btn_citizens_advanced_search').click(function () {
        $('#div_citizens_advanced_search').slideToggle(200);
    });

    ///// toggle search books
    $('#btn_books_advanced_search').click(function () {
        $('#div_books_advanced_search').slideToggle(200);
    });

});

/////////////////////////////////////////////// FUNCTIONS:

function show_loading() {
    $('[id*=pnl_Message]').attr('class', 'hide');
    $('[id*=lbl_wait]').text('در حال ارسال، لطفاً منتظر باشید ...').show();
    return true;
}

function show_lines_count(numbersText) {
    var lines = numbersText.split("\n");
    var count = 0;
    for (var i = 0; i < lines.length; i++) {
        var number = lines[i];
        if (number.length >= 10) {
            number = number.substring((number.length - 10), (number.length - 1));
            if (number.substring(0, 1) == "9")
                count++;
        }
    }
    $("[id*=lbl_lines_count]").text(count.toString());
}

function show_sms_length(smsText) {
    var sms_count = parseInt(smsText.length / 70) + (smsText.length % 70 == 0 ? 0 : 1);
    $('#lbl_sms_length').text(smsText.length + "/" + sms_count);
}