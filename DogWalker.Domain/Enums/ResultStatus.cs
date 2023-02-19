namespace DogWalker.Api.Application.Constants;

public enum ResultStatus
{
    Ok,
    NotFound,
    InvalidArgument,
    PermissionDenied,
    AlreadyExists,
    Unauthenticated,
    Unimplemented,
    Unavailable,
    InternalError,
    TechnicalWorks,
}