﻿$(function () {
    $("#cboMarca").change(function ()
    {
        var marcaId = $(this).val();
        var actionUrl = './RetornarModelos/?marcaId=' + marcaId;
        $.getJSON(actionUrl, function (data)
        {
            $('#cboModelo').empty();
            $('#cboModelo').append('<option value="-1">Carregando...</option>');
            $(data.modelos).each(function (key, val)
            {
                $('#cboModelo').append('<option value="' + val.codigo + '">' + val.nome + '</option>');
            });

            $('#cboAno').empty();
            $('#cboAno').append('<option value="-1">Carregando...</option>');
            $(data.anos).each(function (key, val) {
                $('#cboAno').append('<option value="' + val.codigo + '">' + val.nome + '</option>');
            });
        });
    });
})
