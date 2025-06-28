$(document).ready(function () {
    ValidarDatos();
});

function ValidarDatos() {
    $("#frmDatosFiscales").validate({
        rules: {
            "RFC": {
                required: true,
                maxlength: 20,
                minlength: 12
            },
            "RazonSocial": {
                required: true,
                maxlength: 50
            },
            "DireccionSocial": {
                required: true,
                maxlength: 90
            },
            "Email": {
                required: true,
                email: true
            },
            "Regimen": {
                required: true,
                maxlength: 90
            },
            "EmpresaId": {
                required: true
            }
        },
        messages: {
            "RFC": {
                required: "El RFC es requerido.",
                maxlength: "El RFC no puede tener más de 20 caracteres.",
                minlength: "El RFC debe tener al menos 12 caracteres."
            },
            "RazonSocial": {
                required: "La razón social es requerida.",
                maxlength: "la razón social no puede tener más de 50 caracteres."
            },
            "DireccionSocial": {
                required: "La dirección es requerida.",
                maxlength: "La dirección no puede tener más de 90 caracteres."
            },
            "Email": {
                required: "El correo electrónico es requerido.",
                email: "El formato del correo electrónico es inválido."
            },
            "Regimen": {
                required: "El régimen fiscal es requerido.",
                maxlength: "El régimen fidcal no puede tener mas de 90 caracteres."
            },
            EmpresaId: {
                required: "La empresa es requerida.",
            }
        }
    })
}