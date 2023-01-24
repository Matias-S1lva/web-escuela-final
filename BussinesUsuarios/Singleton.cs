using BASICA;

namespace BussinesUsuarios
{
    internal partial class Singleton: ParentSingleton
    {
        private static Singleton instance = new Singleton();
        private Singleton()
        {
            //cumple con la clausula where
        }
        public static Singleton GetInstance => instance;
    }
}