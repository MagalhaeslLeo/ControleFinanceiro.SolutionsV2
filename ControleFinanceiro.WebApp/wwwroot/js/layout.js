﻿//Obtém a URL Base da aplicação pelo layout ou por uma página específica
var urlBaseElement = document.querySelector('meta[name=base-url]');
var urlBaseId = document.getElementById('base-url');
var urlBaseContent = urlBaseElement ? urlBaseElement.getAttribute('content') ||
    urlBaseId.getAttribute('data-base-url') : '';


document.addEventListener("DOMContentLoaded", function () {

    // Função para recuperar o estado do menu e aplicar
    fetch(urlBaseContent + 'ModuloMenu/FuncionalidadeMenu')
        .then(response => response.json())
        .then(data => {
            if (data) {
                let menuState = JSON.parse(data);
                for (let id in menuState) {
                    let element = document.getElementById(id);
                    if (element) {
                        element.style.display = menuState[id];
                    }
                }
            }
        });

    //Adicionar event Listeners nos itens do menusuperior

    document.querySelectorAll('.menuModulo').forEach(item => {
        item.addEventListener('click', function () {

            let menuId = this.dataset.menuId; 
            let menuElement = document.getElementById(menuId);

            if (menuElement) {
                // Alterna o display do menu
                if (menuElement.style.display === 'none') {
                    menuElement.style.display = 'block';
                } else {
                    menuElement.style.display = 'none';
                }

                // Armazena o estado do menu na sessão
                let menuState = {};
                document.querySelectorAll('.menu-content').forEach(menu => {
                    menuState[menu.id] = menu.style.display;
                });

                fetch(urlBaseContent + 'ModuloMenu/DefinirEstadoFuncionalidadeMenu', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(menuState)
                });
            }
        });
    });
});