using System.Security.Cryptography.X509Certificates;

namespace Stellaris.Traits;

public class TraitProperty<T>
{
    public Type PropertyType { get; private set; }
    public bool IsRequired { get; private set; }
    public T Value { get; private set; }
    public List<TraitDependency<T>> Dependencies { get; private set; }

    public string StellarisName { get; private set; }

    public bool IsChanged { get; private set; }

    public TraitProperty(bool isRequired, T defaultValue, string stellarisName)
    {
        PropertyType = typeof(T);
        IsRequired = isRequired;
        Value = defaultValue;
        Dependencies = new List<TraitDependency<T>>();
        IsChanged = false;
        StellarisName = stellarisName;
    }

    public void SetValue(T newValue)
    {
        IsChanged = true;
        Value = newValue;
    }

    public void AddDependency(TraitDependency<T> dependency)
    {
        if (dependency != null)
        {
            Dependencies.Add(dependency);
        }
    }
}