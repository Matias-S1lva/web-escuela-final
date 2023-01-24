using System.Data;

namespace BASICA
{
    public interface IABMFTable : IABMF
    {
        string List();
        string PathSchema { get; }
        string Path { get; }
        void Create();
        void Save(DataTable Dt);
        DataTable Load();
        IIMage IIMage { get;  }
    }
}
