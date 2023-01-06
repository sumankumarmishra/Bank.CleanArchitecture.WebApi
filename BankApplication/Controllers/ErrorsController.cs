using BankApplication.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            //accessing the thrown exception.
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "User already exists."),
                InvalidUser => (StatusCodes.Status404NotFound, "User doesn't exists."),
                InvalidAccount => (StatusCodes.Status404NotFound, "Invalid UserAccount."),
                InvalidPassword => (StatusCodes.Status400BadRequest, "Invalid Password or Username combination."),
                InvalidFrequency => (StatusCodes.Status400BadRequest, "Invalid Frequency or UserId."),
                InvalidTransferAmount => (StatusCodes.Status400BadRequest, "The Transfer Amount Must Be Positive."),
                InvalidTransferOperation => (StatusCodes.Status400BadRequest, "No such transfer operation, See Documentation for further information."),
                InvalidTransfer => (StatusCodes.Status400BadRequest, "Invalid Account Ownership"),
                InsufficientFunds => (StatusCodes.Status400BadRequest, "Insufficient funds or you're not the owner of both accounts, change operation!"),
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
