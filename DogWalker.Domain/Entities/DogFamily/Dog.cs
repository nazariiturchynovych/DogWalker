namespace DogWalker.Domain.Entities.DogFamily;

using Base;
using Immage;

public class Dog : Entity
{
    public Image Photo { get; set; }

    public string Name { get; set; }

    public double Age { get; set; }

    public double Weight { get; set; }

    public int DogFamilyId { get; set; }

    public string[] Preferences { get; set; }
    public DogFamily DogFamily { get; set; }

}
