// ReSharper disable InconsistentNaming

namespace DogWalker.Domain.Options;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class SMTPOptions
{
    public string Host { get; init; }

    public int Port { get; init; }

    public string UserName { get; init; }

    public string Password { get; init; }
}