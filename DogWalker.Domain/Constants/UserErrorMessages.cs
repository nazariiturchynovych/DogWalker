namespace DogWalker.Api.Application.Constants;

public static class UserErrorMessages
{
    public const string UserDoesNotExist = "USER_DOES_NOT_EXIST";

    public const string UserAlreadyExist = "USER_ALREADY_EXIST";

    public const string CreateUserFailed = "CREATE_USER_FAILED";

    public const string UserEmailConfirmFailed = "USER_EMAIL_CONFIRM_FAILED";

    public const string EmailAlreadyConfirmed = "EMAIL_ALREADY_CONFIRMED";

    public const string PasswordDoesNotMatch = "PASSWORD_DOES_NOT_MATCH";

    public const string ResetPasswordFailed = "RESET_PASSWORD_FAILED";

    public const string PasswordChangeFailed = "PASSWORD_CHANGE_FAILED";

    public const string ThisEmailAlreadyExist = "THIS_EMAIL_ALREADY_EXIST";
}