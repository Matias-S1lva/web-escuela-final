const $$Nav = function () {
    const Anonimous = function () {
        $dn.clear();
        $dn.makeButton("inicio", Home);
        $dn.makeButton("carreras", "");
        $dn.makeButton("novedades", "");

        $dn.makeButtonLogin(
            "login",
            $f.pruebaLogin,
            "fas fa-arrow-right-to-bracket"
        );
    };
    const Administrador = function () {
        $dn.clear();
        $dn.makeButton("inicio", Home);
        $dn.makeButton("carreras", "");
        const dropdownButton = $dn.dropdownButton("ABM USUARIOS", "")
        $dn.optionDropdown("ALTA USUARIOS", $f.ABMUsuarios, dropdownButton)
        $dn.optionDropdown("MOD. USUARIOS POR DNI", $f.findByDni, dropdownButton)
        $dn.optionDropdown("MOD. USUARIOS POR MAIL", $f.findByMail, dropdownButton)
        $dn.optionDropdown("ABM. CARRERAS", $c.ABMCarreras, dropdownButton)
        $dn.makeButtonLogin(
            "perfil",
            $f.perfil,
            "fas fa-file-user"
        );
    };
    const Alumnos = function () {
        $dn.clear();
        $dn.makeButton("inicio", Home);
        $dn.makeButton("carreras", "");
        const dropdownButton = $dn.dropdownButton("MIS MATERIAS", "")
        $dn.optionDropdown("REDES Y COMUNICACIONES", "", dropdownButton)
        $dn.optionDropdown("ALGORITMOS", "", dropdownButton)
        $dn.optionDropdown("ING. DE SOFTWARE", "", dropdownButton)

        $dn.makeButtonLogin(
            "perfil",
            $f.perfil,
            "fas fa-file-user"
        );
    };
    this.init = function () {
        switch (Rol) {
            case undefined:
                Anonimous();
                break;
            case "ADMINISTRADOR":
                Administrador();
                break;
            case "DIRECTOR DE ESTUDIOS":
                DirEstudios();
                break;
            case "PRECEPTOR":
                Preceptores();
                break;
            case "PROFESOR":
                Profesores();
                break;
            case "ALUMNO":
                Alumnos();
                break;
            case "INSCRIPTO":
                Inscripto();
                break;
            case "EXCLUIDO":
                Excluido();
                break;
        }
    };
};

const $n = new $$Nav(); //INSTANCIA
