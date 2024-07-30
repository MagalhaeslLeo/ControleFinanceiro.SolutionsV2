document.addEventListener('DOMContentLoaded', function () {

    var forms = document.querySelectorAll('form.editar-usuario');

    //Validações dos campos do formulário
    forms.forEach(function (form) {
        var nome = form.querySelector('[id^="nomeEditar"]');
        var email = form.querySelector('[id^="emailEditar"]');
        var senha = form.querySelector('[id^="senhaEditar"]');
        var submitButton = form.querySelector('[id^="submitButtonEditar"]');
    

    nome.addEventListener('input', validacaoNome);
    nome.addEventListener('blur', validacaoNome);

    email.addEventListener('input', validacaoEmail);
    email.addEventListener('blur', validacaoEmail);

    senha.addEventListener('input', validacaoSenha);
    senha.addEventListener('blur', validacaoSenha);

    function atualizarSubmitButton() {
        submitButton.disabled = !(validacaoNome() && validacaoEmail() && validacaoSenha());
    };

    nome.addEventListener('input', atualizarSubmitButton);
    email.addEventListener('input', atualizarSubmitButton);
    senha.addEventListener('input', atualizarSubmitButton);

    form.addEventListener('submit', function (event) {
        event.preventDefault();
        var validacao = validacaoFormulario();
        if (validacao) {
            form.submit();
        }
    });

    function validacaoFormulario() {
        var validado = true;
        validado = validacaoNome() && validado;
        validado = validacaoEmail() && validado;
        validado = validacaoSenha() && validado;
        submitButton.disabled = !validado;
        return validado;
    };

    function validacaoNome() {
        var nomeErro = form.querySelector('[id^=nomeErroEditar]');
        if (!nome.value) {
            nome.classList.add('is-invalid');
            nomeErro.textContent = 'Informe o nome do usuário';
            return false;
        }
        else if (nome.value.length < 6) {
            debugger;
            nome.classList.add('is-invalid');
            nomeErro.textContent = 'Informe um nome com pelo menos 6 caracteres';
            return false;
        }
        else {
            nome.classList.remove('is-invalid');
            nomeErro.textContent = '';
            return true;
        }
    }

    function validacaoEmail() {
        var emailErro = form.querySelector('[id^=emailErroEditar]');
        var validacaoPadraoEmail = /^[^\s]+@[^\s]+\.[^\s]+$/;
        if (!validacaoPadraoEmail.test(email.value.trim())) {
            email.classList.add('is-invalid');
            emailErro.textContent = 'Informe um e-mail válido';
            return false;
        }
        else {
            email.classList.remove('is-invalid');
            emailErro.textContent = '';
            return true;
        }

    }

    function validacaoSenha() {
        var senhaErro = form.querySelector('[id^=senhaErroEditar]');
        var validacaoPadraoSenha = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
        if (!validacaoPadraoSenha.test(senha.value.trim())) {
            senha.classList.add('is-invalid');
            senhaErro.textContent = 'Informe uma senha com no mínimo: 8 caracteres contendo letra maiúscula, minúscula e caractere especial';
            return false;
        }
        else {
            senha.classList.remove('is-invalid');
            senhaErro.textContent = '';
            return true;
        }
    }
});
});