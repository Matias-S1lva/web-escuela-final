using System;
using System.Data;

using BASICA;

namespace BussinesSchool
{
    internal partial class Singleton : ISingletonUsuario
    {
        public ISingletonUsuario ISP { get => this; }

        void IGenericSingleton<Usuario>.Add(Usuario Data)
        {
            if (Data.DniExists()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExists()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Insert", "Usuario");
            IConnection.AddVarchar("Nombre", 50, Data.Nombre); //los parametros que recibe MyCommand 
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Direccion", 50, Data.Direccion);
            IConnection.AddDateTime("FechaNac", Data.FechaNac);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddVarchar("Telefono", 15, Data.Telefono);
            Data.Password = IHashing.Hash(Data.Password);
            IConnection.AddVarchar("Password", 64, Data.Password);
            Data.ID = IConnection.Insert(); //devuelve la primera columna de la primera fila, o sea el ID
            IIMage.Add(Data.Fu,Data.MakeData);
        }

        bool ISingletonUsuario.DniExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_DniExists", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddInt("Dni", Data.Dni);
            return IConnection.Exists();
        }

        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Delete", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.Delete();
            IIMage.Erase(Data.MakeData);
        }

        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Find", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return ISP.MakeJson(Dr, Data);
        }

        string ISingletonUsuario.FindByDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByDni", "Usuario");
            IConnection.AddInt("Dni", Data.Dni);
            DataRow dr = IConnection.Find();
            return ISP.MakeJson(dr, Data);
        }

        string ISingletonUsuario.FindByMail(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMail", "Usuarios");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            DataRow dr = IConnection.Find();
            return ISP.MakeJson(dr, Data);
        }

        string ISingletonUsuario.FindByMailAndDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMailAndDni", "Usuario");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddInt("Dni", Data.Dni);
            DataRow dr = IConnection.Find();
            return ISP.MakeJson(dr, Data);
        }

        string ISingletonUsuario.List(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_List", "Usuario");
            DataTable Dt = IConnection.List();
          
            return IListToTable.TableToJson(Dt, ISP);
        }

        string ISingletonUsuario.Login(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Login", "Usuario");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            Data.Password = IHashing.Hash(Data.Password);
            IConnection.AddVarchar("Password", 64, Data.Password);
            DataRow Dr = IConnection.Find();
            Data.ID = int.Parse(Dr["ID"].ToString());
            return ISP.MakeJson(Dr, Data);
        }

        bool ISingletonUsuario.MailExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_MailExists", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            return IConnection.Exists();
        }

        string IGenericSingleton<Usuario>.MakeJson(DataRow Dr, Usuario Data)
        {
            IJson Ijson = new Json();
            //cargamos los datos del dataRow en el objeto Usuario
            Data.ID = int.Parse(Dr["ID"].ToString());
            Data.Nombre = Dr["Nombre"].ToString();
            Data.Direccion = Dr["Direccion"].ToString();
            Data.Telefono = Dr["Telefono"].ToString();
            Data.Mail = Dr["Mail"].ToString();
            Data.FechaNac = (DateTime)Dr["FechaNac"];
            Data.Dni = int.Parse(Dr["Dni"].ToString());
            string JSON = Ijson.json(Dr);

        
            string url = IIMage.URL(Dr["ID"].ToString() + ";" + Data.DirBase + ";" + Data.Directory + ";" + Data.Prefix + ";jpg");
            JSON = JSON.Remove(JSON.Length - 1) + "," + "\"" + "Foto" + "\"" + ":" + "\"" + url + "\"" + "}";
       
            return JSON;
        }

        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            if (Data.DniExists()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExists()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Update", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Nombre", 50, Data.Nombre); //los parametros que recibe MyCommand 
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Direccion", 50, Data.Direccion);
            IConnection.AddDateTime("FechaNac", Data.FechaNac);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddVarchar("Telefono", 15, Data.Telefono);
            if (Data.Password != "")
            {
                Data.Password = IHashing.Hash(Data.Password);
            }
            IConnection.AddVarchar("Password", 64, Data.Password);
            IConnection.Update();
            
            IIMage.Add(Data.Fu, Data.MakeData);
        }

        string ISingletonUsuario.ListUsuariosByRol(string rol,Usuario Data)
        {
            IConnection.CreateCommand("UsuariosRoles_ListUsuariosByRol", "usuarios por rol");
            IConnection.AddVarchar("Rol", 30,rol);
            DataTable Dt = IConnection.List();
            return IListToTable.TableToJson(Dt, ISP);
        }
    }
}
