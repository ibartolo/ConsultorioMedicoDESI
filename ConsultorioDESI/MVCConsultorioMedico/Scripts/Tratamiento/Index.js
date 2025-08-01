$(document).ready(function () {
    ValidarDatos();

    $('#tblTratamiento').DataTable({
        columns: [
            {
                title: "Id",
                data: "Id",
                visible: false
            },
            {
                title: "Nombre",
                data: "Nombre"
            },
            {
                title: "Duración (min)",
                data: "Duracion"
            },
            {
                title: "Descripción",
                data: "Descripcion"
            }
        ]
    });

    $.ajax({
        url: "/Tratamiento/GetAllCatalogoTratamiento",
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data)
            $("#tblTratamiento").dataTable().fnAddData(data);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
});

function ValidarDatos() {
    $("#frmTratamiento").validate({
        rules: {
            Nombre: {
                required: true,
                minlength: 3,
                maxlength: 250
            },
            Duracion: {
                required: true,
                number: true
            },
            Descripcion: {
                maxlength: 500
            }
        },
        messages: {
            Nombre: {
                required: "El nombre del tratamiento es obligatorio.",
                minlength: "El nombre debe tener al menos 3 caracteres.",
                maxlength: "El nombre no puede exceder los 250 caracteres"
            },
            Duracion: {
                required: "Este campo es obligatorio",
                number: "La duración debe ser un número válido"
            },
            Descripcion: {
                maxlength: "La descripción no puede exceder los 500 caracteres"
            }
        }
    });
}