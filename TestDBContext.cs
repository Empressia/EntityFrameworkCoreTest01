using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreTest01 {
    public sealed class TestDBContext : DbContext {
		public DbSet<User> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlite($"Filename=file:DesignDB?mode=memory&cache=shared");
		}
	}
}
