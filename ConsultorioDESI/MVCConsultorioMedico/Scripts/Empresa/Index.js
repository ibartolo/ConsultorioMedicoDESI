$(document).ready(function () {
    ValidarDatos();
});

function ValidarDatos() {
    $("#frmEmpresa").validate({
        rules: {
            "Nombre": {
                required: true,
                maxlength: 15,
                minlength: 4
            },
            "EmailContacto": {
                required: true,
                email: true
            }
        },
        messages: {
            "Nombre": {
                required: "El campo Nombre es requerido.",
                maxlength: "El nombre no puede ser mayor a 15 caracteres.",
                minlength: "El nombre tiene que ser mayor a 4 caracteres."
            }
        }
    });
}