using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class ChoppedHamHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        SetNext(new CreamCheeseHandler(IngredientProvider));
        HandleStep("chopped ham", sandwich);
    }

    public ChoppedHamHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}