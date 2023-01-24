using System.Web;

namespace BASICA
{
    public interface IABMFIMG : IABMF
    {
        string DirBase { get; }
        string Directory { get; }
        string Prefix { get; }
        string Extension { get; set; }
        HttpPostedFile Fu { get; set; }
    }
}
