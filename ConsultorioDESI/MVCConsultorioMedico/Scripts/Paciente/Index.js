$(document).ready(function () {
    ValidarDatos();
});

function ValidarDatos() {
    $("#frmPaciente").validate({
        rules: {
            "Nombre": {
                required: true,
                maxlength: 150,  
                minlength: 3   
            },
            "ApellidoP": {
                required: true,
                maxlength: 150, 
                minlength: 3   
            },
            "ApellidoM": {
                required: true,
                maxlength: 150,  
                minlength: 3   
            }, 
            "Genero": {
                required: true
            },
            "FechaNacimiento": {
                required: true,
                date: true
            },
            "Edad": {
                required: true,
                digits: true,
                min: 0,   //La edad no puede ser negativa
                max: 120  //La edad no puede ser mayor a 120 años
            },
            "Telefono": {
                required: true, 
                minlength: 10,
                maxlength: 13
            },
            "Email": {
                required: true,
                maxlength: 250,
                email: true
            },
            "Comentario": {
                maxlength: 650 
            }
        },
        messages: {
            "Nombre": {
                required: "El campo Nombre es requerido.",
                maxlength: "El nombre no puede ser mayor a 150 caracteres.", 
                minlength: "El nombre no puede ser menor de 3 caracteres."
            },
            "ApellidoP": {
                required: "No has registrado el apellido paterno",
                minlength: "El apellido no puede ser menor de 3 caracteres",
                maxlength: "El apellido no puede ser mayor de 150 caracteres"
            },
            "ApellidoM": {
                required: "No has registrado el apellido materno",
                minlength: 3,
                maxlength: 150
            },
            "Genero": {
                required: "El campo Género es requerido.",
            },
            "FechaNacimiento": {
                required: "La fecha de nacimiento es requerida.",
                date: "Ingresa una fecha válida."
            },
            "Edad": {
                required: "La edad es requerida.",
                digits: "La edad debe ser un número entero.",
                min: "La edad no puede ser negativa.",
                max: "La edad no puede ser mayor a 120 años."
            }, 
            "Telefono": {
                required: "El campo Teléfono es requerido.",
                minlength: "El teléfono debe tener al menos 10 caracteres.",
                maxlength: "El teléfono no puede ser mayor a 13 caracteres."
            },
            "Email": {
                required: "El campo Email es requerido.",
                email: "El formato del email es incorrecto.",
                maxlength: "El email no puede ser mayor de 250 caracteres."
            },
            "Comentario": {
                maxlength: "El comentario no puede exceder los 650 caracteres"
            }
        }
    })
}