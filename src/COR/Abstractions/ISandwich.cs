using COR.Enumerations;

namespace COR.Abstractions;

public interface ISandwich
{
    void AddIngredient(IIngredient ingredient);
    IEnumerable<IIngredient> GetIngredients();
    SandwichState GetState();
    void Cook();
}