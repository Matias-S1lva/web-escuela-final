using System.Web;

namespace BussinesSchool
{
    public class Carrera : ICarrera
    {
        internal Singleton S => Singleton.GetInstance;
        public string Nombre { get ; set ; }
        public string Sigla { get ; set ; }
        public string Titulo { get ; set ; }
        public int Duracion { get ; set ; }
        public string Estado { get ; set ; }
        public HttpPostedFile FUPdf { get ; set ; }
        public HttpPostedFile Fu { get ; set ; }

        public string DirBase => "IMAGENES";

        public string Directory => "CARRERAS";

        public string Prefix => "CARRERA";

        public string Extension { get ; set ; }
        public int ID { get ; set ; }

        public string MakeData => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "jpg";
        public string MakeDataPDF => ID + ";" + DirBase + ";" + Directory + ";" + Prefix + ";" + "pdf";
        public void Add()
        {
            S.ISC.Add(this);
        }

        public void Erase()
        {
            S.ISC.Erase(this);
        }

        public string Find()
        {
            return S.ISC.Find(this);
        }

        public string FindBySigla()
        {
            return S.ISC.FindBySigla(this);
        }

        public string List()
        {
            return S.ISC.List(this);
        }

        public void Modify()
        {
            S.ISC.Modify(this);
        }

        public bool NameExists()
        {
            return S.ISC.NameExists(this);
        }

        public bool SiglaExists()
        {
            return S.ISC.SiglaExists(this);
        }
    }
}
