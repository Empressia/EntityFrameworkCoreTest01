using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreTest01 {
    public sealed class TestAccessor {
        public Task<List<string>> TestMethod1(CancellationToken cancellationToken = default) {
			TestDBContext context = new TestDBContext();
			Task<List<string>> IDs = context.Users.OrderBy(u => u.ID).Select(u => u.ID).ToListAsync(cancellationToken);
			return IDs;
		}
    }
}
