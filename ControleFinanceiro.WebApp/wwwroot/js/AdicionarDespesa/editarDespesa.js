document.addEventListener('DOMContentLoaded', function () {


    var forms = document.querySelectorAll('form.editar-despesa');

    //Validações dos campos do formulário
    forms.forEach(function (form) {
        var descricao = form.querySelector('[id^="descricaoEditar"]');
        var periodo = form.querySelector('[id^="periodoEditar"]');
        var valor = form.querySelector('[id^="valorEditar"]');
        var submitButton = form.querySelector('[id^="submitButtonEditar"]');

        //Funções de validação
        function atualizarSubmitButton() {
            submitButton.disabled = !(validacaoDescricao() && validacaoValor && validacaoPeriodo());
        };

        function validacaoFormulario() {
            var validado = true;
            validado = validacaoDescricao() && validado;
            validado = validacaoValor() && validado;
            validado = validacaoPeriodo() && validado;
            submitButton.disabled = !validado;
            return validado;
        };

        function validacaoDescricao() {
            var descricaoErro = form.querySelector('[id^=descricaoErroEditar]');
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
            var valorErro = form.querySelector('[id^=valorErroEditar]');
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
            var periodoErro = form.querySelector('[id^=periodoErroEditar]');
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

        //Verifica se os elementos existem antes de adicionar os eventos
        if (descricao && valor && periodo && submitButton) {
            descricao.addEventListener('input', validacaoDescricao);
            descricao.addEventListener('blur', validacaoDescricao);

            valor.addEventListener('input', validacaoValor);
            valor.addEventListener('blur', validacaoValor);

            periodo.addEventListener('input', validacaoPeriodo);
            periodo.addEventListener('blur', validacaoPeriodo);


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
        }
    });
    
});
