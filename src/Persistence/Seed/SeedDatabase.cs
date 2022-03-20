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

        public void Seed()
        {
            SeedActivities();
        }

        private void SeedActivities()
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
            context.Activities.AddRange(activities);
            context.SaveChanges();
        }
    }
}
