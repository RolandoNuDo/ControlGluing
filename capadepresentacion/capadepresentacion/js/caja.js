function addRowDT(data) {
    var tabla = $("#tbl_cajas").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].ID_Etiqueta,
            data[i].FechaEntrada,
            data[i].Rack,
            data[i].Nivel,
            data[i].Fila,
            ((data[i].Liberacion >= 4) ? "Libre" : "Le faltan " + (4 - data[i].Liberacion) + " horas"),
            data[i].NoParte,
        ]);
    }
}

//evento clik para actualizar registros
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    $(this).parent().parent().children().first().text();
    var row = $(this).parent().parent()[0];
    var data = table.fnGetData(row);
    console.log(data);
});

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "AgregarCaja.aspx/ListarCajas",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            console.log(data.d);
            addRowDT(data.d);
        }
    });
}

//Llamando a la funcion de ajax al cargar el documento 
sendDataAjax();