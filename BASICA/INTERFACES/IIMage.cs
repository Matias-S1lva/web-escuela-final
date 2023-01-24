using System.Web;


namespace BASICA
{
    public interface IIMage : IID
    {
        /// <summary>
        /// Agrega o sustituye
        /// </summary>
        /// <param name="FU"></param>
        /// <param name="Data"></param>
        void Add(HttpPostedFile FU, string Data);

        /// <summary>
        /// Elimina un archivo de imagen
        /// del sistema web persistente
        ///  string que contiene
        /// ID + archivoBase + Directorio + Prefijo
        /// </summary>
        /// <param name="Data"></param>
        void Erase(string Data);

        /// <summary>
        ///Devuelve la Url de la imagen del objeto
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        string URL(string Data);
    }
}
