window.addEventListener('DOMContentLoaded', () => {
    toggleMenu();
})

function toggleMenu() {
    const $btnMenu = document.querySelector('.principal-nav__logo-menu__btn-mobile');

    document.addEventListener('click', e => {
        if (e.target === $btnMenu) {
            let $menu = document.querySelector('.principal-nav__link-list');
            $menu.classList.toggle('isOpen');
            ($menu.classList.contains('isOpen')) ? $btnMenu.innerHTML = 'close' : $btnMenu.innerHTML = 'menu'
        }
    });
}
