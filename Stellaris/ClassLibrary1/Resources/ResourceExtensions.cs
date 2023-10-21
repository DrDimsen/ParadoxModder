namespace Stellaris.Resources;

public static class ResourceTypesExtensions
{
    public static string ToResourceString(this ResourceTypes resourceType)
    {
        return resourceType.ToString().ToLower();
    }
}