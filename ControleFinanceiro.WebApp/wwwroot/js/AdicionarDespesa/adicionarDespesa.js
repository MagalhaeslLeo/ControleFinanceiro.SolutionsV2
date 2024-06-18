document.addEventListener('DOMContentLoaded', function () {
    debugger;
    var descricao = document.getElementById('descricao');
    var periodo = document.getElementById('periodo');
    var valor = document.getElementById('valor');

    descricao.addEventListener('input', validacaoDescricao);
    descricao.addEventListener('blur', validacaoDescricao);

    valor.addEventListener('input', validacaoValor);
    descricao.addEventListener('blur', validacaoValor);

    function validacaoDescricao() {
        var descricaoErro = document.getElementById('descricaoErro');
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
        var valorErro = document.getElementById('valorErro');
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
});
