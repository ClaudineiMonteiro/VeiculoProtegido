$(function () {
    $("#cboMarca").change(function () {
        $('#cboModelo').empty().append('<option value="-1">Carregando...</option>');
        $('#cboAno').empty().append('<option value="-1">Carregando...</option>');
        var marcaId = $(this).val();
        var actionUrl = './RetornarModelos/?marcaId=' + marcaId;
        $.getJSON(actionUrl, function (data) {
            $('#cboModelo').empty();
            $('#cboAno').empty();
            $(data.modelos).each(function (key, val) {
                $('#cboModelo').append('<option value="' + val.codigo + '">' + val.nome + '</option>');
            });
            $(data.anos).each(function (key, val) {
                $('#cboAno').append('<option value="' + val.codigo + '">' + val.nome + '</option>');
            });
        });
    });

    $("#cboModelo").change(function () {
        $('#cboAno').empty().append('<option value="-1">Carregando...</option>');
        var marcaId = document.getElementById('cboMarca').value;
        var modeloId = $(this).val();
        var actionUrl = './RetornarAnoPorModelo/?marcaId=' + marcaId + '&modeloId=' + modeloId;
        $.getJSON(actionUrl, function (data) {
            $('#cboAno').empty();
            $(data).each(function (key, val) {
                $('#cboAno').append('<option value="' + val.codigo + '">' + val.nome + '</option>');
            });
        });
    });
})