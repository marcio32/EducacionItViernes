let token = getCookie("Token");

let table = $("#servicios").DataTable({
    ajax: {
        url: 'https://localhost:7205/api/Servicios/BuscarServicios',
        dataSrc: '',
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'nombre', title: 'Nombre' },
        {
            data: function (row) {
                return row.activo ? "Si" : "No";
            },
            title: 'Activo'
        },
        {

            data: function (row) {
                var botones = `<td><a href='javascript:EditarServicio(${JSON.stringify(row)})'/><i class="fa-solid fa-pen-to-square editarServicio"></i></td>` +
                    `<td><a href='javascript:EliminarServicio(${JSON.stringify(row)})'/><i class="fa-solid fa-trash eliminarServicio"></i></td>`;

                return botones;
            },
            width: "5%"
        }
    ],
    language: {
        url: "../../lib/datatable/dist/js/idiomadatatablees.js"
    }
});


const GuardarServicio = () => {
    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            debugger
            $("#serviciosAddPartial").html(resultado);
            $("#servicioModal").modal('show');
        }
    });
}

const EditarServicio = (row) => {
    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#serviciosAddPartial").html(resultado);
            $("#servicioModal").modal('show');
        }
    })
}

const EliminarServicio = (row) => {
    Swal.fire({
        title: "Estas seguro?",
        text: "Vas a eliminar al servicio!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Eliminar!",
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/Servicios/EliminarServicio",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire({
                        title: "Eliminado!",
                        text: "Se elimino el servicio.",
                        icon: "success"
                    });
                    table.ajax.reload();
                }
            });
        }
    });
}