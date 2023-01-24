let Rol, MainUser, User, Carrera;
let Usuarios = [];
const menuBars = $d.id("menuBars")
const colorSwitch = document.querySelector('.switch');

function cambiaTema(ev) {
    (ev.target.checked)
        ?
        document.documentElement.setAttribute('tema', 'light')
        :
        document.documentElement.setAttribute('tema', 'dark')
}
colorSwitch.addEventListener('change', cambiaTema);

const Home = () => {
    Section.innerHTML = "<img src='IMAGENES/FONDO.jpg' class='portada'>";

}

const ListUsuarios = () => {
    Usuarios = JSON.parse(POST("accion=LOADUSUARIOS"))
    Listado(Usuarios, "USUARIOS")
}

const POST = (Data) => {
    let type = typeof Data
    const xhttp = new XMLHttpRequest();
    let resp;
    xhttp.open("POST", "Default.aspx", false);
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            resp = this.response;
        }
    };
    if (type !== "object")
        xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send(Data);
    return resp;
};

$n.init()
const menuVertical = document.querySelector(".menu__left")

const toggleMenuBars = () => {
    if (!menuVertical.classList.contains("inactive"))
        menuVertical.classList.add("inactive")
}
menuBars.addEventListener("click", () => {
    menuVertical.classList.toggle("inactive")
})
$f.pruebaLogin()