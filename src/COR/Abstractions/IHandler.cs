namespace COR.Abstractions;

public interface IHandler
{
    void SetNext(IHandler handler);
    void Handle(ISandwich sandwich);
}