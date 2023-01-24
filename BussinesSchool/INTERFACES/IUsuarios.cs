using BASICA;

namespace BussinesSchool
{
    public interface IUsuario:IABMFIMG
    {
        //Data contract
        string Nombre { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }
        string Password { get; set; }
        //Method Contract
        string List();
        string Login();
        string FindByMail();
        string FindByDni();
        string FindByMailAndDni();
        bool DniExists();
        bool MailExists();
        string ListUsuariosByRol(string Rol);
    }
}
