const validar = (respuesta) => {
    if (respuesta !== "OK") {
        alert(respuesta)
    }
}

const $$Form = function () {

    const ROLES = ["ADMINISTRADOR", "DIRECTOR DE ESTUDIOS", "PROFESOR", "PRECEPTOR", "ALUMNO", "INSCRIPTO", "EXCLUIDO"]

    const RolExists = function (ROL, user) {
        if (user.Roles === "") return false

        for (let i = 0; i < user.Roles.length; i++) {
            if (user.Roles[i] === ROL) return true;
        }
        return false
    };
    const MakeRols = function (selectRol, rolUser, user) {
        if (selectRol !== undefined) {
            selectRol.innerHTML = "";
            ROLES.forEach(rol => {
                if (!RolExists(rol, user))
                    $dc.option(selectRol, rol, rol);
            })
        }
        if (rolUser !== undefined) {
            rolUser.innerHTML = "";
            ROLES.forEach(rol => {
                if (RolExists(rol, user))
                    $dc.option(rolUser, rol, rol);
            })
        }
    };

    this.findByDni = () => {
        toggleMenuBars();
        const Submit = function () {
            try {
                let user = POST("accion=FindUserRolByDni&Dni=" + dni.value)
                user = JSON.parse(user)

                $f.ModifyUser(user);
            } catch (e) {
                alert(e);
            }
            return false;
        };
        const f = $dc.form("Modificar usuario", "fas fa-arrow-left");
        const icon = $d.id('atras')
        icon.onclick = $f.logout
        const divDni = $dc.divGroup("divDni");
        const dni = $dc.inputNumber(divDni, "Dni");

        $dc.submit(container, "submit", "BUSCAR", "submit");
        $dc.submit(container, "reset", "CANCELAR", "reset");

        f.onsubmit = Submit;
    };
    this.findByMail = () => {
        toggleMenuBars();
        const Submit = function () {
            try {
                let user = POST("accion=FindUserRolByMail&Mail=" + mail.value)
                user = JSON.parse(user)

                $f.ModifyUser(user);
            } catch (e) {
                alert(user);
            }
            return false;
        };
        const f = $dc.form("Modificar usuario", "fas fa-arrow-left");
        const icon = $d.id('atras')
        icon.onclick = $f.logout
        const divMail = $dc.divGroup("divMail");
        const mail = $dc.inputCorreo(divMail, "Mail");

        $dc.submit(container, "submit", "BUSCAR", "submit");
        $dc.submit(container, "reset", "CANCELAR", "reset");
        f.onsubmit = Submit;
    };
    this.perfil = () => {
        toggleMenuBars();
        const f = $dc.form("Mi Perfil", "fas fa-arrow-left");

        const img = $dc.img(container);
        img.src = MainUser.Foto;
        img.className = "perfil";

        const divNombre = $dc.divGroup("divNombre");
        const nombre = $dc.inputText(divNombre, "Nombre");
        nombre.value = MainUser.Nombre;

        const divDirec = $dc.divGroup("divDirec");
        const direccion = $dc.inputText(divDirec, "Direccion");
        direccion.value = MainUser.Direccion

        const divTel = $dc.divGroup("divTel");
        const telefono = $dc.inputText(divTel, "Telefono");
        telefono.value = MainUser.Telefono

        const divFoto = $dc.divGroup("divFoto");
        $dc.inputFileImg(divFoto, "Imagen:", "Foto:");

        const divModifpass = $dc.divGroup("divModifPass");
        const pass = $dc.inputModifPass(divModifpass, "Password");

        const divConfirm = $dc.divGroup("divConfirm");
        const passConfirm = $dc.inputConfirm(divConfirm, "confirmar contraseña");

        pass.onchange = () => {
            if (pass.value != "") {
                passConfirm.style.display = "block"
                passConfirm.required = true
            }
            else {
                passConfirm.style.display = "none"
                passConfirm.required = false
                passConfirm.value = ""
            }
        }

        passConfirm.onchange = () => {
            if (passConfirm.value != pass.value && passConfirm.value != "")
                passConfirm.setCustomValidity("Las contraseñas no coinciden")
            else {
                passConfirm.setCustomValidity("")
            }
        }

        $dc.submit(container, "submit", "modificar", "submit");
        $dc.submit(container, "reset", "cancelar", "reset");
        const icon = $d.id('atras')
        icon.onclick = $f.logout

        f.addEventListener("submit", e => {
            e.preventDefault();
            let datos = new FormData(f);
            let respuesta
            datos.append("accion", "MODIFICARUSUARIO");
            datos.append("ID", MainUser.ID);
            try {
                respuesta = POST(datos);
                MainUser = JSON.parse(respuesta);
                $f.logout();
            } catch (err) {
                alert(respuesta);
                console.error(err.message);
            }
        })

    };
    this.recoveryPassword = () => {
        const Submit = function () {
            try {
                let respuesta = POST("accion=RecoveryPassword&Mail=" + mail.value + "&Dni=" + dni.value)
                validar(respuesta)
                alert("SU CONTRASEÑA AHORA ES SU DNI")
            } catch (e) {
                alert(e);
            }

            $f.pruebaLogin();
            return false;
        };
        const f = $dc.form("Recuperar Contraseña", "fas fa-arrow-left", $f.pruebaLogin);

        const icon = $d.id('atras')
        icon.onclick = $f.pruebaLogin

        const iconUser = $dc.icon(container);
        iconUser.id = "user";
        iconUser.className = "fas fa-user";

        const divCorreo = $dc.divGroup("divCorreo");
        const mail = $dc.inputCorreo(divCorreo, "@correo");

        const divDni = $dc.divGroup("divDni");
        const dni = $dc.inputNumber(divDni, "ingresar dni");
        $dc.submit(container, "submit", "CONFIRMAR", "submit");
        f.onsubmit = Submit;
    };

    this.ModifyUser = (user) => {
        Section.innerHTML = ""

        const f = $dc.form("Modificar Usuario", "fas fa-arrow-left")

        const divName = $dc.divGroup("divName")
        const inputName = $dc.inputText(divName, "Nombre");
        inputName.value = user.Nombre

        const divDni = $dc.divGroup("divDni")
        const inputDni = $dc.inputNumber(divDni, "Dni");
        inputDni.value = user.Dni

        const divMail = $dc.divGroup("divMail")
        const inputMail = $dc.inputCorreo(divMail, "Mail");
        inputMail.value = user.Mail

        const divDirec = $dc.divGroup("divDirec")
        const inputDirec = $dc.inputText(divDirec, "Direccion");
        inputDirec.value = user.Direccion

        const divFecha = $dc.divGroup("divFecha")
        const inputFecha = $dc.inputFecha(divFecha, "Fecha");
        inputFecha.value = user.FechaNac;

        const divTelefono = $dc.divGroup("divTelefono")
        const inputTelefono = $dc.inputText(divTelefono, "Telefono");
        inputTelefono.value = user.Telefono;

        const divSelect1 = $dc.divGroup("divSelect1")
        const selectRoles = $dc.select(divSelect1, "Roles")

        const divSelect2 = $dc.divGroup("divSelect2")
        const rolSeleccionado = $dc.select(divSelect2, "Rol")

        const divButtons = $dc.divGroup("divButtons")
        divButtons.className = "form__container--buttons"

        MakeRols(selectRoles, rolSeleccionado, user)

        const btnAddRol = $dc.btn(divButtons, "AGREGAR ROL")
        btnAddRol.onclick = () => {
            let res = POST("accion=ADDROL&UserID=" + user.ID + "&Rol=" + selectRoles.value);
            user = JSON.parse(res);

            MakeRols(selectRoles, rolSeleccionado, user);
        };

        const btnEraseRol = $dc.btn(divButtons, "QUITAR ROL")
        btnEraseRol.onclick = () => {
            let res = POST("accion=DELROL&UserID=" + user.ID + "&Rol=" + rolSeleccionado.value);//mandamos el id del usuario y el rol seleccinado
            user = JSON.parse(res);

            MakeRols(selectRoles, rolSeleccionado, user);
        };

        $dc.submit(divButtons, "submit", "CONFIRMAR", "submit");
        $dc.submit(divButtons, "reset", "CANCELAR", "reset");

        const icon = $d.id('atras')
        icon.onclick = $f.ABMUsuarios

        f.addEventListener("submit", (e) => {
            e.preventDefault();
            if (user.Roles.length === 0) {
                alert("SE DEBE INGRESAR POR LO MENOS UN ROL");
                return this.ModifyUser(user);
            }
            let datos = new FormData(f);
            datos.append("ID", user.ID);
            datos.append("accion", "MODIFYUSERWITHROLES");
            let respuesta = POST(datos)
            validar(respuesta)
            this.ABMUsuarios();

        });
    }
    this.ABMUsuarios = () => {
        toggleMenuBars();
        Section.innerHTML = "";
        const f = $dc.form("Agregar Usuario", "fas fa-arrow-left");

        const divName = $dc.divGroup("divName")
        $dc.inputText(divName, "Nombre");

        const divDni = $dc.divGroup("divDni")
        $dc.inputNumber(divDni, "Dni");

        const divMail = $dc.divGroup("divMail")
        $dc.inputCorreo(divMail, "Mail");

        const divDirec = $dc.divGroup("divDirec")
        $dc.inputText(divDirec, "Direccion");

        const divFecha = $dc.divGroup("divFecha")
        $dc.inputFecha(divFecha, "Fecha");

        const divTelefono = $dc.divGroup("divTelefono")
        $dc.inputText(divTelefono, "Telefono");

        $dc.submit(container, "submit", "Agregar", "submit");
        $dc.submit(container, "reset", "Cancelar", "reset");

        ListUsuarios();
        const icon = $d.id('atras')
        icon.onclick = $f.logout
        f.addEventListener("submit", (e) => {
            e.preventDefault();
            let datos = new FormData(f);
            datos.append("accion", "ADDUSUARIO")
            let response = POST(datos)

            try {
                User = JSON.parse(response)
                $f.ModifyUser(User)

            } catch (e) {
                alert(response)
                console.log(e)
            }
        })
    }
    this.logout = () => {
        const Change = () => {
            Rol = rolSeleccionado.value
            $n.init();
        }
        Rol = MainUser.Roles[0];
        $n.init();
        const f = $dc.form(MainUser.Nombre, "fas fa-arrow-left");

        const img = $dc.img(container);
        img.src = MainUser.Foto;
        img.className = "perfil";

        const divSelect2 = $dc.divGroup("divSelect2")
        const rolSeleccionado = $dc.select(divSelect2, "Roles")
        rolSeleccionado.onchange = Change

        MakeRols(undefined, rolSeleccionado, MainUser)

        const salir = $dc.btn(container, "SALIR DEL SISTEMA");
        salir.onclick = function () {
            MainUser = undefined;
            Rol = undefined;
            $n.init();
            $f.pruebaLogin();
        };
    };

    this.pruebaLogin = () => {

        const Submit = function () {
            let datos = new FormData(f)
            const res = POST(datos)
            try {
                MainUser = JSON.parse(res)
                //splitRoles(MainUser.Roles, MainUser)
                $f.logout();
            } catch (err) {
                alert(res);
                console.log(err)
            }
            return false;
        };
        const f = $dc.form("ingresar al sistema", "fas fa-arrow-left");
        const iconUser = $dc.icon(container);
        iconUser.id = "user";
        iconUser.className = "fas fa-user";

        const divCorreo = $dc.divGroup("divCorreo");
        const inputMail = $dc.inputCorreo(divCorreo, "Mail");
        inputMail.value = 'admin@mail.com'
        const divPass = $dc.divGroup("divPass");
        const password = $dc.inputPass(divPass, "Password");
        password.value = "admin"
        const inputHidden = $dc.input(f, "hidden", "accion")
        inputHidden.value = "LOGIN"


        $dc.submit(container, "submit", "Ingresar", "submit");
        const btn = $dc.btn(container, "¿olvido su contraseña?");

        f.onsubmit = Submit;
        btn.onclick = $f.recoveryPassword;
    };
};
const $f = new $$Form();
