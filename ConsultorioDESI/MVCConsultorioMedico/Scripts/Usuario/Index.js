$(document).ready(function () {
    ValidarDatosUsuario();

    $('#tblUsuario').DataTable({
        columns: [
            {
                title: "Id",
                data: "Id",
                visible: false
            },
            {
                title: "Usuario",
                data: "UserName"
            },
            {
                title: "Contraseña",
                data: "Pass"
            },
            {
                title: "Correo Electronico",
                data: "Email"
            },
            {
                title: "Nombre",
                data: "Nombre"
            },
            {
                title: "Apellido",
                data: "Apellido"
            }
        ]
    });

    $.ajax({
        type: 'get',
        url: '/Usuario/GetAllUsuario',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data)
            $('#tblUsuario').dataTable().fnAddData(data);
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
});







function ValidarDatosUsuario(){
    $("#frmUsuario").validate({
        rules: {
            "UserName": {
                required: true,
                maxlength: 25,                       
            },
            "Pass": {
                required: true 
            },
            "Email": {
                required: true,
                email: true
            }, 
            "Nombre": {
                required: true,
                maxlength: 150
            },
            "Apellido": {
                required: true,
                maxlength: 150           
            }
        },
        messages: {
            "UserName": {
                "required": "El campo Nombre de usuario es requerido.",
                "maxlength": "El nombre de usuario no puede ser mayor de 25 caracteres.",     
            },
            "Pass": {
                "required": "El campo contraseña es requerido"   
            },
            "Email": {
                "required": "El campo Email es requerido.",
                "email": "El formato del email es incorrecto."
            },
            "Nombre": {
                "required": "El campo Nombre es requerido.",
                "maxlength": "El nombre no puede ser mayor a 150 caracteres."     
            },
            "Apellido": {
                "required": "El campo Apellido es requerido",
                "maxlength": "El apellido no puede pasar de los 150 caracteres."  
            }
        }
    });
}