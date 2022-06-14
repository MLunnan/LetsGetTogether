using Let_sGetTogether.Data;

namespace Let_sGetTogether.Services
{
    public class DatabaseService
    {
        private readonly ApplicationDbContext _ctx;

        public DatabaseService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task Recreate()
        {
            await _ctx.Database.EnsureDeletedAsync();

            await _ctx.Database.EnsureCreatedAsync();
        }
        public async Task RecreateAndSeed()
        {
            await Recreate();
            //await Seed();
        }
        public async Task CreateIfNotExist()
        {
            await _ctx.Database.EnsureCreatedAsync();
        }
        public async Task CreateAndSeedIfNotExist()
        {
            bool didCreateDatabase = await _ctx.Database.EnsureCreatedAsync();
            if (didCreateDatabase)
            {
                //await Seed();
            }
        }
    }
}
