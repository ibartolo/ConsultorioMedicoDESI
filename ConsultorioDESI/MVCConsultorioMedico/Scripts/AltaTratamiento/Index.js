let valoresSeleccionados = [];

$(document).ready(function () {
    ValidarDatos();
    CrearTratamientoPaquetes(); 
    $("#Paciente").select2({
        width: '100%'
    });
    $("#TratamientoSelect").select2({
        width: '100%'
    });
})

function ValidarDatos() {
    $("#frmAltaTratamiento").validate({
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
            Tratamiento: {
                required: true
            }
        },
        messages: {
            Paciente: {
                required: "Seleccione un paciente"
            },
            Fecha: {
                required: "Seleccione una fecha"
            },
            Hora: {
                required: "Seleccione una hora"
            },
            Tratamiento: {
                required: "Ingrese el tratamiento"
            }
        }
    })
}

function CrearTratamientoPaquetes() {
    $('#tblTratamientosTemp').DataTable({
        columns: [
            { title: "Id", data: "TratamientoId" },
            { title: "Tratamiento", data: "Tratamiento" }
        ]
    });
}

function AgregarTratamiento() {
    var tratamientoSelect = $("#tratamientoSelect").val();
    var tratamientoSelectText = $("#tratamientoSelect option:selected").text();

    var itemAdd = {
        TratamientoId: tratamientoSelect,
        Tratamiento: tratamientoSelectText
    };

    var tratamientoFind = valoresSeleccionados.find(t => t.TratamientoId == tratamientoSelect);
    if (tratamientoFind == undefined) {
        valoresSeleccionados.push(itemAdd);
        MapingPropertiesDataTable('tblTratamientosTemp', valoresSeleccionados);
    }
}

function GuardarAltaTratamiento() {
    let request = {
        altaTratamiento: {
            Paciente: $("#Paciente").val(),
            Fecha: $("#Fecha").val(),
            Hora: $("#Hora").val()
        },
        relaciones: valoresSeleccionados.map(t => ({
            TratamientoId: parseInt(t.TratamientoId)
        }))
    };
   
    $.ajax({
        type: "POST",
        url: "/AltaTratamiento/SaveOrUpdateAltaTratamiento",
        data: JSON.stringify(request),
        contentType: 'application/json',
        success: function (response) {
            console.log(response);
        },
        error: function (error) {
            console.log(error); 
        }
    });
}

