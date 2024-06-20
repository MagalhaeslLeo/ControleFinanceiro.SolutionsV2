$('.botaoMostrarModal').on('click', function () {
    var targetId = $(this).data('target');
    $(targetId).modal('show');
});

document.addEventListener('DOMContentLoaded', function () {
    function showSpinner() {
        var spinner = document.getElementById('spinner');
        spinner.classList.remove('d-none');
    }
    function hideSpinner() {
        var spinner = document.getElementById('spinner');
        spinner.classList.add('d-none');
    }
    showSpinner();

    window.addEventListener('load', function () {
        hideSpinner();
    })
});

