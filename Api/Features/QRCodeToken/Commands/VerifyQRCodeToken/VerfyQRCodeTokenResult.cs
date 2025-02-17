using Api.Shared.Enums;

namespace Api.Features.QRCodeToken.Commands.VerifyQRCodeToken
{
    public class VerfyQRCodeTokenResult
    {
        public VerificationTokenStatus VerificationStatus { get; set; }
        public string Message { get; set; }

    }
}
