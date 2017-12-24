//BANCOS
$(document).ready(function () {
    $("#bancosInput").hide();

    $("#pesquisaBancos").click(function () {
        $("#bancosInput").fadeIn(300);
        $("#bancosTable").empty();
        $(this).fadeOut(300);
    })

    $("#bancosInput").keyup(function () {
        var tempUrl = "http://localhost:57756/Plataforma/Cheques/GetBancos"
        var qualifiedUrl = '@Url.Action("GetBancos")';
        var prefix = $("#bancosInput").val();

        $.ajax({
            url: tempUrl,
            type: "GET",
            cache: true,
            data: { bancoPrefix: prefix },
            success: function (response) {
                if (response.includes("<tr>"))
                    $("#bancosTable").html(response);
                else
                    $("#bancosTable").html("<p>Nenhum banco encontrado.</p>")
            },
            beforeSend: function (param) {
                $("#bancosTable").append("<p id=\"loadingCaption\">Buscando informações...</p>");
            },
            complete: function (param, status) {
                $("#bancosTable").children().remove("#loadingCaption");
            }
        });
    });
    

    //PESSOAS
    $("#pessoasInput").hide();

    $("#pesquisaPessoas").click(function () {
        $("#pessoasInput").fadeIn(300);
        $("#pessoasTable").empty();
        $(this).fadeOut(300);
    })

    $("#pessoasInput").keyup(function () {
        var tempUrl = "http://localhost:57756/Plataforma/Cheques/GetPessoas"
        var qualifiedUrl = '@Url.Action("GetPessoas")';
        var prefix = $("#pessoasInput").val();

        $.ajax({
            url: tempUrl,
            type: "GET",
            cache: true,
            data: { pessoaPrefix: prefix },
            success: function (response) {
                if (response.includes("<tr>"))
                    $("#pessoasTable").html(response);
                else
                    $("#pessoasTable").html("<p>Nenhuma pessoa encontrada.</p>")
            },
            beforeSend: function (param) {
                $("#pessoasTable").append("<p id=\"loadingCaption\">Buscando informações...</p>");
            },
            complete: function (param, status) {
                $("#pessoasTable").children().remove("#loadingCaption");
            }
        });
    });
})