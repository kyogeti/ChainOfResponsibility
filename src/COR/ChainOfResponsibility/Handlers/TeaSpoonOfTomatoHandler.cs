using COR.Abstractions;

namespace COR.ChainOfResponsibility.Handlers;

public class TeaSpoonOfTomatoHandler : BaseHandler
{

    public override void Handle(ISandwich sandwich)
    {
        SetNext(new CheeseSliceHandler(IngredientProvider));
        HandleStep("tomato sauce", sandwich);
    }

    public TeaSpoonOfTomatoHandler(IIngredientProvider ingredientProvider) : base(ingredientProvider)
    {
    }
}