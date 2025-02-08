using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
namespace Api.Infrastructure.DbContext
{
    public interface IApplicationContext
    {
        DbSet<Test> Tests { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}