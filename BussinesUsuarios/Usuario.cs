using System.Web;

namespace BussinesUsuarios
{
    public class Usuario : IUsuario
    {
        internal Singleton S { get => Singleton.GetInstance; } //obtengo la instancia de Singleton
        public int ID { get ; set; }
        public string Nombre { get ; set; }
        public int Dni { get; set; }
        public string Mail { get ; set; }
        public string Password { get; set; }
        public string DirBase => "IMAGENES";
        public string Directory => "USUARIOS";
        public string Prefix => "USUARIO";
        public string Extension { get ; set; }
        public HttpPostedFile Fu { get ; set; }

        //-----------Metodos----------

        public void Add()
        {
            S.ISP.Add(this);
        }

        public void Erase()
        {
            S.ISP.Erase(this);
        }

        public string Find()
        {
            return S.ISP.Find(this);
        }

        public string List()
        {
            return S.ISP.List(this);
        }

        public void Modify()
        {
            S.ISP.Modify(this);
        }

        public string Login()
        {
            return S.ISP.Login(this);
        }

        public string FindByMail()
        {
            return S.ISP.FindByMail(this);
        }

        public string FindByDni()
        {
            return S.ISP.FindByDni(this);
        }

        public string FindByMailAndDni()
        {
            return S.ISP.FindByMailAndDni(this);
        }

        public bool DniExists()
        {
            return S.ISP.DniExists(this);
        }

        public bool MailExists()
        {
            return S.ISP.MailExists(this);
        }

        public string ListUsuariosByRol(string Rol)
        {
            return S.ISP.ListUsuariosByRol(Rol,this);
        }
    }
}
