document.addEventListener('DOMContentLoaded', function () {
    // Elementos del DOM
    const authPage = document.getElementById('authPage');
    const dashboard = document.getElementById('dashboard');
    const loginForm = document.getElementById('loginForm');
    const logoutBtn = document.getElementById('logoutBtn');
    const menuItems = document.querySelectorAll('.menu-item');
    const tabs = document.querySelectorAll('.tab');
    const tabContents = document.querySelectorAll('.tab-content');
    const notificationBtn = document.getElementById('notificationBtn');
    const notificationContainer = document.getElementById('notificationContainer');
    const notificationForm = document.getElementById('notificationForm');

    // Función para mostrar notificación
    function showNotification(type, title, message) {
        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;

        let iconClass = 'fas fa-info-circle';
        if (type === 'success') iconClass = 'fas fa-check-circle';
        if (type === 'error') iconClass = 'fas fa-exclamation-circle';
        if (type === 'warning') iconClass = 'fas fa-exclamation-triangle';

        notification.innerHTML = `
                        <div class="notification-icon">
                            <i class="${iconClass}"></i>
                        </div>
                        <div class="notification-content">
                            <div class="notification-title">${title}</div>
                            <div class="notification-message">${message}</div>
                        </div>
                        <button class="notification-close">
                            <i class="fas fa-times"></i>
                        </button>
                    `;

        notificationContainer.appendChild(notification);
        notificationContainer.style.display = 'block';

        // Evento para cerrar la notificación
        notification.querySelector('.notification-close').addEventListener('click', function () {
            notification.style.animation = 'fadeIn 0.3s ease reverse';
            setTimeout(() => {
                notificationContainer.removeChild(notification);
                if (notificationContainer.children.length === 0) {
                    notificationContainer.style.display = 'none';
                }
            }, 300);
        });

        // Auto cerrar después de 5 segundos
        setTimeout(() => {
            if (notification.parentNode) {
                notification.style.animation = 'fadeIn 0.3s ease reverse';
                setTimeout(() => {
                    if (notification.parentNode) {
                        notificationContainer.removeChild(notification);
                        if (notificationContainer.children.length === 0) {
                            notificationContainer.style.display = 'none';
                        }
                    }
                }, 300);
            }
        }, 5000);
    }

    // Iniciar sesión
    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const username = this.querySelector('input[type="text"]').value;
        const password = this.querySelector('input[type="password"]').value;

        if (username && password) {
            // Simular inicio de sesión exitoso
            authPage.classList.add('hidden');
            dashboard.classList.remove('hidden');

            // Mostrar notificación de bienvenida
            showNotification('success', '¡Bienvenido!', 'Has iniciado sesión correctamente.');
        } else {
            showNotification('error', 'Error', 'Por favor, completa todos los campos.');
        }
    });

    // Cerrar sesión
    logoutBtn.addEventListener('click', function () {
        authPage.classList.remove('hidden');
        dashboard.classList.add('hidden');
        showNotification('info', 'Sesión finalizada', 'Has cerrado sesión correctamente.');
    });

    // Navegación del menú
    menuItems.forEach(item => {
        item.addEventListener('click', function (e) {
            e.preventDefault();

            // Quitar activo de todos los items
            menuItems.forEach(i => i.classList.remove('active'));

            // Agregar activo al item clickeado
            this.classList.add('active');

            // Ocultar todos los contenidos de pestañas
            tabContents.forEach(content => content.classList.remove('active'));

            // Mostrar la pestaña correspondiente
            const tabId = this.getAttribute('data-tab');
            document.getElementById(tabId).classList.add('active');
        });
    });

    // Navegación de pestañas
    tabs.forEach(tab => {
        tab.addEventListener('click', function () {
            // Quitar activo de todas las pestañas
            tabs.forEach(t => t.classList.remove('active'));

            // Agregar activo a la pestaña clickeada
            this.classList.add('active');

            // Ocultar todos los contenidos de pestañas
            document.querySelectorAll('.tab-content').forEach(content => content.classList.remove('active'));

            // Mostrar el contenido correspondiente
            const contentId = this.getAttribute('data-content');
            document.getElementById(contentId).classList.add('active');
        });
    });

    // Botón de notificaciones
    notificationBtn.addEventListener('click', function () {
        showNotification('info', 'Notificaciones', 'Tienes 3 notificaciones sin leer.');
    });

    // Envío de notificación por correo
    notificationForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const subject = this.querySelector('input[type="text"]').value;

        // Simular envío de notificación
        showNotification('success', 'Notificación enviada', `La notificación "${subject}" ha sido enviada correctamente.`);

        // Resetear formulario
        this.reset();
    });

    // Demo de notificaciones
    setTimeout(() => {
        showNotification('info', 'Recordatorio', 'Tienes una reunión programada en 15 minutos.');
    }, 3000);

    setTimeout(() => {
        showNotification('warning', 'Advertencia', 'El sistema se cerrará por mantenimiento en 1 hora.');
    }, 8000);
});