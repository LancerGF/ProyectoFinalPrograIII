
/************************************************* Funcion Inicial *****************/
$(document).ready(function () {

    // Le da el diseño a la tabla
    EstiloTabla();

});


/************************************************* Estilo de Tabla *****************/
// Crea el diseño de la tabla
function EstiloTabla() {

    // Crear estilo de tabla
    var tablaDatos = $("#table");

    tablaDatos.dataTable({

        stateSave: true,
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }

    });
}

// Funcion para retornar en el capo el valor con 2 decimales
function decimales(number) {
    if (document.getElementById("txtMonto").value == "") {
        // Asigna el valor con 2 decimales al campo
        document.getElementById("txtMonto").value = "0.00";
    }
    else {
        // Asigna el valor con 2 decimales al campo
        document.getElementById("txtMonto").value = parseFloat(number).toFixed(2);
    }

}

// Valida que solo se presionen numeros
function validarNumero(evt) {

    // Código de la tecla que presiona
    var code = evt.which ? evt.which : evt.keyCode;

    if (code == 8) {
        // Si es la tecla borrar
        return true;
    }
    else if (code == 190) {
        // Si es la tecla punto .
        return true;
    }
    else if (code >= 48 && code <= 57) {
        // Si es algún número
        return true;
    }
    else {
        // Si no es ni la tecla borrar ni un número retorna falso
        return false;
    }
}

// Asigna un campo a la fecha de hoy
function AsignarFechaHoy(idCampoFecha) {

    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $('#' + idCampoFecha).val(today);
}

// Cambia el formato de la fecha de mes/dia/año a año-mes-dia para datepickers
function FormatearFecha(pFecha) {

    var date = new Date(pFecha),
        yr = date.getFullYear(),
        month = date.getMonth() < 10 ? '0' + date.getMonth() : date.getMonth(),
        day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate(),
        newDate = yr + '-' + month + '-' + day;

    return newDate;
}


// Cambia el formato de la fecha
function FormatearFecha2(pFecha) {

    var date = new Date(pFecha),
        yr = date.getFullYear(),
        month = date.getMonth() < 10 ? '0' + date.getMonth() : date.getMonth(),
        day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate(),
        hour = date.getHours() < 10 ? '0' + date.getHours() : date.getHours(),
        minutes = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes(),
        newDate = day + '/' + (parseInt(month) + 1) + '/' + yr + ' ' + hour + ':' + minutes;

    return newDate;
}