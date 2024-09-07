let token = getCookie("Token");
debugger
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