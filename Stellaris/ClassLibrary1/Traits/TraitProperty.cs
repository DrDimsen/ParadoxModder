namespace Stellaris.Traits;

public class TraitProperty<T>
{
    public Type PropertyType { get; private set; }
    public bool IsRequired { get; private set; }
    public T Value { get; set; }
    public bool CanBeEmpty { get; private set; }
    public List<TraitDependency<T>> Dependencies { get; set; }

    public TraitProperty(bool isRequired, T defaultValue, bool canBeEmpty)
    {
        PropertyType = typeof(T);
        IsRequired = isRequired;
        Value = defaultValue;
        CanBeEmpty = canBeEmpty;
        Dependencies = new List<TraitDependency<T>>();
    }

    public void AddDependency(TraitDependency<T> dependency)
    {
        Dependencies.Add(dependency);
    }
}