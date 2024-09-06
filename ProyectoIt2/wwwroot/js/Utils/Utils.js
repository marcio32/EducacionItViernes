const setCookie = (nombre, valor) => {
    debugger
    var expiracion = "";
    var fecha = new Date().setHours(24);
    expiracion = "; expires=" + fecha;
    document.cookie = nombre + "=" + (valor || "") + expiracion + "; path=/";
}

const getCookie = (nombre) => {
    var nombreEQ = nombre = "=";
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookie[i];
        if (cookies.indexOf(nombreEQ) == 0 || cookies.indexOf(nombreEQ) == 1) {
            return cookie.substring(cookie.indexOf(nombreEQ) == 1 ? nombreEQ.length + 1 : nombreEQ.length, cookie.length);
        }
    }

    return null;
}