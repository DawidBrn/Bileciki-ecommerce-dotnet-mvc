using Bileciki_ecommerce.Data.Base;
using Bileciki_ecommerce.Models;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Data.Services
{
    public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
