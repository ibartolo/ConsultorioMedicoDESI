let valoresSeleccionados = [];

$(document).ready(function () {

    ValidarDatos();
    CrearPaquetes();
    CrearTratamientoPaquetes();
});

function ValidarDatos() {
    $('#tblTratamientoPaquete').validate({
        rules: {
            "TratamientoId": {
                required: true
            },
            "Paquete": {
                reqired: true,
                maxlength: 100
            },
            "Costo": {
                required: true,
                number: true
            }
        },
        messages: {
            "TratamientoId": {
                required: "debes seleccionar los tratamientos"
            },
            "Paquete": {
                required: "debes ingresar el nombre del paquete",
                maxlength: "El nombre del paquete no debe pasar de los 100 caracteres"
            },
            "Costo": {
                required: "Debes ingresar el costo del paquete",
                number: "El costo debe ser un valor numerico"
            }
        }
    })
}

function CrearPaquetes() {
    $('#tblTP').DataTable({
        columns: [
            { title: "Id", data: "TratamientoId" },
            { title: "Tratamiento", data: "Tratamiento" }
        ]
    })
}
function CrearTratamientoPaquetes() {
    $('#tblTratamientosTemp').DataTable({
        columns: [
            { title: "Id", data: "TratamientoId" },
            { title: "Tratamiento", data: "Tratamiento" }
        ]
    })
}
function AgregarTratamiento() {
    var tratamientoSelect = $("#TratamientoId").val();
    var tratamientoSelectText = $("#TratamientoId option:selected").text();

    var itemToAdd = {
        TratamientoId: tratamientoSelect,
        Tratamiento: tratamientoSelectText
    };

    var tratramientoFind = valoresSeleccionados.find(x => x.TratamientoId == tratamientoSelect);
    if (tratramientoFind == undefined) {
        valoresSeleccionados.push(itemToAdd);
        MapingPropertiesDataTable('tblTratamientosTemp', valoresSeleccionados);
    }
}

function GuardarPaquete() {
    let request = {
        Paquete: {
            NombrePaquete: document.getElementById("NombrePaquete").value,
            Costo: parseFloat(document.getElementById("Costo").value),
            Descripcion: document.getElementById("Descripcion").value
        },
        Tratamientos: valoresSeleccionados.map(x => ({
            TratamientoId: parseInt(x.TratamientoId)
        }))
    };

    alert("JSON enviado:\n" + JSON.stringify(request, null, 2));

    $.ajax({
        type: "POST",
        url: "/Tratamiento/SaveTratamientoPaquete",
        data: JSON.stringify(request),
        contentType: "application/json",
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}
