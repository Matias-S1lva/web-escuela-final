﻿namespace BussinesSchool
{
    public interface IUsuarioROL : BASICA.IABMF
    {
        Usuario Usuario { get; set; }
        string Rol { get; set; }
        string ListRolesByUsurio();
      
    }
}
