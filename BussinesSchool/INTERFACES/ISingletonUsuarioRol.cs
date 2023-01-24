using System;
using System.Data;
using BASICA;

namespace BussinesSchool
{
    interface ISingletonUsuarioRol:IGenericSingleton<UsuarioRol>
    {
        string ListRolesByUsuario(UsuarioRol Data);
       
    }
}
