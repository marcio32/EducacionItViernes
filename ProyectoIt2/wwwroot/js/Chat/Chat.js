$(function () {
    var conexion = new signalR.HubConnectionBuilder().withUrl("/Chat").build();
    conexion.start().then(() => { conexion.invoke("AgregarGrupo", "1") });

    $("#btnEnviar").click(function (e) {
        conexion.invoke("EnviarMensaje", 1, $("#usuario").val(), $("#mensaje").val());
        $("#mensaje").val("");
        $("#mensaje").focus();
        e.preventDefault();
    });

    conexion.on("RecibirMensaje", (usuario, mensaje) => {
        var li = $("<li>", { class: "list-group-item" });
        var small = $("<small>", { text: usuario + "  -  " });
        li.append(small);
        li.append(mensaje);
        $("#mensajes").append(li);
    })
});