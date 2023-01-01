using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class LastBreadLayerHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        HandleStep("bread", sandwich);
    }

    public LastBreadLayerHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}