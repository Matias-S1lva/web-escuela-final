using BASICA;

namespace BussinesSchool
{
    public interface ISingletonCarrera: IGenericSingleton<Carrera>
    {
        bool NameExists(Carrera Data);
        bool SiglaExists(Carrera Data);
        string List(Carrera Data);
        string FindBySigla(Carrera Data);
    }
}
