using COR.Abstractions;
using COR.ChainOfResponsibility.Handlers;
using COR.Enumerations;
using COR.Models;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;

namespace COR.UnitTests;

public class Test
{
    private readonly Mock<IIngredientProvider> _ingredientProviderMock;

    public Test()
    {
        _ingredientProviderMock = new Mock<IIngredientProvider>();
        _ingredientProviderMock.Setup(x => x.HasStock(It.IsAny<string>()))
            .Returns(true);
        SetupIngredientProviderMock("black pepper", "cheese", "chopped ham", "cream cheese",
            "bread", "tomato sauce");
    }

    private void SetupIngredientProviderMock(params string[] ingredients)
    {
        for(var i = 0; i <= ingredients.Length - 1; i++)
        {
            _ingredientProviderMock.Setup(x => x.GetIngredient(ingredients[i]))
                .Returns(new Ingredient(ingredients[i]));
        }
    }

    [Fact]
    public void Handle_GivenExistingIngredients_ShouldActAsExpected()
    {
        var firstStep = new FirstBreadLayerHandler(_ingredientProviderMock.Object);
        var sandwich = new Sandwich();
        
        firstStep.Handle(sandwich);

        sandwich.GetIngredients().Should().HaveCount(7);
        AssertIngredients(sandwich.GetIngredients(), "black pepper", "cheese", "chopped ham", "cream cheese",
            "bread", "tomato sauce");
        sandwich.GetState().Should().Be(SandwichState.ReadyToEat);
    }

    private static void AssertIngredients(IEnumerable<IIngredient> sandwichIngredients, params string[] ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            sandwichIngredients.Any(x => x.GetName() == ingredient).Should().BeTrue();
        }
    }

    [Fact]
    public void Handle_GivenMissingIngredient_ShouldThrow()
    {
        _ingredientProviderMock.Setup(x => x.HasStock("black pepper"))
            .Returns(false);
        var firstStep = new FirstBreadLayerHandler(_ingredientProviderMock.Object);
        var sandwich = new Sandwich();
        
        var action = () => firstStep.Handle(sandwich);

        action.Should().Throw<InvalidOperationException>();
        sandwich.GetState().Should().Be(SandwichState.Raw);
    }
}