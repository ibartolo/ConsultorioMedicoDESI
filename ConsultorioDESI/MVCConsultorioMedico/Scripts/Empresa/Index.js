$(document).ready(function () {
    ValidarDatos();

    $('#tblEmpresa').DataTable({
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
                title: "Descripción",
                data: "Descripcion"
            },
            {
                title: "Representante",
                data: "Representante"
            },
            {
                title: "TelContacto",
                data: "TelContacto"
            },
            {
                title: "EmailContacto",
                data: "EmailContacto"
            }
        ]
    });


    $.ajax({
        type: 'get',
        url: "/Empresa/GetAllEmpresas",
        cache: false,
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            
            console.log(data)

            $("#tblEmpresa").dataTable().fnAddData(data);
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
});

function ValidarDatos() {
    $("#frmEmpresa").validate({
        rules: {
            "Nombre": {
                required: true,
                maxlength: 10,      
                minlength: 4        
            },
            "EmailContacto": {
                required: true,
                email: true
            }, 
            "Representante": {
                required: true,
                maxlength: 250         
            },
            "Descripcion": {
                required: true,
                maxlength: 500     
            },
            "TelContacto": {
                required: true,
                minlength: 10,      
                maxlength: 13
            }
        },
        messages: {
            "Nombre": {
                required: "El campo Nombre es requerido.",
                maxlength: "El nombre no puede ser mayor a 15 caracteres.",
                minlength: "El nombre tiene que ser mayor a 4 caracteres."
            },
            "EmailContacto": {
                "required": "El campo Email es requerido.",
                "email": "El formato del email es incorrecto."
            },
            "Representante": {
                "required": "El campo Representante es requerido",
                "maxlength": "Has sobrepasado los 250 caracteres permitidos."
            },
            "Descripcion": {
                "required": "El campo Descripcion es requerido.",
                "maxlength": "Has sobrepasado los 500 caracteres permitidos."
            },
            "TelContacto": {
                "required": "El campo Telefono de contacto es requerido",
                "minlength": "El telefono debe tener al menor 10 caracteres",
                "maxlength": "El telefono no puede ser mayor a 13 caracteres"
            }
        }
    });
}