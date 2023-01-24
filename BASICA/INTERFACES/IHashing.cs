namespace BASICA
{
    public interface IHashing
    {
        /// <summary>
        /// dispersa data en un string
        /// </summary>
        /// <param name="Data">palabra a dispersar</param>
        /// <returns>dato dispersado</returns>
        string Hash(string Data);
    }
}
