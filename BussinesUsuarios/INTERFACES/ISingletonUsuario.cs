using BASICA;

namespace BussinesUsuarios
{
    public interface ISingletonUsuario:IGenericSingleton<Usuario>
    {
        string List(Usuario Data);
        string Login(Usuario Data);
        string FindByDni(Usuario Data);
        string FindByMail(Usuario Data);
        string FindByMailAndDni(Usuario Data);
        bool MailExists(Usuario Data);
        bool DniExists(Usuario Data);
        string ListUsuariosByRol(string Rol,Usuario Data);
    }
}
