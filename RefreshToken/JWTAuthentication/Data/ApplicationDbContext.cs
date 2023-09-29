
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RefreshToken.Models;

namespace RefreshToken.Data
{
   
        public class ApplicationDbContext : IdentityDbContext<Client>
        {
        //public ApplicationDbContext()
        //{

        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
    
}
