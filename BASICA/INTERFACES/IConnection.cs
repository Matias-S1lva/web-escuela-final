using System.Data;

namespace BASICA
{
    public interface IConnection: IParameters
    {
        void CreateCommand(string StoreProc, string Data);

        int Insert();

        void Delete();

        DataTable List();

        bool Exists();

        DataRow Find();

        void Update();
    }
}
