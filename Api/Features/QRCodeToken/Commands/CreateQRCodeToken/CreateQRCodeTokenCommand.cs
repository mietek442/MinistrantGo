using Api.Domain.Models;
using Api.Features.QRCodeToken.Common.TokensProvider;
using Api.Infrastructure.DbContext;
using Api.Infrastructure.Storage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;


namespace Api.Features.QRCode.Commands.CreateQRCode
{
    public class CreateQRCodeTokenCommand : IRequest<ActionResult<QrCodeToken>>
    {
       
    }

    public class CreateQRCodeCommandHandler : IRequestHandler<CreateQRCodeTokenCommand, ActionResult<QrCodeToken>>
    {
        private readonly IBlobService _blobService;
        private readonly IApplicationContext _context;
        private readonly QRCodeTokenProvider _qRCodeTokenProvider;
        public CreateQRCodeCommandHandler(IApplicationContext context, QRCodeTokenProvider qRCodeTokenProvider)
        {
            _context = context;
            _qRCodeTokenProvider = qRCodeTokenProvider;

        }
       
        public async Task<ActionResult<QrCodeToken>> Handle(CreateQRCodeTokenCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var token = _qRCodeTokenProvider.Create(id);

            var qrCodeToken = new QrCodeToken
            {
                Id = id,
                IsActive = true,
                Token= token
            };

            await _context.QrCodeTokens.AddAsync(qrCodeToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return new OkObjectResult(qrCodeToken);
        }
    }
}
