let valoresSeleccionados = [];

$(document).ready(function () {
    ValidarDatos();

    AgregarTratamiento();

    $('#tblTP').DataTable({
        columns: [
            { title: "Id", data: "TratamientoId" },
            {title: "Tratamiento", data: "Tratamiento"}
        ]
    })

    
})

function ValidarDatos() {
    $('#tblTratamientoPaquete').validate({
        rules: {
            "TratamientoId": {
                required: true
            }
        },
        messages: {
            "TratamientoId": "Este campo es obligatorio"
        }
    })
}

function AgregarTratamiento() {

    $('#btnGuardar').click(function () {
        let ddl = $('#list');
        let tratamientoId = ddl.val();
        let tratamientotxt = ddl.find("option:selected").text();

        valoresSeleccionados.push({ TratamientoId: tratamientoId, Tratamiento: tratamientotxt });

        $('#tblTP').DataTable().row.add({
            TratamientoId: tratamientoId,
            Tratamiento: tratamientotxt
        }).draw();
    });    
}