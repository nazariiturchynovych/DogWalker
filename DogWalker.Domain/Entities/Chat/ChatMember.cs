namespace DogWalker.Domain.Entities.Chat;

using Base;
using User;

public class ChatMember : Entity
{
    public bool Creator { get; set; }

    public int ChatId { get; set; }

    public Chat Chat { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<Message> Messages { get; set; }
}