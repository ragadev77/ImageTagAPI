using System.Linq;
using System.Threading.Tasks;

using ImageTagApi.Models;
namespace ImageTagApi.Repositories
{
    public interface IPictureRepository
    {
        Task<IEnumerable<Picture>> Get();
        Task<Picture> Get(int id);
        Task<IEnumerable<Picture>> GetByTag(string tag);
        Task<Picture> Create(Picture picture);
        // Task Update(Picture picture);
        // Task Delete(int id);        
    }
}