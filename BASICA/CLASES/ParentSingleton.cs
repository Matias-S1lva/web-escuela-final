namespace BASICA
{
    public class ParentSingleton
    {
        public IHashing IHashing =>new  Sha();
        public IJson IJson => new Json();
        public IIMage IIMage => new Image();
        public IConnection IConnection => Connection.GetInstance;
        public IListToTable IListToTable => new ListToTable();
    }
}