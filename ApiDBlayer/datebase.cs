using Microsoft.EntityFrameworkCore;
using DbModels;

namespace ApiDBlayer
{
    public class Database : DbContext
    {
        public DbSet<DtoOrder> Orders { get; set; }
        public DbSet<DtoRating> Rating { get; set; }
        public DbSet<DtoTruckType> TruckTypes { get; set; }
        public DbSet<DtoUser> Users { get; set; }
        public DbSet<DtoUser_credentials> Users_credentials { get; set; }
        public DbSet<DtoUser_info> User_Infos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;DataBase=H6Database;Integrated Security=True; TrustServerCertificate=true;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtoOrder>().HasOne(x => x.Driver).WithMany().HasForeignKey(x => x.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DtoOrder>().HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DtoRating>().HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DtoRating>().HasOne(x => x.Receiver).WithMany().HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
