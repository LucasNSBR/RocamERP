using Microsoft.AspNet.Identity.EntityFramework;
using RocamERP.CrossCutting.Identity.Context;
using RocamERP.CrossCutting.Identity.Models;

namespace RocamERP.CrossCutting.Identity.Managers
{
    public class RocamAppUserStore : UserStore<RocamAppUser>
    {
        public RocamAppUserStore(RocamAppDbContext context) : base(context)
        {
        }
    }
}
