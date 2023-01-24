let Carreras = [];

const $$Carreras = function () {

    const ListCarreras = () => {
        Carreras = JSON.parse(POST("accion=LISTCARRERAS"))
        Listado(Carreras, "CARRERAS")
    }

    this.ABMCarreras = () => {
        toggleMenuBars();
        Section.innerHTML = "";
        const f = $dc.form("Agregar Carrera", "fas fa-arrow-left");
        const icon = $d.id('atras')
        icon.onclick = $f.logout

        const divName = $dc.divGroup("divName")
        $dc.inputText(divName, "Nombre");

        const divSigla = $dc.divGroup("divSigla")
        $dc.inputText(divSigla, "Sigla");

        const divDuracion = $dc.divGroup("divDuracion")
        $dc.inputNumber(divDuracion, "Duracion");

        const divTitulo = $dc.divGroup("divTitulo")
        $dc.inputText(divTitulo, "Titulo");

        const divImg = $dc.divGroup("divImg")
        $dc.inputFileImg(divImg, "Imagen");

        const divPdf = $dc.divGroup("divPdf")
        $dc.inputFilePdf(divPdf, "Pdf");

        const divSelect1 = $dc.divGroup("divSelect1")
        const selectEstado = $dc.select(divSelect1, "Estado")
        $dc.option(selectEstado, "ACTIVO")
        $dc.option(selectEstado, "INACTIVO")

        $dc.submit(container, "submit", "Agregar", "submit");
        $dc.submit(container, "reset", "Cancelar", "reset");

        ListCarreras();
        f.addEventListener("submit", (e) => {
            e.preventDefault();
            let datos = new FormData(f)
            datos.append("accion", "ADDCARRERA")
            let respuesta = POST(datos)

            validar(respuesta)

            this.ABMCarreras();
        })
    }

    this.modifyCarrera = (carrera) => {
        Section.innerHTML = "";
        const f = $dc.form("Modificar Carrera", "fas fa-arrow-left");

        const divName = $dc.divGroup("divName")
        const inputNombre = $dc.inputText(divName, "Nombre");
        inputNombre.value = carrera.Nombre

        const divSigla = $dc.divGroup("divSigla")
        const inputSigla = $dc.inputText(divSigla, "Sigla");
        inputSigla.value = carrera.Sigla

        const divDuracion = $dc.divGroup("divDuracion")
        const inputDuracion = $dc.inputNumber(divDuracion, "Duracion");
        inputDuracion.value = carrera.Duracion

        const divTitulo = $dc.divGroup("divTitulo")
        const inputTitulo = $dc.inputText(divTitulo, "Titulo");
        inputTitulo.value = carrera.Titulo

        const divImg = $dc.divGroup("divImg")
        $dc.inputFileImg(divImg, "Imagen");

        const divPdf = $dc.divGroup("divPdf")
        $dc.inputFilePdf(divPdf, "Pdf");

        const divSelect1 = $dc.divGroup("divSelect1")
        const selectEstado = $dc.select(divSelect1, "Estado")
        $dc.option(selectEstado, "ACTIVO")
        $dc.option(selectEstado, "INACTIVO")

        $dc.submit(container, "submit", "Agregar", "submit");
        $dc.submit(container, "reset", "Cancelar", "reset");

        f.addEventListener("submit", (e) => {
            e.preventDefault();
            let datos = new FormData(f)
            datos.append("ID", carrera.ID)
            datos.append("accion", "MODIFYCARRERA")
            POST(datos)

            this.ABMCarreras();
        })
    }
}
let $c = new $$Carreras();