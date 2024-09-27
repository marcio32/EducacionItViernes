const setCookie = (nombre, valor) => {
    var expiracion = "";
    var fecha = new Date().setHours(24);
    expiracion = "; expires=" + fecha;
    document.cookie = nombre + "=" + (valor || "") + expiracion + "; path=/";
}

const getCookie = (nombre) => {
    debugger
    var nombreEQ = nombre + "=";
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        if (cookie.indexOf(nombreEQ) == 0 || cookie.indexOf(nombreEQ) == 1) {
            return cookie.substring(cookie.indexOf(nombreEQ) == 1 ? nombreEQ.length + 1 : nombreEQ.length, cookie.length);
        }
    }

    return null;
}