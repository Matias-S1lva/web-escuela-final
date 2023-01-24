using System;
using System.Data;
using BASICA;

namespace BussinesSchool
{
    internal partial class Singleton : ISingletonCarrera
    {
        public ISingletonCarrera ISC => this;
        void IGenericSingleton<Carrera>.Add(Carrera Data)
        {
            if (Data.SiglaExists()) throw new Exception("Error ya existe otra carrera con la misma sigla");
            if (Data.NameExists()) throw new Exception("Error ya existe otra carrera con el mismo nombre");
            IConnection.CreateCommand("Carreras_Insert", "Carrera");
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            IConnection.AddInt("Duracion", Data.Duracion);
            IConnection.AddVarchar("Titulo", 40, Data.Titulo);
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            Data.ID = IConnection.Insert();
            IIMage.Add(Data.Fu, Data.MakeData);
            IIMage.Add(Data.FUPdf, Data.MakeDataPDF);
        }

        void IGenericSingleton<Carrera>.Erase(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Delete", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.Delete();
            IIMage.Erase(Data.MakeData);
            IIMage.Erase(Data.MakeDataPDF);
        }

        string IGenericSingleton<Carrera>.Find(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Find", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return ISC.MakeJson(Dr, Data);
        }

        string ISingletonCarrera.FindBySigla(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_FindBySigla", "Carrera");
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            DataRow Dr = IConnection.Find();
            return ISC.MakeJson(Dr, Data);
        }

        string ISingletonCarrera.List(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_List", "Carrera");
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            DataTable Dt = IConnection.List();
            return IListToTable.TableToJson(Dt, ISC);
        }

        string IGenericSingleton<Carrera>.MakeJson(DataRow Dr, Carrera Data)
        {
            IJson Ijson = new Json();
            Data.ID = int.Parse(Dr["ID"].ToString());
            Data.Sigla = Dr["Sigla"].ToString();
            Data.Nombre = Dr["Nombre"].ToString();
            Data.Duracion = int.Parse(Dr["Duracion"].ToString());
            Data.Titulo = Dr["Titulo"].ToString();
            Data.Estado = Dr["Estado"].ToString();
           
            string JSON = Ijson.json(Dr);


            string url = IIMage.URL(Data.MakeData);
            JSON = JSON.Remove(JSON.Length - 1) + "," + "\"" + "Foto" + "\"" + ":" + "\"" + url + "\"" + "}";

            string urlPDF = IIMage.URL(Data.MakeDataPDF);
            JSON = JSON.Remove(JSON.Length - 1) + "," + "\"" + "Pdf" + "\"" + ":" + "\"" + urlPDF + "\"" + "}";

            return JSON;
        }

        void IGenericSingleton<Carrera>.Modify(Carrera Data)
        {
            if (Data.SiglaExists()) throw new Exception("Error ya existe otra carrera con la misma sigla");
            if (Data.NameExists()) throw new Exception("Error ya existe otra carrera con el mismo nombre");
            IConnection.CreateCommand("Carreras_Update", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            IConnection.AddInt("Duracion", Data.Duracion);
            IConnection.AddVarchar("Titulo", 40, Data.Titulo);
            IConnection.AddVarchar("Estado", 10, Data.Estado);
            IConnection.Update();
            IIMage.Add(Data.Fu, Data.MakeData);
            IIMage.Add(Data.FUPdf, Data.MakeDataPDF);
        }

        bool ISingletonCarrera.NameExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_NameExists", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Nombre", 40, Data.Nombre);
            return IConnection.Exists();
        }

        bool ISingletonCarrera.SiglaExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_SiglaExists", "Carrera");
            IConnection.AddInt("ID", Data.ID);
            IConnection.AddVarchar("Sigla", 10, Data.Sigla);
            return IConnection.Exists();
        }
    }
}
