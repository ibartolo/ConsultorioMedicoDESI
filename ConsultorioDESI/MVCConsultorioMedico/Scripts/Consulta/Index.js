$(document).ready(function () {
    ValidarDatos();
    $("#Paciente").select2({
        width: '100%',
        placeholder: "seleccione un paciente"
    });
})

function ValidarDatos() {
    $("#frmConsulta").validate({
        rules: {
            Paciente: {
                required: true
            },
            Fecha: {
                required: true
            },
            Hora: {
                required: true
            },
            TipoConsulta: {
                required: true
            },
            Comentarios: {
                required: true,
                maxlength: 500
            }
        },
        messages: {
            Paciente: {
                required: "El campo Paciente es obligatorio"
            },
            Fecha: {
                required: "El campo Fecha es obligatorio"
            },
            Hora: {
                required: "El campo Hora es obligatorio"
            },
            TipoConsulta: {
                required: "Elige el tipo de consulta"
            },
            Comentarios: {
                required: "El campo Comentarios es obligatorio",
                maxlength: "Los comentarios no pueden exceder los 500 caracteres"
            }
        }
    })
}
