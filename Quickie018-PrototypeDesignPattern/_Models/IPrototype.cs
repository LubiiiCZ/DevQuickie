namespace Quickie018;

public interface IPrototype
{
    IPrototype ShallowClone();
    IPrototype DeepClone();
}
