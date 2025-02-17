using Api.Features.QRCodeToken.Common.TokensProvider;
using Api.Infrastructure.DbContext;
using Api.Shared.Enums;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Features.QRCodeToken.Commands.VerifyQRCodeToken
{
    public class VerifyQrCodeToken : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/qrcode/verify", async (IMediator mediator, VerifyQrCodeTokenCommand command) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("QRCode_Verify")
            .WithTags("QRCode")
            .WithSummary("Verifies a QR Code Token")
            .WithDescription("Validates the provided QR Code Token");
        }

        public class VerifyQrCodeTokenCommand : IRequest<VerfyQRCodeTokenResult>
        {
            public VerfyQRCodeTokenRequest VerifyQRCodeTokenRequest { get; set; }
        }

        public class VerifyQrCodeTokenCommandHandler : IRequestHandler<VerifyQrCodeTokenCommand, VerfyQRCodeTokenResult>
        {
            private readonly IApplicationContext _context;
            private readonly QRCodeTokenProvider _qRCodeTokenProvider;

            public VerifyQrCodeTokenCommandHandler(IApplicationContext context, QRCodeTokenProvider qRCodeTokenProvider)
            {
                _context = context;
                _qRCodeTokenProvider = qRCodeTokenProvider;
            }

            public async Task<VerfyQRCodeTokenResult> Handle(VerifyQrCodeTokenCommand request, CancellationToken cancellationToken)
            {
                Console.WriteLine(request.VerifyQRCodeTokenRequest.UrlToken);

                var qrCodeTokenResult = new VerfyQRCodeTokenResult
                {


                    VerificationStatus = VerificationTokenStatus.Expired,
                    Message = "takkkkk"
                    
                };

                return qrCodeTokenResult;
            }
        }
    }


}
