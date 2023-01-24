using System;
using System.Web;

namespace BussinesSchool
{
    public class Usuario : IUsuario
    {
        internal Singleton S { get => Singleton.GetInstance; } //obtengo la instancia de Singleton
        public int ID { get ; set; }
        public string Nombre { get ; set; }
        public int Dni { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string MakeFecha => FechaNac.Year.ToString() + "-" + FechaNac.Month.ToString() + "-" + FechaNac.Day.ToString() + "-";
       
        public string Mail { get ; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }

        public string DirBase => "IMAGENES";
        public string Directory => "USUARIOS";
        public string Prefix => "USUARIO";
        public string Extension { get ; set; }
        public HttpPostedFile Fu { get ; set; }
        public string MakeData => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "jpg";

        //-----------Metodos----------

        public void Add()
        {
            S.ISP.Add(this);
        }
        public bool DniExists()
        {
            return S.ISP.DniExists(this);
        }
        public void Erase()
        {
            S.ISP.Erase(this);
        }
        public string Find()
        {
            return S.ISP.Find(this);
        }
        public string FindByDni()
        {
            return S.ISP.FindByDni(this);
        }
        public string FindByMail()
        {
            return S.ISP.FindByMail(this);
        }
        public string FindByMailAndDni()
        {
            return S.ISP.FindByMailAndDni(this);
        }
        public string List()
        {
            return S.ISP.List(this);
        }
        public string Login()
        {
            return S.ISP.Login(this);
        }
        public bool MailExists()
        {
            return S.ISP.MailExists(this);
        }
        public void Modify()
        {
            S.ISP.Modify(this);
        }
        public string ListUsuariosByRol(string Rol)
        {
            return S.ISP.ListUsuariosByRol(Rol,this);
        }
    }
}
