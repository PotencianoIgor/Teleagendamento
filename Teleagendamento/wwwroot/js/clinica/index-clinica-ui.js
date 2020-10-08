
$('#expande-filtro').on('click', function () {
    let expandido = JSON.parse($(this).attr('aria-expanded'));
    let icone = $(this).find('i');
    if (expandido == true) {
        icone.removeClass('fa-minus');
        icone.addClass('fa-plus');
    }
    else {
        icone.removeClass('fa-plus');
        icone.addClass('fa-minus');
    }
});

$("tr.linha-conteudo").on('click', function () {
    $(this).addClass("table-dark").siblings().removeClass("table-dark");
    $(this).addClass("selected").siblings().removeClass("selected");
})

$('#editar').click(function () {
    let id = $('.table-responsive').find('tr.selected').find('th').first().text();

    if (id.length == 0) {
        $("#selecione-registro").dialog({
            title: "Atenção!",
            hide: { effect: "explode", duration: 800 },
            dialogClass: "alert",
            buttons: [
                {
                    text: "Ok",
                    icon: "ui-icon-heart",
                    click: function () {
                        $(this).dialog("close");
                    }
                }
            ]
        });
    }
    else {
        let url = window.location.origin + '/Clinica/Cadastro/' + id;
        window.location.href = url;
    }
})