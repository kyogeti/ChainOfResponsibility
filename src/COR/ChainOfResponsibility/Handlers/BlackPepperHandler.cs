using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class BlackPepperHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        SetNext(new LastBreadLayerHandler(IngredientProvider));
        HandleStep("black pepper", sandwich);
    }
    public BlackPepperHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}