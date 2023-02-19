// ReSharper disable InconsistentNaming
namespace DogWalker.Domain.Options;

public record SMTPOptions
(
    string Host,
    int Port,
    string UserName,
    string Password);