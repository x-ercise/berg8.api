//using System.Data.Entity.ModelConfiguration;
using Berg8.Data.EntityFramework.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Berg8.Data.EntityFramework.Identity.EntityConfigurations
{
    public static class IdentityConfigurationHelpers
    {
        public static void IgnorePhone(this EntityTypeConfiguration<AppUser> source)
        {
            source
                .Ignore(m => m.PhoneNumber)
                .Ignore(m => m.PhoneNumberConfirmed);
        }
    }
}
