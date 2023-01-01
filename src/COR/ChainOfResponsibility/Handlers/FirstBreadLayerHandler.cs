using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class FirstBreadLayerHandler : BaseHandler
{
    public override void Handle(ISandwich sandwich)
    {
        SetNext(new TeaSpoonOfTomatoHandler(IngredientProvider));
        HandleStep("bread", sandwich);
    }

    public FirstBreadLayerHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}