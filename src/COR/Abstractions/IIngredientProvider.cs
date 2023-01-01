namespace COR.Abstractions;

public interface IIngredientProvider
{
    bool HasStock(string name);
    IIngredient GetIngredient(string name);
}