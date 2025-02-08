using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Api.Infrastructure.DbContext
{
    public interface IApplicationContext
    {
      
        DbSet<QrCodeToken> QrCodeTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}