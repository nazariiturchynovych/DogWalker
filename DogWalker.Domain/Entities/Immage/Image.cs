namespace DogWalker.Domain.Entities.Immage;

using Base;
using DogFamily;
using Walker;
//TODO make id's nullable
public class Image : Entity
{
    public int? DogFamilyId { get; set; }

    public DogFamily DogFamily { get; set; }

    public int? DogId { get; set; }

    public Dog Dog { get; set; }

    public int? WalkerId { get; set; }

    public Walker Walker { get; set; }
    public byte[] ImageBytes { get; set; }
}