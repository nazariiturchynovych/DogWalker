namespace DogWalker.Domain.Entities.Chat;

using Base;
public class Message : Entity
{
    public string Body { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ChangedDate { get; set; }

    public int ChatMemberId { get; set; }

    public ChatMember ChatMember { get; set; }
}