using COR.Abstractions;

namespace COR.Models;

public class Ingredient : IIngredient
{
    public string Name { get; }

    public Ingredient(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }
}