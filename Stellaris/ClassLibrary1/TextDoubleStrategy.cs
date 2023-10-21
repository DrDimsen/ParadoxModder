using Stellaris.Traits;

namespace Stellaris;

public class TextDoubleStrategy : ITextStrategy<double>
{
    public string Write(TraitProperty<double> property)
    {
        if (property.IsRequired == false && property.IsChanged == false) return "";
        return $"{property.StellarisName} = {property.Value}";
    }
}

public class TextIntStrategy : ITextStrategy<int>
{
    public string Write(TraitProperty<int> property)
    {
        if (property.IsRequired == false && property.IsChanged == false) return "";
        return $"{property.StellarisName} = {property.Value}";
    }
}

public class TextStringStrategy : ITextStrategy<string>
{
    public string Write(TraitProperty<string> property)
    {
        if (property.IsRequired == false && property.IsChanged == false) return "";
        return $"{property.StellarisName} = {property.Value}";
    }
}