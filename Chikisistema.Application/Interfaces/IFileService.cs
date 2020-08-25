using System.IO;
using System.Threading.Tasks;

namespace Chikisistema.Application.Interfaces
{
    public interface IFileService
    {
        Stream GetStreamFile(string hash);
        Task<string> SaveFile(Stream file);
    }
}
