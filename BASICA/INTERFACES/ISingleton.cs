using System.Data;
using System.Collections.Generic;


namespace BASICA
{
    public interface ISingleton
    {
        IIMage IIm { get; }
        IHashing IHash { get; }
        IJson Json { get; }
        string TableToJson<T>(DataTable Dt, IGenericSingleton<T> IGS);
        IConnection IC { get; }
        List<T> TableToList<T>(DataTable Dt, IGenericSingleton<T> IGS);
    }
}
