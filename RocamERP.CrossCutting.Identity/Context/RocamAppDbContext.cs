using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RocamERP.CrossCutting.Identity.Models;

namespace RocamERP.CrossCutting.Identity.Context
{
    public class RocamAppDbContext : IdentityDbContext<RocamAppUser>
    {
        public RocamAppDbContext() : base("RocamIdentityDb")
        {
        }
    }
}
