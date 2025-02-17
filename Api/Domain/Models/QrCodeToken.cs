using System;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Models
{
    public class QrCodeToken
    {
        public Guid Id { get; set; }
        public string Token { get;  set; }
        public bool IsActive { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        
    }
}
