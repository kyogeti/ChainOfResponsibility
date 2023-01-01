using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class CheeseSliceHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        SetNext(new ChoppedHamHandler(IngredientProvider));
        HandleStep("cheese", sandwich);
    }

    public CheeseSliceHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}