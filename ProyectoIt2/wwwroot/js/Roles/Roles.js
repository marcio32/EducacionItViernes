let token = getCookie("Token");

let table = $("#roles").DataTable({
    ajax: {
        url: 'https://localhost:7205/api/Roles/BuscarRoles',
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
                var botones = `<td><a href='javascript:EditarRol(${JSON.stringify(row)})'/><i class="fa-solid fa-pen-to-square editarRol"></i></td>` +
                    `<td><a href='javascript:EliminarRol(${JSON.stringify(row)})'/><i class="fa-solid fa-trash eliminarRol"></i></td>`;

                return botones;
            },
            width: "5%"
        }
    ],
    language: {
        url: "../../lib/datatable/dist/js/idiomadatatablees.js"
    }
});


const GuardarRol = () => {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            debugger
            $("#rolesAddPartial").html(resultado);
            $("#rolModal").modal('show');
        }
    });
}

const EditarRol = (row) => {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#rolesAddPartial").html(resultado);
            $("#rolModal").modal('show');
        }
    })
}

const EliminarRol = (row) => {
    Swal.fire({
        title: "Estas seguro?",
        text: "Vas a eliminar al rol!",
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
                url: "/Roles/EliminarRol",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire({
                        title: "Eliminado!",
                        text: "Se elimino el rol.",
                        icon: "success"
                    });
                    table.ajax.reload();
                }
            });
        }
    });
}