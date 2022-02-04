using Bileciki_ecommerce.Data.Base;
using Bileciki_ecommerce.Models;
using Bileciki_ecommerce.Models.ViewModels;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Data.Services
{
    public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<MovieDropdownsVM> GetMovieDropdownValues();
    }
}
