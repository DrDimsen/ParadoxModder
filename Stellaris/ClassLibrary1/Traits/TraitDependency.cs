namespace Stellaris.Traits;

public class TraitDependency<T>
{
    public TraitProperty<T> DependentProperty { get; private set; }
    public T RequiredValue { get; private set; }

    public TraitDependency(TraitProperty<T> dependentProperty, T requiredValue)
    {
        DependentProperty = dependentProperty;
        RequiredValue = requiredValue;
    }
}