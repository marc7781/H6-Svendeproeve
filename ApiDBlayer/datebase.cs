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
        public DbSet<DtoUserCredentials> Users_credentials { get; set; }
        public DbSet<DtoUserInfo> User_Infos { get; set; }
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

            modelBuilder.Entity<DtoTruckType>().HasData(new DtoTruckType { Id = 1, Trucktype = "Lastbil" });
            modelBuilder.Entity<DtoTruckType>().HasData(new DtoTruckType { Id = 2, Trucktype = "Varebil" }); 
            
            modelBuilder.Entity<DtoUser>().HasData(new DtoUser { Id = 1, Driver = true, TruckTypeId = 1, UserCredentialsId = 1, UserInfoId = 1 });
            modelBuilder.Entity<DtoUser>().HasData(new DtoUser { Id = 2, Driver = false, UserCredentialsId = 2, UserInfoId = 2 });

            modelBuilder.Entity<DtoUserCredentials>().HasData(new DtoUserCredentials { Id = 1, Password = "$2a$12$F4AMp7JgfE05JlEhpkNZc./kr1LiR27Pm28O4M8mR9QrASYYnb1XO" });
            modelBuilder.Entity<DtoUserCredentials>().HasData(new DtoUserCredentials { Id = 2, Password = "$2a$12$JaBadjoD5fqhKjI.Algi7.fAGmMxVdgzGOAWn8imtJ9E9m6dgcbBa" });

            modelBuilder.Entity<DtoUserInfo>().HasData(new DtoUserInfo { Id = 1, Name = "Simon", Address = "Viborg", Email = "simon@gmail.com", Phone_number = 88888888 });
            modelBuilder.Entity<DtoUserInfo>().HasData(new DtoUserInfo { Id = 2, Name = "Marcus", Address = "Fjelstervang", Email = "marcus@gmail.com", Phone_number = 12345678 });

            
        }
    }
}
