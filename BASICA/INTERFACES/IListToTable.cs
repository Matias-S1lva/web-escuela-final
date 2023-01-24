using System.Collections.Generic;
using System.Data;


namespace BASICA
{
    public interface IListToTable
    {
        IList<T> TableToList<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new();
        string TableToJson<T>(DataTable Dt, IGenericSingleton<T> Igs) where T : new();
    }
}
