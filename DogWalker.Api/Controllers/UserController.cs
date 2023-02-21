namespace DogWalker.Api.Controllers;

using Application.Commands.UserCommands;
using Application.Commands.Walker;
using Application.Queries.Walker;
using MediatR;
using Microsoft.AspNetCore.Mvc;

//TODO when return some values with includes we need to map them into response dto because of possible object cycle


[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUrlHelper _urlHelper;

    public UserController(IMediator mediator, IUrlHelper urlHelper)
    {
        _mediator = mediator;
        _urlHelper = urlHelper;
    }



    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUpAndSendEmailAccountConfirmation(
        SignUpCommand signUpCommand,
        CancellationToken cancellationToken
    )
    {
        var signUpResult = await _mediator.Send(
            signUpCommand,
            cancellationToken);

        if (signUpResult.IsFailure)
            return Ok(signUpResult);

        var link = _urlHelper.Action(
            "ConfirmEmailAndSetRole",
            "User",
            null,
            HttpContext.Request.Scheme);

        var sendEmailAccountConfirmationResult = await _mediator.Send(
            new SendEmailConfirmationTokenCommand(
                signUpCommand.Email, link),
            cancellationToken);

        return Ok(sendEmailAccountConfirmationResult);
    }

    [HttpGet("SignUp/ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAndSetRole(
        int userId,
        string token,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new ConfirmEmailAndSetDefaultRoleCommand(
                userId,
                token),
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("CreateWalker")]
    public async Task<IActionResult> CreateWalker(CreateWalkerCommand createWalkerCommand)
    {
        return Ok(await _mediator.Send(createWalkerCommand));
    }

    [HttpPost("SetWalkerAvatar")]
    public async Task<IActionResult> CreateWalker([FromForm] AddWalkerAvatarCommand addWalkerAvatarCommand)
    {
        return Ok(await _mediator.Send(addWalkerAvatarCommand));
    }


    [HttpGet("GetFullWalker")]
    public async Task<IActionResult> GetFullWalker(GetWalkerWithAvatarQuery walkerWithAvatarQuery)
        => Ok(await _mediator.Send(walkerWithAvatarQuery));

}