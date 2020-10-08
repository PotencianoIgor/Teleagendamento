var ui = {
    mascararCampos: function () {
        $('#Endereco_CEP').mask('00000-000');
        $('#Telefone').mask('(00) 0 0000-0000');
        $('#CNPJ').mask("99.999.999/9999-99");
    },
  
    init: function () {
        this.mascararCampos();
        // this.inicializarComponentes();
    },

    consultarCepApi: function (cep) {

        $.ajax({
            url: 'https://viacep.com.br/ws/' + cep + '/json/',
            type: "GET",
            dataType: "Json",
            success: function (retorno) {
                $('#Endereco_Logradouro').val(retorno.logradouro);
                $('#Endereco_Bairro').val(retorno.bairro);
                $('#Endereco_Cidade').val(retorno.localidade);
            },
            error: function (jqXHR, exception) {
                if (jqXHR.status === 0) {
                    alert('Not connect.n Verify Network.');
                } else if (jqXHR.status == 404) {
                    alert('Requested page not found. [404]');
                } else if (jqXHR.status == 500) {
                    alert('Internal Server Error [500].');
                } else if (exception === 'parsererror') {
                    alert('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    alert('Time out error.');
                } else if (exception === 'abort') {
                    alert('Ajax request aborted.');
                } else {
                    alert('Uncaught Error.n' + jqXHR.responseText);
                }
            }
        });
    }
};

$(document).ready(function () {

    $('#cadastro-clinica')
        .on('change', '#Endereco_CEP', function () {
            var cep = $(this).val();
            if (cep.length === 9) {
                cep = cep.replace("-", '');
                ui.consultarCepApi(cep);
            }
        })
        .on('click', '#salvar', function (e) {
            var cep = $('#Endereco_CEP').val().length > 0;
            var logradouro = $('#Endereco_Logradouro').val().length > 0;
            var bairro = $('#Endereco_Bairro').val().length > 0;
            var cidade = $('#Endereco_Cidade').val().length > 0;
            if (!cep || !logradouro || !bairro || !cidade) {
                e.preventDefault();
                $('#endereco-tab').click();
            }
        });

    ui.init();
})