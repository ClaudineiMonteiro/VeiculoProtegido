$(function(){
    $("#cboEstado").change(function () {
        var estadoId = $(this).val();

        var actionUrl = './RetornarCidades/?estadoId=' + estadoId;

        $('#cboCidade').empty();
        $('#cboCidade').append('<option value="-1">Carregando...</option>');

        $.getJSON(actionUrl, function (data) {
            $('#cboCidade').empty();
            $(data).each(function (key, val) {
                $('#cboCidade').append('<option value="' + val.Codigo + '">'+ val.Nome + '</option>');
            })
        });
    });

    $("#btnValorCidade").click(function () {
        alert($("#cboCidade").val());
    });

})