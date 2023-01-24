using System;
using System.Data;
using BASICA;

namespace BussinesUsuarios
{
    partial class Singleton : ISingletonUsuarioRol
    {
        public ISingletonUsuarioRol ISUR => this;

        void IGenericSingleton<UsuarioRol>.Add(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Insert", "Rol de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            IConnection.AddVarchar("Rol", 30, Data.Rol);
            Data.ID = IConnection.Insert();
        }

        void IGenericSingleton<UsuarioRol>.Erase(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Delete", "Rol de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            IConnection.AddVarchar("Rol", 30, Data.Rol);
            IConnection.Delete();
        }

        string IGenericSingleton<UsuarioRol>.Find(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_Find", "Roles de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            DataRow row = IConnection.Find();
            return ISUR.MakeJson(row,Data);
        }

        string ISingletonUsuarioRol.ListRolesByUsuario(UsuarioRol Data)
        {
            IConnection.CreateCommand("UsuariosRoles_ListRolesByUsuario", "roles de usuario");
            IConnection.AddInt("IDUsuario", Data.Usuario.ID);
            DataTable Dt = IConnection.List();
            string Json = Data.Usuario.Find();
            string Lista = "";

            foreach (DataRow row in Dt.Rows)
            {
                Lista += row["Rol"].ToString() + ",";
            }
            if (Dt.Rows.Count > 1) Lista = Lista.Remove(Lista.Length - 1);
            Json = IJson.addObject(Json, "Roles", Lista);
            return Json;
        }

        string IGenericSingleton<UsuarioRol>.MakeJson(DataRow Dr, UsuarioRol Data)
        {
            IJson Ijson = new Json();
            string JSON = Ijson.json(Dr);
            return JSON;
        }

        void IGenericSingleton<UsuarioRol>.Modify(UsuarioRol Data)
        {
            throw new NotImplementedException();
        }
    }
}
