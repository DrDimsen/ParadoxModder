using System.Net.Mime;
using Stellaris.Traits;

namespace Stellaris;

public class TextBoolStrategy : ITextStrategy<bool>
{
    public string Write(TraitProperty<bool> property)
    {
        if (property.IsRequired == false && property.IsChanged == false) return "";

        var action = property.Value ? "yes" : "no";
        var text = $"{property.StellarisName} = {action}";
        return text;
    }
}