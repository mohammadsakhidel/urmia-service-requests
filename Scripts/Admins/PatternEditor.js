$(function () {

    $('#btn_insert_name').click(function () {
        insert_text("--name--");
    });

    $('#btn_insert_position').click(function () {
        insert_text("--position--");
    });

    function insert_text(text) {
        var currentText = $('[id*=tb_Text]').val();
        $('[id*=tb_Text]').val(currentText + text);
        $('[id*=tb_Text]').focus();
    }

});