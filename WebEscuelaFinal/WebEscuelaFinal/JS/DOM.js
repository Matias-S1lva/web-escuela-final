const $$DomBasic = function () {

    this.id = function (id) {
        return document.getElementById(id);
    };
    this.tag = function (tag) {
        return document.getElementsByTagName(tag);
    }; //agregado
    this.value = function (id) {
        return document.getElementById(id).value;
    }; //agregado
    this.ce = function (type) {
        return document.createElement(type);
    };
    this.ac = function (parent, child) {
        parent.appendChild(child);
    };
    this.rc = function (parent, child) {
        parent.removeChild(child);
    };
    this.cn = function (parent) {
        return parent.childNodes();
    };
    this.class = function (classname) {
        return document.getElementsByClassName(classname)[0];
    };
};
const $d = new $$DomBasic();

const $$DomControls = function () {
    const AddControl = function (parent, strelem) {
        let control = $d.ce(strelem);
        $d.ac(parent, control);
        return control;
    };
    const AddInput = function (parent, type, name) {
        let input = $dc.input(parent, type);
        input.name = name;
        return input;
    };

    this.div = function (parent) {
        return AddControl(parent, "div");
    };
    this.label = function (parent, txt) {
        let lbl = AddControl(parent, "label");
        lbl.innerText = txt;
        return lbl;
    };
    this.ul = function (parent, id, classname) {
        let ul = AddControl(parent, "ul");
        ul.id = id;
        ul.className = classname;
        return ul;
    };
    this.li = function (parent, id, classname) {
        let li = AddControl(parent, "li");
        li.id = id;
        li.className = classname;
        return li;
    };
    this.a = function (parent, txt) {
        let a = AddControl(parent, "a");
        a.innerText = txt.toUpperCase();
        return a;
    };
    this.icon = function (parent) {
        let icon = AddControl(parent, "i");
        return icon;
    };
    this.span = function (parent) {
        return AddControl(parent, "span");
    };
    this.img = function (parent) {
        return AddControl(parent, "img");
    };
    this.btn = function (parent, txt) {
        let boton = AddControl(parent, "input");
        boton.type = "button";
        boton.value = txt;
        boton.className = "form__submit";
        return boton;
    };
    this.divGroup = function (id) {
        let div = AddControl(container, "div");
        div.className = "form__group";
        div.id = id;
        return div;
    };
    this.input = function (parent, type, name) {
        let input = AddControl(parent, "input");
        input.type = type;
        input.name = name
        input.autocomplete = "off";
        input.required = true;
        input.placeholder = " ";
        input.className = "form__input";
        return input;
    };
    this.select = function (parent, name) {
        $dc.label(parent, name);
        let select = AddControl(parent, "select");
        select.id = "select";
        select.name = name
        return select;
    };
    this.option = function (parent, value) {
        let op = AddControl(parent, "option");
        op.innerText = value;
        op.value = value;
        return op;
    };
    this.submit = function (parent, type, txt, id) {
        let submit = AddControl(parent, "input");
        submit.type = type;
        submit.className = "form__submit";
        submit.value = txt;
        submit.id = id;

        return submit;
    };
    this.reset = function (parent, type) {
        let submit = AddControl(parent, "input");
        submit.type = type;
        submit.className = "form__reset";
        submit.value = "Cancelar";
        return submit;
    };
    this.inputText = function (parent, name) {
        let input = AddInput(parent, "text", name);
        let lbl = $dc.label(parent, name);
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputDirec = function (parent, name) {
        let input = AddInput(parent, "text", name);
        let lbl = $dc.label(parent, name);
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputNumber = function (parent, name) {
        let input = AddInput(parent, "number", name);
        let lbl = $dc.label(parent, name);
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputCorreo = function (parent, name) {
        let input = AddInput(parent, "email", name);
        let lbl = $dc.label(parent, name);
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputPass = function (parent, name) {
        let input = AddInput(parent, "password", name);
        let lbl = $dc.label(parent, name);
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputModifPass = function (parent, name) {
        let input = AddInput(parent, "password", name);
        let lbl = $dc.label(parent, name);
        input.required = false;
        lbl.className = "form__label";
        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputConfirm = function (parent, name) {
        let input = AddInput(parent, "password", name);
        input.style.display = "none";
        input.required = false;

        let lbl = $dc.label(parent, "Confirmar password");
        lbl.className = "form__label";
        lbl.id = "labelConfirm";
        lbl.style.display = "none";

        let spanName = $dc.span(parent);
        spanName.className = "form__line";
        return input;
    };
    this.inputFecha = function (parent, name) {
        let input = AddInput(parent, "date", "fecha");
        input.className = "fecha";
        let lbl = $dc.label(parent, name);

        lbl.className = "form__label";
        input.className = "form__input";

        let spanName = $dc.span(parent);
        spanName.className = "form__line";

        return input;
    };
    this.inputFile = function (parent) {
        let input = AddInput(parent, "file", "file");
        input.required = false;
        input.className = "file";
        return input;
    };
    this.inputFileImg = function (parent, txt, name) {
        let fileimg = $dc.inputFile(parent, name);
        let lbl = $dc.label(parent, txt);

        fileimg.onchange = () => {
            if (fileimg.files.length === 0) return;

            if (!fileimg.files[0].name.endsWith("jpg"))
                fileimg.setCustomValidity("solo archivos jpg");
            else if (fileimg.files[0].size / 1024 >= 3000) {
                fileimg.setCustomValidity("el archivo es muy pesado");
            }
            else fileimg.setCustomValidity("");
                
        };
        lbl.className = "form__label";
        fileimg.className = "form__input";
        return fileimg;
    };
    this.inputFilePdf = function (parent, txt, name) {
        const change = function () {
            if (this.files.length === 0) return;

            if (!this.files[0].type.match("pdf.*")) 
                this.setCustomValidity("no es un archivo pdf".toUpperCase());

            else if (this.files[0].size / 1024 >= 3000) 
                this.setCustomValidity("el archivo es muy pesado");
            
            else
                this.setCustomValidity("");
        };

        let filepdf = $dc.inputFile(parent);
        let lbl = $dc.label(parent, txt);
        lbl.className = "form__label";
        filepdf.className = "form__input";
        filepdf.onchange = change;
        filepdf.required = false;
        return filepdf;
    };
    this.form = function (title, icono) {
        Section.innerHTML = ""; //limpiamos la section

        let formulario = AddControl(Section, "form"); // creammos formulario
        formulario.className = "form";
        formulario.id = "formulario";

        let icon = $dc.icon(formulario);
        icon.className = icono;

        icon.id = "atras";


        let container = $dc.div(formulario); //en esta caja esta todo el contenido del formulario
        container.className = "form__container";
        container.id = "container";

        let lbl = $dc.label(container);
        lbl.id = "titulo";

        lbl.innerHTML = title;

        return formulario;
    };

    //lo ultimo que se agrego, por ahora no forma parte del codigo que funciona correctamente


    this.table = function (parent) {
        let table = AddControl(parent, "table");
        table.className = "tabla";
        table.id = "Table";
        return table;
    };
    this.thead = function (parent) {
        let thead = AddControl(parent, "thead");
        thead.className = "tabla__head";
        return thead;
    };
    this.tbody = function (parent) {
        let tbody = AddControl(parent, "tbody");
        return tbody;
    };
    this.tr = function (parent) {
        let tr = AddControl(parent, "tr");
        return tr;
    };
    this.th = function (parent, txt) {
        let th = AddControl(parent, "th");
        th.scope = "col";
        th.innerText = txt;
        return th;
    };
    this.td = function (parent, txt) {
        let td = AddControl(parent, "td");
        td.innerHTML = txt;
        return td;
    };
};
const $dc = new $$DomControls();
const $$DomNav = function () {
    let ulLeft
    const ulRight = $d.ce("ul")

    const MakeUl = function () {
        if (ulLeft !== undefined) return; //valida si la variable ul ya esta definida
        ulLeft = $d.ce("ul");
        ulLeft.className = "menu__left inactive";
        ulRight.className = "menu__right";

        $d.ac(Nav, ulLeft); //crea elemento ul y lo mete en el nav
        $d.ac(Nav, ulRight)
    };

    this.clear = function () {
        //limpia la navegacion
        MakeUl();
        ulLeft.innerHTML = "";
        ulRight.innerHTML = "";
    };

    this.makeButton = function (txt, event) {
        let li = $d.ce("li");
        $d.ac(ulLeft, li);

        let a = $d.ce("a");
        a.innerHTML = txt.toUpperCase();
        a.onclick = event;

        $d.ac(li, a);
        return li;
    };

    this.makeButtonLogin = function (txt, event, icontxt) {
        //aca le damos una clase a la

        let li = $d.ce("li"); //etiqueta li para poder colocarla
        $d.ac(ulRight, li); //en la esquina de la pagina
        li.id = "login";

        let a = $dc.a(li, txt.toUpperCase());
        a.onclick = event;
        let icon = $dc.icon(li);

        icon.className = icontxt;
        return a;
    };

    this.dropdownButton = function (txt, event) {
        let li = $d.ce("li");
        $d.ac(ulLeft, li);
        li.id = "dropdown";

        let a = $dc.a(li, txt.toUpperCase());
        a.onclick = event;

        let dropdown = $d.ce("ul");
        dropdown.className = "menu__vertical";
        dropdown.id = "optionsDropdown";
        $d.ac(li, dropdown);
        return dropdown;
    };

    this.optionDropdown = function (txt, event, parent) {
        let liDropdown = $d.ce("li");
        $d.ac(parent, liDropdown);

        let option1 = $d.ce("a");
        option1.innerText = txt.toUpperCase();
        $d.ac(liDropdown, option1);

        option1.onclick = event;
        return option1;
    };
};

const $dn = new $$DomNav(); //instancia $$DomNav
