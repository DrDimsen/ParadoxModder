using Stellaris.Resources;
using Stellaris.Traits;

namespace Stellaris;

public class ResourceCostListWritterStrategy : ITextStrategy<List<ResourceCost>>
{
    public string Write(TraitProperty<List<ResourceCost>> property)
    {
        if (property.IsRequired == false && property.IsChanged == false) return "";
        if (property.Value.Count == 0) return "";

        var text = $"{property.StellarisName} = " + "{\n";

        foreach (var resourceCost in property.Value)
        {
            text += "\t" + ResourceCostToString(resourceCost) + "\n";
        }

        text += "}";
        return text;
    }

    private string ResourceCostToString(ResourceCost cost)
    {
        return $"{cost.Type.ToResourceString()} = {cost.Value}";
    }
}