using System.Data.Entity;

namespace Crypticism.Models.DatabaseModel
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Server=localhost;Database=Cripticism;Integrated Security=True;") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     // Define the relationship between User and Company
        //     modelBuilder.Entity<User>()
        //         .HasRequired(u => u.Company)
        //         .WithMany(c => c.Users)
        //         .HasForeignKey(u => u.CompanyId)
        //         .WillCascadeOnDelete(false);  // No cascading delete
        //
        //     base.OnModelCreating(modelBuilder);
        // }


        // public User GetUserById(int id)
        // {
        //     return Users.SingleOrDefault(u => u.Id == id);
        // }
        //
        // public User GetUserByUsername(string username)
        // {
        //     return Users.SingleOrDefault(u => u.Username == username);
        // }
    }
}