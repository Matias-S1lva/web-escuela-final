using System;
using System.Data;
using BASICA;

namespace BussinesUsuarios
{
    interface ISingletonUsuarioRol:IGenericSingleton<UsuarioRol>
    {
        string ListRolesByUsuario(UsuarioRol Data);
       
    }
}
