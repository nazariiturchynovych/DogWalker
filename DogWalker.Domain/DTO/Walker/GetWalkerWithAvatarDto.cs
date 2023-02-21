namespace DogWalker.Domain.DTO.Walker;

public record GetWalkerWithAvatarDto(
    string FirstName,
    string LastName,
    int Age,
    AvatarDto Avatar);
