using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class CreamCheeseHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        SetNext(new BlackPepperHandler(IngredientProvider));
        HandleStep("cream cheese", sandwich);
    }

    public CreamCheeseHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}