using System.Data;
using BASICA;

namespace BussinesUsuarios
{
    internal partial class Singleton : ISingletonUsuario
    {
        public ISingletonUsuario ISP { get => this; }

        void IGenericSingleton<Usuario>.Add(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Insert", "Usuario");
            IConnection.AddVarchar("Nombre", 50, Data.Nombre); //los parametros que recibe MyCommand 
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            Data.Password = IHashing.Hash(Data.Password);
            IConnection.AddVarchar("Password", 64, Data.Password);
            Data.ID = IConnection.Insert(); //devuelve la primera columna de la primera fila, o sea el ID
            IIMage.Add(Data.Fu, Data.ID + ";" + Data.DirBase + ";" + Data.Directory + ";" + Data.Prefix + ";jpg");
        }

        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Erase", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.Delete();
            IIMage.Erase(Data.ID + ";" + Data.DirBase + ";" + Data.Directory + ";" + Data.Prefix + ";jpg");
        }

        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Find", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return ISP.MakeJson(Dr, Data);
        }

        string IGenericSingleton<Usuario>.MakeJson(DataRow Dr, Usuario Data)
        {
            IJson Ijson = new Json();
            string JSON = Ijson.json(Dr);

            string url = IIMage.URL(Dr["ID"].ToString() + ";" + Data.DirBase + ";" + Data.Directory + ";" + Data.Prefix + ";jpg");
            JSON = JSON.Remove(JSON.Length - 1) + "," + "\"" + "Foto" + "\"" + ":" + "\"" + url + "\"" + "}";

            return JSON;
        }

        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Update", "Usuario");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Nombre", 50, Data.Nombre);
            IConnection.AddInt("Dni", Data.Dni);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            if (Data.Password != "")
            {
                Data.Password = IHashing.Hash(Data.Password);
            }
            IConnection.AddVarchar("Password", 64, Data.Password);

            IConnection.Update();
            IIMage.Add(Data.Fu, Data.ID + ";" + Data.DirBase + ";" + Data.Directory + ";" + Data.Prefix + ";jpg");
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

        string ISingletonUsuario.List(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_List", "Usuario");
            DataTable Dt = IConnection.List();
            return IListToTable.TableToJson(Dt, ISP);
        }

        string ISingletonUsuario.FindByDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByDni", "Usuarios");
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
            IConnection.CreateCommand("Usuarios_FindByMailAndDni", "Usuarios");
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            IConnection.AddInt("Dni", Data.Dni);
            DataRow dr = IConnection.Find();
            return ISP.MakeJson(dr, Data);
        }

        bool ISingletonUsuario.MailExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_MailExists", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Mail", 60, Data.Mail);
            return IConnection.Exists();
        }

        bool ISingletonUsuario.DniExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_DniExists", "Usuarios");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddInt("Dni", Data.Dni);
            return IConnection.Exists();
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
