let token = getCookie("Token");

let table = $("#usuarios").DataTable({
    ajax: {
        url: 'https://localhost:7205/api/Usuarios/BuscarUsuarios',
        dataSrc: '',
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'nombre', title: 'Nombre' },
        { data: 'apellido', title: 'Apellido' },
        {
            data: function (row) {
                return moment(row.fecha_Nacimiento).format("DD/MM/YYYY");
            },
            title: 'Fecha de nacimiento'
        },
        { data: 'mail', title: 'Mail' },
        { data: 'roles.nombre', title: 'Rol' },
        {
            data: function (row) {
                return row.activo ? "Si" : "No";
            },
            title: 'Activo'
        },
        {

            data: function (row) {
                var botones = `<td><a href='javascript:EditarUsuario(${JSON.stringify(row)})'/><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                    `<td><a href='javascript:EliminarUsuario(${JSON.stringify(row)})'/><i class="fa-solid fa-trash eliminarUsuario"></i></td>`;

                return botones;
            },
            width: "5%"
        }
    ],
    language: {
        url: "../../lib/datatable/dist/js/idiomadatatablees.js"
    }
});


const GuardarUsuario = () => {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            debugger
            $("#usuariosAddPartial").html(resultado);
            $("#usuarioModal").modal('show');
        }
    });
}

const EditarUsuario = (row) => {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#usuariosAddPartial").html(resultado);
            $("#usuarioModal").modal('show');
        }
    })
}

const EliminarUsuario = (row) => {
    Swal.fire({
        title: "Estas seguro?",
        text: "Vas a eliminar al usuario!",
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
                url: "/Usuarios/EliminarUsuario",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire({
                        title: "Eliminado!",
                        text: "Se elimino el usuario.",
                        icon: "success"
                    });
                    table.ajax.reload();
                }
            });
        }
    });
}