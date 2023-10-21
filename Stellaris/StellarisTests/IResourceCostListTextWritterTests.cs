using Stellaris;
using Stellaris.Resources;
using Stellaris.Traits;

namespace StellarisTests;

public class IResourceCostListTextWritterTests
{
    public ITextStrategy<List<ResourceCost>> writter;

    public IResourceCostListTextWritterTests()
    {
        this.writter = new ResourceCostListWritterStrategy();
    }

    [Fact]
    public void CreatingAWritterShouldSucceed()
    {
        Assert.True(writter != null);
    }

    [Fact]
    public void IfValueIsDefaultAndIsntRequiredReturnEmpty()
    {
        TraitProperty<List<ResourceCost>> prop =
            new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(), "initial");
        var result = writter.Write(prop);
        Assert.Empty(result);
    }

    [Fact]
    public void IfValueIsNotDefaultButListIsEmptyYouShouldReturnEmpty()
    {
        TraitProperty<List<ResourceCost>> prop =
            new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(), "initial");

        var newOb = new List<ResourceCost>();

        prop.SetValue(newOb);

        var result = writter.Write(prop);
        Assert.Empty(result);
    }

    [Fact]
    public void IfValueIsNotDefaultAndHaveOneElementShouldReturnCorrectString()
    {
        TraitProperty<List<ResourceCost>> prop =
            new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(), "initial");

        var newOb = new List<ResourceCost>();
        newOb.Add(new ResourceCost(ResourceTypes.Energy, 50));

        prop.SetValue(newOb);

        var result = writter.Write(prop);
        Assert.Equal("initial = {\n\tenergy = 50\n}", result);
    }

    [Fact]
    public void IfValueIsNotDefaultAndHaveMoreElementShouldReturnCorrectString()
    {
        TraitProperty<List<ResourceCost>> prop =
            new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(), "initial");

        var newOb = new List<ResourceCost>();
        newOb.Add(new ResourceCost(ResourceTypes.Energy, 50));
        newOb.Add(new ResourceCost(ResourceTypes.Minerals, 150));

        prop.SetValue(newOb);

        var result = writter.Write(prop);
        Assert.Equal("initial = {\n\tenergy = 50\n\tminerals = 150\n}", result);
    }
}