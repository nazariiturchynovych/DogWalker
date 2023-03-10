namespace DogWalker.Api.Application.Commands.UserCommands;

using System.Net;
using System.Net.Mail;
using Constants;
using Domain.Entities.User;
using Domain.Options;
using Domain.Results.Abstraction;
using Infrastructure.Services.EMailService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ResultFactory;

public record SendEmailConfirmationTokenCommand(string UserEmail, string Link) : IRequest<IResult>
{
    public class Handler : IRequestHandler<SendEmailConfirmationTokenCommand, IResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly SMTPOptions _options;

        public Handler(UserManager<User> userManager, IOptions<SMTPOptions> options, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
            _options = options.Value;
        }

        public async Task<IResult> Handle(SendEmailConfirmationTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserEmail);

            if (user is null)
                return ResultFactory.Failure(UserErrorMessages.UserDoesNotExist);

            var userId = user.Id;

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var link =
                $"{request.Link}" + $"?{nameof(userId)}={userId}" + $"&{nameof(token)}={WebUtility.UrlEncode(token)}";

            var message = new MailMessage(_options.UserName, request.UserEmail)
            {
                IsBodyHtml = true,
                Body = $"Activate account: <a href = '{link}'> link </a>",
            };

            await _emailService.SendAsync(message);

            return ResultFactory.Success();
        }
    }
}