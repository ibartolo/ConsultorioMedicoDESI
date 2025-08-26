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