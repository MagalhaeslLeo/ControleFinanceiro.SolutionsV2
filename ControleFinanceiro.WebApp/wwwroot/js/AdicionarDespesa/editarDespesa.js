﻿document.addEventListener('DOMContentLoaded', function () {

    //Validações dos campos do formulário
    var form = document.getElementById('frmEditar');
    var descricao = document.getElementById('descricaoEditar');
    var periodo = document.getElementById('periodoEditar');
    var valor = document.getElementById('valorEditar');
    var submitButton = document.getElementById('submitButtonEditar');


    descricao.addEventListener('input', validacaoDescricao);
    descricao.addEventListener('blur', validacaoDescricao);

    valor.addEventListener('input', validacaoValor);
    valor.addEventListener('blur', validacaoValor);

    periodo.addEventListener('input', validacaoPeriodo);
    periodo.addEventListener('blur', validacaoPeriodo);

    function atualizarSubmitButton() {
        submitButton.disabled = !(validacaoDescricao() && validacaoValor && validacaoPeriodo());
    };

    descricao.addEventListener('input', atualizarSubmitButton);
    valor.addEventListener('input', atualizarSubmitButton);
    periodo.addEventListener('input', atualizarSubmitButton);

    form.addEventListener('submit', function (event) {
        event.preventDefault();
        var validacao = validacaoFormulario();
        if (validacao) {
            form.submit();
        }
    });

    function validacaoFormulario() {
        var validado = true;
        validado = validacaoDescricao() && validado;
        validado = validacaoValor() && validado;
        validado = validacaoPeriodo() && validado;
        submitButton.disabled = !validado;
        return validado;
    };

    function validacaoDescricao() {
        var descricaoErro = document.getElementById('descricaoErroEditar');
        if (descricao.value.trim() === '') {
            descricao.classList.add('is-invalid');
            descricaoErro.textContent = 'Informe a descrição';
            return false;
        }
        else {
            descricao.classList.remove('is-invalid');
            descricaoErro.textContent = '';
            return true;
        }
    }

    function validacaoValor() {
        var valorErro = document.getElementById('valorErroEditar');
        if (valor.value === "0,00" || valor.value === '') {
            valor.classList.add('is-invalid');
            valorErro.textContent = 'Informe o valor';
            return false;
        }
        else {
            valor.classList.remove('is-invalid');
            valorErro.textContent = '';
            return true;
        }
    }

    function validacaoPeriodo() {
        var periodoErro = document.getElementById('periodoErroEditar');
        if (periodo.value === '') {
            periodo.classList.add('is-invalid');
            periodoErro.textContent = 'Informe a data';
            return false;
        }
        else {
            periodo.classList.remove('is-invalid');
            periodoErro.textContent = '';
            return true;
        }
    }
});
