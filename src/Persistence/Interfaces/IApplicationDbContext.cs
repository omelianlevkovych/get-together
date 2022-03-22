using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ActivityEntity> Activities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
