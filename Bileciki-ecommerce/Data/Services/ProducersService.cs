using Bileciki_ecommerce.Data.Base;
using Bileciki_ecommerce.Models;

namespace Bileciki_ecommerce.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
        
    }
}
