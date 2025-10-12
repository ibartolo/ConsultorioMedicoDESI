$(document).ready(function () {
    ValidarDatos();

    $.ajax({
        url: "/Institucion/ObtenerDatos",
        type: "POST",
        dataType: "json",
        contentType: "json/application",
        success: function (data) {
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
})

function ValidarDatos() {
    $("#frmInstitucion").validate({
        rules: {
            Nombre: {
                required: true,
                maxlength: 300
            },
            NumeroTrabajadores: {
                required: true,
                number: true
            },
            TelefonoL1: {
                required: true,
                number: true,
                maxlength: 15
            },
            TelefonoL2: {
                required: true,
                maxlength: 15,
                number: true
            },
            Email: {
                required: true,
                email: true,
                maxlength: 125
            },
            Calle: {
                required: true,
                maxlength: 300
            },
            NumeroInterior: {
                required: true,
                maxlength: 150
            },
            NumeroExterior: {
                required: true,
                maxlength: 150
            },
            Colonia: {
                required: true,
                maxlength: 250
            },
            Delegacion: {
                required: true,
                maxlength: 250
            },
            Municipio: {
                required: true,
                maxlength: 250
            },
            Estado: {
                required: true,
                maxlength: 250
            },
            CodigoPostal: {
                required: true,
                number: true
            },
            Pais: {
                required: true,
                maxlength: 250
            }
        },
        messages: {
            Nombre: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Institución no debe exceder los 300 caracteres."
            },
            NumeroTrabajadores: {
                required: "El campo es obligatorio.",
                number: "El campo debe ser numérico."
            },
            TelefonoL1: {
                required: "El campo es obligatorio.",
                number: "El campo debe ser numérico.",
                maxlength: "El campo Teléfono Línea 1 no debe exceder los 15 caracteres."
            },
            TelefonoL2: {
                required: "El campo es obligatorio.",
                number: "El campo debe ser numérico.",
                maxlength: "El campo Teléfono Línea 2 no debe exceder los 15 caracteres."
            },
            Email: {
                required: "El campo es obligatorio.",
                email: "El campo debe ser un correo electrónico válido.",
                maxlength: "El campo Email no debe exceder los 125 caracteres."
            },
            Calle: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Calle no debe exceder los 300 caracteres."
            },
            NumeroInterior: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Número Interior no debe exceder los 125 caracteres."
            },
            NumeroExterior: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Número Exterior no debe exceder los 125 caracteres."
            },
            Colonia: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Colonia no debe exceder los 250 caracteres."
            },
            Delegacion: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Delegación no debe exceder los 250 caracteres."
            },
            Municipio: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Municipio no debe exceder los 250 caracteres."
            },
            Estado: {
                required: "El campo es obligatorio.",
                maxlength: "El campo Estado no debe exceder los 250 caracteres."
            },
            CodigoPostal: {
                required: "El campo es obligatorio.",
                number: "El campo debe ser numérico."
            },
            Pais: {
                required: "El campo es obligatorio.",
                maxlength: "El campo País no debe exceder los 250 caracteres."
            }
        }
    })
}