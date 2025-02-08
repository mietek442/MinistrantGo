using Api.Domain.Models;
using Api.Infrastructure.DbContext;
using Api.Infrastructure.Storage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Features.QRCode.Commands.CreateQRCode
{
    public class CreateQRCodeTokenCommand : IRequest<ActionResult<QrCodeToken>>
    {
        public int QRCodeTokenRequest { get; set; }
    }

    public class CreateQRCodeCommandHandler : IRequestHandler<CreateQRCodeTokenCommand, ActionResult<QrCodeToken>>
    {
        private readonly IBlobService _blobService;
        private readonly IApplicationContext _context;

        /*public CreateQRCodeCommandHandler(IBlobService blobService, IApplicationContext context)
        {
            _blobService = blobService;
            _context = context;
        }*/

        public async Task<ActionResult<QrCodeToken>> Handle(CreateQRCodeTokenCommand request, CancellationToken cancellationToken)
        {
            var qrCodeToken = new QrCodeToken
            {
                IsActive = true,          
            };
            await _context.QrCodeTokens.AddAsync(qrCodeToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(qrCodeToken);
        }
    }
}
