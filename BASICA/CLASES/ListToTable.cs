using System.Collections.Generic;
using System.Data;


namespace BASICA
{
    public class ListToTable : IListToTable
    {
        public string TableToJson<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new() // esta restriccion indica que la clase debe tener un constructor accesible sin parámetros
        {
            if (Dt.Rows.Count == 0) return "[]";
            string Json = "[";
            foreach (DataRow Dr in Dt.Rows)
            {
                
                Json += Igs.MakeJson(Dr, new T()) + ",";
            }
            return Json.Remove(Json.Length - 1) + "]";
        }

        public IList<T> TableToList<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new()
        {
            IList<T> IL = new List<T>();
            foreach (DataRow Dr in Dt.Rows)
            {
                T t = new T();
                Igs.MakeJson(Dr, t);
                IL.Add(t);
            }
            return IL;
        }
    }
}
