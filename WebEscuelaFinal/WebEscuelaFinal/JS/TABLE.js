const div = $d.ce("div")
div.id = "divTable"

const postEdit = (usuario) => {
    let respuesta = POST("accion=ObtenerUserRol&ID=" + usuario.ID)
    try {
        usuario = JSON.parse(respuesta)
        $f.ModifyUser(usuario);
    } catch (e) {
        alert(respuesta)
    }
}

const Listado = function (lista, user) {
    if (lista.length === 0) return

    $d.ac(Section, div)
    div.innerHTML = " " //limpiamos la tabla 

    const table = $dc.table(div);
    const thead = $dc.thead(table);
    const trhead = $dc.tr(thead);
    const tbody = $dc.tbody(table);

    for (let key in lista[0]) {
        if (key === "Pdf")
            $dc.th(trhead, "PLAN DE ESTUDIO"); //por cada propiedad que tenga el primer objeto, 
        else
            $dc.th(trhead, key.toUpperCase());
    }

    $dc.th(trhead, "EDITAR");

    if (user !== "CARRERAS")
        $dc.th(trhead, "BORRAR");
    tbody.innerHTML = " ";
    lista.forEach((usuario) => {

        const trBody = $dc.tr(tbody);
        for (var key in usuario) {
            if (key !== "Foto" && key !== "Pdf" && key !== "Duracion")
                $dc.th(trBody, usuario[key]);

            if (key === "Foto") {
                let imgtd = $dc.td(trBody, "");
                let img = $dc.img(imgtd)
                img.className = "tabla__foto"
                img.src = usuario[key];
            }
            if (key === "Duracion")
                $dc.th(trBody, usuario[key] + " años");
            if (key === "Pdf") {
                let ifrtd = $dc.td(trBody, "");

                ifrtd.onclick = () => {
                    iframe.style.display = "block"
                    iframe.className = "tabla__pdf"
                    let icon = $dc.icon(Section);

                    icon.className = "atras fas fa-circle-xmark";
                    icon.onclick = () => {
                        iframe.classList.remove("tabla__pdf")
                        iframe.classList.add("tabla__foto")
                        icon.style.display = "none"
                        iframe.style.display = "none"
                    }
                }

                let iframe = $d.ce("iframe")

                $d.ac(ifrtd, iframe)
                iframe.className = "tabla__foto"
                iframe.src = usuario[key];
                iframe.style.display = "none"

                let icon = $dc.icon(ifrtd)
                icon.className = "pdf fas fa-file-pdf "

            }
        }
        const tdEdit = $dc.td(trBody, "");
        const iconEdit = $dc.icon(tdEdit);
        iconEdit.className = "edit fas fa-pen-to-square";

        if (user !== "CARRERAS") {
            const tdDelete = $dc.td(trBody, "");
            const iconDelete = $dc.icon(tdDelete);
            iconDelete.className = "edit fa-solid fa-trash";
            iconDelete.addEventListener("click", () => {
                let respuesta = POST("accion=ELIMINARUSUARIO&ID=" + usuario.ID);
                validar(respuesta)
                $f.ABMUsuarios();
            })
        }
        iconEdit.addEventListener("click", () => {
            if (user === "USUARIOS")
                postEdit(usuario)
            if (user === "CARRERAS")
                $c.modifyCarrera(usuario);
        })
    })
}
