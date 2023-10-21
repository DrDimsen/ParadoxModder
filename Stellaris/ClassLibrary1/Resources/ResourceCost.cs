namespace Stellaris.Resources;

public class ResourceCost
{
    public ResourceCost(ResourceTypes type, double value)
    {
        Type = type;
        Value = value;
    }

    public ResourceTypes Type { get; set; }
    public double Value { get; set; }
}