$(document).ready(function () {
    ValidarDatos();

    $('#tblPaquete').DataTable({
        columns: [
            { 
                title: "Paquete",
                data: "NombrePaquete"
            },
            {
                title: "Precio",
                data: "Costo"
            }
        ]
    });

    $.ajax({
        type: 'get',
        url: "/Paquete/GetAllPaquete",
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
            $("#tblPaquete").dataTable().fnAddData(data);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
});

function ValidarDatos() {
    $("#frmPaquete").validate({
        rules: {
            "NombrePaquete": {
                required: true,
                minlength: 4,
                maxlength: 125
            },
            "Costo": {
                required: true,
                number: true
            },
            "Descripcion": {
                maxlength: 500
            }
        },
        messages: {
            "NombrePaquete": {
                required: "El nombre del paquete es requerido",
                minlength: "El nombre del paquete debe tener al menos 4 caracteres",
                maxlength: "El nombre del paquete no puede exceder los 125 caracteres"
            },
            "Costo": {
                required: "El precio es requerido",
                number: "El precio debe ser un número válido"
            },
            "Descripcion": {
                maxlength: "La descripción no puede exceder los 500 caracteres"
            }
        }
    })
}