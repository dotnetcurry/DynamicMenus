using System.Data.Entity;

namespace LiveTile.Models
{
    public class LiveTileContext : DbContext
    {
        public LiveTileContext() : base("LiveTileDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LiveTileContext>(new CreateDatabaseIfNotExists<LiveTileContext>());
        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
