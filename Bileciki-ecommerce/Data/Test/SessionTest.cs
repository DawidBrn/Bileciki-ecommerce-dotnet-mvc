using Microsoft.AspNetCore.Http;

namespace Bileciki_ecommerce.Data.Test
{
    public class SessionTest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionTest(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void setSession()
        {
            _session.SetString("Test", "Works");
        }

        public string getSession()
        {
            return _session.GetString("Test");
            
        }
    }
}
