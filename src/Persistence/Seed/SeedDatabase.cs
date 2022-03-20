using Domain.Entities;

namespace Persistence.Seed
{
    public class SeedDatabase
    {
        private readonly ApplicationDbContext context;

        public SeedDatabase(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            await SeedActivities();
        }

        private async Task SeedActivities()
        {
            if (context.Activities is null)
            {
                throw new ArgumentNullException(nameof(context.Activities));
            }
            if (context.Activities.Any())
            {
                // TODO: Log
                return;
            }

            var activities = new List<ActivityEntity>
            {
                new ActivityEntity
                {
                    Title = "UkraineVictory",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Activity a month ago",
                    Category = "drinks",
                    City = "Kiev",
                    Venue = "Central Pub",
                },

                new ActivityEntity
                {
                    Title = "FutureActivity1",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Activity in a month from now",
                    Category = "music",
                    City = "Lviv",
                    Venue = "Arena Lviv",
                }
            };
            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}
