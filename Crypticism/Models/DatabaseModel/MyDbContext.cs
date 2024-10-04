using System.Data.Entity;

namespace Crypticism.Models.DatabaseModel
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Server=localhost;Database=Crypticism;Integrated Security=True;") { }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Review> Review { get; set; }
        
        public DbSet<Comment> Comment { get; set; }

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     // Define the relationship between User and Company
        //     modelBuilder.Entity<User>()
        //         .HasRequired(u => u.Company)
        //         .WithMany(c => c.User)
        //         .HasForeignKey(u => u.CompanyId)
        //         .WillCascadeOnDelete(false);  // No cascading delete
        //
        //     base.OnModelCreating(modelBuilder);
        // }


        // public User GetUserById(int id)
        // {
        //     return User.SingleOrDefault(u => u.Id == id);
        // }
        //
        // public User GetUserByUsername(string username)
        // {
        //     return User.SingleOrDefault(u => u.Username == username);
        // }
    }
}