# Minha receita de Misto Quente *over engineered*

Este projeto serve como estudo do pattern Chain of Responsibility.

A receita só funciona se as etapas ocorrem na ordem prevista. Cada etapa está representada por um Handler que adicionará ingredientes ao sanduíche ou mudará o seu estado final.

O objeto ```Sandwich``` possui dois estados possíveis: ```Raw``` e ```ReadToEat```. Entre o início do procedimento de preparo e o fim, diversas adições a lista de ingredientes deverá acontecer e, por fim, o sanduíche passará pela última etapa que é o cozimento, que alterará seu estado para ```ReadToEat```. Se alguma etapa falhar, o estado continua como ```Raw```.

```c#
public interface ISandwich
{
    void AddIngredient(IIngredient ingredient);
    IEnumerable<IIngredient> GetIngredients();
    SandwichState GetState();
    void Cook();
}
```

```c#
public enum SandwichState
{
    Raw = 1,
    ReadyToEat = 2
}
```

```c#
public interface IIngredient
{
    string GetName();
}
```

Ao chamar o ```ISandwich.GetIngredients()```, o resultado deve ser uma lista como a seguir:
```json
[
  {
    "Name": "bread"
  },
  {
    "Name": "tomato sauce"
  },
  {
    "Name": "cheese"
  },
  {
    "Name": "chopped ham"
  },
  {
    "Name": "cream cheese"
  },
  {
    "Name": "black pepper"
  },
  {
    "Name": "bread"
  }
]
```

