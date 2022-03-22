using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ActivityEntity> Activities { get; set; }

        // TODO: remove default, should just have cancellationToken param
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
