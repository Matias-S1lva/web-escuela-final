using System.Data;

namespace BASICA
{
    public abstract class BasicTable : IABMFTable
    {
        #region abstract 
        public abstract string PathSchema { get; }
        public abstract string Path { get; }
        public abstract void Add();
        public abstract void Create();
        public abstract void Erase();
        public abstract string Find();
        public abstract string List();
        public abstract void Modify();
        #endregion

        #region Metodos
        public IIMage IIMage => new Image();
        public int ID { get; set; }

        public DataTable Load()
        {
            DataTable Dt = new DataTable();
            Dt.ReadXmlSchema(PathSchema); 
            Dt.ReadXml(Path);
            return Dt;
        }
        public void Save(DataTable Dt)
        {
            Dt.WriteXmlSchema(PathSchema); //escribe en el archivo AlumnosSchema.xml
            Dt.WriteXml(Path); //escribe en el archivo Alumnos.xml
        }
        #endregion
    }
}
