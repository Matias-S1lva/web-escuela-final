﻿using BASICA;

namespace BussinesSchool
{
    public interface ISingletonUsuario:IGenericSingleton<Usuario>
    {
        bool MailExists(Usuario Data);
        bool DniExists(Usuario Data);
        string FindByDni(Usuario Data);
        string FindByMail(Usuario Data);
        string FindByMailAndDni(Usuario Data);
        string Login(Usuario Data);
        string List(Usuario Data);
        string ListUsuariosByRol(string Rol,Usuario Data);
    }
}
