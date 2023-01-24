using System.Data;

namespace BASICA
{
    public interface IJson
    {
        /// <summary>
        /// genera un objeto json
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="value">
        /// string valor que puede ser objeto{}    tabla[]    valor
        /// </param>
        /// <returns></returns>
        string json(DataRow Dr);
        string addObject(string parent, string name, string value);
    }
}
