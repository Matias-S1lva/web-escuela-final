using System.IO;
using System;
using System.Web;


namespace BASICA
{
    public class Image : IMakeImg
    {
        public string DirBase { get; set; }
        public string Directory { get; set; }
        public string Path => AppDomain.CurrentDomain.BaseDirectory +
                DirBase +
                @"\" + Directory + @"\" +
                Prefix + ID + "."+ Extension;
        public string Prefix { get; set; }
        public int ID { get; set; }
        public string Extension { get; set; }
        public void ResetPrefix()
        {
            if (Prefix.EndsWith("_")) ChangePrefix();
        }

        public void ChangePrefix()
        {
            if (Prefix.EndsWith("_"))
            {
                Prefix = Prefix.Remove(Prefix.Length - 1);
                return;
            }
            Prefix += "_";
        }

        public void Add(HttpPostedFile FU, string Data)
        {
            if (FU == null || FU.FileName == "") return; //valida si hay un archivo cargado
            Erase(Data);
            FU.SaveAs(Path); //guarda el archivo que contiene FU en la ruta que le pasamos en el Path
        }
     

        public void Erase(string Data)
        {
            SplitData(Data);
            ResetPrefix();
            if (File.Exists(Path))
            {
                File.Delete(Path);
                ChangePrefix();
                return;
            }
            ChangePrefix();
            if (File.Exists(Path))
            {
                File.Delete(Path);
                ChangePrefix();
                return;
            }
            ResetPrefix();
        }

        public void SplitData(string Data)
        {
            string[] Datos = Data.Split(new char[] { ';' });
            ID = int.Parse(Datos[0]);
            DirBase = Datos[1];
            Directory = Datos[2];
            Prefix = Datos[3];
            Extension = Datos[4];
            //todas estas propiedades forman el Path
        }

        public string URL(string Data)
        {
            SplitData(Data);
            ResetPrefix();
            if (File.Exists(Path))
            {
                return DirBase + "/" + Directory + "/" + Prefix + ID + "." + Extension;
            }
            ChangePrefix();
            if (File.Exists(Path))
            {
                return DirBase + "/" + Directory + "/" + Prefix + ID + "." + Extension;
            }
            ResetPrefix();
            return DirBase + "/" + Directory + "/" + Prefix + "default." + Extension;
        }
    }
}
