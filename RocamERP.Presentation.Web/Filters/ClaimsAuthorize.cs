using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Filters
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        private string _claimType;
        private string _claimValue;

        public ClaimsAuthorize(string claimType, string claimValue)
        {
            _claimValue = claimValue;
            _claimType = claimType;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identityClaims = httpContext.User.Identity as ClaimsIdentity;
            var claim = identityClaims.Claims.FirstOrDefault(c => c.Type == _claimType);

            if (claim != null)
                return _claimValue == claim.Value;

            return false;
        }
    }
}