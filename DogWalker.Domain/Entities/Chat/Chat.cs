namespace DogWalker.Domain.Entities.Chat;
#pragma warning disable CS8618
using Base;

public enum ChatType
{
    OneToOne = 1,
    Support = 2,
    Group = 3
}

public class Chat : Entity
{
    public ChatType Type { get; set; }

    public DateTime LastActionDate { get; set; }

    public ICollection<ChatMember> ChatMembers { get; set; }
        = new List<ChatMember>();

}
