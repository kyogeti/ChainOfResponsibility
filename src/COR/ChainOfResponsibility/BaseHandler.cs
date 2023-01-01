using COR.Abstractions;
using COR.ChainOfResponsibility.Handlers;

namespace COR.ChainOfResponsibility;

public abstract class BaseHandler : IHandler
{
    protected readonly IIngredientProvider IngredientProvider;
    private IHandler? _next = null;

    protected BaseHandler(IIngredientProvider ingredientProvider)
    {
        IngredientProvider = ingredientProvider;
    }

    public void SetNext(IHandler handler)
    {
        _next = handler;
    }

    protected virtual void HandleStep(string ingredientName, ISandwich sandwich)
    {
        if (!IngredientProvider.HasStock(ingredientName))
        {
            throw new InvalidOperationException("The ingredient is missing :(");
        }
        
        var ingredient = IngredientProvider.GetIngredient(ingredientName);

        sandwich.AddIngredient(ingredient);

        if (_next?.GetType() == typeof(LastBreadLayerHandler))
        {
            sandwich.Cook();
        }

        _next?.Handle(sandwich);
    }

    public abstract void Handle(ISandwich sandwich);
}