using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace UserServices.Models;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    { }

    //Db Data Models
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}