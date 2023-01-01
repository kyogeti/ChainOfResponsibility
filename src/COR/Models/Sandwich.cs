using COR.Abstractions;
using COR.Enumerations;

namespace COR.Models;

public class Sandwich : ISandwich
{
    public string Name { get; private set; }
    private IEnumerable<IIngredient> _ingredients;
    private SandwichState _sandwichState;

    public Sandwich()
    {
        Name = "Will's over-engineered sandwich";
        _sandwichState = SandwichState.Raw;
        _ingredients = new List<IIngredient>();
    }

    public void AddIngredient(IIngredient ingredient)
    {
        _ingredients = _ingredients.Append(ingredient);
    }

    public IEnumerable<IIngredient> GetIngredients()
    {
        return _ingredients;
    }

    public SandwichState GetState()
    {
        return _sandwichState;
    }

    public void Cook()
    {
        if (_sandwichState is SandwichState.Raw)
            _sandwichState = SandwichState.ReadyToEat;
    }
}