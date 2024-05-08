$('.botaoMostrarModal').on('click', function () {
    var targetId = $(this).data('target');
    $(targetId).modal('show');
})