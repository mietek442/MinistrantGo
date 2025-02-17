using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MediatR;
using Api.Domain.Models;

namespace Api.Features.QRCode.Commands.CreateQRCode
{
    public class CreateQRCodeTokenEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<QrCodeToken>
    {
        private readonly IMediator _mediator;
        public CreateQRCodeTokenEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/qrcode")]
        [SwaggerOperation(
            Summary = "Creates a new QRCode",
            Description = "Creates a new QRCode",
            OperationId = "QRCode_Create",
            Tags = new[] { "QRCode" })
        ]
        public override async Task<ActionResult<QrCodeToken>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new CreateQRCodeTokenCommand { }, cancellationToken);
            
        }
    }
}
