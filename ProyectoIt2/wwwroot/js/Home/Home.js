$(function () {
    if ($("#Token").val() != "") {
        debugger
        setCookie("Token", $("#Token").val());
        setCookie("WebUrl", $("#WebUrl").val());
        $("#Token").remove();
        $("#WebUrl").remove();
    }
})