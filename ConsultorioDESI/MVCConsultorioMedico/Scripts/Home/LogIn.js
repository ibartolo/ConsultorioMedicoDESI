function LoginUser() {
    var parametro = {
        userName: $("#txtUserName").val(),
        pass: $("#txtPassword").val()
    };
    PostMVC("/Home/Autenticacion", parametro, function (response) {
        if (response === null || response === undefined) {
            alert("No es posible autenticarse.");
        }
        else {
            window.location = "/Home/Index";
        }
    });
}