using System.Text;
using System.Security.Cryptography;

namespace BASICA
{
    public class Sha : IHashing
    {
        public string Hash(string Data)
        {
            UTF8Encoding enc = new UTF8Encoding(); //
            byte[] data = enc.GetBytes(Data); //GetBytes() hace la codificacion convirtiendo los caracteres en bytes
            byte[] result;
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //convertimos los valores en hexadecimal
                //cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos digitos.
                sb.Append(result[i].ToString("X2"));//al pasar la X en mayuscula nos devuelve la cadena de texto en  mayuscula
            }
            return sb.ToString();
        }
    }
}
